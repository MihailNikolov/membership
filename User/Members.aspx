<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Members.aspx.cs" Inherits="MemberPages_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <p>
            My sellings
        </p>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionStringName %>" SelectCommand="SELECT [Id], [ImagePath], [Title], [Price], [DateSelled], [BuyerEmail] FROM [UsersSellings] WHERE ([UserId] = @UserId)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="&quot;&quot;" Name="UserId" SessionField="Uid" Type="String" />
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
                                    <asp:Image ID="Image2"
                                        ImageUrl='<%# "~/UserSellings/" + ProcessMyDataItem(Eval("ImagePath"))%>'
                                        runat="Server"
                                        Width="100"
                                        Height="75"
                                        Style="border: solid" />
                                </asp:HyperLink>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HyperLink ID="HyperLink1"
                                    runat="Server"
                                    NavigateUrl='<%# "~/SellingsView.aspx?ID=" + Eval("Id")%>'>
                                    <span>
                                        <%#:Eval("Title")%>
                                    </span>
                                </asp:HyperLink>
                                </a>
                                <br />
                                <span>
                                    <b>Price: </b><%#:String.Format("{0:c}", Eval("Price"))%>
                                    <%#IsBought(Eval("DateSelled") ,Eval("BuyerEmail"))%>
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
        <asp:LinkButton CssClass="ShopaButton" runat="Server" />
    </div>
</asp:Content>
