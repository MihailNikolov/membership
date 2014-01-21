<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="MemberPages_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <table id="Table1" runat="server">
        <tr>
            <td colspan="2">
                <h3>User List</h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">Number of Users Online:
                <asp:Label ID="UsersOnlineLabel" runat="Server" Font-Names="Lucida Sans Unicode" /><br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="NavigationPanel" Visible="false" runat="server">
                    <table border="0" cellpadding="3" cellspacing="3">
                        <tr>
                            <td>Page
                                <asp:Label ID="CurrentPageLabel" runat="server" Font-Names="Lucida Sans Unicode" />
                                of
                                <asp:Label ID="TotalPagesLabel" runat="server" Font-Names="Lucida Sans Unicode" />
                            </td>
                            <td style="width: 50%">
                                <asp:LinkButton ID="PreviousButton" Text="Prev &lt;"
                                    OnClick="PreviousButton_OnClick" runat="server" /></td>
                            <td style="width: 50%">
                                <asp:LinkButton ID="NextButton" Text="Next >"
                                    OnClick="NextButton_OnClick" runat="server" /></td>
                        </tr>
                    </table>
                </asp:Panel>

                <div id="oDiv" style="overflow: scroll; width:30%; text-align: left" runat="Server">
                    <asp:DataGrid ID="UserGrid"
                        runat="server"
                        OnItemCommand="ItemsGrid_ItemCommand"
                        CssClass="navigation_table"
                        Font-Names="Lucida Sans Unicode">

                        <Columns>
                            <asp:ButtonColumn HeaderText="Deactivate" ButtonType="PushButton" Text="Deactivate" CommandName="Deactivate" />
                            <asp:TemplateColumn HeaderText="Admin">
                                <ItemTemplate>
                                    <asp:CheckBox ID="Admin" OnCheckedChanged="OnCheckedChanged_Admin" runat="server" AutoPostBack="true" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Administrator/CreateUser.aspx">Create New User</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
