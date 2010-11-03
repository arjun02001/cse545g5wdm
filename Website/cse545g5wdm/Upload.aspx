<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management - Upload</title>
<style type="text/css">
.uploadbox
{
	float:none;
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
.heading
{
	text-align:center;
	font-family:Arial;
	font-style:normal;
	font-size:xx-large;
}
.smallheading
{
	text-align:center;
	font-family:Arial;
	font-style:normal;
	font-size:larger;
}
.navigationbox
{
	float:left;
	border-bottom-color:Black;
	border-bottom-style:solid;
	border-bottom-width:thin;
	border-left-color:Black;
	border-left-style:solid;
	border-left-width:thin;
	border-top-color:Black;
	border-top-style: solid;
	border-top-width:thin;
	border-right-color:Black;
	border-right-style:solid;
	border-right-width:thin;
	width: auto;
}
</style>
</head>
<body>
    <form id="UploadDocument" runat="server" method="post" enctype="multipart/form-data">
    <div class="heading">
        Upload Documents
    </div>
    <div class="navigationbox">
        <div class="smallheading">
            Navigation
        </div>
            <ul>
                <li><asp:HyperLink ID="hl_DocumentList" runat="server" NavigateUrl="~/cse545g5wdm/DocumentList.aspx" Text="Document List"></asp:HyperLink> </li>
                <li><asp:HyperLink ID="hl_Upload" runat="server" NavigateUrl="~/cse545g5wdm/Upload.aspx" Text="Upload Document"></asp:HyperLink></li>
                <li><asp:HyperLink ID="hl_Delete" runat="server" NavigateUrl="~/cse545g5wdm/DeleteDocument.aspx" Text="Delete Document"></asp:HyperLink></li>
            </ul>
    </div>
    <div>
    <table class="uploadbox">
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
        <tr>
            <td>
                <asp:Button ID="btn_Upload" runat="server" Text="Upload" Visible="true" 
                 OnClick="Upload_Button_Click" />
            </td>
        </tr>
        
        
        </table>
    </div>
    </form>
</body>
</html>
