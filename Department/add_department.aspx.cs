using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.Department
{
    public partial class add_department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void add_departments(object sender, EventArgs e)
        {
            myDAL objmydal = new myDAL();
            string dep = dep12.Value.ToString();
            int done = 0;
            if (dep != null) {
                done=objmydal.add_dep(dep);
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

    }
}