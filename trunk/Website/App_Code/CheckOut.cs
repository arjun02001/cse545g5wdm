using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for CheckOut
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CheckOut : System.Web.Services.WebService {

    public CheckOut () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string checkOut(String []docName, int userID) {

        DocListService ds = new DocListService();
        int []docId = new int[docName.Length];
        for (int i = 0; i < docName.Length; i++)
        {
            if (docName[i] != null)
            {
                docId[i] = ds.DocumentListData(userID, docName[i]);
            }
        }
        for (int i = 0; i < docId.Length; i++)
        {
            if (docId[i] != 0)
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
                SqlCommand doclist = new SqlCommand("group5.sp_DocumentCheckIn", connect);
                doclist.CommandType = CommandType.StoredProcedure;
                doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userID;
                doclist.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docId[i];

                try
                {
                    connect.Open();
                    doclist.ExecuteNonQuery();
                    connect.Close();

                }
                catch (SqlException)
                {
                    Server.Transfer("~/Error.aspx");
                }
            }
        }

        return "Document Checked Out";
    }
    
}

