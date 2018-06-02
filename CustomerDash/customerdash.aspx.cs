using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.CustomerDash
{
    public partial class customerdash : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../login/login.aspx");
                return;
            }
        }

        protected void Reserve_the_room(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../login/login.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                string email = Session["username"].ToString();

                object date12 = chki.Value;
                object date21 = chko.Value;
                date12 = (String)date12;
                date21 = (String)date21;
                if ((date12) == "" || date21 == "")
                {
                    Label1.Text = "You have to select the date Booking unsuccessful";
                    return;
                }
                int count = int.Parse(DropDownList2.SelectedValue.ToString());
                DateTime ci = DateTime.Parse(chki.Value.ToString());
                DateTime co = DateTime.Parse(chko.Value.ToString());
                string category = DropDownList1.SelectedValue.ToString();
                int status = objmyDAl.Reservation_Room(count, email, ci, co, category);
                if (status == 1)
                {
                    Label1.Text = "Room Booked";
                }
                else
                {
                    Label1.Text = "Room Not Booked";
                }
            }
            else
            {
                Label1.Text = "Values given are not correct";
            }
        }

        protected void add_feedback(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                myDAL objmydal = new myDAL();
                object fbd = txt_comments1.Value;
                fbd = (String)fbd;
                if (fbd == "")
                {
                    Label1.Text = "Feedback cannot be null Feedback not submitted";
                    return;
                }

                string feedb = txt_comments1.Value.ToString();
                string user = Session["username"].ToString();
                int done = objmydal.add_fb(feedb, user);
                if (done == 1)
                {
                    Label1.Text = "Feedback submitted";
                }
                else
                {
                    Label1.Text = "Feedback not submitted";

                }
            }
            else
            {
                Label1.Text = "Values given are not correct";

            }
        }

        protected void Reserve_the_hall(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../login/login.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                string email = Session["username"].ToString();
                int count = int.Parse(DropDownList4.SelectedValue.ToString());
                object date12 = Date1.Value;
                object date21 = Date2.Value;
                date12 = (String)date12;
                date21 = (String)date21;
                if (date12 == "" || date21 == "")
                {
                    Label1.Text = "You have to select the date Booking unsuccessful";
                    return;
                }
                DateTime ci = DateTime.Parse(Date1.Value.ToString());
                DateTime co = DateTime.Parse(Date2.Value.ToString());
                string category = DropDownList3.SelectedValue.ToString();
                int status = objmyDAl.Reservation_Hall(count, email, ci, co, category);
                if (status == 1)
                {
                    Label1.Text = "Hall Booked";
                }
                else
                {
                    Label1.Text = "Hall Not Booked";
                }
            }
            else
            {
                Label1.Text = "Value is not correct";
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


        protected void CustomValidatorDate_ServerValidate(object source, ServerValidateEventArgs args)
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

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("../login/login.aspx");
        }
    }
}