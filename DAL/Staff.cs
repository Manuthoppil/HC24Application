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
                using (cmd = new SqlCommand("tbl_ProfileInsert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@chkpara", "Insert");
                    cmd.Parameters.AddWithValue("@frstname", stf.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", stf.lastname);
                    cmd.Parameters.AddWithValue("@Email", stf.EmailId);
                    cmd.Parameters.AddWithValue("@phno", stf.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Nation", stf.Nationality);
                    cmd.Parameters.AddWithValue("@Dateof", stf.DateofBirth);
                    cmd.Parameters.AddWithValue("@Gender", stf.Gender);
                    //cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(objSchema.Age));
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
                using (cmd = new SqlCommand("tbl_positionInsert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@position", stf.Position);
                    cmd.Parameters.AddWithValue("@NmcPin",stf.NmcPin);
                    cmd.Parameters.AddWithValue("@RenewalDate", stf.RenewlDate);
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
        
        }
        public int InsertOtherDetails(StaffSchema stf) {
            try
            {

                using (cmd = new SqlCommand("InsertOtherDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NiNumber", stf.NiNumber);
                    cmd.Parameters.AddWithValue("@DBSNumber", stf.DBS);
                    cmd.Parameters.AddWithValue("@DBSType", stf.DBSType);
                    cmd.Parameters.AddWithValue("@DBSIssueDate", stf.DBSIssueDate);
                    cmd.Parameters.AddWithValue("@DBSExpiryDate", stf.DBSExpirydate);
                    cmd.Parameters.AddWithValue("@DrivingLicence", stf.Driving);
                    cmd.Parameters.AddWithValue("@ProofofAddress", stf.ProofofAddress);
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
