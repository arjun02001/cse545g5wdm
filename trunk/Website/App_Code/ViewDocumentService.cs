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
            string query = "SELECT * FROM Document WHERE doc_id = " + itemvalue + "";
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command.Connection.Open();
            SqlDataReader myReader = command.ExecuteReader();
            myReader.Read();
            vds.Data = (byte[])myReader["doc"];
            vds.Extension = myReader["doc_type"].ToString().Substring(1).Trim();
            command.Connection.Close();
            command.Connection.Dispose();
            return vds;
        }
        catch (Exception ex)
        {
            //TODO
            throw;
        }
        
    }
    
}

