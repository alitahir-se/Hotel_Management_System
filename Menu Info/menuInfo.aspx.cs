using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;

namespace try2.Menu_Info
{
    public partial class menuInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT1 = new DataTable();
            

            objmyDAl.display_Menu(ref DT1);


            menuGrid.DataSource = DT1;
            menuGrid.DataBind();
           
        }
    }
}