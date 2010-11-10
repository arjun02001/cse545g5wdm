using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for CheckIn
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class CheckInService : System.Web.Services.WebService {

    public CheckInService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CheckInDocument(int docId, int userID) {
       DocListService ds = new DocListService();
       
       
            if (docId != 0)
            {
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
                SqlCommand doclist = new SqlCommand("group5.sp_DocumentCheckout", connect);
                doclist.CommandType = CommandType.StoredProcedure;
                doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userID;
                doclist.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docId;

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
           

        return "Document Checked in";
    
    }
    
}

