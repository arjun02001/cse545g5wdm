﻿using System;
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
        lgn_Login.Focus();
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

    protected void lgn_Login_OnLoggingIn(object sender, LoginCancelEventArgs e)
    {
        
    }

    protected void lgn_Login_LoggedIn(object sender, EventArgs e)
    {
        LoginHandler(lgn_Login.UserName, lgn_Login.Password);
    }

    private void LoginHandler(string username, string password)
    {
        Session["loginAttempts"] = (object)((int)Session["loginAttempts"] + 1);
        //validate password
        Regex passwordRegex = new Regex("([A-z]|[0-9]){6,100}");
        UserTransferObject user = new UserTransferObject();
        LoginService login = new LoginService();
        user = login.Login(passwordRegex, username, password);

        //if userid is found and login attempts not yet 5
        if (user.userid != 0 && ((int)Session["loginAttempts"] < 5))
        {
            //add user variables
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

    }

}
