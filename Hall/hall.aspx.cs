using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.Hall
{
    public partial class hall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Reserve_the_hall(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            string email = Session["username"].ToString();
            int count = int.Parse(DropDownList3.SelectedValue.ToString());
            DateTime ci = DateTime.Parse(chki.Value.ToString());
            DateTime co = DateTime.Parse(chko.Value.ToString());
            string category = DropDownList4.SelectedValue.ToString();
            int status = objmyDAl.Reservation_Hall(count, email, ci, co, category);
            if (status == 1)
            {
                Label1.Text = "Booked";
            }
            else
            {
                Label1.Text = "Not Booked";
            }
        }
    }
}