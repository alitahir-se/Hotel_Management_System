using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.Menu
{
    public partial class add_menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void add_items(object sender, EventArgs e)
        {
            myDAL objmydal = new myDAL();
            string name = name12.Value.ToString();
            int price = int.Parse(price12.Value.ToString());
            int done=objmydal.add_item(name, price);
            if (done == 1)
            {
                Label1.Text = "Item Added";
            }
            else
            {
                Label1.Text = "Item Not Added";
            }
        }
    }
}