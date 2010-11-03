using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for DeleteDocumentService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DeleteDocumentService : System.Web.Services.WebService {

    public DeleteDocumentService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string DeleteDocument(int docid)
    {
        string result = "Failure.";

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand delete = new SqlCommand("group5.sp_DeleteDocumentByID", connect);
        delete.CommandType = CommandType.StoredProcedure;
        delete.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docid;

        try
        {
            connect.Open();
            delete.ExecuteNonQuery();
            connect.Close();
            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to delete document.";
        }

        return result;
    }

    [WebMethod]
    public string DeleteDocument(string title)
    {
        string result = "Failure.";

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand delete = new SqlCommand("group5.sp_DeleteDocumentByTitle", connect);
        delete.CommandType = CommandType.StoredProcedure;
        delete.Parameters.Add(new SqlParameter("@par_title", SqlDbType.NChar)).Value = title;

        try
        {
            connect.Open();
            delete.ExecuteNonQuery();
            connect.Close();
            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to delete document.";
        }

        return result;
    }
    
}

