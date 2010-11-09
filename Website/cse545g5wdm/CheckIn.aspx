<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master" CodeFile="CheckIn.aspx.cs" Inherits="CheckIn" %>

<asp:Content ContentPlaceHolderID="content1" ID="contentView" Visible="true" runat="server">
   <form id="checkIn">
    <div class="heading">
        CheckIn Document
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
                            DataSourceID="wdm_authored_documents_CheckIn" DataTextField="doc_title" 
                            DataValueField="doc_id"> </asp:DropDownList>
                        <asp:SqlDataSource ID="wdm_authored_documents_CheckIn" runat="server" 
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
                    <td align="right" width="100%">
                          <asp:CheckBox ID="cb_Confirm" runat="server" Text="Confirm Check In" />
                    </td>
            </tr>
            <tr>
                    <td align="right" width="100%">
                         <asp:Button ID="btn_CheckIn" runat="server" Text="Check In Document" OnClick="btn_CheckIn_Click" />
                     </td>
            </tr>
    </form>
</asp:Content>
