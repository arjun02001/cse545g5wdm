<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="cse545g5wdm_DocumentList" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master"%>

<asp:Content ContentPlaceHolderID="content1" ID="contentView" Visible="true" runat="server">
    <form id="frmDocumentList">
        <div class="heading">
            List of Documents
        </div>
     <center>
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
         </center>          
    </form>


   </asp:Content>    
    
