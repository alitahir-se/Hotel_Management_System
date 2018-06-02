using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
namespace try2.CustomerInfo
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            object Email1 = Session["username"];
            if (Email1 != null)
            {
                myDAL objmyDAl = new myDAL();
                String Email = Session["username"].ToString(); string fname = ""; string lname = ""; string cnici = ""; string addressi = ""; string cityi = ""; string phonei = ""; int privelegei = 0;
                objmyDAl.display_user(Email, ref fname, ref lname, ref privelegei, ref cnici, ref addressi, ref phonei, ref cityi);
                email.Value = Email;
                first_name.Value = fname;
                last_name.Value = lname;
                address.Value = addressi;
                cnic.Value = cnici;
                city.Value = cityi;
                phone.Value = phonei;

                if (privelegei == 1)
                {

                    privledge.Value = "You Have Applied for Privledge Club ";
                }
                else
                {
                    privledge.Value = "You Have Not Applied for Privledge  Club";

                }
            }else
            {
                Response.Redirect("../login/login.aspx");
            }
        }

        protected void Customer_SignOut(object sender, EventArgs e) {
            Session["username"] = null;
            Response.Redirect("../home/home.aspx");


        }

       
    }
}