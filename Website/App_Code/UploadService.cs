﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
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
public class UploadService : System.Web.Services.WebService
{

    public UploadService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string UploadFileService(String documentName, FileUpload fileUploadDoc, int userid)
    {
        int returnvalue=0;
        Boolean fileOK = false;
        Boolean extensionOK = false;
        String path = Server.MapPath("Files");

        String result;
        String fileExtension =
                System.IO.Path.GetExtension(fileUploadDoc.FileName).ToLower();
        if (fileUploadDoc.HasFile)
        {
            String[] allowedExtensions = { ".pdf", ".doc", ".txt", ".docx", ".rtf", ".ppt", ".pptx", ".jpg", ".bmp", ".png", ".jpeg", ".gif", ".tiff", ".xls", ".xlsx" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    extensionOK = true;
                    break;
                }
            }
        }

        HttpPostedFile uploadedFile = fileUploadDoc.PostedFile;
        int fileLength = uploadedFile.ContentLength;

        if (fileLength < 1)
        {
            result = "No file found.";
            return result;
        }

        //check for msword
        if (uploadedFile.ContentType == "application/msword")
        {
            fileOK = true;
        }
        //check for msword 2007+
        if (uploadedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
        {
            fileOK = true;
        }
        //check for pdf
        if (uploadedFile.ContentType == "application/pdf")
        {
            fileOK = true;
        }
        //check for plain text
        if (uploadedFile.ContentType == "text/plain")
        {
            fileOK = true;
        }
        //check for rich text
        if (uploadedFile.ContentType == "application/rtf")
        {
            fileOK = true;
        }
        //check for rich text
        if (uploadedFile.ContentType == "image/jpeg")
        {
            fileOK = true;
        }
        //check for rich text
        if (uploadedFile.ContentType == "image/bmp")
        {
            fileOK = true;
        }

        //check for rich text
        if (uploadedFile.ContentType == "image/png")
        {
            fileOK = true;
        }

        //check for rich text
        if (uploadedFile.ContentType == "image/tiff")
        {
            fileOK = true;
        }

        //check for rich text
        if (uploadedFile.ContentType == "image/gif")
        {
            fileOK = true;
        }

        //check for rich text
        if (uploadedFile.ContentType == "application/vnd.ms-excel")
        {
            fileOK = true;
        }
        //check for rich text
        if (uploadedFile.ContentType == "application/vnd.ms-powerpoint")
        {
            fileOK = true;
        }

        //check for mspowerpoint 2007+
        if (uploadedFile.ContentType == "application/vnd.openxmlformats-officedocument.presentationml.presentation")
        {
            fileOK = true;
        }

        //check for msexcel 2007+
        if (uploadedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            fileOK = true;
        }



        if (fileOK && extensionOK)
        {
            try
            {
                byte[] docData = new byte[fileLength];
                uploadedFile.InputStream.Read(docData, 0, fileLength);

                //upload the file
                SqlConnection connect = SingletonObject.getInstance();
                SqlCommand uploadCommand = new SqlCommand("group5.sp_AddNewDocument", connect);
                uploadCommand.CommandType = CommandType.StoredProcedure;
                uploadCommand.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userid;
                uploadCommand.Parameters.Add(new SqlParameter("@par_title", SqlDbType.NChar)).Value = documentName + fileExtension;
                uploadCommand.Parameters.Add(new SqlParameter("@par_doc_type", SqlDbType.NChar)).Value = fileExtension;
                uploadCommand.Parameters.Add(new SqlParameter("@par_doc", SqlDbType.VarBinary, fileLength)).Value = docData;
                uploadCommand.Parameters.Add(new SqlParameter("@RETURNVALUE", SqlDbType.Int)).Value = returnvalue;
                uploadCommand.Parameters["@RETURNVALUE"].Direction = ParameterDirection.ReturnValue;

                connect.Open();
                uploadCommand.ExecuteNonQuery();
                returnvalue = (int)uploadCommand.Parameters["@RETURNVALUE"].Value;
                connect.Close();
                connect.Dispose();
                uploadCommand.Dispose();
            }
            catch (ArgumentNullException)
            {
                result = "No file found.";
            }
            catch (ArgumentOutOfRangeException)
            {
                result = "Argument out of range.";
            }
            catch (IOException)
            {
                result = "IO operation not possible.";
            }
            catch (NotSupportedException)
            {
                result = "Operation not supported";
            }
            catch (ObjectDisposedException)
            {
                result = "File already disposed of";
            }
            catch (SqlException)
            {
                result = "Internal server error.";
            }
        }
        else
        {
            result = "Cannot accept files of this type.";
        }
        DataTable s = new DataTable();
        if (returnvalue == 1)
        {
            result = "Success.";
        }
        else
        {
            result = "Failed to add document due to duplicate name or database error.";
        }

        return result;
    }

}

