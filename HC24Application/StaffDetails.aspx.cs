using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DAL;
using BLL;
using Appprop;

namespace HC24Application
{
    public partial class StaffDetails : System.Web.UI.Page
    {

        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetDetails() {

         
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
                        data += "<tr><td>" + dr["ApplicationNo"] + "</td><td>" + Name + "</td><td>" + dr["Position"] + "</td><td>" + dr["Phn"] + "</td><td>" + dr["EmailAdd"] + "</td><td>" + dr["Nationality"] + "</td><td>" + dr["Country"] + "</td><td>" + dr["Address"] + "</td><td>" + dr["Postal"] + "</td></tr>";

                    }
                }

                return data;
           
        }
    }
}