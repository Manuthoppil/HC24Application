using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using Appprop;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace HC24Application
{
    public partial class AddStaff : System.Web.UI.Page
    {
        public string query, constr;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                load();
                RegistrationId();
            }
            catch(Exception ex)
            {

                throw ex;
            
            }

        }
        public void RegistrationId() {

            query = "select count(*) as count from tbl_PersonalInformation";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            AppLabel.Text = "HC2400" + count;



        }
        public void load()
        {

            if (Drpposition.SelectedItem.Text == "RGN")
            {

                PinNo.Visible = Visible;
                NMCPin.Visible = Visible;
                RenId.Visible = Visible;
                RenewalInputdate.Visible = Visible;


            }
            else
            {
                PinNo.Visible = false;
                NMCPin.Visible = false;
                RenId.Visible = false;
                RenewalInputdate.Visible = false;
            }
            if (DrpAddress.SelectedItem.Text == "YES")
            {
                adrp.Visible = Visible;
                upl.Visible = Visible;
                Adrupl.Visible = Visible;
            }
            else
            {
                adrp.Visible = false;
                upl.Visible = false;
                Adrupl.Visible = false;
            }
            if (Drptraining.SelectedItem.Text == "YES")
            {
                IsDate.Visible = Visible;
                lbl_ISdate.Visible = Visible;
                Inputdate3.Visible = Visible;
                ExDate.Visible = Visible;
                lbl_ExDate.Visible = Visible;
                Inputdate4.Visible = Visible;
                crtraining.Visible = Visible;
                tlbl.Visible = Visible;
                tfupld.Visible = Visible;

            }
            else
            {
                IsDate.Visible = false;
                lbl_ISdate.Visible = false;
                Inputdate3.Visible = false;
                ExDate.Visible = false;
                lbl_ExDate.Visible = false;
                Inputdate4.Visible = false;
                crtraining.Visible = false;
                tlbl.Visible = false;
                tfupld.Visible = false;
            }
         
            
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }
        public void Insert() 
        {
            if (txtlastname.Text == "" || txtlastname.Text == "" || txtemail.Text == ""  || Drpnationality.SelectedItem.Text=="" || txtmobileNumber.Text=="")
            {
  
            }
            else
            {

                try
                {
                    StaffSchema staff = new StaffSchema();
                    staff.FirstName = txtfirstname.Text;
                    staff.lastname = txtlastname.Text;
                    staff.EmailId = txtemail.Text;
                    staff.PhoneNumber = txtmobileNumber.Text;
                    staff.Nationality = Drpnationality.SelectedItem.Text;
                    string datea = Request.Form[exampleInputdate.UniqueID];
                    DateTime dt = DateTime.Parse(datea);
                    string dateofbirth = dt.ToString("dd-MMM-yyyy");
                    staff.DateofBirth = dt.ToString("dd-MMM-yyyy");
                    string gender = string.Empty;
                    if (RadioButtonList1.SelectedItem.Text == "")
                    {
                        gender = "";
                    }
                    else
                    {
                        gender = RadioButtonList1.SelectedItem.Text;
                    }
                    staff.Gender = gender;
                    BLL.StaffBLL staffBLL = new BLL.StaffBLL();
                    staffBLL.InsertStaff(staff);
                }
                catch (Exception ex)
                {

                    throw ex;
                
                }
                
            }


        }
        public void InsertAddress() 
        {
            StaffSchema staff = new StaffSchema();
            staff.Address = txtaddress.Text;
            staff.street = txtstreet.Text;
            staff.county = county.SelectedItem.Text;    
            staff.PostCode = txtpostcode.Text;
            staff.Isdelete = 1;
            BLL.StaffBLL stb = new StaffBLL();
            stb.InsertAddress(staff);
        }
        public void InsertOtherDetails()
        {
            StaffSchema sfs = new StaffSchema();
            sfs.NiNumber = txtNI.Text;  
            sfs.DBS = txtDBS.Text;
            sfs.DBSType = DrpDBS.SelectedItem.Text;
            string issuedate = string.Empty;
            issuedate = Request.Form[Inputdate.UniqueID];
            DateTime dt = DateTime.Parse(issuedate);
            sfs.DBSIssueDate = dt.ToString("dd-MMM-yyyy"); 
            string expiryDate = string.Empty;
            expiryDate = Request.Form[Inputdate2.UniqueID];
            DateTime dt1 = DateTime.Parse(expiryDate);
            sfs.DBSExpirydate = dt1.ToString("dd-MMM-yyyy");
            string Licence = string.Empty;
            if (DrivingList.SelectedItem.Text == "")
            {

                Licence = "";
            
            }
            else 
            { 

                sfs.Driving = DrivingList.SelectedItem.Text; 


            }
            
            sfs.ProofofAddress = DrpAddress.SelectedItem.Text;
            sfs.Isdelete = 1;
            BLL.StaffBLL stb = new StaffBLL();
            stb.InserOtherDtails(sfs);
        }
        protected void Staffadd_Click(object sender, EventArgs e)
        {

         Insert();
         InsertPosition();
         InsertAddress();
         Imageupload();
         InsertOtherDetails();
         ProofUpload();
         TrainingCertificate();
         InsertApplicationId();



        }
        protected void Drpposition_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Drpposition.SelectedItem.Text == "HCA")
            {
                PinNo.Visible = false;
                NMCPin.Visible = false;
                RenId.Visible = false;
                RenewalInputdate.Visible = false;
            }
            else if (Drpposition.SelectedItem.Text == "RGN")
            {
                PinNo.Visible = Visible;
                NMCPin.Visible = Visible;
                RenId.Visible = Visible;
                RenewalInputdate.Visible = Visible;

            }
            else {
                PinNo.Visible = Visible;
                NMCPin.Visible = Visible;
                RenId.Visible = Visible;
                RenewalInputdate.Visible = Visible;


            }
        }

        protected void DrpAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DrpAddress.SelectedItem.Text == "YES")
            {
                adrp.Visible   = Visible;
                upl.Visible    = Visible;
                Adrupl.Visible = Visible;
            }
            else {

                adrp.Visible = false;
                upl.Visible = false;
                Adrupl.Visible = false;

            }
            if (Drpposition.SelectedItem.Text == "RGN")
            {
                PinNo.Visible = Visible;
                NMCPin.Visible = Visible;
                RenId.Visible = Visible;
                RenewalInputdate.Visible = Visible;

            }
            else { 
            
            }
        }
        protected void Drptraining_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Drptraining.SelectedItem.Text == "YES")
            {
                IsDate.Visible     = Visible;
                lbl_ISdate.Visible = Visible;
                Inputdate3.Visible = Visible;
                ExDate.Visible     = Visible;
                lbl_ExDate.Visible = Visible;
                Inputdate4.Visible = Visible;
                crtraining.Visible = Visible;
                tlbl.Visible       = Visible;
                tfupld.Visible     = Visible;

            }
            else
            {
                IsDate.Visible     = false;
                lbl_ISdate.Visible = false;
                Inputdate3.Visible = false;
                ExDate.Visible     = false;
                lbl_ExDate.Visible = false;
                Inputdate4.Visible = false;
                crtraining.Visible = false;
                tlbl.Visible       = false;
                tfupld.Visible     = false;
            }
          
          
        }
        private void Imageupload()
        {
                if (ImageUpload.HasFile)
                {
                    int imagefilelenth = ImageUpload.PostedFile.ContentLength;
                    byte[] imgarray = new byte[imagefilelenth];
                    HttpPostedFile image = ImageUpload.PostedFile;
                    image.InputStream.Read(imgarray, 0, imagefilelenth);
                    query = "insert into tbl_Image(Image,MatchingCode)values(@Image,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc))";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Image", SqlDbType.Image).Value = imgarray;
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    cmd.ExecuteNonQuery();
                }
        }
        public void ProofUpload() 
        {
            if (DrpAddress.SelectedItem.Text == "Select")
            {



            }
            else
            {
                if (DrpAddress.SelectedItem.Text == "YES")
                {

                    string filename = Path.GetFileName(Adrupl.PostedFile.FileName);
                    string contentType = Adrupl.PostedFile.ContentType;
                    using (Stream fs = Adrupl.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
                            query = "Insert into tbl_ProofOfDocument(Name,ContentType,TypeOfproof,Data,MatchingCode) values(@Name,@ContentType,@Typeofproof,@Data,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc))";
                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                            cmd.Parameters.AddWithValue("@ContentType", SqlDbType.NVarChar).Value = contentType;
                            cmd.Parameters.AddWithValue("@Typeofproof", SqlDbType.NVarChar).Value = "Address";
                            cmd.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = bytes;
                            if (con.State.Equals(ConnectionState.Closed)) con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }


                }
                else
                {

                    query = "Insert into tbl_ProofOfDocument(TypeOfproof,MatchingCode) values(@Typeofproof,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc))";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Typeofproof", SqlDbType.NVarChar).Value = "Address";             
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    cmd.ExecuteNonQuery();


                }

            }

        }
        public void TrainingCertificate() {

            string Attend = String.Empty;
            Attend = Drptraining.SelectedItem.Text;
            if (Drptraining.SelectedItem.Text == "Select")
            {

            }
            else {
                if(Drptraining.SelectedItem.Text== "YES")
                {
                    
                    if (Inputdate3.Value == "" || Inputdate4.Value == "")
                    {



                    }
                    else {
                        
                       
                        string AtDate = string.Empty;
                        AtDate = Convert.ToDateTime(Request.Form[Inputdate3.UniqueID]).ToString("dd-MMM-yyyy");
                        string ExDate = string.Empty;
                        ExDate= Convert.ToDateTime(Request.Form[Inputdate4.UniqueID]).ToString("dd-MMM-yyyy");
                        string filename = Path.GetFileName(tfupld.PostedFile.FileName);
                        string contentType = tfupld.PostedFile.ContentType;
                        using (Stream fs = tfupld.PostedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                query = "Insert into tbl_Training(Attended,IssueDate,ExpiryDate,CertificateName,ContentType,Data,MatchingCode,IsDelete) values(@Attended,@IssueDate,@ExpiryDate,@CertificateName,@ContentType,@Data,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc),@IsDelete)";
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@Attended", SqlDbType.NVarChar).Value = Attend;
                                cmd.Parameters.AddWithValue("@IssueDate", SqlDbType.NVarChar).Value = AtDate;
                                cmd.Parameters.AddWithValue("@ExpiryDate", SqlDbType.NVarChar).Value = ExDate;
                                cmd.Parameters.AddWithValue("@CertificateName", SqlDbType.NVarChar).Value = "Training Certificate";
                                cmd.Parameters.AddWithValue("@ContentType", SqlDbType.NVarChar).Value = contentType;
                                cmd.Parameters.AddWithValue("@Data", SqlDbType.VarBinary).Value = bytes;
                                cmd.Parameters.AddWithValue("@IsDelete", SqlDbType.Int).Value = 1;
                                if (con.State.Equals(ConnectionState.Closed)) con.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }


                    }
                   

                    }
                if (Drptraining.SelectedItem.Text == "NO")
                {

                    query = "Insert into tbl_Training(Attended,MatchingCode,IsDelete) values(@Attended,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc),@IsDelete)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Attended", SqlDbType.NVarChar).Value = Attend;
                    cmd.Parameters.AddWithValue("@IsDelete", SqlDbType.Int).Value = 1;
                    if (con.State.Equals(ConnectionState.Closed)) con.Open();
                    cmd.ExecuteNonQuery();


                }
                else 
                { 
                }

            }
        
        
        }
        public void InsertPosition() {

            StaffSchema stf = new StaffSchema();
            stf.Position = Drpposition.SelectedItem.Text;
            stf.NmcPin = NMCPin.Text;
            stf.RenewlDate= Convert.ToDateTime(Request.Form["rdate"]).ToString("dd-MMM-yyyy");
            stf.Isdelete = 1;
            BLL.StaffBLL staffBll = new BLL.StaffBLL();
            staffBll.PositionInsert(stf);


        }


        public void InsertApplicationId() {


            query = "Insert into tbl_ApplicationNumber(ApplicationId,MatchingCode,IsDelete) values(@ApplicationId,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc),@IsDelete)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ApplicationId", SqlDbType.NVarChar).Value = AppLabel.Text;
            cmd.Parameters.AddWithValue("@IsDelete", SqlDbType.Int).Value = 1;
            if (con.State.Equals(ConnectionState.Closed)) con.Open();
            cmd.ExecuteNonQuery();

            
        }

    }
}