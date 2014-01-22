<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Members.aspx.cs" Inherits="MemberPages_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <p>My sellings
        </p>

          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionStringName %>" SelectCommand="SELECT [Id], [ImagePath], [Title], [Price] FROM [UsersSellings] WHERE ([UserId] = @UserId)">
              <SelectParameters>
                  <asp:SessionParameter DefaultValue="&quot;&quot;" Name="UserId" SessionField="Uid" Type="String" />
              </SelectParameters>
        </asp:SqlDataSource>

          <asp:ListView ID="productList" runat="server" GroupItemCount="4" DataSourceID="SqlDataSource1">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
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
                                    <a href="SellingsEdit.aspx?ID=<%#Eval("Id")%>">
                                    <img src="<%#Server.MapPath("~/UserSellings/") + Eval("ImagePath")%>" width="100" height="75" style="border: solid" />
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="SellingsEdit.aspx?ID=<%#Eval("Id")%>">
                                        <span>
                                            <%#:Title%>
                                        </span>
                                    </a>
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
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
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
