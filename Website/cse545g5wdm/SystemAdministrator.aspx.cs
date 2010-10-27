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

    private void ToggleCheckState(bool checkState)
    {
        try
        {
            foreach (GridViewRow row in user_GridView.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("userSelector_CheckBox");
                if (cb != null)
                    cb.Checked = checkState;
            }
        }
        catch (Exception ex)
        {
            //TODO
        }
    }

    protected void checkAll_Button_Click(object sender, EventArgs e)
    {
        ToggleCheckState(true);
    }

    protected void uncheckAll_Button_Click(object sender, EventArgs e)
    {
        ToggleCheckState(false);
    }

    protected void grantAccess_Button_Click(object sender, EventArgs e)
    {
        TakeAction("access");
    }

    protected void denyAccess_Button_Click(object sender, EventArgs e)
    {
        TakeAction("deny");
    }

    private void TakeAction(string action)
    {
        foreach (GridViewRow row in user_GridView.Rows)
        {
            CheckBox cb = (CheckBox)row.FindControl("userSelector_CheckBox");
            if (cb != null && cb.Checked)
            {
                string user_name = user_GridView.DataKeys[row.RowIndex].Value.ToString();
                if (action.ToLower().Equals("access"))
                    GrantAccess(user_name);
                else
                    DenyAccess(user_name);
            }
        }
    }

    private void GrantAccess(string user_name)
    {
        //TODO: db query to change the role to what the user demanded
    }

    private void DenyAccess(string user_name)
    {
        //TODO: db query to delete the user
    }
}
