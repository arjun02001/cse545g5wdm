using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
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
            SqlCommand command = new SqlCommand("group5.sp_GetTempUsers", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection.Open();
            user_GridView.DataSource = command.ExecuteReader();
            user_GridView.DataBind();
            command.Connection.Close();
            command.Connection.Dispose();
        }
        catch (Exception)
        {
            Server.Transfer("../Error.aspx");
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
            Server.Transfer("../Error.aspx");
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
            Server.Transfer("../Error.aspx");
        }
    }

    private void GrantAccess(string user_name, string position)
    {
        try
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand("group5.sp_ModifyUserRole", connect);
            SqlParameter returnValue = new SqlParameter();
            returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            int updateruserid = (int)Session["userid"];
            command.Parameters.Add(new SqlParameter("@par_userupdateid", SqlDbType.Int)).Value = updateruserid;
            command.Parameters.Add(new SqlParameter("@par_username", SqlDbType.NChar)).Value = user_name;
            command.Connection.Open();
            SqlDataReader returnValueReader = command.ExecuteReader();

            //1 if occured
            //0 if failed
            int result = Convert.ToInt32(returnValue.Value);
            if (result == 1)
            {

            }
            else
            {

            }

            command.CommandText = "group5.sp_GetRoleUsername";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@par_username", SqlDbType.NChar)).Value = user_name;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataRole = new DataTable();
            dataAdapter.Fill(dataRole);
            command.Connection.Close();
            command.Connection.Dispose();
            command.Dispose();

            int role = (int)dataRole.Rows[0]["role_id"];

            switch (role)
            {
                case 2:
                    Roles.AddUserToRole(user_name, "Guest");
                    break;
                case 3:
                    Roles.AddUserToRole(user_name, "SystemAdministrator");
                    break;
                case 4:
                    Roles.AddUserToRole(user_name, "Employee");
                    break;
                case 5:
                    Roles.AddUserToRole(user_name, "CorporateExecutive");
                    break;
                case 6:
                    Roles.AddUserToRole(user_name, "CEO");
                    break;
            }

            FetchUsers();
        }
        catch (InvalidOperationException)
        {
            Server.Transfer("~/Error.aspx");
        }
        catch (Exception)
        {
            Server.Transfer("~/Error.aspx");
        }
    }

    private void DenyAccess(string user_name)
    {
        try
        {
            Membership.DeleteUser(user_name);
            int user_id = GetUserId(user_name);
            DeleteUser(user_id, "User_Dept");
            DeleteUser(user_id, "User");
            
        }
        catch (Exception ex)
        {
            Server.Transfer("../Error.aspx");
        }
    }

    private void DeleteUser(int user_id, string table)
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
            Server.Transfer("../Error.aspx");
        }
    }

    private int GetUserId(string user_name)
    {
        try
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ASPNETDB"].ConnectionString);
            SqlCommand command = new SqlCommand("group5.sp_GetUserID", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@par_email", SqlDbType.NChar)).Value = user_name;
            command.Connection.Open();
            SqlDataReader myReader = command.ExecuteReader();
            myReader.Read();
            int user_id = Convert.ToInt32(myReader.GetValue(0));
            command.Connection.Close();
            command.Connection.Dispose();
            return user_id;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    protected void fetchUsers_Button_Click(object sender, EventArgs e)
    {
        FetchUsers();
    }
}
