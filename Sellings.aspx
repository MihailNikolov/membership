<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Sellings.aspx.cs" Inherits="MemberPages_Sellings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <p>
            My sellings
        </p>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionStringName %>" SelectCommand="SELECT * FROM [UsersSellings] WHERE ([DateSelled] = @DateSelled)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1753-01-01 00:00:00.000" Name="DateSelled" Type="DateTime" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:ListView ID="productList" runat="server" GroupItemCount="4" DataSourceID="SqlDataSource1">
            <EmptyDataTemplate>
                <table>
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                <td />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td id="Td1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <asp:HyperLink ID="HyperLink2"
                                    runat="Server"
                                    NavigateUrl='<%# "~/SellingsView.aspx?ID=" + Eval("Id")%>'>
                                    <asp:Image ID="Image1"
                                        ImageUrl='<%# "~/UserSellings/" + ProcessMyDataItem(Eval("ImagePath"))%>'
                                        runat="Server"
                                        Width="100"
                                        Height="75"
                                        Style="border: solid" />
                                </asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HyperLink ID="HyperLink1"
                                    runat="Server"
                                    NavigateUrl='<%# "~/SellingsView.aspx?ID=" + Eval("Id")%>'>
                                        <%#:Eval("Title")%>
                                </asp:HyperLink>
                                <br />
                                <span>
                                    <b>Price: </b><%#:String.Format("{0:c}", Eval("Price"))%>
                                </span>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    </p>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table style="width: 100%;">
                    <tbody>
                        <tr>
                            <td>
                                <table id="groupPlaceholderContainer" runat="server" style="width: 100%">
                                    <tr id="groupPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr></tr>
                    </tbody>
                </table>
            </LayoutTemplate>
        </asp:ListView>

    </div>
</asp:Content>
