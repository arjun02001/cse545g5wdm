<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDocument.aspx.cs" Inherits="cse545g5wdm_ViewDocument" MasterPageFile = "~/cse545g5wdm/SiteMasterPage.master"%>

<asp:Content ContentPlaceHolderID="content1" ID="contentView" Visible="true" runat="server">
    <form id="frmViewDocument">
    <div class="heading">
        Document Viewing
    </div>
    <div>
        
        <div class="uploadbox">
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
                            SelectCommand="sp_GetDocumentsToRead" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="par_userid" SessionField="userid" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
            <asp:Button ID="btn_View" runat="server" Text="View Document" 
                onclick="btn_View_Click"/>
            <div>
                <asp:Label id="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
            </div> 
        </div>
    </div>
    </form>
</asp:Content>
