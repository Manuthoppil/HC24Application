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
    public partial class Profile : System.Web.UI.Page
    {
        public string query, constr;
        public SqlConnection con;
        SqlCommand cmd;
        DataTable dt;

        public void connection()
        {
            constr = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            con = new SqlConnection(constr);
            con.Open();


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Request["value"]);
            Session["id"] = id;
            Image1.ImageUrl = "~/ImageHandler.ashx?id=" + id;
        }
        public string GetDetails()
        {
            string data = string.Empty;
          StaffSchema stf = new StaffSchema();
            StaffBLL staff = new StaffBLL();
            stf.Staffid = Convert.ToInt32(Session["id"]);
            dt = staff.Staff_Verfication(stf);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string Firstname = dr["FirstName"].ToString();
                    string Lastname = dr["LastName"].ToString();
                    String Name = (Firstname + Lastname).ToString();
                    data += "<div class='text-center mt-3 pl-3 pr-3'><h4><b> " + Name + "</b></h4><p>" + dr["Position"] + "</p></div><hr><div class='iq-card-body'><div class='about-info m-0 p-0'><div class='row'>" +
                                  "<div class='col-4'>Email:</div>" +
                                  "<div class='col-8'>" + dr["EmailAdd"] + "</div>" +
                                  "<div class='col-4'>Mobile Number:</div>" +
                                  "<div class='col-8'>" + dr["Phn"] + "</div>" +
                                  "<div class='col-4'>Nationality</div>" +
                                  "<div class='col-8'>" + dr["Nationality"] + "</div>" +
                                  "<div class='col-4'>Date of Birth</div>" +
                                  "<div class='col-8'>" + dr["Dob"] + "</div>" +
                                  "<div class='col-4'>Gender</div>" +
                                   "<div class='col-8''>" + dr["Gender"] + "</div>" +
                              "</div>" +
                           "</div> " +
                        "</div>";
                }
            }
            return data;
        }
        public string GetAddress()
        {

            string data = string.Empty;
            StaffSchema stf = new StaffSchema();
            StaffBLL staff = new StaffBLL();
            stf.Staffid = Convert.ToInt32(Session["id"]);
            dt = staff.Staff_Verfication(stf);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    

                    data += "<div class='iq-card'>" +
                           "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Personal Information</h4>" +
                                 "</div>" +
                              "</div>" +
                        "<div class='iq-card-header d-flex justify-content-between'>" +
                           "<div class='iq-header-title'>" +
                               "<div class='iq-card-body'>" +
                                 "<ul class='speciality-list m-0 p-0'>" +
                                    "<li class='d-flex mb-4 align-items-center'>" +
                                       "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
                                       "<div class='media-support-info ml-3'>" +
                                          "<h6>Address</h6>" +
                                          "<p class='mb-0'>" + dr["Address"] + "," + dr["Street"] + "</p>" +
                                           "<p class='mb-0'>" + dr["Postal"] +","+ dr["Country"]+ "</p>" +
                                           //"<p class='mb-0'>" +  + "</p>" +
                                       "</div>" +
                                    "</li>" +
                                 "</ul>" +
                              "</div>" +
                           "</div>" +
                        "</div>" +
                     "</div>";

                }
            }

            return data;


        }


        public string GetOtherDetails() {

            string data = string.Empty;
            StaffSchema stf = new StaffSchema();
            StaffBLL staff = new StaffBLL();
            stf.Staffid = Convert.ToInt32(Session["id"]);
            dt = staff.Staff_Verfication(stf);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    DateTime dtt = Convert.ToDateTime(dr["DBSIssue"]);
                    DateTime dateonly = dtt.Date;

                    DateTime dateex=Convert.ToDateTime(dr["DBSExpiry"]);
                    DateTime dateexonly=dateex.Date;

                    data += "<div class='col-lg-7'>" +
                      "<div class='container iq-card'>" +
                          "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Other Details</h4>" +
                                 "</div>" +
                              "</div>" +
                          "<div class='iq-card-body'>" +
                            "<div class='row'>" +
                                "<div class='col-6'>" +
                                    "<ul class='list-inline m-0 p-0'>" +
                                           "<li>" +
                                       "<h6 class='float-left mb-1'>NI Number</h6>" +
                                       "<div class='d-inline-block w-100'>" +
                                          "<p class='badge badge-primary'>" + dr["NationalInsNo"] + "</p>" +
                                       "</div>" +
                                    "</li>" +
                                      "</ul>" +
                                            "</div>" +
                                                "<div class='col-6'>" +
                                            "<ul class='list-inline m-0 p-0'>" +
                                           "<li>" +
                                       "<h6 class='float-left mb-1'>DBS Number</h6>" +
                                       "<div class='d-inline-block w-100'>" +
                                          "<p class='badge badge-primary'>" + dr["DBS"] + " </p>" +
                                       "</div>" +
                                    "</li>" +
                                      "</ul>" +
                                            "</div>" +
                                        "<div class='col-6'>" +
                                        "<ul class='list-inline m-0 p-0'>" +
                                           "<li>" +
                                       "<h6 class='float-left mb-1'>DBS Type</h6>" +
                                       "<div class='d-inline-block w-100'>" +
                                          "<p class='badge badge-primary'>" + dr["DBSType"] + "</p>" +
                                       "</div> " +
                                     "</li> " +
                                       "</ul> " +
                                        "</div> " +
                                            "<div class='col-6'>" +
                                            "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>DBS Issue Date</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                           "<p class='badge badge-primary'>" + dateonly.ToString("dd/mm/yyyy") + "</p>" +
                                        "</div>" +
                                     "</li>" +
                                       "</ul>" +
                                        "</div>" +
                                        "<div class='col-6'>" +
                                        "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>DBS Expiry Date</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                          " <p class='badge badge-primary'>" + dateex.ToString("dd/mm/yyyy") + "</p>" +
                                        "</div>" +
                                     "</li>" +
                                      " </ul>" +
                                    "</div>" +
                                         "<div class='col-6'>" +
                                        "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>Uk Full Driving Licence</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                           "<p class='badge badge-primary'>" + dr["DrivingLic"] + "</p>" +
                                       " </div>" +
                                     "</li>" +
                                       "</ul>" +
                                    "</div>" +
                                "</div>" +
                                 "</div>" +
                               "</div>";
                           
                            if (dr["TrainingAttend"].ToString() == "NO")
                    {
                        data += "<div class='col-lg-7'>" +
                            "<div class='iq-card'>" +
                           "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Training Document</h4>" +
                                 "</div>" +
                              "</div>" +
                        "<div class='iq-card-header d-flex justify-content-between'>" +
                           "<div class='iq-header-title'>" +
                               "<div class='iq-card-body'>" +
                                 "<ul class='speciality-list m-0 p-0'>" +
                                    "<li class='d-flex mb-4 align-items-center'>" +
                                       "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
                                       "<div class='media-support-info ml-3'>" +
                                          "<h6>Training</h6>" +
                                         "<p class='badge badge-primary'>Training was not attended</p>" +

                                       "</div>" +
                                    "</li>" +
                                 "</ul>" +
                              "</div>" +
                           "</div>" +
                        "</div>" +
                         "</div>" +
                     "</div>";

                    }
                    else
                    {
                        DateTime dateTimeIssue = Convert.ToDateTime(dr["Issuedate"]);
                        string dateIssue = dateTimeIssue.ToString("dd/MM/yyyy");
                        DateTime dateTimeExpire = Convert.ToDateTime(dr["Issuedate"]);
                        string dateExpire = dateTimeExpire.ToString("dd/MM/yyyy");


                        string doc = dr["TrainingDoc"].ToString();
                        string path = "Files/Training/" + doc + "";


                        data += 
                            "<div class='container iq-card'>" +
                           "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Training Document</h4>" +
                                 "</div>" +
                              "</div>" +
                               "<div class='iq-card-body'>" +
                                 "<ul class='speciality-list m-0 p-0'>" +
                                    "<li class='d-flex mb-4 align-items-center'>" +

                                    "<div class='col-3'>" +
                                            "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                      
                                        "<div class='d-inline-block w-100'>" +

                                     
                                          "<h6>Issue Date</h6>" +
                                           "<p class='mb-0'>" + dateIssue + "</p>" +


                                            "</div>" +
                                     "</li>" +
                                       "</ul>" +
                                        "</div>" +
                                         "<div class='col-4'>" +
                                            "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<div class='d-inline-block w-100'>" +
                                            "<h6>Expire Date</h6>" +
                                           "<p class='mb-0'>" + dateExpire + "</p>" +
                                                "</div>" +
                                     "</li>" +
                                       "</ul>" +
                                        "</div>" +
                                          "<div class='col-4'>" +
                                           "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<div class='d-inline-block w-100'>" +
                                                "<h6>Training Document</h6>" +
                                         "<a href='" + path + "' class='btn btn-primary button_magin' target='_blank'>Certificate</a>" +
                                        "</div>" +
                                     "</li>" +
                                       "</ul>" +
                                        "</div>" +
                                    "</li>" +
                                 "</ul>" +
                                  
                        "</div>" +
                       
                     "</div>";
                    }

                    if (dr["ProofOfAddress"].ToString() == "NO")
                    {
                        data += "<div class='col-lg-7'>" +
                            "<div class='iq-card'>" +
                           "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Address Proof Document</h4>" +
                                 "</div>" +
                              "</div>" +
                        "<div class='iq-card-header d-flex justify-content-between'>" +
                           "<div class='iq-header-title'>" +
                               "<div class='iq-card-body'>" +
                                 "<ul class='speciality-list m-0 p-0'>" +
                                    "<li class='d-flex mb-4 align-items-center'>" +
                                       "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
                                       "<div class='media-support-info ml-3'>" +
                                          "<h6>Document</h6>" +
                                         "<p class='badge badge-primary'>No records Found</p>" +

                                       "</div>" +
                                    "</li>" +
                                 "</ul>" +
                              "</div>" +
                           "</div>" +
                        "</div>" +
                         "</div>" ;
                    

                    }
                    else
                    {
                        string doc = dr["AddressDoc"].ToString();
                        string path = "Files/ProofOfAddress/" + doc + "";
                        //                        data += "<div class='col-lg-7'> " +
                        //    "<div class='container iq-card'>  " +
                        //        "<div class='iq-card-header d-flex justify-content-between'>  " +
                        //            "<div class='iq-header-title'>  " +
                        //                "<h4 class='card-title'>Proof Of Address</h4>" +
                        //                "</ div > " +
                        //            "</ div > " +
                        //        "<div class='iq-card-body'> " +
                        //            "<div class='row'>" +
                        //                "<div class='col-6'> " +
                        //                    "<ul class='list-inline m-0 p-0'>" +
                        //                        " <li> " +
                        //                            "<h6 class='float-left mb-1'>Document</h6>" +
                        //                            "<div class='d-inline-block w-100'>  " +
                        //                                "<a href='" + path + "' class='btn btn-primary float-right' target='_blank'>Proof Of Address</a>" +
                        //                               "</ div > " +
                        //                            "  </ li > " +
                        //                        "</ ul > " +
                        //                    "</ div > " +
                        //"</ div > " +
                        //            "</ div > " +
                        //        "</ div > " +
                        //    "</ div > " + "";

                        data += 
                            "<div class='iq-card'>" +
                           "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Address Proof Document</h4>" +
                                 "</div>" +
                              "</div>" +
                        "<div class='iq-card-header d-flex justify-content-between'>" +
                           "<div class='iq-header-title'>" +
                               "<div class='iq-card-body'>" +
                                 "<ul class='speciality-list m-0 p-0'>" +
                                    "<li class='d-flex mb-4 align-items-center'>" +
                                    
                                       "<div class='media-support-info ml-3'>" +
                                          "<h6>Document</h6>" +
                                         "<a href='" + path + "' class='btn btn-primary float-right' target='_blank'>Proof Of Address</a>" +
                                       "</div>" +
                                    "</li>" +
                                 "</ul>" +
                              "</div>" +
                           "</div>" +
                        "</div>" +
                     "</div>" +
                     "</div>";
                       
                    }




                }
            }

            return data;



        }

        //public string GetProofDocuments()
        //{

        //    string data = string.Empty;
        //    StaffSchema stf = new StaffSchema();
        //    StaffBLL staff = new StaffBLL();
        //    stf.Staffid = Convert.ToInt32(Session["id"]);
        //    dt = staff.Staff_Verfication(stf);
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            if (dr["ProofOfAddress"].ToString() == "NO")
        //            {
        //                data += "<div class='iq-card'>" +
        //                   "<div class='iq-card-header d-flex justify-content-between'>" +
        //                         "<div class='iq-header-title'>" +
        //                            "<h4 class='card-title'>Address Proof Document</h4>" +
        //                         "</div>" +
        //                      "</div>" +
        //                "<div class='iq-card-header d-flex justify-content-between'>" +
        //                   "<div class='iq-header-title'>" +
        //                       "<div class='iq-card-body'>" +
        //                         "<ul class='speciality-list m-0 p-0'>" +
        //                            "<li class='d-flex mb-4 align-items-center'>" +
        //                               "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
        //                               "<div class='media-support-info ml-3'>" +
        //                                  "<h6>Document</h6>" +
        //                                 "<p class='badge badge-primary'>No records Found</p>" +

        //                               "</div>" +
        //                            "</li>" +
        //                         "</ul>" +
        //                      "</div>" +
        //                   "</div>" +
        //                "</div>" +
        //             "</div>";

        //            }
        //            else
        //            {
        //                string doc = dr["AddressDoc"].ToString();
        //                string path = "Files/ProofOfAddress/" + doc + "";
        //                //                        data += "<div class='col-lg-7'> " +
        //                //    "<div class='container iq-card'>  " +
        //                //        "<div class='iq-card-header d-flex justify-content-between'>  " +
        //                //            "<div class='iq-header-title'>  " +
        //                //                "<h4 class='card-title'>Proof Of Address</h4>" +
        //                //                "</ div > " +
        //                //            "</ div > " +
        //                //        "<div class='iq-card-body'> " +
        //                //            "<div class='row'>" +
        //                //                "<div class='col-6'> " +
        //                //                    "<ul class='list-inline m-0 p-0'>" +
        //                //                        " <li> " +
        //                //                            "<h6 class='float-left mb-1'>Document</h6>" +
        //                //                            "<div class='d-inline-block w-100'>  " +
        //                //                                "<a href='" + path + "' class='btn btn-primary float-right' target='_blank'>Proof Of Address</a>" +
        //                //                               "</ div > " +
        //                //                            "  </ li > " +
        //                //                        "</ ul > " +
        //                //                    "</ div > " +
        //                //"</ div > " +
        //                //            "</ div > " +
        //                //        "</ div > " +
        //                //    "</ div > " + "";

        //                data += "<div class='iq-card'>" +
        //                   "<div class='iq-card-header d-flex justify-content-between'>" +
        //                         "<div class='iq-header-title'>" +
        //                            "<h4 class='card-title'>Address Proof Document</h4>" +
        //                         "</div>" +
        //                      "</div>" +
        //                "<div class='iq-card-header d-flex justify-content-between'>" +
        //                   "<div class='iq-header-title'>" +
        //                       "<div class='iq-card-body'>" +
        //                         "<ul class='speciality-list m-0 p-0'>" +
        //                            "<li class='d-flex mb-4 align-items-center'>" +
        //                               "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
        //                               "<div class='media-support-info ml-3'>" +
        //                                  "<h6>Document</h6>" +
        //                                 "<a href='" + path + "' class='btn btn-primary float-right' target='_blank'>Proof Of Address</a>" +

        //                               "</div>" +
        //                            "</li>" +
        //                         "</ul>" +
        //                      "</div>" +
        //                   "</div>" +
        //                "</div>" +
        //             "</div>";
        //            }
        //        }
        //    }

        //    return data;



        //}


        //public string GetProofTraining()
        //{

        //    string data = string.Empty;
        //    StaffSchema stf = new StaffSchema();
        //    StaffBLL staff = new StaffBLL();
        //    stf.Staffid = Convert.ToInt32(Session["id"]);
        //    dt = staff.Staff_Verfication(stf);
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            if (dr["TrainingAttend"].ToString() == "NO")
        //            {
        //                data += "<div class='col-lg-7'>" +
        //                    "<div class='iq-card'>" +
        //                   "<div class='iq-card-header d-flex justify-content-between'>" +
        //                         "<div class='iq-header-title'>" +
        //                            "<h4 class='card-title'>Training Document</h4>" +
        //                         "</div>" +
        //                      "</div>" +
        //                "<div class='iq-card-header d-flex justify-content-between'>" +
        //                   "<div class='iq-header-title'>" +
        //                       "<div class='iq-card-body'>" +
        //                         "<ul class='speciality-list m-0 p-0'>" +
        //                            "<li class='d-flex mb-4 align-items-center'>" +
        //                               "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
        //                               "<div class='media-support-info ml-3'>" +
        //                                  "<h6>Training</h6>" +
        //                                 "<p class='badge badge-primary'>Training was not attended</p>" +

        //                               "</div>" +
        //                            "</li>" +
        //                         "</ul>" +
        //                      "</div>" +
        //                   "</div>" +
        //                "</div>" +
        //                 "</div>" +
        //             "</div>";

        //            }
        //            else
        //            {
        //                DateTime dateTimeIssue = Convert.ToDateTime(dr["Issuedate"]);
        //                string dateIssue = dateTimeIssue.ToString("dd/MM/yyyy");
        //                DateTime dateTimeExpire = Convert.ToDateTime(dr["Issuedate"]);
        //                string dateExpire = dateTimeExpire.ToString("dd/MM/yyyy");


        //                string doc = dr["TrainingDoc"].ToString();
        //                string path = "Files/Training/" + doc + "";


        //                data += "<div class='col-lg-7'>" +
        //                    "<div class='container iq-card'>" +
        //                   "<div class='iq-card-header d-flex justify-content-between'>" +
        //                         "<div class='iq-header-title'>" +
        //                            "<h4 class='card-title'>Training Document</h4>" +
        //                         "</div>" +
        //                      "</div>" +
        //                "<div class='iq-card-header d-flex justify-content-between'>" +
        //                   "<div class='iq-header-title'>" +
        //                       "<div class='iq-card-body'>" +
        //                         "<ul class='speciality-list m-0 p-0'>" +
        //                            "<li class='d-flex mb-4 align-items-center'>" +
        //                               "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
        //                               "<div class='media-support-info ml-3'>" +
        //                                  "<h6>Issue Date</h6>" +
        //                                   "<p class='mb-0'>" + dateIssue + "</p>" +
        //                                    "<h6>Expire Date</h6>" +
        //                                   "<p class='mb-0'>" + dateExpire + "</p>" +
        //                                     "<h6>Training Document</h6>" +



        //                                 "<a href='" + path + "' class='btn btn-primary float-right' target='_blank'>Training Document</a>" +

        //                               "</div>" +
        //                            "</li>" +
        //                         "</ul>" +
        //                      "</div>" +
        //                   "</div>" +
        //                "</div>" +
        //                "</div>" +
        //             "</div>";
        //            }
        //        }
        //    }

        //    return data;



        //}
    }
}