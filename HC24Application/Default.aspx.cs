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
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ToString());
        string str, UserName, Password;
        SqlCommand cmd;
        SqlDataAdapter sqlda;
        DataTable dt;
        int RowCount;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Login_Click(object sender, EventArgs e)
        {

            con.Open();
            str = "Select UserName,Password from tbl_Registration";
            cmd = new SqlCommand(str);
            sqlda = new SqlDataAdapter(cmd.CommandText, con);
            dt = new DataTable();
            sqlda.Fill(dt);
            RowCount = dt.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {

                UserName = dt.Rows[i]["UserName"].ToString();
                Password = dt.Rows[i]["Password"].ToString();
                if (UserName == InputEmail.Text && Password == InputPassword.Text)
                {

                    Response.Redirect("~/AddStaff.aspx");

                }
                else
                {

                }
            }
        }
    }
}