<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="MemberPages_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <h1>
            Change Password
        </h1>
        <p>
            <asp:ChangePassword ID="ChangePassword1" runat="server" ContinueDestinationPageUrl="~/Default.aspx" OnCancelButtonClick="ChangePassword1_CancelButtonClick" >
                <CancelButtonStyle CssClass="ShopaButton" />
                <ChangePasswordButtonStyle CssClass="ShopaButton" />
            </asp:ChangePassword>
            &nbsp;</p>
    </div>
</asp:Content>
