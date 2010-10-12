<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management Server</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="heading">
        Web Document Management
    </div>
    <div class="loginbox">
        <div class="centertext">
            Login
        </div>
        <br />
        <div>
            Username: 
            <asp:TextBox runat="server" ID="txt_Login" MaxLength="100" Width="200"></asp:TextBox> 
        </div>
        <br />
        <div>
            Password:
            <asp:TextBox runat="server" ID="txt_Password" MaxLength="100" Width="200" TextMode="Password"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button runat="server" ID="btn_Submit" Text="Submit" Enabled="true" Font-Names="Times New Roman" Font-Size="Medium" Visible="true" />
        </div>
        <div>
            <b>New User?</b> Click <a href="NewUser.aspx">here</a>.
        </div>
    </div>
    <div class="copyright">
         Group 5 Arizona State University CSE 545 Fall 2010©
    </div>
    </form>
</body>
</html>
