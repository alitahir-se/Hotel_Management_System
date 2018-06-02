using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;

namespace try2.Showfeedback
{
    public partial class showfeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            myDAL objmyDAl = new myDAL();
            DataTable DT1 = new DataTable();


            objmyDAl.display_Feedback(ref DT1);


            gridFeedback.DataSource = DT1;
            gridFeedback.DataBind();

        }
    }
}