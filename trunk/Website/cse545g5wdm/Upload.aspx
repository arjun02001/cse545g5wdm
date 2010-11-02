<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="UploadDocument" runat="server">
    <div>
    <table>
    <tr>
    <td> Document Name
    </td>
        <td>
        <asp:TextBox ID="txt_fileName" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td>
        Select File
        </td>
        <td>
        <asp:FileUpload ID="FileUploadPath" runat="server" />
        </td>
        </tr>
        
        
        
        </table>
        
       <br>
          <asp:Button ID="Upload_Button" runat="server" Text="Upload" Visible="true" 
            onclick="Upload_Button_Click" />
            
    </div>
    </form>
</body>
</html>
