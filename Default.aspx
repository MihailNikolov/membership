<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <h1>Welcome to My site</h1>
        <asp:LoginView ID="LoginView1" runat="server">
            <AnonymousTemplate>
                Hello!
                    You are not logged in. Click the Login link to sign in<br />
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/RecoverPassword.aspx">Forgot your password? </asp:HyperLink><br />
                <br />
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in. Welcome,
                <asp:LoginName ID="LoginName1" runat="server" />
                <br />
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MemberPages/ChangePassword.aspx">Change password </asp:HyperLink><br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MemberPages/Members.aspx">Members page</asp:HyperLink>
            </LoggedInTemplate>
        </asp:LoginView>
    </div>
</asp:Content>
