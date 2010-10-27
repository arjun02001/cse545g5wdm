using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlClient.SqlGen;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for LoginService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LoginService : System.Web.Services.WebService {

    public LoginService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public UserTransferObject Login(Regex RegexPassword, string username, string password )
    {
        UserTransferObject safeMode = new UserTransferObject();
        bool sqlinjection = true;
        bool xssinjection = true;
        bool regexfiltered = false;
        
        //sql and xss injection testing
        SQLInjectionDetectionService detectSQL = new SQLInjectionDetectionService();
        DetectXSSAttemptService detectXSS = new DetectXSSAttemptService();
        EmailSyntax emailcheck = new EmailSyntax();
        sqlinjection = detectSQL.DetectSQL(username);
        if (sqlinjection)
        {
            return safeMode;
        }

        xssinjection = detectXSS.IsXSSInjection(username);
        if (xssinjection)
        {
            return safeMode;
        }

        sqlinjection = detectSQL.DetectSQL(password);
        if (sqlinjection)
        {
            return safeMode;
        }

        xssinjection = detectXSS.IsXSSInjection(password);
        if(xssinjection)
        {
            return safeMode;
        }

        regexfiltered = emailcheck.VerifyEmail(username);
        if (!regexfiltered)
        {
            return safeMode;
        }
        

        regexfiltered = followsRegex(RegexPassword, password);
        if (!regexfiltered)
        {
            return safeMode;
        }

        //if pass all these, connect to sql server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand command = new SqlCommand("sp_AuthenticateUser", connect);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add("@par_username", System.Data.SqlDbType.NChar).Value = username;
        command.Parameters.Add("@par_password", System.Data.SqlDbType.NChar).Value = password;
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataTable user = new DataTable();
        try
        {
            connect.Open();
            adapter.Fill(user);
            connect.Close();
        }
        catch (InvalidOperationException)
        {
            return safeMode;
        }
        catch (SqlException)
        {
            return safeMode;
        }

        //check that the datatable has rows
        if ((user.Rows.Count == 1) && (user.Columns.Count == 3))
        {
            //now fill the UserTransferObject
            UserTransferObject returnedValue = new UserTransferObject();
            returnedValue.userid = (int)user.Rows[0]["user_id"];
            returnedValue.username = (string)user.Rows[0]["password"];
            returnedValue.role = (int)user.Rows[0]["role_id"];

            return returnedValue;
        }
        


        return safeMode;
    }

    public bool followsRegex(Regex filter, string input)
    {
        bool matches = false;
        try
        {
            matches = filter.IsMatch(input);
        }
        catch (ArgumentNullException)
        {
            return false;
        }
        return matches;
    }
    
}

