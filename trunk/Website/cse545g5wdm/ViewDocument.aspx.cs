﻿using System;
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
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
        Response.Expires = -1500;
        Response.CacheControl = "no-cache";
    }
    protected void btn_View_Click(object sender, EventArgs e)
    {
        try
        {
            LogService logService = new LogService();
            ListItem selectedItem = ddl_ChooseDocument.SelectedItem;
            int itemvalue = Int32.Parse(selectedItem.Value);
            ViewDocumentService vds = new ViewDocumentService();
            vds = vds.GetFileService(itemvalue);
            byte[] data = vds.Data;
            string extension = vds.Extension.ToLower();
            string mime = string.Empty;
            if (extension.Equals("pdf"))
            {
                mime = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + vds.FileName + "");
            }
            if (extension.Equals("doc"))
            {
                mime = "application/ms-word";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + vds.FileName + "");
            }
            if (extension.Equals("txt"))
            {
                mime = "text/plain";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + vds.FileName + "");
            }
            if (extension.Equals("docx"))
            {
                mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + vds.FileName + "");
            }
            if (extension.Equals("rtf"))
            {
                mime = "application/rtf";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + vds.FileName + "");
            }
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = mime;
            Response.BinaryWrite(data);
            Response.Charset = "";
            Response.Flush();
            Response.Clear();
            Response.End();
            logService.LogAction(DateTime.Now.ToString() + ": User " + (string)Session["username"] + " has opened the document " + selectedItem.Text + ".\n");
        }
        catch (Exception ex)
        {
            //TODO
        }
    }
}
