<%@ Page Title="Web Document Management - Share Document" Language="C#" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master" AutoEventWireup="true" CodeFile="ShareDocument.aspx.cs" Inherits="cse545g5wdm_ShareDocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="topMenu" Runat="Server">
    <div class="heading">
        Share Document
    </div>
    <div class="basicbox">
        <table>
            <tr>
                <td align="right">
                    Username:
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txt_Username" runat="server" MaxLength="100" CausesValidation="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Username" runat="server" ControlToValidate="txt_Username" Text="Please enter a valid username."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Document:
                </td>
                <td align="left" colspan="2">
                    <asp:DropDownList ID="ddl_AuthoredDocuments" runat="server" 
                        CausesValidation="True" DataSourceID="sql_authored_documents" 
                        DataTextField="doc_title" DataValueField="doc_id"></asp:DropDownList>
                    <asp:SqlDataSource ID="sql_authored_documents" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                        SelectCommand="sp_GetAuthoredDocuments" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="par_userid" SessionField="userid" 
                                Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:CheckBox ID="cb_Read" runat="server" Text="Read Access" />
                </td>
                <td align="center">
                    <asp:CheckBox ID="cb_Update" runat="server" Text="Update Access" />
                </td>
                <td align="left">
                    <asp:CheckBox ID="cb_Check" runat="server" Text="Checkout Access" />
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="btn_Share" runat="server" Text="Share" 
                        onclick="btn_Share_Click" />
                </td>
                <td align="left" colspan="2">
                    <asp:Label ID="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lbl_Success" runat="server" Visible="false" Text="Successfully shared a document."></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


