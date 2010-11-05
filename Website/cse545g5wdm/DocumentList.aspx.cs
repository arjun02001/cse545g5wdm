using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cse545g5wdm_DocumentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
        }
    }

    protected void CheckOut_Button_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/Login.aspx");
    }
}
