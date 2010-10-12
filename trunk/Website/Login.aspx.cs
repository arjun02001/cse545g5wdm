using System;
using System.Collections.Generic;
using System.Linq;
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
    }

    private void LoginHandler(string username, string password)
    {

    }
}
