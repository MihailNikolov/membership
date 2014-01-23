<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <h1>Reset my password to a new value
        </h1>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>&nbsp;
        </p>
        <p>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" >
                <SubmitButtonStyle CssClass="ShopaButton" />
            </asp:PasswordRecovery>
            &nbsp;
        </p>
    </div>
</asp:Content>
