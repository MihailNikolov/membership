<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
        <div>
            <asp:Login ID="Login1" runat="server" >
                <LoginButtonStyle CssClass="ShopaButton" />
            </asp:Login>
        </div>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
</asp:Content>
