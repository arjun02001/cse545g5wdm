using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            //continue with add new user
            String password = txt_Password.Text;
            String confirmPass = txt_ConfirmPassword.Text;
            String role = RoleList.Text;
            String department = DepartmentList.Text;
            String username = txt_UserName.Text;

            RegisterService rs = new RegisterService();
            bool returnVal = rs.RegisterNewUser(username, password, confirmPass, role, department);

            if (returnVal)
            {

            }
            else
            {

            }

        }
    }
}
