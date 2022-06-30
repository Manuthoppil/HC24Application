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
        int result;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    load();
                    RegistrationId();
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
        }
        public void RegistrationId() {
            //con.Open();
            query = "select count(*) as count from tbl_Info";
            SqlCommand cmd = new SqlCommand(query, con);
            if (con.State.Equals(ConnectionState.Closed)) con.Open();
            int count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            AppLabel.Text = "HC2400" + count;
            //con.Close();




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

            IsDate.Visible     = false;
            lbl_ISdate.Visible = false;
            Inputdate3.Visible = false;
            ExDate.Visible     = false;
            lbl_ExDate.Visible = false;
            Inputdate4.Visible = false;
            crtraining.Visible = false;
            tlbl.Visible       = false;
            tfupld.Visible     = false;
            RenewalInputdate.Visible = false;
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
        }
        public void Insert() 
        {
                try
                {
                DateTime myDateTime = DateTime.Now;
                string year = myDateTime.Year.ToString();
                DateTime myDate = Convert.ToDateTime(exampleInputdate.Value);
                DateTime date = Convert.ToDateTime(myDate);
                int DateOfBirth = date.Year;
                int year1 = Convert.ToInt32(DateOfBirth);
                int year2 = Convert.ToInt32(year);
                int age = year2 - year1;
                ViewState["age"] = age.ToString();
                //int imagefilelenth = ImageUpload.PostedFile.ContentLength;
               // byte[] imgarray = new byte[imagefilelenth];
               // HttpPostedFile image = ImageUpload.PostedFile;
               // image.InputStream.Read(imgarray, 0, imagefilelenth);
                StaffSchema staff = new StaffSchema();
                
                //string result = ImageUpload.PostedFile.FileName;
               //ImageUpload.PostedFile.SaveAs(MapPath("~") + "/Images/Staffimage/" + result);
           
                staff.image = ""; 
                staff.FirstName = txtfirstname.Text;
                    staff.lastname = txtlastname.Text;
                    staff.EmailId = txtemail.Text;
                    staff.PhoneNumber = txtmobileNumber.Text;
                    staff.Nationality = Drpnationality.SelectedItem.Text;
                    staff.ApplicationNo = AppLabel.Text;
                    string datea = Request.Form[exampleInputdate.UniqueID];
                    DateTime dt = DateTime.Parse(datea);
                    string dateofbirth = dt.ToString("dd-MMM-yyyy");
                    staff.DateofBirth = dt.ToString("dd-MMM-yyyy");
                    string gender = string.Empty;
                    if (RadioButtonList1.SelectedIndex == -1)
                    {
                        gender = "Not Mentioned";
                    }
                    else
                    {
                        gender = RadioButtonList1.SelectedItem.Text;
                    }
                    staff.Gender = gender;
                staff.Address = txtaddress.Text;
                staff.street = txtstreet.Text;
                staff.county = county.SelectedItem.Text;
                staff.PostCode = txtpostcode.Text;
                staff.Position = Drpposition.SelectedItem.Text;
                staff.Age =Convert.ToInt32(ViewState["age"].ToString());
                    BLL.StaffBLL staffBLL = new BLL.StaffBLL();
                    staffBLL.InsertStaff(staff);
                }
              catch (Exception ex)
                {

                    throw ex;
                
                }
                
            


        }
        //public void InsertAddress() 
        //{
        //    StaffSchema staff = new StaffSchema();
        //    staff.Address = txtaddress.Text;
        //    staff.street = txtstreet.Text;
        //    staff.county = county.SelectedItem.Text;    
        //    staff.PostCode = txtpostcode.Text;
        //    staff.Isdelete = 1;
        //    BLL.StaffBLL stb = new StaffBLL();
        //    stb.InsertAddress(staff);
        //}
        public void InsertOtherDetails()
        {
            StaffSchema sfs = new StaffSchema();
            sfs.ApplicationNo = AppLabel.Text;
            sfs.Name = txtfirstname.Text;
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
            if (DrivingList.SelectedIndex == -1)
            {

                sfs.Driving = "";
            
            }
            else 
            { 

                sfs.Driving = DrivingList.SelectedItem.Text; 


            }
            
            sfs.ProofofAddress = DrpAddress.SelectedItem.Text;
            if(DrpAddress.SelectedItem.Text == "YES")
            {
                string proof = AppLabel.Text + Adrupl.PostedFile.FileName;
                Adrupl.PostedFile.SaveAs(MapPath("~") + "/Files/ProofOfAddress/" + proof);
                sfs.ProofDoc = proof.ToString();
               
            }
            else
            {
                sfs.ProofDoc = "";
            }
            sfs.Training = Drptraining.SelectedItem.Text;
            if (Drptraining.SelectedItem.Text == "YES")
            {
                string training = AppLabel.Text + tfupld.PostedFile.FileName;
                tfupld.PostedFile.SaveAs(MapPath("~") + "/Files/Training/" + training);
                sfs.TrainingDoc = training.ToString();
                string Issuedate = Inputdate3.Value;
                DateTime Issuedate2 = DateTime.Parse(Issuedate);
                string Issuedate1 = Issuedate2.ToString("dd-MMM-yyyy");
                sfs.Issuedate = Issuedate2.ToString("dd-MMM-yyyy");

                string ExpiryDate = Inputdate4.Value;
                DateTime ExpiryDate2 = DateTime.Parse(ExpiryDate);
                string ExpiryDate1 = ExpiryDate2.ToString("dd-MMM-yyyy");
                sfs.ExpiryDate = ExpiryDate2.ToString("dd-MMM-yyyy");
            }
            else
            {
                sfs.TrainingDoc = "";
                sfs.Issuedate = "";
                sfs.ExpiryDate = "";

            }
            sfs.Isdelete = 1;
            BLL.StaffBLL stb = new StaffBLL();
            stb.InserOtherDtails(sfs);
        }
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }


        public void clear()
        {
            ClearTextBoxes(Page);
       Drpnationality.SelectedIndex= -1;
            exampleInputdate.Value = "";
            RadioButtonList1.SelectedIndex = -1;
            county.SelectedIndex = -1;
            DrpDBS.SelectedIndex = -1;
            Inputdate.Value = "";
            Inputdate2.Value = "";
            DrivingList.SelectedIndex = -1;
            DrpAddress.SelectedIndex = -1;
            Drptraining.SelectedIndex = -1;
            Inputdate3.Value = "";
            Inputdate4.Value = "";
            Drpposition.SelectedIndex = -1;
            PinNo.Visible = false;
                    NMCPin.Visible = false;
                    RenId.Visible = false;
                    RenewalInputdate.Visible = false;
                
              
                    adrp.Visible = false;
                    upl.Visible = false;
                    Adrupl.Visible = false;
                

                IsDate.Visible = false;
                lbl_ISdate.Visible = false;
                Inputdate3.Visible = false;
                ExDate.Visible = false;
                lbl_ExDate.Visible = false;
                Inputdate4.Visible = false;
                crtraining.Visible = false;
                tlbl.Visible = false;
                tfupld.Visible = false;
                RenewalInputdate.Visible = false;
            // Page.Form.Attributes.Add("enctype", "multipart/form-data");
           



            RegistrationId();

        }
        protected void Staffadd_Click(object sender, EventArgs e)
        {
           try
            {

             Insert();
              Imageupload();
            InsertPosition();
            InsertOtherDetails();
                if (result >= 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Staff Details Added')", true);
                    clear();

                }
                
            }
            catch
            {
              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went Wrong')", true);

            }
          

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
            else 
            {

                adrp.Visible = false;
                upl.Visible = false;
                Adrupl.Visible = false;

            }
            if (Drpposition.SelectedItem.Text == "RGN")
            {
                PinNo.Visible  = Visible;
                NMCPin.Visible = Visible;
                RenId.Visible  = Visible;
                RenewalInputdate.Visible = Visible;

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

 //Profile Image Upload
 private void Imageupload()
        {
            if (ImageUpload.HasFile)
            {
                int imagefilelenth = ImageUpload.PostedFile.ContentLength;
                byte[] imgarray = new byte[imagefilelenth];
                HttpPostedFile image = ImageUpload.PostedFile;
                image.InputStream.Read(imgarray, 0, imagefilelenth);
                query = "insert into tbl_Image(Image,MatchingCode)values(@Image,(Select top 1 Staffid as id From tbl_Info Order By Id Desc))";
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
        public void TrainingCertificate()
        {

            string Attend = String.Empty;
            Attend = Drptraining.SelectedItem.Text;
            if (Drptraining.SelectedItem.Text == "Select")
            {

            }
            else
            {
                if (Drptraining.SelectedItem.Text == "YES")
                {

                    if (Inputdate3.Value == "" || Inputdate4.Value == "")
                    {



                    }
                    else
                    {


                        string AtDate = string.Empty;
                        AtDate = Convert.ToDateTime(Request.Form[Inputdate3.UniqueID]).ToString("dd-MMM-yyyy");
                        string ExDate = string.Empty;
                        ExDate = Convert.ToDateTime(Request.Form[Inputdate4.UniqueID]).ToString("dd-MMM-yyyy");
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
            stf.ApplicationNo = AppLabel.Text;
            stf.Name = txtfirstname.Text;
            if (Drpposition.SelectedItem.Text == "RGN")
            {
                stf.NmcPin = NMCPin.Text;
                string dateRen = RenewalInputdate.Value;
                DateTime dt = DateTime.Parse(dateRen);
                string Renwaldate = dt.ToString("dd-MMM-yyyy");
                stf.RenewlDate = dt.ToString("dd-MMM-yyyy");
            }
          
           
        //    stf.RenewlDate= Convert.ToDateTime(Request.Form["rdate"]).ToString("dd-MMM-yyyy");
            stf.Isdelete = 1;
            BLL.StaffBLL staffBll = new BLL.StaffBLL();
            staffBll.PositionInsert(stf);


        }


        //public void InsertApplicationId() {


        //    query = "Insert into tbl_ApplicationNumber(ApplicationId,MatchingCode,IsDelete) values(@ApplicationId,(Select top 1 Id as id From tbl_PersonalInformation Order By Id Desc),@IsDelete)";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    cmd.Parameters.AddWithValue("@ApplicationId", SqlDbType.NVarChar).Value = "HC24001";
        //    cmd.Parameters.AddWithValue("@IsDelete", SqlDbType.Int).Value = 1;
        //    if (con.State.Equals(ConnectionState.Closed)) con.Open();
        //    cmd.ExecuteNonQuery();

            
        //}

    }
}