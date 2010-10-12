using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class SQLInjectionDetectionService : System.Web.Services.WebService {

    public SQLInjectionDetectionService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool DetectSQLInjectionByRegex(string input, Regex validator)
    {
        //default to find SQLInjection
        bool match = true;
        try
        {
            match = validator.IsMatch(input, 0);
            //only way to return false
            return match;
        }
        catch (ArgumentNullException)
        {
            //if error return true as safe mode to reject input
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            //if error return true as safe mode to reject input
            return true;
        }
    }
    
}

