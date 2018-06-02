using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using try2;
using System.Data;
namespace try2.FeedBack
{
    public partial class feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../login/login.aspx");
                return;
            }
        }
        protected void add_feedback(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Admin Login/adminLogin.aspx");
                return;
            }
            myDAL objmydal = new myDAL();
            string feedb = txt_comments1.Value.ToString();
            if (feedb == "")
            {
                Label1.Text = "Feedback cannot be null";
                return;
            }
            string user = Session["username"].ToString();
            int done=objmydal.add_fb(feedb, user);
            if (done == 1)
            {
                Label1.Text = "Feedback submitted";
            }
            else
            {
                Label1.Text = "Feedback not submitted";

            }
        }
    }
}