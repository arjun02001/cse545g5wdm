using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for EmailSyntax
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EmailSyntax : System.Web.Services.WebService {


    [WebMethod]
         public Boolean VerifyEmail(String EmailId)
        {
            int count = 0;
            char[] chars = EmailId.ToCharArray();

            String strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                 @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
                 @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex re = new Regex(strRegex);
            


            int FirstAtIndex = EmailId.IndexOf('@');
            int LastIndex = EmailId.LastIndexOf('@');

            foreach (char c in chars)
            {
                if (c == '@')
                {
                    count++;
                }
            }

            if (EmailId.Length > 8)
            {
                if (EmailId.Contains("@") && count < 2 && FirstAtIndex == LastIndex
               
                     && EmailId.Contains(".") && re.IsMatch(EmailId))
                {      
                            return true;
                }       
                    
                    else
                    {
                        return false;
                    }
                }
            

            return false;
    }

}

