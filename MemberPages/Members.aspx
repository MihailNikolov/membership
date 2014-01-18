<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Members.aspx.cs" Inherits="MemberPages_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <h1>Welcome, Members!</h1>
        <p>
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
            &nbsp;
        </p>
        <p>
            <asp:LoginView ID="LoginView2" runat="server">
                <AnonymousTemplate>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MemberPages/DeactivateUser.aspx">Deactivate Account</asp:HyperLink>&nbsp;
                </LoggedInTemplate>
                <RoleGroups>
                    <asp:RoleGroup Roles="Admin">
                        <ContentTemplate>
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MemberPages/Users.aspx">Users</asp:HyperLink>&nbsp;
                        </ContentTemplate>
                    </asp:RoleGroup>
                </RoleGroups>

            </asp:LoginView>

        </p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Home</asp:HyperLink>&nbsp;
        </p>
    </div>
</asp:Content>
