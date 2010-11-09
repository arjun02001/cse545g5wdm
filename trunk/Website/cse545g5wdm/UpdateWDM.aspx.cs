using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateWDM : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        //check for if user should not be here
      /*  if (Roles.IsUserInRole("Guest"))
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
        }*/
    }
    protected void Update_Button_Click(object sender, EventArgs e)
    {
        LogService logAction = new LogService();
        String fileName = ddl_ChooseDocument.Text;
        FileUpload filePath = FileUploadPath;
        UpdateService updateServiceObj = new UpdateService();
        try
        {
            String returnVal = updateServiceObj.UpdateFileService(fileName, filePath, (int)Session["userid"]);
            if (returnVal == "Success.")
            {
                logAction.LogAction("User " + (string)Session["username"] + " successfully updated a file.");
            }
            else
            {
                logAction.LogAction("User " + (string)Session["username"] + " failed to update a file due to " + returnVal + ".");
            }
        }
        catch (HttpException)
        {
            //no userid means no login, get this guy out of here
            Server.Transfer("~/Login.aspx");
        }
    }
}
