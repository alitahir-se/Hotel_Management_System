using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using try2.DAL;
using System.Data;
using try2;
namespace try2.home
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        
      

       
        protected void Sign_up(object sender, EventArgs e)
        {
            Response.Redirect("../signup/signup.aspx");
        }
    }
}