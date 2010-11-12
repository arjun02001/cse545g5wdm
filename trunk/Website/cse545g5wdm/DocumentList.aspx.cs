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
using System.Collections;

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

        if (!this.IsPostBack)
        {
            DocListService doclistService = new DocListService();
            if (Session["userid"] != null)
            {
                userid = (int)Session["userid"];

                //userid = 41;
                Console.WriteLine(userid);
                DataSet ds = doclistService.DocumentListService(userid);

                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
                GridView1.EmptyDataText = "No record found in database";

                Check_ShareOptions(ds);
                Hide_Checked();
            }
            else
            {
                Server.Transfer("~/Login.aspx");
            }
        }

    }

    protected void CheckOut_Button_Click(object sender, EventArgs e)
    {
        //Server.Transfer("~/Login.aspx");
        //HttpContext.Current.Response.Write("<script>alert('" + userid + "');history.back()</script>");
        //HttpContext.Current.Response.End(); 
        string str = "";
        string[] text = new string[GridView1.Rows.Count];
        string[] emailId = new string[GridView1.Rows.Count];
        int j = 0;
        int userid = 0;
        CheckOut checkOutDocService = new CheckOut();
        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {
            
           
            CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("chkClick");
            if (cbox.Checked == true)
            {
                str += i + " ";
                text[j] = GridView1.Rows[i].Cells[1].Text;
                emailId[j] = GridView1.Rows[i].Cells[5].Text.Trim();
              j++;
            }
        }
        if (Session["userid"] != null)
        { 
            
            userid = (int)Session["userid"];
            // Put a check of text is not empty
            checkOutDocService.checkOut(text, userid, emailId);

            
        }
        else
        {
            Server.Transfer("~/Login.aspx");
            return;
        }

        HttpContext.Current.Response.Write("<script>alert(' Documents has been checked out ');history.back()</script>");
        //HttpContext.Current.Response.End();

        Response.Write("<script language=javascript>window.location.href='" + Request.Url.ToString() + "'</script>");
    }

    private void Hide_Checked()
    {
        DocListService doclistService = new DocListService();
        if (Session["userid"] != null)
        {
            DataSet ds = doclistService.CheckedDocumentListData();

            Hashtable htable = new Hashtable();

            foreach (DataTable dtable in ds.Tables)
            {
                foreach (DataRow drow in dtable.Rows)
                {
                    String title = (String)drow["Title"];
                    int docid = (int)drow["DocID"];
                    htable.Add(title, docid);
                }
            }


            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("chkClick");

                String name = GridView1.Rows[i].Cells[1].Text;

                //String name = (String)drow["Title"];
                if (htable.ContainsKey(name))
                {
                    cbox.Visible = false;
                }
                else
                    cbox.Visible = true;



                //cbox.Visible = false;
            }
        }
        else
        {
            Server.Transfer("~/Login.aspx");
        }
    }

    private void Check_ShareOptions(DataSet dset)
    {
        DocListService doclistService = new DocListService();
        if (Session["userid"] != null)
        {
            userid = (int)Session["userid"];

            //userid = 41;
            Console.WriteLine(userid);
            DataSet ds = doclistService.DocumentListShareOnService(userid);

            Hashtable htable = new Hashtable();

            foreach (DataTable dtable in ds.Tables)
            {
                foreach (DataRow drow in dtable.Rows)
                {
                    String name = (String)drow["Title"];
                    bool check = (bool)drow["Check"];
                    htable.Add(name, check);
                }
            }


            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("chkClick");

                String name = GridView1.Rows[i].Cells[1].Text;

                //String name = (String)drow["Title"];
                if (htable.ContainsKey(name) && (bool)htable[name] == false)
                {
                    cbox.Visible = false;
                }
                else
                    cbox.Visible = true;

                                

                //cbox.Visible = false;
            }
        }
        else
        {
            Server.Transfer("~/Login.aspx");
        }
    }
}
