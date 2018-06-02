using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Configuration;
using System.Net.Mail;
using try2.DAL;
using System.Data;
namespace try2.Application
{
    public partial class application : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Employee_Register(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                myDAL objmyDAl = new myDAL();
                String FName = first_name.Value;
                String LName = last_name.Value;
                String cnic_e = cnumber.Value.ToString();
                String Phone = phone.Value;
                String Email = email.Value;

                String Address = address.Value;
                String typeofjob = jobType.Value.ToString();
                if (typeofjob == "1")
                {
                    typeofjob = "Manager";
                }
                else if (typeofjob=="2")
                {
                    typeofjob = "Receptionist";
                }
                else
                {
                    typeofjob = description.Value.ToString();
                }
                String gen = gene.Value.ToString();
                String department_name = departmentName.Value.ToString();

                DateTime date_birth = DateTime.Parse(dating.Value.ToString());
                if (typeofjob == "" || gen == "")
                {
                    er1.Text = "Job Type cannot be empty";
                    return;
                }
                else
                {
                    String password = passwordApp.Value.ToString();
                    if (typeofjob !="Manager")
                    {
                        int done = objmyDAl.Send_applications(FName, LName, cnic_e, Address, department_name, typeofjob, date_birth, Email, gen);
                        if (done == 0)
                        {
                            er1.Text = "Application unsuccessful";
                        }
                        else
                        {
                           er1.Text = "Application Successful";



                            MailMessage msg = new MailMessage();
                            msg.From = new MailAddress("ali14tahir@gmail.com");
                            msg.To.Add(Email);
                            msg.Subject = "HMS Sign Up ";
                            msg.Body = ("You have successfully signed for HMS. Your Username is:" + Email + "<br/><br/>" + "Your Password is:" + password);
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







                            if (typeofjob == "Receptionist")
                            {
                               int done3 =objmyDAl.temp_login(cnic_e, password);
                                if (done3 == 0)
                                {
                                    er2.Text = "Receptionist Login not made";
                                }
                                else
                                {
                                 er2.Text = "Receptionist Login made";
                                }
                            }
                        }       
                    }
                    else
                    {
                        
                        int done2 = objmyDAl.enterEmployee(FName, LName, cnic_e, Address, department_name, typeofjob, date_birth, Email, gen);
                        if (done2 == 0)
                        {
                            er1.Text = "Employee not successfully registered";
                        }
                        else
                        {
                            er1.Text = "Employee successfully registered";
                            int done3=objmyDAl.employee_register_login(Email, password);
                            if (done3 == 0)
                            {
                                er2.Text = "Login not made";
                            }
                            else
                            {
                                er2.Text = "Login made";
                            }
                        }
                    }


                }
            }
            else
            {
               
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
                    if (startIndex1 != -1)
                    {
                        if (startIndex1 - endIndex1 == 0)
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


        protected void CustomValidatorSelect_ServerValidate(object source, ServerValidateEventArgs args)
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