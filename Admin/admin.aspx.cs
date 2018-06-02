using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.Admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
        }

        protected void add_halls(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            string category = DropDownList1.SelectedValue.ToString();
            string status = stat12.Value.ToString();
            int discount = 0;
            int done = objmydal.add_hall(category, status, discount);
            if (done == 1)
            {
                Label1.Text = "Hall added";
            }
            else
            {
                Label1.Text = "Hall not added";
            }
        }

        protected void add_rooms(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            string category = DropDownList2.SelectedValue.ToString();
            string status = stat12.Value.ToString();
            int discount = 0;
            int done = objmydal.add_room(category, status, discount);
            if (done == 1)
            {
                Label1.Text = "Room added";
            }
            else
            {
               Label1.Text = "Room not added";
            }
        }


        protected void add_items(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            object name21 = name12.Value;
            name21 = (String)name21;
            if (name21 == "")
            {
                Label1.Text = "Item Name cannot be Null";
                return;
            }
            name21 = price12.Value.ToString();
            string cn = price12.Value.ToString();
            bool isIntString = cn.All(char.IsDigit);
            if (!isIntString)
            {
                Label1.Text = "Item Price cannot have characters";
                return;


            }
           
            if (name21 == "")
            {
                Label1.Text = "Item Price cannot be Null";
                return;
            }
            string name = name12.Value.ToString();
            int price = int.Parse(price12.Value.ToString());
            int done = objmydal.add_item(name, price);
            if (done == 1)
            {
                 Label1.Text = "Item Added";
            }
            else
            {
                 Label1.Text = "Item Not Added";

            }
        }
        protected void add_departments(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            object dep21 = dep12.Value;
            dep21 = (String)dep21;
            if (dep21 == "")
            {
                Label1.Text = "Department cannot be empty";
                return;
            }
            string dep = dep12.Value.ToString();
            int done = 0;
            if (dep != null)
            {
                done = objmydal.add_dep(dep);
            }
            if (done == 0)
            {
                Label1.Text = "Department Not Added";
            }
            else
            {
                Label1.Text = "Department Added";

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


        protected void CustomValidatorSelect_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "0")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }


        protected void SignOut_Click(object sender, EventArgs e)
        {

            Response.Redirect("../AdminLogin/adminLogin.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin Login/adminLogin.aspx");
        }
    }
}