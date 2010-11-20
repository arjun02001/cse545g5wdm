using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlClient.SqlGen;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for ViewDocumentService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ViewDocumentService : System.Web.Services.WebService {

    private byte[] data;

    public byte[] Data
    {
        get { return data; }
        set { data = value; }
    }
    private string extension;

    public string Extension
    {
        get { return extension; }
        set { extension = value; }
    }

    private string fileName;

    public string FileName
    {
        get { return fileName; }
        set { fileName = value; }
    }
    public ViewDocumentService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ViewDocumentService GetFileService(int itemvalue) 
    {
        try
        {
            ViewDocumentService vds = new ViewDocumentService();
            SqlConnection connect = SingletonObject.getInstance();
            SqlCommand command = new SqlCommand("group5.sp_GetDocumentData", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@doc_id", System.Data.SqlDbType.Int)).Value = itemvalue;
            DataTable dt = new DataTable();
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = command;
            da.Fill(dt);
            connect.Close();
            vds.Data = (byte[])dt.Rows[0]["doc"];
            vds.Extension = dt.Rows[0]["doc_type"].ToString().Substring(1).Trim();
            vds.FileName = dt.Rows[0]["doc_title"].ToString().Trim();
            return vds;
        }
        catch (Exception ex)
        {
            //TODO
            throw;
        }
        
    }
    
}

