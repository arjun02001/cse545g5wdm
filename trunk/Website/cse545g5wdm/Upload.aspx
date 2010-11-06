<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" MasterPageFile="~/cse545g5wdm/SiteMasterPage.master"%>


<asp:Content ID="content1" ContentPlaceHolderID="content1" runat ="server">
    <form id="UploadDocument" method="post" enctype="multipart/form-data">
    <div class="heading">
        Upload Documents
    </div>
    
    <div>
    <table class="uploadbox">
    <tr>
    <td> Document Name
    </td>
        <td>
        <asp:TextBox ID="txt_fileName" runat="server"></asp:TextBox>
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
                <asp:Button ID="btn_Upload" runat="server" Text="Upload" Visible="true" 
                 OnClick="Upload_Button_Click" />
            </td>
        </tr>
        
        
        </table>
    </div>
    </form>
    
</asp:Content>

