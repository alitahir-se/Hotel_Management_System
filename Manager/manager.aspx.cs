using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using try2.DAL;

namespace try2.Manager
{
    public partial class manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Employee Login/employeeLogin.aspx");
                return;
            }
            myDAL objmyDAl = new myDAL();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();

            objmyDAl.display_Applications(ref DT1);
            objmyDAl.display_Employee(ref DT2);

            grid.DataSource = DT1;
            grid.DataBind();
            grid2.DataSource = DT2;
            grid2.DataBind();
        }
        protected void Reject_Application(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Employee Login/employeeLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            String number = customerID.Value.ToString();
            int done=objmydal.rejectapp(number);
            if (done == 0)
            {
                Label1.Text = "This cnic does not exist";
            }
            else
            {
                Page_Load(null, null);
            }
        }
        protected void Accept_Application(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Employee Login/employeeLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            String number = customerID.Value.ToString();
            int done = objmydal.acceptapp(number);
            if (done == 0)
            {
                Label1.Text = "This cnic does not exist";
            }
            else
            {
                Page_Load(null, null);
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
        protected void RecepSignOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("../Employee Login/employeeLogin.aspx");

        }

    }
}