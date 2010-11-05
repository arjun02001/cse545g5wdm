<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DocumentList.aspx.cs" Inherits="cse545g5wdm_DocumentList" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master"%>

<asp:Content ContentPlaceHolderID="content1" ID="contentView" Visible="true" runat="server">
    <form id="frmDocumentList">
    <div class="heading">
        List of Documents
    </div>
    
    <div class="navigationbox">
        <asp:GridView ID="GridView2" runat="server">
            
        </asp:GridView>
        .</div>
    &nbsp;<br />
    <br />
    &nbsp;
    <asp:Button ID="Button_CheckOut" runat="server" Text="Check Out" Visible="true" 
                 OnClick="CheckOut_Button_Click" />
    </form>
    
   </asp:Content>    
    
