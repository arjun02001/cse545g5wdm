using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for UploadService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UploadService : System.Web.Services.WebService {

    public UploadService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string UploadFileService(String documentName, FileUpload fileUploadDoc)
    {

        Boolean fileOK = false;
        String path = Server.MapPath("");

        String result;

        if (fileUploadDoc.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(fileUploadDoc.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg",".pdf",".doc",".txt",".docx" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }

        if (fileOK)
        {
            try
            {
                fileUploadDoc.PostedFile.SaveAs(path
                    + fileUploadDoc.FileName);
                result = "File uploaded!";
            }
            catch (Exception ex)
            {
                result = "File could not be uploaded.";
            }
        }
        else
        {
            result = "Cannot accept files of this type.";
        }


        return result;
    }
    
}

