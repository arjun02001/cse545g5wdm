using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for DetectXSSAttemptService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DetectXSSAttemptService : System.Web.Services.WebService {

    public DetectXSSAttemptService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool IsXSSInjection(string input)
    {
        input = input.ToLower();
        if (input.Contains("<applet") ||
            input.Contains("<body") ||
            input.Contains("<embed") ||
            input.Contains("<frame") ||
            input.Contains("<script") ||
            input.Contains("<frameset") ||
            input.Contains("<html") ||
            input.Contains("<iframe") ||
            input.Contains("<img") ||
            input.Contains("<style") ||
            input.Contains("<layer") ||
            input.Contains("<link") ||
            input.Contains("<ilayer") ||
            input.Contains("<meta") ||
            input.Contains("<object") ||
            input.Contains("<src") ||
            input.Contains("<lowsrc") ||
            input.Contains("<href"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [WebMethod]
    public StringBuilder EncodeInputHTML(string input)
    {
        StringBuilder output =  new StringBuilder( HttpUtility.HtmlEncode(input));
        return output;
    }

    [WebMethod]
    public StringBuilder EncodeURL(string input)
    {
        StringBuilder output = new StringBuilder(HttpUtility.UrlEncode(input));
        return output;
    }
    
}

