using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cse545g5wdm_DeleteDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
        }
        if(Roles.IsUserInRole("Guest"))
        {
            Server.Transfer("~/cse545g5wdm/DocumentList.aspx");
        }
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        LogService logAction = new LogService();
        string result = "Failure.";
        if (cb_Confirm.Checked)
        {
            DeleteDocumentService deleteDocument = new DeleteDocumentService();
            result = deleteDocument.DeleteDocument(ddl_ChooseDocument.SelectedValue);

        }

        //handle failure
        if (result == "Failure.")
        {
            lbl_Error.Visible = true;
            lbl_Error.Text = "Could not delete document.";
        }
        //update documents
        if (result == "Success.")
        {
            logAction.LogAction(DateTime.Now.ToString() + ": User has deleted the document " + ddl_ChooseDocument.SelectedValue + ".\n");
            lbl_Error.Visible = false;
            ddl_ChooseDocument.DataBind();
        }
        else
        {
            logAction.LogAction(DateTime.Now.ToString() + ": User attempted to delete the documnt " + ddl_ChooseDocument.SelectedValue + " but an error prevented that.\n");
            lbl_Error.Text = "Selection is not confirmed.";
            lbl_Error.Visible = true;
        }
    }
}
