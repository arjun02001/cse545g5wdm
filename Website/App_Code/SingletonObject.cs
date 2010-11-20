using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for SingletonObject
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SingletonObject : System.Web.Services.WebService {

    private SingletonObject () {
    }

    [WebMethod]
    public static SqlConnection getInstance()
    {
  
        SqlConnection connect = null;
        if (connect == null)
        {
            connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            
        }
        return connect;
    }
    
}

