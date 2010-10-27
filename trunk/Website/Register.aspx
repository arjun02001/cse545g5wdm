<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

  <div class="heading">
        Web Document Management
    </div>
    <form id="Register" runat="server">
    <div>
    
            <p style="margin-left: 200px">
            Username/ Email Id:&nbsp;             <asp:TextBox runat="server" 
                    ID="txt_UserName" MaxLength="100" Width="200"></asp:TextBox> 
                  
           
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <p style="margin-left: 200px">
                &nbsp;Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="txt_Password" MaxLength="100" Width="200" TextMode="Password"></asp:TextBox>
            </p>
            <p style="margin-left: 200px">
                &nbsp;Confirm Password:&nbsp;
                <asp:TextBox runat="server" ID="txt_ConfirmPassword" MaxLength="100" Width="200" TextMode="Password"></asp:TextBox>

              
            </p>
             <p style="margin-left: 200px">
            Role:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="RoleList" runat="server" 
                 Height="18px" Width="197px"  
                DataTextField="role_name" DataValueField="role_name" 
                     DataSourceID="SqlDataSource1" >
              
            </asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                     ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                     SelectCommand="sp_GetRoles" SelectCommandType="StoredProcedure">
                 </asp:SqlDataSource>
            </p>
            
            <p style="margin-left: 200px">
            Department:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DepartmentList" runat="server" 
                 Height="18px" Width="197px"  
                DataTextField="dept_name" DataValueField="dept_name" 
                    DataSourceID="SqlDataSource2" >
              
            </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                    SelectCommand="sp_GetDepartments" SelectCommandType="StoredProcedure">
                </asp:SqlDataSource>
            </p>
            
            <div>
            <p style="margin-left: 320px">
            <asp:Button runat="server" ID="btn_Submit" Text="Register" Enabled="true" 
                Font-Names="Times New Roman" Font-Size="Medium" Visible="true" 
                onclick="btn_Submit_Click" />
            </p>
        </div>
        
        
            
    
    </div>
    <div class="copyright">
         Group 5 Arizona State University CSE 545 Fall 2010©
         </div>
    </form>
</body>
</html>
