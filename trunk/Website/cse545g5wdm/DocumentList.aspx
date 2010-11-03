<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="cse545g5wdm_DocumentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management - Document List</title>
</head>
<style type="text/css">
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
.basicbox
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
<body>
    <form id="frmDocumentList" runat="server">
    <div class="heading">
        List of Documents
    </div>
    <div>
        <div class="navigationbox">
            <li><asp:HyperLink ID="hl_DocumentList" runat="server" NavigateUrl="~/cse545g5wdm/DocumentList.aspx" Text="Document List"></asp:HyperLink> </li>
            <li><asp:HyperLink ID="hl_Upload" runat="server" NavigateUrl="~/cse545g5wdm/Upload.aspx" Text="Upload Document"></asp:HyperLink></li>
            <li><asp:HyperLink ID="hl_Delete" runat="server" NavigateUrl="~/cse545g5wdm/DeleteDocument.aspx" Text="Delete Document"></asp:HyperLink></li>
        </div>
        <div class="basicbox">
           
        </div>
    </div>
    </form>
</body>
</html>
