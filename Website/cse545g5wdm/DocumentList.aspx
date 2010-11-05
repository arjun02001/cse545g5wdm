<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="cse545g5wdm_DocumentList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management - Document List</title>
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
</head>
<body>
    <form id="frmDocumentList" runat="server">
    <div class="heading">
        List of Documents
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
    <div class="basicbox">
    
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p style="height: 125px; width: 1049px">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" 
            GridLines="None" onselectedindexchanged="GridView1_SelectedIndexChanged">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:BoundField DataField="doc_title" HeaderText="doc_title" 
                    SortExpression="doc_title" />
                <asp:BoundField DataField="doc_create_time" HeaderText="doc_create_time" 
                    SortExpression="doc_create_time" />
                <asp:BoundField DataField="doc_last_access" HeaderText="doc_last_access" 
                    SortExpression="doc_last_access" />
                <asp:BoundField DataField="doc_type" HeaderText="doc_type" 
                    SortExpression="doc_type" />
                <asp:BoundField DataField="user_name" HeaderText="user_name" 
                    SortExpression="user_name" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
            SelectCommand="SELECT [Document].doc_title, [Document].doc_create_time, [Document].doc_last_access, [Document].doc_type, [User].user_name FROM [Document] INNER JOIN [User] ON [Document].user_id = [User].user_id">
        </asp:SqlDataSource>
    </p>
    </form>
</body>
</html>
