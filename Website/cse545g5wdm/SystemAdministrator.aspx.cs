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

public partial class cse545g5wdm_SystemAdministrator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE role_id = '1'", connect);
            command.Connection.Open();
            user_GridView.DataSource = command.ExecuteReader();
            user_GridView.DataBind();
            command.Connection.Close();
            command.Connection.Dispose();
        }
        catch (Exception)
        {
            //TODO
        }
       
    }
}
