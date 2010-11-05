using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DocumentListService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DocListService : System.Web.Services.WebService
{

    public DocListService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public DataSet DocumentListService(int userid)
    {
        String result = "Failure.";

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand doclist = new SqlCommand("group5.StoredProcedure3", connect);
        doclist.CommandType = CommandType.StoredProcedure;
        doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userid;

        DataSet ds = new DataSet();
        try
        {
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = doclist;
            da.Fill(ds);
            connect.Close();
            
            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to delete document.";
        }

        return ds;
    }

}

