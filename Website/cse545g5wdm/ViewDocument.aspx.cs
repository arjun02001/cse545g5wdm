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

        string extenstion = myReader["doc_type"].ToString().Substring(1).Trim();
        byte[] data = (byte[])myReader["doc"];

        string mime = string.Empty;
        if (extenstion.Equals("pdf"))
        {
            mime = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment;filename=wdm.pdf");
        }
        if (extenstion.Equals("doc"))
        {
            mime = "application/ms-word";
            Response.AddHeader("Content-Disposition", "attachment;filename=wdm.doc");
        }
        if (extenstion.Equals("txt"))
        {
            mime = "text/plain";
            Response.AddHeader("Content-Disposition", "attachment;filename=wdm.txt");
        }
        if (extenstion.Equals("docx"))
        {
            mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            Response.AddHeader("Content-Disposition", "attachment;filename=wdm.docx");
        }
        if (extenstion.Equals("rtf"))
        {
            mime = "application/rtf";
            Response.AddHeader("Content-Disposition", "attachment;filename=wdm.rtf");
        }
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = mime;
        
        

        Response.BinaryWrite(data);
        Response.Charset = "";
        Response.Flush();
        Response.Clear();
        Response.End();
        command.Connection.Close();
        command.Connection.Dispose();
    }
}
