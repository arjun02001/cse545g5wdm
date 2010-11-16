using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

/// <summary>
/// Summary description for UpdateService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UpdateService : System.Web.Services.WebService {

    public UpdateService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string UpdateFileService(string FileName, FileUpload fileUpdateDoc, int userId, int docid)
    {
        Boolean fileOK = false;
        Boolean extensionOK = false;
        String path = Server.MapPath("Files");
        int returnvalue = 0;
        String result;
        String fileExtension =
                System.IO.Path.GetExtension(fileUpdateDoc.FileName).ToLower();

        ViewDocumentService vds = new ViewDocumentService();
        vds.GetFileService(docid);

        MemoryStream memoryStream = new MemoryStream(vds.Data);

        //if(vds.Extension == fileExtension && vds.)

        if (fileUpdateDoc.HasFile)
        {
            String[] allowedExtensions = { ".pdf", ".doc", ".txt", ".docx", ".rtf", ".ppt",".pptx",".jpg", ".bmp", ".png", ".jpeg", ".gif", ".tiff", ".xls", ".xlsx" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    extensionOK = true;
                    break;
                }
            }
        }

        HttpPostedFile uploadedFile = fileUpdateDoc.PostedFile;
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


        if (fileOK && extensionOK)
        {
            try
            {
                byte[] docData = new byte[fileLength];
                uploadedFile.InputStream.Read(docData, 0, fileLength);
                DocListService docService = new DocListService();
                int docId = docService.DocumentListData(userId, FileName);
                SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
               
                int roleid = 0;

                SqlCommand userRoleCommand = new SqlCommand("group5.sp_GetUserRole", connect);
                userRoleCommand.CommandType = CommandType.StoredProcedure;
                userRoleCommand.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userId;
                DataTable dataTable = new DataTable();

                SqlDataAdapter da = new SqlDataAdapter(userRoleCommand);
                    connect.Open();
                    da.Fill(dataTable);
                    if (dataTable.Rows.Count == 1)
                    {
                        roleid = (int)dataTable.Rows[0]["role_id"];
                    }

                    connect.Close();
               
             

                //update the file
                if (roleid != 0)
                {
                    SqlCommand updateCommand = new SqlCommand("group5.sp_UpdateDocument", connect);
                    updateCommand.CommandType = CommandType.StoredProcedure;
                    updateCommand.Parameters.Add(new SqlParameter("@par_userid", SqlDbType.Int)).Value = userId;
                    updateCommand.Parameters.Add(new SqlParameter("@par_docid", SqlDbType.Int)).Value = docid;
                    updateCommand.Parameters.Add(new SqlParameter("@par_doc", SqlDbType.VarBinary, fileLength)).Value = docData;
                    updateCommand.Parameters.Add(new SqlParameter("@par_doclength", SqlDbType.Int)).Value = fileLength;
                    updateCommand.Parameters.Add(new SqlParameter("@RETURNVALUE", SqlDbType.Int)).Value = returnvalue;
                    updateCommand.Parameters["@RETURNVALUE"].Direction = ParameterDirection.ReturnValue;

                    connect.Open();
                    updateCommand.ExecuteNonQuery();
                    returnvalue = (int)updateCommand.Parameters["@RETURNVALUE"].Value;
                    connect.Close();
                    connect.Dispose();
                    updateCommand.Dispose();
                }
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
            result = "Database error or bad arguments.";
        }
        return result;
        
    }
    
}

