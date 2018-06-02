using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using System.Data;
using System.Net;
using System.IO;
using System.Configuration;
using System.Net.Mail;
namespace try2.signup
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            first_name.Focus();
        }
        protected void register_customer(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                myDAL objmyDAl = new myDAL();
                String FName = first_name.Value;
                String LName = last_name.Value;
                String Cnic = cnic.Value;
                String Phone = phone.Value;
                String Email = email.Value;
                String Password = password.Value;
                String Address = address.Value;
                String City = city.Value;
                String Privelege = jobType.Value.ToString();
                if (Privelege == "")
                {
                    er1.Text = "You have to select the Privelege";
                    return;
                }
                int pri = int.Parse(Privelege);
                int found;
                found = objmyDAl.SearchStudentByName_DAL(FName, LName, pri, Cnic, Address, Phone, City, Email, Password);
                if (found == 0)
                {
                    
                    er1.Text = "Sign up UnSuccessful";

                }
                else if (found == -1)
                {

                    er1.Text = "This Email Already Exist. If you are already a Customer Sign In";
                }
                else if (found == -2) {
                    er1.Text = "This CNIC Already has an account. If you are already a Customer Sign In";

                }
                else if (found == -3)
                {
                    er1.Text = "Sorry you are BlackListed so you cannot register";
                }
                else
                {

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("ali14tahir@gmail.com");
                    msg.To.Add(Email);
                    msg.Subject = "HMS Sign Up ";
                    msg.Body = ("You have successfully signed for HMS. Your Username is:" + Email + "<br/><br/>" + "Your Password is:" + Password);
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
                  

                    Response.Redirect("../login/login.aspx");

                }
            }
            else
            {
                er1.Text = "There was some error";
            }
        }


        protected void CustomValidatorFirstName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string fn = args.Value.ToString();
                bool containsInt = fn.Any(char.IsDigit);
                if (containsInt)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }


            }
        }

        protected void CustomValidatorCNIC_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string cn = args.Value.ToString();
                bool isIntString = cn.All(char.IsDigit);
                if (isIntString)
                {
                    if (cn.Length == 13)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }

            }

        }

        protected void CustomValidatorPhone_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string pn = args.Value.ToString();
                bool isIntString = pn.All(char.IsDigit);
                if (isIntString)
                {
                    if (pn.Length > 7)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }

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

                    char atTest1 = '.';
                    int startIndex1 = em.IndexOf(atTest1);
                    int endIndex1 = em.LastIndexOf(atTest1);
                    if (startIndex1 != -1) {
                        if(startIndex1 - endIndex1 == 0)
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }

                    }else
                    {
                        args.IsValid = false;

                    }
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

        protected void CustomValidatorAddress_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }


    }
}
