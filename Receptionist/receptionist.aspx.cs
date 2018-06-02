using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using try2.DAL;

namespace try2.Receptionist
{
    public partial class receptionist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object Email1 = Session["username"];
            if (Email1 == null)
            {
                Response.Redirect("../Employee Login/employeeLogin.aspx");
                return;
            }
            myDAL objmyDAl = new myDAL();
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();
            DataTable DT3 = new DataTable();
            DataTable DT4 = new DataTable();

            objmyDAl.display_RoomsReservation(ref DT1);
            objmyDAl.display_RoomsReservationRecord(ref DT2);
            objmyDAl.display_HallsReservation(ref DT3);
            objmyDAl.display_HallsReservationRecord(ref DT4);

            grid.DataSource = DT1;
            grid.DataBind();
            grid2.DataSource = DT2;
            grid2.DataBind();
            grid3.DataSource = DT3;
            grid3.DataBind();
            grid4.DataSource = DT4;
            grid4.DataBind();
        }

        protected void RejectReservationRoom_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../Employee Login/employeeLogin.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                int RID =  int.Parse(RoomID.Value);
                int found;
        
                found = objmyDAl.Reject_Reservation_Room(RID);
                if (found == 1)
                {
                    er1.Text = "Reservation Deleted Successfully";
                    Page_Load(null, null);
                    

                }
                
                else if (found == -1)
                {

                    er1.Text = "Registration ID Does Not Exists";
                }
                else
                {
                    er1.Text = "Customer still has time you can delete reservation if he does not reaches after 2 hours";
                }



            }

        }

        protected void CustomValidatorFirstName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value == "")
            {
                args.IsValid = false;
            }
            else
            {
                string fn = args.Value.ToString();
                bool containsInt = fn.Any(char.IsDigit);
                if (containsInt)
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }


            }
        }

        protected void CustomValidatorHallID_ServerValidate(object source, ServerValidateEventArgs args)
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
                    if (cn.Length < 6)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }

            }

        }


        protected void CustomValidatorRoomID_ServerValidate(object source, ServerValidateEventArgs args)
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
                    if (cn.Length < 6)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }

            }

        }

        protected void RejectReservationHall_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../Employee Login/employeeLogin.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                
                int RID = int.Parse(HallID.Value);
                int found;

                found = objmyDAl.Reject_Reservation_Hall(RID);
                if (found == 1)
                {
                    er1.Text = "Reservation Deleted Successfully";
                    Page_Load(null, null);


                }
                else if (found == -1)
                {

                    er1.Text = "Registration ID Does Not Exists";
                }
                else
                {
                    er1.Text = "Customer still has time you can delete reservation if he does not reaches after 2 hours";
                }



            }

        }

        protected void CheckOutRoom_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../Employee Login/employeeLogin.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                int RID = int.Parse(RoomID.Value);
                int found;
                int status1 = 0;
                found = objmyDAl.CheckOut_Reservation_Room(RID, ref status1);
                if (found == 0)
                {
                    er1.Text = "Reservation Checked Out Successfully";
                    Label1.Text = "Please Collect Rs:   " + status1.ToString();
                    Page_Load(null, null);


                }
                else if (found == -1)
                {

                    er1.Text = "Registration ID Does Not Exists";
                    Label1.Text = " ";
                }



            }

        }



        protected void CheckOutHall_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object Email1 = Session["username"];
                if (Email1 == null)
                {
                    Response.Redirect("../Employee Login/employeeLogin.aspx");
                    return;
                }
                myDAL objmyDAl = new myDAL();
                int RID = int.Parse(HallID.Value);
                int found;
                int status1 = 0;
                found = objmyDAl.CheckOut_Reservation_Hall(RID, ref status1);
                if (found == 0)
                {
                    er1.Text = "Reservation Checked Out Successfully";
                    Label1.Text = "Please Collect Rs:   "+status1.ToString();
                    Page_Load(null, null);


                }
                else if (found == -1)
                {

                    er1.Text = "Registration ID Does Not Exists";
                    Label1.Text = " ";
                }



            }
        }

        protected void RecepSignOut_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("../Employee Login/employeeLogin.aspx");

        }
    }
}