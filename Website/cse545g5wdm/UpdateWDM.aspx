<%@ Page Language="C#"  MasterPageFile ="~/cse545g5wdm/SiteMasterPage.master" AutoEventWireup="true" CodeFile="UpdateWDM.aspx.cs" Inherits="UpdateWDM" %>



<asp:Content ID="content1" ContentPlaceHolderID="content1" runat ="server">
    <form id="UpdateDocument" method="post" enctype="multipart/form-data">
    <div class="heading">
        Update Documents
    </div>
    
    <div>
    <table class="uploadbox">
    <tr>
    <td> Select Document 
    </td>
        
        <td align="left">
                         <asp:DropDownList ID="ddl_ChooseDocument" runat="server" 
                            DataSourceID="wdm_authored_documents_Update" DataTextField="doc_title" 
                            DataValueField="doc_title"> </asp:DropDownList>
                        <asp:SqlDataSource ID="wdm_authored_documents_Update" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
                            SelectCommand="getCheckOutDocument" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="par_userid" SessionField="userid" 
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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
                <asp:Button ID="btn_Update" runat="server" Text="Update" Visible="true" 
                 OnClick="Update_Button_Click" />
            </td>
        </tr>
        
        
        </table>
    </div>
    </form>
    
</asp:Content>


