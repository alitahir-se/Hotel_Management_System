using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.Room
{
    public partial class room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Reserve_the_room(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            string email = Session["username"].ToString();
            int count = int.Parse(DropDownList2.SelectedValue.ToString());
            DateTime ci = DateTime.Parse(chki.Value.ToString());
            DateTime co = DateTime.Parse(chko.Value.ToString());
            string category = DropDownList1.SelectedValue.ToString();
            int status = objmyDAl.Reservation_Room(count,email,ci,co,category);
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