using System;
using System.Collections.Generic;
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
        string filepath = "log.txt";
        try
        {
            //creates a file if it does not exist
            File.AppendAllText(filepath, action, new UTF8Encoding());
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
        catch (ArgumentNullException)
        {
            return false;
        }
        catch (PathTooLongException)
        {
            return false;
        }
        catch (DirectoryNotFoundException)
        {
            return false;
        }
        catch (NotSupportedException)
        {
            return false;
        }
        catch (FileNotFoundException)
        {
            return false;
        }
        catch (System.Security.SecurityException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
        catch (IOException)
        {
            return false;
        }
        
        
        
        

        return true;
    }
    
}

