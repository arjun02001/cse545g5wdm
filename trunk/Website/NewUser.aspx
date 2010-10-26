<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUser.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management - New User Application</title>
</head>
<body>
   
  
 <form id="NewUser" runat="server">
    <div class="heading">
        Web Document Management
    </div>
    <div class="loginbox">
        <div class="centertext">
            <p style="margin-left: 200px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            New User
            </p>
        </div>
        <br />
        <div>
            <p style="margin-left: 200px">
            Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;             <asp:TextBox runat="server" ID="txt_Login" MaxLength="100" Width="200"></asp:TextBox> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <p style="margin-left: 200px">
                &nbsp;Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txt_Password" MaxLength="100" Width="200" TextMode="Password"></asp:TextBox>
            </p>
            <p style="margin-left: 200px">
&&nbsp;Confirm Password:&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txt_ConfirmPassword" MaxLength="100" 
                    Width="200"></asp:TextBox>
            </p>
        </div>
         <div>
             <p style="margin-left: 200px">
            Email Id:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox runat="server" ID="txt_emailId" MaxLength="100" Width="200"></asp:TextBox>
             </p>
             <p style="margin-left: 200px">
            Role:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:DropDownList ID="DropDownList1" runat="server" 
                     DataSourceID="SqlDataSource1" Height="18px" Width="197px">
                 </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                     SelectCommand="SELECT [role_name] FROM [Role]"></asp:SqlDataSource>
             </p>
        </div>
        <br />
        <div>
            <p style="margin-left: 320px">
            <asp:Button runat="server" ID="btn_Submit" Text="Register" Enabled="true" 
                Font-Names="Times New Roman" Font-Size="Medium" Visible="true" 
                onclick="btn_Submit_Click" />
            </p>
        </div>
        <div>
        </div>
    </div>
    <div class="copyright">
         Group 5 Arizona State University CSE 545 Fall 2010©
    
    </form>
</body>

</html>
