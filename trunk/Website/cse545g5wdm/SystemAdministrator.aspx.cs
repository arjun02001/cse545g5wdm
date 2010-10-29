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
    }

    private void FetchUsers()
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
        try
        {
            foreach (GridViewRow row in user_GridView.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("userSelector_CheckBox");
                if (cb != null && cb.Checked)
                {
                    string user_name = row.Cells[0].Text;
                    string position = row.Cells[2].Text;
                    if (action.ToLower().Equals("access"))
                        GrantAccess(user_name.Trim(), position.Trim());
                    else
                        DenyAccess(user_name.Trim());
                }
            }
        }
        catch (Exception ex)
        {
            //TODO
        }
    }

    private void GrantAccess(string user_name, string position)
    {
        try
        {
            string query = "UPDATE [User] SET role_id = " + position + " WHERE user_name = " + "'" + user_name + "'";
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command.Connection.Open();
            command.ExecuteReader();
            command.Connection.Close();
            command.Connection.Dispose();
            FetchUsers();
        }
        catch (Exception)
        {
            //TODO
        }
    }

    private void DenyAccess(string user_name)
    {
        try
        {
            string user_id = GetUserId(user_name);
            DeleteUser(user_id, "User_Dept");
            DeleteUser(user_id, "User");
            
        }
        catch (Exception ex)
        {
            //TODO
        }
    }

    private void DeleteUser(string user_id, string table)
    {
        try
        {
            string query = "DELETE FROM [" + table + "] WHERE user_id = " + "'" + user_id + "'";
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command.Connection.Open();
            command.ExecuteReader();
            command.Connection.Close();
            command.Connection.Dispose();
            FetchUsers();
        }
        catch (Exception ex)
        {
            
        }
    }

    private string GetUserId(string user_name)
    {
        try
        {
            string query = "SELECT user_id FROM [User] WHERE user_name = " + "'" + user_name + "'";
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command.Connection.Open();
            SqlDataReader myReader = command.ExecuteReader();
            myReader.Read();
            string user_id = myReader.GetValue(0).ToString();
            command.Connection.Close();
            command.Connection.Dispose();
            return user_id;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    protected void fetchUsers_Button_Click(object sender, EventArgs e)
    {
        FetchUsers();
    }
}
