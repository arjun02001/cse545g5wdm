<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="cse545g5wdm_DocumentList" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master"%>

<asp:Content ContentPlaceHolderID="content1" ID="contentView" Visible="true" runat="server">
    <form id="frmDocumentList">
        <div class="heading">
            List of Documents
        </div>
    
    <!--div class="navigationbox">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="sql_related_documents">
            <Columns>
                <asp:BoundField DataField="doc_title" HeaderText="doc_title" ReadOnly="True" 
                    SortExpression="doc_title" />
                <asp:BoundField DataField="doc_id" HeaderText="doc_id" ReadOnly="True" 
                    SortExpression="doc_id" />
            </Columns>
            
        </asp:GridView>
        <asp:SqlDataSource ID="sql_related_documents" runat="server" 
            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
            SelectCommand="sp_GetDocumentsOfUser" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="par_userid" SessionField="userid" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        .</div -->
        <div class="DocumentListbox">
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                <asp:TemplateField ShowHeader="False" HeaderText="Click">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkClick" runat="server"></asp:CheckBox>
                    
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    &nbsp;<br />
    <br />
    &nbsp;
    <table>
    <tr align="center">
        <td align="center">
    <asp:Button ID="Button_CheckOut" runat="server" Text="Check Out" Visible="true" 
                 OnClick="CheckOut_Button_Click" />
       </td>
     </tr>
     </table>
                 
    </form>
    
   </asp:Content>    
    
