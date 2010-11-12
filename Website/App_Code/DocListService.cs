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
        
        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            connect.Open();
            
            da.SelectCommand = doclist;
            da.Fill(ds);
            connect.Close();
            
            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to delete document.";
        }
        if (da != null)
        {
            
        }

        return ds;
    }

    [WebMethod]
    public DataSet DocumentListShareOnService(int userid)
    {
        String result = "Failure.";

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand doclist = new SqlCommand("group5.StoredProcedure1", connect);
        doclist.CommandType = CommandType.StoredProcedure;
        doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userid;

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            connect.Open();

            da.SelectCommand = doclist;
            da.Fill(ds);
            connect.Close();

            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to delete document.";
        }
        if (da != null)
        {

        }

        return ds;
    }

    [WebMethod]
    public int DocumentListData(int userid,string doc_title)
    {

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand doclist = new SqlCommand("group5.StoredProcedure2", connect);
        doclist.CommandType = CommandType.StoredProcedure;
        doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userid;
        doclist.Parameters.Add(new SqlParameter("@par_doc_title", SqlDbType.NChar)).Value = doc_title;

        DataTable dataTableDocument = new DataTable();

        SqlDataAdapter da = new SqlDataAdapter(doclist);
        int docId = 0;
        try
        {
            connect.Open();
            da.Fill(dataTableDocument);
            
            if (dataTableDocument.Rows.Count == 1)
            {
                docId = (int)dataTableDocument.Rows[0]["doc_id"];
            }

            connect.Close();
        }
        catch (SqlException)
        {
            Server.Transfer("~/Login.aspx");
        }
       
        
        return docId;
    }

    [WebMethod]
    public DataSet CheckedDocumentListData()
    {
        String result = "Failure.";

        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand doclist = new SqlCommand("group5.StoredProcedure6", connect);
        doclist.CommandType = CommandType.StoredProcedure;

        DataSet ds = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter();
        try
        {
            connect.Open();

            da.SelectCommand = doclist;
            da.Fill(ds);
            connect.Close();

            result = "Success.";
        }
        catch (SqlException)
        {
            result = "Failed to load checked document.";
        }
        if (da != null)
        {

        }

        return ds;
    }

}

