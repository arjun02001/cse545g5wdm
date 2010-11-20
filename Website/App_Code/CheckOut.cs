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
    public string checkOut(String []docName, int userID, String []emailID) {

        DocListService ds = new DocListService();
        SqlConnection connect = SingletonObject.getInstance();
        SqlCommand userIDCommand = new SqlCommand("group5.sp_GetUserID", connect);
        userIDCommand.CommandType = CommandType.StoredProcedure;


        int []docId = new int[docName.Length];
        int[] userIDVal = new int[emailID.Length];

        for (int i = 0; i < docName.Length; i++)
        {
            if (docName[i] != null)
            {
                userIDCommand.Parameters.Add(new SqlParameter("@par_email", SqlDbType.NChar)).Value = emailID[i];

                DataTable dataTableUserId = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(userIDCommand);
                
                try
                {
                    connect.Open();
                    da.Fill(dataTableUserId);

                    if (dataTableUserId.Rows.Count == 1)
                    {
                        userIDVal[i] = (int)dataTableUserId.Rows[0]["user_id"];
                    }

                    connect.Close();
                }
                catch (SqlException)
                {
                    Server.Transfer("~/Login.aspx");
                }
                docId[i] = ds.DocumentListData(userIDVal[i], docName[i]);
            }
            else
            {
                break;
            }
        }
        int returnVal = 0;
        for (int i = 0; i < docId.Length; i++)
        {
            if (docId[i] != 0)
            {
                
                 SqlCommand doclist = new SqlCommand("group5.sp_DocumentCheckIn", connect);
                doclist.CommandType = CommandType.StoredProcedure;
                doclist.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userID;
                doclist.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docId[i];
                doclist.Parameters.Add(new SqlParameter("@return", SqlDbType.Int));
                doclist.Parameters["@return"].Direction = ParameterDirection.ReturnValue;
                try
                {
                    connect.Open();
                    doclist.ExecuteNonQuery();
                    returnVal = (int)doclist.Parameters["@return"].Value;
                    connect.Close();

                }
                catch (SqlException)
                {
                    Server.Transfer("~/Error.aspx");
                }
            }
            else {
                break;
                }
        }
        if (returnVal == 0)
        {
            return "Document already exists";
        }
        else
        {
            return "Document Checked Out";
        }
    }
    
}

