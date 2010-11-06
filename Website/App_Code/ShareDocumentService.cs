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
/// Summary description for ShareDocumentService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class ShareDocumentService : System.Web.Services.WebService {

    public ShareDocumentService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string ShareDocument(string username_target, int userid_source, int docid, bool read, bool update, bool check)
    {
        //no XSS injection for you
        username_target = Server.HtmlEncode(username_target);

        try
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand isuserexist = new SqlCommand("group5.sp_IsUserExist", connect);
            isuserexist.CommandType = System.Data.CommandType.StoredProcedure;
            isuserexist.Parameters.Add(new SqlParameter("@par_username", SqlDbType.NChar)).Value = username_target;
            isuserexist.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int));
            isuserexist.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;

            connect.Open();
            SqlDataReader isuserexist_read = isuserexist.ExecuteReader();

            int userexist = (int)isuserexist.Parameters["@RETURN_VALUE"].Value;
            isuserexist_read.Close();
            isuserexist_read.Dispose();
            isuserexist.Dispose();

            if (userexist <= 0)
            {
                return "User does not exist.";
            }

            SqlCommand userid = new SqlCommand("group5.sp_GetUserID", connect);
            userid.CommandType = CommandType.StoredProcedure;
            userid.Parameters.Add(new SqlParameter("@par_email", SqlDbType.NChar)).Value = username_target;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(userid);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            int userid_target = (int)dataTable.Rows[0]["user_id"];
            dataAdapter.Dispose();
            userid.Dispose();

            if (userid_target <= 0)
            {
                return "Could not find user.";
            }

            SqlCommand sharedocument = new SqlCommand("group5.sp_ShareDocument", connect);
            sharedocument.CommandType = CommandType.StoredProcedure;
            sharedocument.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docid;
            sharedocument.Parameters.Add(new SqlParameter("@par_user_originid", SqlDbType.Int)).Value = userid_source;
            sharedocument.Parameters.Add(new SqlParameter("@par_user_targetid", SqlDbType.Int)).Value = userid_target;
            sharedocument.Parameters.Add(new SqlParameter("@par_read", SqlDbType.Bit)).Value = read;
            sharedocument.Parameters.Add(new SqlParameter("@par_update", SqlDbType.Bit)).Value = update;
            sharedocument.Parameters.Add(new SqlParameter("@par_check", SqlDbType.Bit)).Value = check;
            sharedocument.ExecuteNonQuery();
            connect.Close();



        }
        catch (ConfigurationErrorsException)
        {
            return "Server connection error.";
        }
        catch (InvalidCastException)
        {
            return "Not a proper datatype.";
        }
        catch (ArgumentNullException)
        {
            return "Empty argument found.";
        }
        catch (SqlException)
        {
            return "Database connection error.";
        }
        catch (InvalidOperationException)
        {
            return "Invalid operation discovered.";
        }
        catch (ArgumentException)
        {
            return "Argument failure.";
        }

        return "Success.";
    }
    
}

