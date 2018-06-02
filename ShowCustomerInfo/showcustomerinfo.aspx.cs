using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.ShowCustomerInfo
{
    public partial class showcustomerinfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmyDAl = new myDAL();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();


            objmyDAl.display_Customers_info(ref DT1);
            objmyDAl.display_Blacklist_info(ref DT2);

            gridFeedback.DataSource = DT1;
            gridFeedback.DataBind();
            Blacklisted.DataSource = DT2;
            Blacklisted.DataBind();
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

                    args.IsValid = true;

                }
                else
                {
                    args.IsValid = false;
                }

            }

        }
        protected void Blacklistcid(object sender, EventArgs e)
        {
            String bid = blackid.Value.ToString();
            myDAL objmydal = new myDAL();
            int done=objmydal.transfertoblacklist(bid);
            if (done == 0)
            {
                er2.Text = "There does not exist any customer with this Cid ";
            }
            else
            {
                er2.Text = "Customer successfully transfered to black list";
                Page_Load(null, null);
            }
        }
    }
}