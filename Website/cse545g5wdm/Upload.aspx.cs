using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check for if user should not be here
        if (Roles.IsUserInRole("Guest"))
        {
            Server.Transfer("~/DocumentList.aspx");
        }
        if (Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
        }
        if(Roles.IsUserInRole("SystemAdministrator"))
        {
            Server.Transfer("~/cse545g5wdm/SystemAdministrator.aspx");
        }
    }
    protected void Upload_Button_Click(object sender, EventArgs e)
    {
        LogService logAction = new LogService();
        String fileName = txt_fileName.Text;
        FileUpload filePath = FileUploadPath;
        UploadService uploadServiceObj = new UploadService();
        try
        {
            String returnVal = uploadServiceObj.UploadFileService(fileName, filePath, (int)Session["userid"]);
            if (returnVal == "Success.")
            {
                logAction.LogAction("User " + (string)Session["username"] + " successfully uploaded a file.");
            }
            else
            {
                logAction.LogAction("User " + (string)Session["username"] + " failed to upload a file due to " + returnVal + ".");
            }
        }
        catch (HttpException)
        {
            //no userid means no login, get this guy out of here
            Server.Transfer("~/Login.aspx");
        }
    }
}
