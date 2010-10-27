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
        //validate password
        rev_password.Validate();
        Regex passwordRegex = new Regex(rev_password.ValidationExpression);
        UserTransferObject user = new UserTransferObject();
        LoginService login = new LoginService();
        user = login.Login(passwordRegex, username, password);

        if (user.userid != 0)
        {
            Session.Add("userid", user.userid);
            Session.Add("username", user.username);
            Session.Add("role", user.role);
            if (user.role == (int)Enumeration.Role.SystemAdministrator)
            {
                Server.Transfer("cse545g5wdm/DocumentList.aspx");
            }
            else
            {
                Server.Transfer("cse545g5wdm/Document.aspx");
            }
        }

    }
}
