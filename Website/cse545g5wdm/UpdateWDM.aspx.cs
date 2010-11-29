using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
        try
        {
            if (Roles.IsUserInRole("Temp"))
            {
                Server.Transfer("~/Login.aspx");
            }
            if(Roles.IsUserInRole("SystemAdministrator"))
            {
                Server.Transfer("~/cse545g5wdm/SystemAdministrator.aspx");
            }
        }
        catch(HttpException)
        {
            Server.Transfer("~/Error.aspx");
        }
    }

    protected void Update_Button_Click(object sender, EventArgs e)
    {
        LogService logAction = new LogService();
        String fileName = ddl_ChooseDocument.SelectedItem.Text;
        FileUpload filePath = FileUploadPath;
        UpdateService updateServiceObj = new UpdateService();
        try
        {
            int filenumber = Int32.Parse(ddl_ChooseDocument.SelectedValue);
            String returnVal = updateServiceObj.UpdateFileService(fileName, filePath, (int)Session["userid"], filenumber);
            if (returnVal == "Success.")
            {
                lbl_Success.Visible = true;
                lbl_Error.Visible = false;
                logAction.LogAction("User " + (string)Session["username"] + " successfully updated a file.");
            }
            else
            {
                lbl_Success.Visible = false;
                lbl_Error.Visible = true;
                lbl_Error.Text = "Database error.";
                logAction.LogAction("User " + (string)Session["username"] + " failed to update a file due to " + returnVal + ".");
            }
        }
        catch (ArgumentNullException)
        {
            lbl_Success.Visible = false;
            lbl_Error.Visible = true;
            lbl_Error.Text = "No document found.";
        }
        catch (FormatException)
        {
            lbl_Success.Visible = false;
            lbl_Error.Visible = true;
            lbl_Error.Text = "Not an integer based document.";
        }
        catch (OverflowException)
        {
            lbl_Success.Visible = false;
            lbl_Error.Visible = true;
            lbl_Error.Text = "Cannot convert document value, too large.";
        }
        catch (HttpException)
        {
            //no userid means no login, get this guy out of here
            Server.Transfer("~/Login.aspx");
        }
    }
}
