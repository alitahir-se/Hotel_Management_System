using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using System.Net.Mail;
namespace try2.Employee_Login
{
    public partial class employeeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_check(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                myDAL objmyDAl = new myDAL();
                String Email = email.Value;
                String Password = password.Value;
                int found;
                found = objmyDAl.check_log_in_of_employee(Email, Password);
                if (found == 0)
                {
                    er2.Text = "Email or Password is Invalid";

                }
                else
                {

                    Session["username"] = Email;
                    Session.Timeout = 10;
                    String jb="";
                    objmyDAl.manorrep(Email,ref jb);

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("ali14tahir@gmail.com");
                    msg.To.Add(Email);
                    msg.Subject = "HMS Log In";
                    msg.Body = ("Someone has Loged into Your HMS account.If it Were not you Please reply as soon as Possible. ");
                    msg.IsBodyHtml = true;

                    SmtpClient smt = new SmtpClient();
                    smt.Host = "smtp.gmail.com";

                    System.Net.NetworkCredential ntwd = new System.Net.NetworkCredential();
                    ntwd.UserName = "ali14tahir@gmail.com";
                    ntwd.Password = "iamJARED";
                    smt.UseDefaultCredentials = true;
                    smt.Credentials = ntwd;
                    smt.Port = 587;
                    smt.EnableSsl = true;
                    smt.Send(msg);



                    if (jb == "Manager")
                    {
                        Response.Redirect("../Manager/manager.aspx");
                    }
                    else
                    {
                        Response.Redirect("../Receptionist/receptionist.aspx");
                    }
                    }
            }
            else
            {
                password.Value = "Not logged in";
            }
        }

        protected void CustomValidatorEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string em = args.Value.ToString();
                char atTest = '@';
                int startIndex = em.IndexOf(atTest);
                int endIndex = em.LastIndexOf(atTest);
                if (startIndex - endIndex == 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }

        }

        protected void CustomValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string pass = args.Value.ToString();
                if (pass.Length > 7)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }

            }

        }
    }
}