using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class cse545g5wdm_DocumentList : System.Web.UI.Page
{
    private int userid;

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";

        if (Roles.IsUserInRole("Temp"))
        {
            Server.Transfer("~/Login.aspx");
            return;
        }

        /*DocListService doclistService = new DocListService();
        if (Session["userid"] != null)
        {
            userid = (int)Session["userid"];

            //userid = 41;
            Console.WriteLine(userid);
            DataSet ds = doclistService.DocumentListService(userid);

            GridView2.DataSource = ds;
            GridView2.DataBind();
            GridView2.Visible = true;
            GridView2.EmptyDataText = "No record found in database";
        }
        else
        {
            Server.Transfer("~/Login.aspx");
        }*/

    }

    protected void CheckOut_Button_Click(object sender, EventArgs e)
    {
        //Server.Transfer("~/Login.aspx");
        HttpContext.Current.Response.Write("<script>alert('" + userid + "');history.back()</script>");
        HttpContext.Current.Response.End(); 
    }
}
