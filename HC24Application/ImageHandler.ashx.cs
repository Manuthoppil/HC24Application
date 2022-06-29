using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace HC24Application
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    public class ImageHandler : IHttpHandler
    {
        Profile cls = new Profile();
        public void ProcessRequest(HttpContext context)
        {
            string displayimgid = context.Request.QueryString["id"].ToString();
            cls.connection();
            //retriving the images on the basis of id of uploaded 
            //images,by using the querysting valaues which comes from Defaut.aspx page
            cls.query = "Select Image from [tbl_Image] where MatchingCode="+displayimgid;
            SqlCommand com = new SqlCommand(cls.query, cls.con);
            //com.Parameters.AddWithValue("@Matching", SqlDbType.Int).Value = displayimgid;
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}