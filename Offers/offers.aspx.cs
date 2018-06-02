using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2;
using System.Data;
using try2.DAL;

namespace try2.Offers
{
    public partial class offers : System.Web.UI.Page
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

            objmyDAl.display_offers(ref DT1);
            objmyDAl.display_offers_hall(ref DT2);

            grid.DataSource = DT1;
            grid.DataBind();
            grid2.DataSource = DT2;
            grid2.DataBind();
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

        protected void ChangeDiscount_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../Admin Login/adminLogin.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                int RID = int.Parse(discount.Value);
                if (RID > 50)
                {
                    er1.Text = "Discount cannot be more than 50 percent";
                    return;
                }
                if (RID < 0)
                {
                    er1.Text = "Discount cannot be less than 0 percent";
                    return;
                }
                string cat = category.Value.ToString();

                if(cat == "1")
                {
                    cat = "economy";
                }else if(cat == "2")
                {
                    cat = "premium";
                }else if(cat == "3")
                {
                    cat = "royal";
                }

                int found;

                found = objmyDAl.UpdateDiscount(RID,cat);
                if (found == 1)
                {
                    er1.Text = "Discount Changed";
                    Page_Load(null, null);


                }
                else if (found == 0)
                {

                    er1.Text = "Error";
                }



            }

        }
    }
}