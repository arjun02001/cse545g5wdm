<%@ Page Language="C#"  MasterPageFile ="~/cse545g5wdm/SiteMasterPage.master" CodeFile="DeleteDocument.aspx.cs" Inherits="cse545g5wdm_DeleteDocument"  %>


<asp:Content ID="content1" ContentPlaceHolderID="content1" runat="server">


    <form id="frmDeleteDocument" >
   
		<center>
         <div class="navigationbox">
            <table width="100%" border="0">
                <tr>
                    <td align="right" width="10%">
                        <asp:Label ID="lbl_ChooseDocument" runat="server" Text="Choose Document" AssociatedControlID="ddl_ChooseDocument"></asp:Label>

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
            <td>
            <asp:CheckBox ID="cb_Confirm" runat="server" Text="Confirm Deletion" />
            </td>
            </tr>
            <tr>
            <td>
            <asp:Button ID="btn_Delete" runat="server" Text="Delete Document" OnClick="btn_Delete_Click" />
            </td>
            </tr>
            <div>
            </table>
                <asp:Label id="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>   
            </div> 
        </div>
        
   </center>
    </form>

</asp:Content>