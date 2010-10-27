using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.Initialize();
        if(Session.IsNewSession)
        {
            Session.Add("loginAttempts", (object)0);
        }
        txt_Login.Focus();
        //handles the case the user go backs to the login page while logged in
        try
        {
            if ((int)Session["role"] == (int)Enumeration.Role.SystemAdministrator)
            {
                Server.Transfer("cse545g5wdm/SystemAdministrator.aspx");
            }
            else
            {
                Server.Transfer("cse545g5wdm/DocumentList.aspx");
            }
        }
        catch (Exception)
        {

        }

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        //validate input
        string username = txt_Login.Text;
        string password = txt_Password.Text;
        //sent to login handler
        LoginHandler(username, password);
    }

    private void LoginHandler(string username, string password)
    {
        Session["loginAttempts"] = (object)((int)Session["loginAttempts"] + 1);
        //validate password
        rev_password.Validate();
        Regex passwordRegex = new Regex(rev_password.ValidationExpression);
        UserTransferObject user = new UserTransferObject();
        LoginService login = new LoginService();
        user = login.Login(passwordRegex, username, password);

        //if userid is found and login attempts not yet 5
        if (user.userid != 0 && ((int)Session["loginAttempts"] < 5))
        {
            //add user variables
            lbl_Error.Visible = false;
            Session.Add("userid", user.userid);
            Session.Add("username", user.username);
            Session.Add("role", user.role);
            Session.Remove("loginAttempts");
            //decide what kind of user, check if sysadmin
            if (user.role == (int)Enumeration.Role.SystemAdministrator)
            {
                Server.Transfer("cse545g5wdm/SystemAdministrator.aspx");
            }
            else
            {
                Server.Transfer("cse545g5wdm/DocumentList.aspx");
            }
        }
        else
        {
            //failed login, still have login attempts display so, otherwise tell them session is gone
            if ((int)Session["loginAttempts"] < 5)
            {
                lbl_Error.Text = "Invalid username or password. You have " + (5 - (int)Session["loginAttempts"]).ToString() + " attempts remaining.";
                lbl_Error.Visible = true;
            }
            else
            {
                lbl_Error.Text = "You have exceeded your allowed login attempts.  Come back in a few minutes.";
            }
        }

    }
}
