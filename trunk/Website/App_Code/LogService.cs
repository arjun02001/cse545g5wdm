using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Configuration;
using System.Web.Services.Discovery;
using System.Web.Services.Protocols;

/// <summary>
/// Summary description for LogService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LogService : System.Web.Services.WebService {

    public LogService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [SoapDocumentMethod(OneWay = true)]
    public bool LogAction(string action)
    {
        try
        {
            SqlConnection connect = SingletonObject.getInstance();
            SqlCommand command = new SqlCommand("group5.sp_AddLog", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@par_text", SqlDbType.NChar)).Value = action;

            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            command.Dispose();
        }
        catch (SqlException)
        {
            return false;
        }
        catch (ConfigurationErrorsException)
        {
            return false;
        }
        catch(InvalidOperationException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
        
        
        
        

        return true;
    }
    
}

