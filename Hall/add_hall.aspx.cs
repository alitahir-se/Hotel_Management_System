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
    public partial class add_hall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void add_halls(object sender, EventArgs e)
        {
            myDAL objmydal = new myDAL();
            string category = DropDownList1.SelectedValue.ToString();
            string status = stat12.Value.ToString();
            float discount = int.Parse(dis12.Value.ToString());
            int done = objmydal.add_hall(category, status, discount);
            if (done == 1)
            {
                Label1.Text = "added";
            }
            else
            {
                Label1.Text = "not added";
            }
        }
    }
}