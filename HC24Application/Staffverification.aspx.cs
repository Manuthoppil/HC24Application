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
    public partial class Staffverification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datagrid();
        }
        public void datagrid() {

            StaffBLL staf = new StaffBLL();
            DataTable dt;
            dt = staf.Staff_Details();
            if (dt.Rows.Count > 0) {

                grdEmp.DataSource = dt;
                grdEmp.DataBind();


            }
        
        
        }

        protected void verify_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            int id = Convert.ToInt32(grdEmp.DataKeys[rowIndex].Values[0]);
            Response.Redirect("Profile.aspx?value=" + 9);
        }
    }
}