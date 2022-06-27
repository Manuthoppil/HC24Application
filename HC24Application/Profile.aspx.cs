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
           
           // int id = Convert.ToInt32(Request["value"]);
            Image1.ImageUrl = "~/ImageHandler.ashx?id=" + 1;
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
                    data += "<div class='text-center mt-3 pl-3 pr-3'><h4><b> "+Name+"</b></h4><p>"+dr["Position"] +"</p></div><hr><div class='iq-card-body'><div class='about-info m-0 p-0'><div class='row'>"+
                                  "<div class='col-4'>Email:</div>"+
                                  "<div class='col-8'>"+dr["EmailAddress"]+"</div>" +
                                  "<div class='col-4'>Mobile Number:</div>"+
                                  "<div class='col-8'>"+dr["PhoneNumber"] +"</div>" +
                                  "<div class='col-4'>Nationality</div>"+
                                  "<div class='col-8'>"+dr["Nationality"] +"</div>" +
                                  "<div class='col-4'>Date of Birth</div>"+
                                  "<div class='col-8'>"+dr["DateOfBirth"] +"</div>" +
                                  "<div class='col-4'>Gender</div>"+
                                   "<div class='col-8''>"+dr["Gender"] +"</div>" +
                              "</div>"+
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
                    data += "<div class='iq-card'>"+
                           "<div class='iq-card-header d-flex justify-content-between'>"+
                                 "<div class='iq-header-title'>"+
                                    "<h4 class='card-title'>Personal Information</h4>"+
                                 "</div>"+
                              "</div>"+
                        "<div class='iq-card-header d-flex justify-content-between'>"+
                           "<div class='iq-header-title'>" +
                               "<div class='iq-card-body'>"+
                                 "<ul class='speciality-list m-0 p-0'>"+
                                    "<li class='d-flex mb-4 align-items-center'>"+
                                       "<div class='user-img img-fluid'><a href = '#' class='iq-bg-primary'><i class='ri-award-fill'></i></a></div>" +
                                       "<div class='media-support-info ml-3'>" +
                                          "<h6>Address</h6>" +
                                          "<p class='mb-0'>"+dr["Address"]+","+dr["Street"] +"</p>"+
                                           "<p class='mb-0'>" + dr["PostCode"] + "</p>" +
                                           "<p class='mb-0'>" + dr["County"] + "</p>" +
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
    }
}