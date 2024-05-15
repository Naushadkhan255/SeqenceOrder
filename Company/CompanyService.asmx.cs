using Company.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Company
{
    /// <summary>
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CompanyService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetCompanyDetail()
        {
           
            string cs = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            List<CompanyDetails> companyDetails = new List<CompanyDetails>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;


                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    CompanyDetails Details = new CompanyDetails();
                    Details.Id = Convert.ToInt32(sdr["Id"]);
                    Details.CompanyId = Convert.ToInt32(sdr["CompanyId"]);
                    Details.Number = Convert.ToInt32(sdr["Number"]);
                    //Details.InsDT = Convert.ToDateTime(sdr["InsDT"]);
                    //Details.InsDT = sdr["InsDT"] is DBNull ? (DateTime?)null : Convert.ToDateTime(sdr["InsDT"]);
                    //Details.InsDT = sdr["InsDT"] != DBNull.Value ? Convert.ToDateTime(sdr["InsDT"]) : DateTime.MinValue;                   
                    if (Convert.IsDBNull(sdr["InsDT"]))
                    {
                        Details.InsDT = null;
                    }

                    else
                    {
                        Details.InsDT = Convert.ToDateTime(sdr["InsDT"]);
                    }



                    companyDetails.Add(Details);


                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(companyDetails));
           

        }
    }
}
