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

public partial class cse545g5wdm_ViewDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_View_Click(object sender, EventArgs e)
    {
        ListItem selectedItem = ddl_ChooseDocument.SelectedItem;
        int itemvalue = Int32.Parse(selectedItem.Value);
        string query = "SELECT * FROM Document WHERE doc_id = " + itemvalue + "";
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
        SqlCommand command = new SqlCommand(query, connect);
        command.Connection.Open();
        SqlDataReader myReader = command.ExecuteReader();
        myReader.Read();
        Response.ContentType = "application/pdf";
        byte[] data = (byte[])myReader["doc"];
        Response.BinaryWrite(data);
        Response.Flush();
        command.Connection.Close();
        command.Connection.Dispose();
    }
}
