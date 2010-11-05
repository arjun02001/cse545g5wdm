using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void RoleList_DataBound(object sender, EventArgs e)
    {
        DropDownList RoleList = (DropDownList)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("RoleList");
        //remove temp
        RoleList.Items.RemoveAt(0);
    }

    protected void cuw_Register_Error(object sender, CreateUserErrorEventArgs e)
    {
        Label lbl_Error = (Label)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("lbl_Error");
        lbl_Error.Text = e.CreateUserError.ToString();
        lbl_Error.Visible = true;
        e.ToString();
    }

    protected void cuw_Register_Created(object sender, EventArgs e)
    {
        Label lbl_Error = (Label)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("lbl_Error");
        lbl_Error.Visible = false;
        //continue with add new user
        LogService logAction = new LogService();
        DropDownList RoleList = (DropDownList)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("RoleList");
        DropDownList DepartmentList = (DropDownList)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("DepartmentList");
        TextBox txt_ConfirmPassword = (TextBox)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("txt_ConfirmPassword");
        TextBox txt_Request = (TextBox)cuw_Register.CreateUserStep.ContentTemplateContainer.FindControl("txt_Request");
        String password = cuw_Register.Password;
        String confirmPass = txt_ConfirmPassword.Text;
        //need to add one after we remove temp
        int role = RoleList.SelectedIndex+2;
        int department = DepartmentList.SelectedIndex+1;
        String username = cuw_Register.UserName;
        String request = txt_Request.Text;

        RegisterService rs = new RegisterService();
        bool returnVal = rs.RegisterNewUser(username, password, confirmPass, request, role, department);
        //make user a temp role
        Roles.AddUserToRole(username, "Temp");

        if (returnVal)
        {
            logAction.LogAction(DateTime.Now.ToString() + ": A new user account has been created by the name of " + username + ".\n");   
        }
        else
        {
            logAction.LogAction(DateTime.Now.ToString() + ": A new user account failed to be created due to an error in RegisterService.\n");
        }

        Server.Transfer("~/Login.aspx");
    }

    protected void cuw_Register_Creating(object sender, LoginCancelEventArgs e)
    {
        Validate("CreateUserWizard");
    }

}
