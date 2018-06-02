using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace try2.DAL
{
    public class myDAL
    {
        private static readonly string connString =
            System.Configuration.ConfigurationManager.ConnectionStrings["sqlCon1"].ConnectionString;

        public int SearchStudentByName_DAL(string Fname,string Lname,int Privelge,string Cnic,string address,string phone,string city,string email,string password)

        {
            
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);

            try { 
                con.Open();
            
           

            SqlCommand cmd;
            
            
                cmd = new SqlCommand("Customer_Register ", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 30); //input of SQL stored procedure

                cmd.Parameters.Add("@Privelege", SqlDbType.Int); //input of SQL stored procedure

                cmd.Parameters.Add("@CNIC", SqlDbType.Char, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@Address_c", SqlDbType.VarChar, 50); //input of SQL stored procedure

                cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 11); //input of SQL stored procedure

                cmd.Parameters.Add("@City", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@Email", SqlDbType.VarChar, 40); //input of SQL stored procedure
                cmd.Parameters.Add("@Password_c", SqlDbType.VarChar, 20); //input of SQL stored procedure
                cmd.Parameters.Add("@flag", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;


                cmd.Parameters["@Fname"].Value = Fname;
                cmd.Parameters["@Lname"].Value = Lname;
                cmd.Parameters["@Privelege"].Value = Privelge;
                cmd.Parameters["@CNIC"].Value = Cnic;
                cmd.Parameters["@Address_c"].Value = address;
                cmd.Parameters["@Phone"].Value = phone;
                cmd.Parameters["@City"].Value = city;
                cmd.Parameters["@Email"].Value = email;

                cmd.Parameters["@Password_c"].Value = password;


                cmd.ExecuteNonQuery(); //executre the cmd query

                Found = int.Parse(cmd.Parameters["@flag"].Value.ToString());
             
                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found; //if no error return 1;

        }
        public void display_offers(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("offers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }
        public void display_offers_hall(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("offers_Halls", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }





        public int UpdateDiscount(int dis, string cat)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            try
            {
                con.Open();
                cmd = new SqlCommand("change_the_discounts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@discount", SqlDbType.Int);
                cmd.Parameters["@discount"].Value = dis;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10);
                cmd.Parameters["@category"].Value = cat;






                cmd.ExecuteNonQuery();


                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return 1;


        }
        public int Reject_Reservation_Room(int rid)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;
            try
            {
                con.Open();
                cmd = new SqlCommand("RemoveReservationForRoom_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CopyofReservation_id", SqlDbType.Int);
                cmd.Parameters["@CopyofReservation_id"].Value = rid;


                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return status;
        }







        public int CheckOut_Reservation_Room(int rid, ref int status1)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;

            try
            {
                con.Open();
                cmd = new SqlCommand("RoomCheckOut_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CopyofReservation_id", SqlDbType.Int);
                cmd.Parameters["@CopyofReservation_id"].Value = rid;


                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                status1 = int.Parse(cmd.Parameters["@Result"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return status;
        }







        public int CheckOut_Reservation_Hall(int rid, ref int status1)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;

            try
            {
                con.Open();
                cmd = new SqlCommand("HallCheckOut_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CopyofReservation_id", SqlDbType.Int);
                cmd.Parameters["@CopyofReservation_id"].Value = rid;


                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Result", SqlDbType.Int);
                cmd.Parameters["@Result"].Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                status1 = int.Parse(cmd.Parameters["@Result"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return status;
        }

        public int Reject_Reservation_Hall(int rid)
        {

            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;
            try
            {
                con.Open();
                cmd = new SqlCommand("RemoveReservationForHall_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CopyofReservation_id", SqlDbType.Int);
                cmd.Parameters["@CopyofReservation_id"].Value = rid;


                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;




                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return status;
        }
        public void display_HallsReservationRecord(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_reservationsRecordHalls", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }














       





        public void display_RoomsReservationRecord(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_reservationsRecord", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }

        public void display_RoomsReservation(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_reservations", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }

        public void display_HallsReservation(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_reservationsHalls", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }





       

        public int employee_register_login(string email,string password)
        {
            SqlConnection con = new SqlConnection(connString);
            int Found = 1;
            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("CreateLogin", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@emai", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters["@emai"].Value = email;
                cmd.Parameters["@password"].Value = password;
                cmd.ExecuteNonQuery(); //executre the cmd query


                con.Close(); //close SQL connection
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found; //if no error return 1;

        }
        public int enterEmployee(string Fname, string Lname, string Cnic, string address, string department, string job, DateTime DOB, string email, string gender)
        {
            int Found = 1;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("InsertEmployee", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 30); //input of SQL stored procedure


                cmd.Parameters.Add("@CN", SqlDbType.Char, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@address", SqlDbType.VarChar, 30); //input of SQL stored procedure

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters.Add("@BD", SqlDbType.Date); //input of SQL stored procedure
                cmd.Parameters.Add("@DName", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@DNoM", SqlDbType.VarChar, 20); //input of SQL stored procedure
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 8); //input of SQL stored procedure
                cmd.Parameters.Add("@sal", SqlDbType.Int); //input of SQL stored procedure

                cmd.Parameters["@FName"].Value = Fname;
                cmd.Parameters["@LName"].Value = Lname;
                cmd.Parameters["@BD"].Value = DOB;
                cmd.Parameters["@CN"].Value = Cnic;
                cmd.Parameters["@address"].Value = address;
                cmd.Parameters["@gender"].Value = gender;
                cmd.Parameters["@email"].Value = email;

                cmd.Parameters["@DName"].Value = department;

                cmd.Parameters["@DNoM"].Value = job;

                cmd.ExecuteNonQuery(); //executre the cmd query


                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found; //if no error return 1;

        }
        public int rejectapp(String cnic)
        {
            SqlConnection con = new SqlConnection(connString);
            int done=0;
            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("RejectApplication", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CN_Ap", SqlDbType.VarChar, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@success", SqlDbType.Int); //input of SQL stored procedu
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters["@CN_Ap"].Value = cnic;
                cmd.ExecuteNonQuery(); //executre the cmd query
                done = int.Parse(cmd.Parameters["@success"].Value.ToString());

                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }
            return done;
        }
        public int temp_login(string cnic,string password)
        {
            SqlConnection con = new SqlConnection(connString);
            
            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_temp_login", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@password", SqlDbType.VarChar,25); //input of SQL stored procedure
                cmd.Parameters["@cnic"].Value = cnic;
                cmd.Parameters["@password"].Value =password;
                cmd.ExecuteNonQuery(); //executre the cmd query
                con.Close(); //close SQL connection
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public int acceptapp(String cnic)
        {
            SqlConnection con = new SqlConnection(connString);
            int done = 0;
            try
            {
                con.Open();



                SqlCommand cmd;
                cmd = new SqlCommand("give_password", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cnic", SqlDbType.VarChar, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@password", SqlDbType.VarChar,25); //input of SQL stored procedure
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters["@password"].Direction = ParameterDirection.Output;
                cmd.Parameters["@email"].Direction = ParameterDirection.Output;
                cmd.Parameters["@cnic"].Value = cnic;
                cmd.ExecuteNonQuery(); //executre the cmd query
                string passes = cmd.Parameters["@password"].Value.ToString();
                string maile = cmd.Parameters["@email"].Value.ToString();

                
                cmd = new SqlCommand("AcceptApplication", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CN_Ap", SqlDbType.VarChar, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@sal_a", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters.Add("@success", SqlDbType.Int); //input of SQL stored procedu
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters["@CN_Ap"].Value = cnic;
                cmd.ExecuteNonQuery(); //executre the cmd query
                done = int.Parse(cmd.Parameters["@success"].Value.ToString());
                employee_register_login(maile, passes);
                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }
            return done;
        }
        public void manorrep(string Email,ref string jb)
        {
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("manager_or_receptionist", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters.Add("@job", SqlDbType.VarChar, 20); //input of SQL stored procedure
                cmd.Parameters["@job"].Direction = ParameterDirection.Output;
                cmd.Parameters["@email"].Value = Email;
                cmd.ExecuteNonQuery(); //executre the cmd query
                jb = cmd.Parameters["@job"].Value.ToString();

                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return;

            }
            finally
            {
                con.Close();
            }

            
        }
        public int Send_applications(string Fname, string Lname, string Cnic, string address,string department,string job, DateTime DOB, string email,string gender)

        {

            int Found = 1;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("SendApplications", con); //name of your SQL procedure
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FNameA", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@LNameA", SqlDbType.VarChar, 30); //input of SQL stored procedure

                
                cmd.Parameters.Add("@CNA", SqlDbType.Char, 15); //input of SQL stored procedure
                cmd.Parameters.Add("@addressA", SqlDbType.VarChar, 30); //input of SQL stored procedure

                cmd.Parameters.Add("@emailA", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters.Add("@BDA", SqlDbType.Date); //input of SQL stored procedure
                cmd.Parameters.Add("@DNameA", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@DNoA", SqlDbType.VarChar, 20); //input of SQL stored procedure
                cmd.Parameters.Add("@genderA", SqlDbType.VarChar, 8); //input of SQL stored procedure


                cmd.Parameters["@FNameA"].Value = Fname;
                cmd.Parameters["@LNameA"].Value = Lname;
                cmd.Parameters["@BDA"].Value = DOB;
                cmd.Parameters["@CNA"].Value = Cnic;
                cmd.Parameters["@addressA"].Value = address;
                cmd.Parameters["@genderA"].Value = gender;
                cmd.Parameters["@emailA"].Value = email;

                cmd.Parameters["@DNameA"].Value = department;

                cmd.Parameters["@DNoA"].Value = job;

                cmd.ExecuteNonQuery(); //executre the cmd query

                
                con.Close(); //close SQL connection


            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found; //if no error return 1;

        }
        public void display_Applications(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_application", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }

        public void display_Employee(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_employee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }



        public int Reservation_Room(int count,string email,DateTime chki,DateTime chko,string category)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;
            try
            {
                con.Open();
                cmd = new SqlCommand("Reserve_room", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Rooms", SqlDbType.Int);
                cmd.Parameters.Add("@emai_res", SqlDbType.VarChar, 40);
                cmd.Parameters.Add("@check_in", SqlDbType.DateTime);
                cmd.Parameters.Add("@check_out", SqlDbType.DateTime);
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Rooms"].Value = count;
                cmd.Parameters["@emai_res"].Value = email;
                cmd.Parameters["@check_in"].Value = chki;
                cmd.Parameters["@check_out"].Value = chko;
                cmd.Parameters["@category"].Value = category;



                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return status;
        }
        public int Reservation_Hall(int count, string email, DateTime chki, DateTime chko, string category)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            int status = 0;
            try
            {
                con.Open();
                cmd = new SqlCommand("Reserve_hall", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Halls", SqlDbType.Int);
                cmd.Parameters.Add("@emai_res", SqlDbType.VarChar, 40);
                cmd.Parameters.Add("@check_in", SqlDbType.DateTime);
                cmd.Parameters.Add("@check_out", SqlDbType.DateTime);
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@success", SqlDbType.Int);
                cmd.Parameters["@success"].Direction = ParameterDirection.Output;
                cmd.Parameters["@Halls"].Value = count;
                cmd.Parameters["@emai_res"].Value = email;
                cmd.Parameters["@check_in"].Value = chki;
                cmd.Parameters["@check_out"].Value = chko;
                cmd.Parameters["@category"].Value = category;



                cmd.ExecuteNonQuery();

                status = int.Parse(cmd.Parameters["@success"].Value.ToString());
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }
            return status;
        }
        public void display_halls_available(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_halls_available", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }
        public void display_halls_occupied(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_halls_occupied", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }


        public void display_rooms_available(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_rooms_available", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }
        public void display_rooms_occupied(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_rooms_occupied", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();


        }

        public void display_user(string email,ref string fname,ref string lname,ref int privelege, ref string cnic,ref string address,ref string phone,ref string city)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;


            con.Open();
            cmd = new SqlCommand("Get_info", con); //name of your SQL procedure
            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 40);
            cmd.Parameters.Add("@Fname", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@Lname", SqlDbType.VarChar, 30);
            cmd.Parameters.Add("@Privelege", SqlDbType.Int);
            cmd.Parameters.Add("@CNIC", SqlDbType.Char, 15);
            cmd.Parameters.Add("@Address_c", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 11);
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 30);
            cmd.Parameters["@Fname"].Direction = ParameterDirection.Output;
            cmd.Parameters["@Lname"].Direction = ParameterDirection.Output;
            cmd.Parameters["@Privelege"].Direction = ParameterDirection.Output;
            cmd.Parameters["@CNIC"].Direction = ParameterDirection.Output;
            cmd.Parameters["@Address_c"].Direction = ParameterDirection.Output;
            cmd.Parameters["@Phone"].Direction = ParameterDirection.Output;
            cmd.Parameters["@City"].Direction = ParameterDirection.Output;
            cmd.Parameters["@email"].Value = email;
            cmd.ExecuteNonQuery();
             fname = cmd.Parameters["@Fname"].Value.ToString();
             lname = cmd.Parameters["@Lname"].Value.ToString();
             privelege = int.Parse(cmd.Parameters["@Privelege"].Value.ToString());
             cnic = cmd.Parameters["@CNIC"].Value.ToString();
             address = cmd.Parameters["@Address_c"].Value.ToString();
             phone = cmd.Parameters["@Phone"].Value.ToString();
             city = cmd.Parameters["@City"].Value.ToString();
            con.Close();

        }
        public int add_room(string categ,string stat,float dis)
        {
           
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_room", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10); //input of SQL stored procedure
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@discount", SqlDbType.Float);
                cmd.Parameters["@category"].Value = categ;
                cmd.Parameters["@discount"].Value = dis;

                cmd.Parameters["@status"].Value = stat;
                cmd.ExecuteNonQuery();
                con.Close(); //close SQL connection
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }
            
            return 1;
        }
        public int add_dep(string name)
        {
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_dep", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 40); //input of SQL stored procedure
                cmd.Parameters["@name"].Value = name;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return 1;
        }
        public int add_item(string name,int price)
        {
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_item", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50); //input of SQL stored procedure
                cmd.Parameters.Add("@price", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters["@price"].Value = price;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return 1;
        }
        public int add_fb(string fb,string user)
        {

            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_fb", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@user", SqlDbType.VarChar, 40); //input of SQL stored procedure
                cmd.Parameters.Add("@fb", SqlDbType.VarChar, 140);
                cmd.Parameters["@user"].Value = user;
                cmd.Parameters["@fb"].Value = fb;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return 1;
        }
        public int add_hall(string categ, string stat, float dis)
        {

            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("add_hall", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@category", SqlDbType.VarChar, 10); //input of SQL stored procedure
                cmd.Parameters.Add("@status", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@discount", SqlDbType.Float);
                cmd.Parameters["@category"].Value = categ;
                cmd.Parameters["@discount"].Value = dis;

                cmd.Parameters["@status"].Value = stat;
                cmd.ExecuteNonQuery();
                con.Close(); //close SQL connection
            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return 1;
        }
        public int check_log_in(string email,string password)
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("Customer_Login_Checking", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters["@Username"].Value = email;
                cmd.Parameters["@Password"].Value = password;
                cmd.Parameters.Add("@flag", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery(); //executre the cmd query

                Found = int.Parse(cmd.Parameters["@flag"].Value.ToString());


                con.Close(); //close SQL connection

            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found;
            }
        public int check_log_in_admin(string email, string password)
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("Admin_Login_Checking", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters["@Username"].Value = email;
                cmd.Parameters["@Password"].Value = password;
                cmd.Parameters.Add("@flag", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery(); //executre the cmd query

                Found = int.Parse(cmd.Parameters["@flag"].Value.ToString());


                con.Close(); //close SQL connection

            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found;
        }
        public void display_Customers_info(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_all_customer_info", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();
        }
        public void display_Blacklist_info(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_black_listed", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();
        }
        public int transfertoblacklist(String bid)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;
            try
            {
                con.Open();
                cmd = new SqlCommand("blacklist_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CopyofCid", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@CopyofCid"].Value = bid;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        public void display_Feedback(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_Feedback", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();
        }




        public void display_Menu(ref DataTable result)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd;

            con.Open();
            cmd = new SqlCommand("show_Menu", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                da.Fill(ds); //get results

            result = ds.Tables[0];
            con.Close();
        }

        public int check_log_in_of_employee(string email, string password)
        {
            int Found = 0;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();



                SqlCommand cmd;


                cmd = new SqlCommand("Employee_Login_Checking", con); //name of your SQL procedure

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Username", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters.Add("@Password", SqlDbType.VarChar, 30); //input of SQL stored procedure
                cmd.Parameters["@Username"].Value = email;
                cmd.Parameters["@Password"].Value = password;
                cmd.Parameters.Add("@flag", SqlDbType.Int); //input of SQL stored procedure
                cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery(); //executre the cmd query

                Found = int.Parse(cmd.Parameters["@flag"].Value.ToString());


                con.Close(); //close SQL connection

            }
            catch (SqlException ex)
            {
                return 0; //if any erron return 0

            }
            finally
            {
                con.Close();
            }

            return Found;
        }
    }
}