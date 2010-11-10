using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_CheckIn_Click(object sender, EventArgs e)
    {
        if (ddl_ChooseDocument.SelectedItem != null)
        {
            LogService logAction = new LogService();
            string result = "Failure.";
            if (cb_Confirm.Checked)
            {
                CheckInService checkInObj = new CheckInService();
                ListItem selectedItem = ddl_ChooseDocument.SelectedItem;
                int itemvalue = Int32.Parse(selectedItem.Value);

                if (Session["userid"] != null)
                {
                    int userId = (int)Session["userid"];
                    result = checkInObj.CheckInDocument(itemvalue, userId);
                }
                else
                {
                    Server.Transfer("~/Login.aspx");
                }

            }

            //handle failure
            if (result == "Failure.")
            {
            //    lbl_Error.Visible = true;
              //  lbl_Error.Text = "Could not checkIn document.";
            }
            //update documents
            if (result == "Success.")
            {
                logAction.LogAction("User attempted to CheckIn the document " + ddl_ChooseDocument.SelectedValue + ".");
                //lbl_Error.Visible = false;
                ddl_ChooseDocument.DataBind();
            }
            else
            {
                logAction.LogAction("User attempted to CheckIn the document " + ddl_ChooseDocument.SelectedValue + " but an error prevented that.");
                //lbl_Error.Text = "Selection is not confirmed.";
                //lbl_Error.Visible = true;
            }
        }
        else
        {
           // lbl_Error.Visible = true;
           // lbl_Error.Text = "No document selected.";
        }
    }
}
