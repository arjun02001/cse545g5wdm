<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" ValidateRequest="true"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
.heading
{
	text-align:center;
	font-family:Arial;
	font-style:normal;
	font-size:xx-large;
}

.loginbox
{
	border-bottom-color:Black;
	border-bottom-style:solid;
	border-bottom-width:medium;
	border-left-color:Black;
	border-left-style:solid;
	border-left-width:medium;
	border-top-color:Black;
	border-top-style: solid;
	border-top-width:medium;
	border-right-color:Black;
	border-right-style:solid;
	border-right-width:medium;
	width: auto;
	margin: 0px 40% 0px 40%;
}
.passwordbox
{
    text-align:center;
	width: auto;
	margin: 0px 20% 0px 20%;
}


.centertext
{
	text-align:center;
}

.copyright
{
	text-align:center;
	font-family:Times New Roman;
	font-size:xx-small;
}

</style>
    <title>Web Document Management Server</title>
</head>
<body onload="history.forward()">
    <form id="form1" runat="server">
    <div class="heading">
        Web Document Management
    </div>
    <div class="passwordbox">
        <asp:Label ID="lbl_PasswordRequirement" runat="server" Text="Passwords must be at least 7 characters with at least one number, letter, and symbol." />
    </div>
    <div class="loginbox">
        <br />
        <asp:Login ID="lgn_Login" runat="server" CreateUserText="New User? Click Here" CreateUserUrl="~/Register.aspx"
         DisplayRememberMe="true" FailureText="Not a valid username or password." MembershipProvider="QuickStartMembershipSqlProvider"
         UserNameLabelText="Email ID:" UserNameRequiredErrorMessage="An email id is required." use
         OnLoggingIn="lgn_Login_OnLoggingIn"
         OnLoggedIn="lgn_Login_LoggedIn">
         
        </asp:Login>
        
            <asp:Label ID="lbl_AttemptError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
           
        <br />
        <asp:ValidationSummary ID="valS_LoginSummary" runat="server" 
            ValidationGroup="lgn_Login" />
    </div>
    <div class="copyright">
         Group 5 Arizona State University CSE 545 Fall 2010©
    </div>
    </form>
</body>
</html>
