<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" MasterPageFile="MasterPageLogin.master"%>


<asp:Content ID="contentNew" ContentPlaceHolderID="contentNew" Visible="true" runat="server">

  
    <form id="FormRegister">
    <center>
 
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
            SelectCommand="sp_GetDepartments" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:wdmConnectionString %>" 
            SelectCommand="sp_GetRoles" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>
                
                <asp:CreateUserWizard ID="cuw_Register" runat="server" RequireEmail="false"
                   OnCreatingUser="cuw_Register_Creating"
                   OnCreatedUser="cuw_Register_Created"
                   OnCreateUserError="cuw_Register_Error"
                   ValidationGroup="CreateUserWizard">
                    <WizardSteps>
                    
                        <asp:CreateUserWizardStep runat="server">
                            <ContentTemplate>
                                <table class ="uploadbox" border="-1" style="font-size: 100%; font-family: Verdana">
                                    <tr>
                                        <td align="center" colspan="2" style="font-weight: bold; color: white; background-color: #5d7b9d">
                                            Sign Up for Your New Account                  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <asp:Label ID="lbl_Error" runat="server" Visible="false" ForeColor="Red"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_Username" runat="server" AssociatedControlID="Username">
                                                Email:</asp:Label></td>
                                        <td align="left">
                                            <asp:TextBox ID="Username" runat="server" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_Email" runat="server" ControlToValidate="Username"
                                                ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_Password" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_Password" runat="server" ControlToValidate="Password"
                                             ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                            <%--<asp:RegularExpressionValidator ID="rev_Password" runat="server" ControlToValidate="Password"
                                             ErrorMessage="Password is not 6 characters or more." ToolTip="Password must be 6 characters or more."
                                             ValidationGroup="CreatUserWizard" ValidationExpression="([A-z]|[0-9]){6,100}"></asp:RegularExpressionValidator>
                                             --%>
                                        </td>    
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_ConfirmPassword" runat="server" AssociatedControlID="txt_ConfirmPassword">Confirm Passowrd:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txt_ConfirmPassword" runat="server" TextMode="Password" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv_ConfirmPassword" runat="server" ControlToValidate="txt_ConfirmPassword"
                                             ErrorMessage="Confirm Password is required." ToolTip="Please repeat your password." ValidationGroup="CreateUserWizer">*</asp:RequiredFieldValidator>
                                            <%--<asp:RegularExpressionValidator ID="rev_confirmPassword" runat="server" ControlToValidate="txt_ConfirmPassword"
                                             ErrorMessage="Password is not 6 characters or more." ToolTip="Password must be 6 characters or more."
                                             ValidationGroup="CreateUserWizard" ValidationExpression="([A-z]|[0-9]){6,100}"></asp:RegularExpressionValidator>
                                            --%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_Request" runat="server" AssociatedControlID="txt_Request">Request:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txt_Request" runat="server" TextMode="MultiLine" MaxLength="3000"></asp:TextBox> 
                                            <asp:RequiredFieldValidator ID="rfv_Request" runat="server" ControlToValidate="txt_Request"
                                             ErrorMessage="Need a request." ToolTip="Place organizational request here." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label id="lbl_Role" runat="server" AssociatedControlID="RoleList">Role:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="RoleList" runat="server" DataSourceID="SqlDataSource1" 
                                                DataTextField="role_name" DataValueField="role_name" Height="18px" 
                                                Width="197px" OnDataBound="RoleList_DataBound" 
                                                onselectedindexchanged="RoleList_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_RoleList" runat="server" ControlToValidate="RoleList"
                                            ErrorMessage="Choose a Role" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>               
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lbl_Department" runat="server" AssociatedControlID="DepartmentList">Department:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DepartmentList" runat="server" 
                                                DataSourceID="SqlDataSource2" DataTextField="dept_name" 
                                                DataValueField="dept_name" Height="18px" Width="197px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_DepartmentList" runat="server" ControlToValidate="DepartmentList"
                                            ErrorMessage="Choose a Role" ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator>   
                                        </td>
                                    </tr>
                                </table>  
                            </ContentTemplate>
                        </asp:CreateUserWizardStep>
                        
                        <asp:CompleteWizardStep runat="server" >
                       <ContentTemplate>
                       <table class="uploadbox">
                       <tr>
                           <td >
                                            <asp:Label ID="lbl_Result" runat="server" Visible="false" ForeColor="Black"></asp:Label>
                            </td>
                              </tr>
                            <tr>   
                            <td style="font-weight: bold; color: white; background-color: #5d7b9d">
                                            <asp:HyperLink ID="Login" runat="server" NavigateUrl="~/Login.aspx" Text="Login"></asp:HyperLink>
   
                            </td>
                            </tr>      
                          
                            </table>
                       </ContentTemplate>
                      
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>       
        
    
   </center>
    </form>
</asp:Content>
