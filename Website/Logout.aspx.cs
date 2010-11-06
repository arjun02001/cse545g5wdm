using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlClient.SqlGen;
using System.Data.SqlTypes;
using System.Configuration;
using System.Web.Security;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand command = new SqlCommand("group5.sp_UserLogout", connect);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@par_userid", System.Data.SqlDbType.Int)).Value = (int)Session["userid"];
        connect.Open();
        command.ExecuteNonQuery();
        connect.Close();
        connect.Dispose();
        LogService logService = new LogService();
        logService.LogAction("User " + (string)Session["username"] + " has logged out.");
        FormsAuthentication.SignOut();
        Roles.DeleteCookie();
        Session.Clear();
        Server.Transfer("Login.aspx");
        
    }
}
