using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        //this will cause the custom validator to fire including the functions
        //cv_PasswordMatching_Validate
        if (Page.IsValid)
        {
            //continue with add new user
        }
    }

    protected void DepartmentList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void cv_PasswordMatching_Validate(object source, ServerValidateEventArgs args)
    {
        //set the validation to false by default
        args.IsValid = false;
        //if the passwords match we can continue with the add user operation
        if (txt_Password.Text == txt_ConfirmPassword.Text)
        {
            args.IsValid = true;
        }

    }
}
