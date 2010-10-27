using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlClient.SqlGen;
using System.Data.SqlTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for RegisterService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RegisterService : System.Web.Services.WebService {

    public RegisterService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool RegisterNewUser(string emailid, string password, string confirmpassword, string role, string department)
    {
        String request = "New User";
        bool safeMode = false;
        bool emailSyntaxValidation = true;
        bool sqlinjection = true;
        bool xssinjection = true;
        bool regexfiltered = false;

        string[] strFields = { emailid, password, confirmpassword, role, department };

        //sql and xss injection testing
        SQLInjectionDetectionService detectSQL = new SQLInjectionDetectionService();
        DetectXSSAttemptService detectXSS = new DetectXSSAttemptService();
        EmailSyntax emailcheck = new EmailSyntax();
        for (int i = 0; i < strFields.Length; i++)
        {
            sqlinjection = detectSQL.DetectSQL(strFields[i]);
            if (sqlinjection)
            {
                return safeMode;
            }
        }

        for (int i = 0; i < strFields.Length; i++)
        {
            xssinjection = detectXSS.IsXSSInjection(strFields[i]);

            if (xssinjection)
            {
                return safeMode;
            }
        }

        emailSyntaxValidation = emailcheck.VerifyEmail(emailid);

        if (emailSyntaxValidation.Equals(false))
        {
            return false;
        }

        bool passMatch = passwordMatch(password, confirmpassword);

        if (!passMatch)
        {
            return false;
        }

        //if pass all these, connect to sql server
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand command = new SqlCommand("group5.sp_AddNewUser", connect);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add("@par_username", System.Data.SqlDbType.NChar).Value = emailid;
        command.Parameters.Add("@par_password", System.Data.SqlDbType.NChar).Value = password;
        command.Parameters.Add("@par_request", System.Data.SqlDbType.NVarChar).Value = request;
        command.Parameters.Add("@par_department", System.Data.SqlDbType.Int).Value = 1;
        SqlDataAdapter adapter = new SqlDataAdapter(command);


        DataTable user = new DataTable();
        try
        {
            connect.Open();
            adapter.Fill(user);
            connect.Close();
            safeMode = true;
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine(e.StackTrace);
            return safeMode;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.StackTrace);
            return safeMode;
        }


        return safeMode;
    }

    bool passwordMatch(String password, String confirmpassword)
    {

        if (password.Length == confirmpassword.Length && password.Equals(confirmpassword))
        {
            return true;
        }
        return false;
    }
    
}

