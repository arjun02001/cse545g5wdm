using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cse545g5wdm_ShareDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        if(Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
        }
        if (Roles.IsUserInRole("SystemAdministrator"))
        {
            Server.Transfer("~/cse545g5wdm/SystemAdministrator.aspx");
        }
        if (Roles.IsUserInRole("Guest"))
        {
            Server.Transfer("~/cse545g5wdm/DocumentList.aspx");
        }
    }
    protected void btn_Share_Click(object sender, EventArgs e)
    {
        Validate();
        lbl_Success.Visible = false;
        ShareDocumentService shareDocument = new ShareDocumentService();
        //no point if no access given
        if (cb_Read.Checked || cb_Update.Checked || cb_Check.Checked)
        {
            LogService logAction = new LogService();
            try
            {
                string result = shareDocument.ShareDocument(txt_Username.Text.Trim(), (int)Session["userid"],
                    Int32.Parse(ddl_AuthoredDocuments.SelectedValue), cb_Read.Checked,
                    cb_Update.Checked, cb_Check.Checked);

                if (result == "Success.")
                {
                    logAction.LogAction("User " + (string)Session["username"] + " shared a document with " + txt_Username.Text.Trim() + ".");
                    lbl_Error.Visible = false;
                    lbl_Success.Visible = true;
                }
                else
                {
                    logAction.LogAction("User " + (string)Session["username"] + " tried to share a document, but failed in the database for reason: " + result);
                    lbl_Error.Visible = true;
                    lbl_Error.Text = result;
                }

            }
            catch (ArgumentNullException)
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "No document selected.";
            }
            catch (FormatException)
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "No document selected.";
            }
            catch (OverflowException)
            {
                lbl_Error.Visible = true;
                lbl_Error.Text = "No documet selected.";
            }
        }
    }
}
