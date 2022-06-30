using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Appprop;
namespace DAL
{
    public class Staff
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
        SqlCommand cmd;
        DataTable dt;
        public int InsertData(StaffSchema stf)
        {
            try
            {

                using (cmd = new SqlCommand("tbl_Profile", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@chkpara", "Insert");
                    cmd.Parameters.AddWithValue("@FirstName", stf.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", stf.lastname);
                    cmd.Parameters.AddWithValue("@EmailAdd", stf.EmailId);
                    cmd.Parameters.AddWithValue("@Phn", stf.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Nationality", stf.Nationality);
                    cmd.Parameters.AddWithValue("@Dob", stf.DateofBirth);
                    cmd.Parameters.AddWithValue("@Address", stf.Address);
                    cmd.Parameters.AddWithValue("@Street", stf.street);
                    cmd.Parameters.AddWithValue("@Country", stf.county);
                    cmd.Parameters.AddWithValue("@Postal", stf.PostCode);
                    cmd.Parameters.AddWithValue("@Position", stf.Position);
                    cmd.Parameters.AddWithValue("@ApplicationNo", stf.ApplicationNo);
                    cmd.Parameters.AddWithValue("@Gender", stf.Gender);
                    cmd.Parameters.AddWithValue("@Age", stf.Age);

                    cmd.Parameters.AddWithValue("@Image", stf.image);
                    cmd.Parameters.AddWithValue("@IsDelete", 1);
                    if (con.State.Equals(ConnectionState.Closed))
                        con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable GetDetails() {

            try
            {
                using (cmd = new SqlCommand("Select_StaffDetails", con)) {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally {


            }


        }
        public DataTable GetVerfDetails(StaffSchema stf)
        {

            try
            {
                using (cmd = new SqlCommand("Select_StaffVerfication", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StaffId", stf.Staffid);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);
                    return dt;
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {


            }


        }
        public int InsertAddress(StaffSchema stf) {

            try
            {
                using (cmd = new SqlCommand("Insert_Address", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Address", stf.Address);
                    cmd.Parameters.AddWithValue("@Street", stf.street);
                    cmd.Parameters.AddWithValue("@County", stf.county);
                    cmd.Parameters.AddWithValue("@PostCode", stf.PostCode);
                    cmd.Parameters.AddWithValue("@IsDelete", stf.Isdelete);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally {

            }

        }

        public int Postion_Insert(StaffSchema stf)
        {
            try
            {
                using (cmd = new SqlCommand("tbl_StaffPosition", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@position", stf.Position);
                    if (stf.Position == "RGN")
                    {
                        cmd.Parameters.AddWithValue("@NmcPin", stf.NmcPin);
                        cmd.Parameters.AddWithValue("@RenewalDate", stf.RenewlDate);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@NmcPin", "");
                        cmd.Parameters.AddWithValue("@RenewalDate", "");
                    }
                    cmd.Parameters.AddWithValue("@IsDelete", stf.Isdelete);
                    cmd.Parameters.AddWithValue("@ApplicationNo", stf.ApplicationNo);
                    cmd.Parameters.AddWithValue("@Name", stf.Name);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;


                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public int InsertOtherDetails(StaffSchema stf)
        {
            try
            {

                using (cmd = new SqlCommand("InsertOtherDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NationalInsNo", stf.NiNumber);
                    cmd.Parameters.AddWithValue("@DBS", stf.DBS);
                    cmd.Parameters.AddWithValue("@DBSType", stf.DBSType);
                    cmd.Parameters.AddWithValue("@DBSIssue", stf.DBSIssueDate);
                    cmd.Parameters.AddWithValue("@DBSExpiry", stf.DBSExpirydate);
                    cmd.Parameters.AddWithValue("@DrivingLic", stf.Driving);
                    cmd.Parameters.AddWithValue("@ProofOfAddress", stf.ProofofAddress);
                    if (stf.ProofofAddress == "YES")
                    {
                        cmd.Parameters.AddWithValue("@AddressDoc", stf.ProofDoc);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@AddressDoc", "");

                    }
                    cmd.Parameters.AddWithValue("@TrainingAttend", stf.Training);

                    cmd.Parameters.AddWithValue("@Issuedate", stf.Issuedate);
                    cmd.Parameters.AddWithValue("@Expirydate", stf.ExpiryDate);
                    cmd.Parameters.AddWithValue("@TrainingDoc", stf.TrainingDoc);


                    cmd.Parameters.AddWithValue("@Name", stf.Name);
                    cmd.Parameters.AddWithValue("@ApplicationNo", stf.ApplicationNo);
                    cmd.Parameters.AddWithValue("@Isdelete", stf.Isdelete);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;


                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {



            }




        }
        public int InsertProof(StaffSchema sfs) {

            try
            {
                using (cmd = new SqlCommand("Insert_Proof", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name",sfs.Name);
                    cmd.Parameters.AddWithValue("@ContentType",sfs.ContentType);
                    cmd.Parameters.AddWithValue("@Typeofproof",sfs.ProofType);
                    cmd.Parameters.AddWithValue("@Data",sfs.Data);
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    int result = cmd.ExecuteNonQuery();
                    con.Close();
                    return result;
                
                }
            }

            catch (Exception ex)
            {
                throw ex;

            }
            finally {
            
            
            }
        
        }
    }
}
