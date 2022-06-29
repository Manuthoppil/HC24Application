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
            Image1.ImageUrl = "~/ImageHandler.ashx?id=" + id;
        }
        public string GetDetails()
        {
            string data = string.Empty;
            StaffBLL staff = new StaffBLL();
            dt = staff.Staff_Details();
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
            StaffBLL staff = new StaffBLL();
            dt = staff.Staff_Details();
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
                                           "<p class='mb-0'>" + dr["Postal"] + "</p>" +
                                           "<p class='mb-0'>" + dr["Country"] + "</p>" +
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
            StaffBLL staff = new StaffBLL();
            dt = staff.Staff_Details();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data += "<div class='col-lg-7'>"+
                      "<div class='container iq-card'>"+
                          "<div class='iq-card-header d-flex justify-content-between'>" +
                                 "<div class='iq-header-title'>" +
                                    "<h4 class='card-title'>Other Details</h4>" +
                                 "</div>"+
                              "</div>"+
                          "<div class='iq-card-body'>"+                    
                            "<div class='row'>"+
                                "<div class='col-6'>"+
                                    "<ul class='list-inline m-0 p-0'>"+
                                           "<li>"+
                                       "<h6 class='float-left mb-1'>NI Number</h6>"+
                                       "<div class='d-inline-block w-100'>"+
                                          "<p class='badge badge-primary'>"+dr["NationalInsNo"]+"</p>"+
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
                                       "<h6 class='float-left mb-1'>DBS Type</h6>"+
                                       "<div class='d-inline-block w-100'>" +
                                          "<p class='badge badge-primary'>" + dr["DBSType"] + "</p>" +
                                       "</div> "+
                                     "</li> " +
                                       "</ul> " +
                                        "</div> " +
                                            "<div class='col-6'>" +
                                            "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>DBS Issue Date</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                           "<p class='badge badge-primary'>"+dr["DBSIssue"] + "</p>" +
                                        "</div>" +
                                     "</li>" +
                                       "</ul>" +
                                        "</div>" +
                                        "<div class='col-6'>" +
                                        "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>DBS Expiry Date</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                          " <p class='badge badge-primary'>" + dr["DBSExpiry"] + "</p>" +
                                        "</div>" +
                                     "</li>" +
                                      " </ul>" +
                                    "</div>" +
                                         "<div class='col-6'>" +
                                        "<ul class='list-inline m-0 p-0'>" +
                                            "<li>" +
                                        "<h6 class='float-left mb-1'>Uk Full Driving Licence</h6>" +
                                        "<div class='d-inline-block w-100'>" +
                                           "<p class='badge badge-primary'>"+dr["DrivingLic"]+"</p>" +
                                       " </div>" +
                                     "</li>" +
                                       "</ul>" +
                                    "</div>" +   
                                "</div>" +
                               "</div>" +
                            "</div>" +
                   "</div>";

                }
            }

            return data;



        }
    }
}