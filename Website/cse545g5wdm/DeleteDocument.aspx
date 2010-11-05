<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeleteDocument.aspx.cs" Inherits="cse545g5wdm_DeleteDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Document Management - Delete Document</title>
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
    <form id="frmDeleteDocument" runat="server">
    <div class="heading">
        Document Deletion
    </div>
    <div>
        <div class="navigationbox">
            <div class="smallheading">
                Navigation
            </div>
            <div>
                <ul>
                    <li><asp:HyperLink ID="hl_DocumentList" runat="server" NavigateUrl="~/cse545g5wdm/DocumentList.aspx" Text="Document List"></asp:HyperLink> </li>
                    <li><asp:HyperLink ID="hl_Upload" runat="server" NavigateUrl="~/cse545g5wdm/Upload.aspx" Text="Upload Document"></asp:HyperLink></li>
                    <li><asp:HyperLink ID="hl_Delete" runat="server" NavigateUrl="~/cse545g5wdm/DeleteDocument.aspx" Text="Delete Document"></asp:HyperLink></li>
                    <li><asp:HyperLink ID="h1_ViewDocument" runat="server" NavigateUrl="~/cse545g5wdm/ViewDocument.aspx" Text="View Document"></asp:HyperLink></li>
                </ul>
            </div>
        </div>
        <div class="basicbox">
            <table>
                <tr>
                    <td align="right">
                        <asp:Label ID="lbl_ChooseDocument" runat="server" Text="Choose Document" AssociatedControlID="ddl_ChooseDocument"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_ChooseDocument" runat="server" 
                            DataSourceID="wdm_authored_documents" DataTextField="doc_title" 
                            DataValueField="doc_id"></asp:DropDownList>
                        <asp:SqlDataSource ID="wdm_authored_documents" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                            SelectCommand="sp_GetAuthoredDocuments" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="par_userid" SessionField="userid" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <asp:CheckBox ID="cb_Confirm" runat="server" Text="Confirm Deletion" />
            <asp:Button ID="btn_Delete" runat="server" Text="Delete Document" OnClick="btn_Delete_Click" />
            <div>
                <asp:Label id="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
            </div> 
        </div>
    </div>
    </form>
</body>
</html>
