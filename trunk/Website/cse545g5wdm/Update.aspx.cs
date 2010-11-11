using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cse545g5wdm_Update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
        //check for if user should not be here
        /*if (Roles.IsUserInRole("Guest"))
        {
            Server.Transfer("~/DocumentList.aspx");
        }
        if (Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
        }
        if (Roles.IsUserInRole("SystemAdministrator"))
        {
            Server.Transfer("~/cse545g5wdm/SystemAdministrator.aspx");
        }*/

    }
}
