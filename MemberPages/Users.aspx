<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="MemberPages_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 97%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">

    <table id="Table1" runat="server">
        <tr>
            <td colspan="2">
                <h3>User List</h3>
            </td>
        </tr>
        <tr>
            <td colspan="2">Number of Users Online:
    <asp:Label ID="UsersOnlineLabel" runat="Server" /><br />

            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="NavigationPanel" Visible="false" runat="server">
                    <table border="0" cellpadding="3" cellspacing="3">
                        <tr>
                            <td class="auto-style1">Page
                    <asp:Label ID="CurrentPageLabel" runat="server" />
                                of
                    <asp:Label ID="TotalPagesLabel" runat="server" /></td>
                            <td style="width: 60%">
                                <asp:LinkButton ID="PreviousButton" Text="Prev &lt;"
                                    OnClick="PreviousButton_OnClick" runat="server" /></td>
                            <td style="width: 60%">
                                <asp:LinkButton ID="NextButton" Text="Next >"
                                    OnClick="NextButton_OnClick" runat="server" /></td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:DataGrid ID="UserGrid" runat="server"
                    CellPadding="2" CellSpacing="1"
                    OnItemCommand="ItemsGrid_ItemCommand">
                    <HeaderStyle BackColor="darkblue" ForeColor="white" />

                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:CheckBox ID="Admin" OnCheckedChanged="OnCheckedChanged_Admin" runat="server" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:ButtonColumn ButtonType="PushButton" Text="Remove" CommandName="Deactivate" />
                        <asp:ButtonColumn Text="Admin" CommandName="Admin" />
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="RolesGrid" runat="server"
                    CellPadding="2" CellSpacing="1"
                    GridLines="Both">
                    <HeaderStyle BackColor="darkblue" ForeColor="white" />
                </asp:DataGrid>

            </td>
        </tr>
        <tr>
            <td>&nbsp;
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MemberPages/CreateUser.aspx">Create New User</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
