<%@ Page Language="C#"  MasterPageFile ="~/cse545g5wdm/SiteMasterPage.master" CodeFile="DeleteDocument.aspx.cs" Inherits="cse545g5wdm_DeleteDocument"  %>


<asp:Content ID="content1" ContentPlaceHolderID="content1" runat="server">
    <form id="frmDeleteDocument" >
     <div class="heading">
        Delete Document
    </div>
		<center>
         <div class="uploadbox">
            <table width="100%" border="-1">
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lbl_ChooseDocument" runat="server" Text="Choose Document" AssociatedControlID="ddl_ChooseDocument"></asp:Label>
                     </td>
                     <td align="right" width="50%">
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
            <tr>
                    <td align="right" width="100%">
                          <asp:CheckBox ID="cb_Confirm" runat="server" Text="Confirm Deletion" />
                    </td>
            </tr>
            <tr>
                    <td align="right" width="100%">
                         <asp:Button ID="btn_Delete" runat="server" Text="Delete Document" OnClick="btn_Delete_Click" />
                     </td>
            </tr>
            
            </table>
                <asp:Label id="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
            </div> 
       
        
   </center>
    </form>

</asp:Content>