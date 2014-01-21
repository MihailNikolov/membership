<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Members.aspx.cs" Inherits="MemberPages_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <p>My sellings
        </p>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\ASPNETDB.MDF;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Id], [Title], [ImagePath], [Description], [Price], [DateCreated], [DateSelled] FROM [UsersSellings] WHERE ([UserId] = @UserId) ORDER BY [DateCreated] DESC">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="-1" Name="UserId" SessionField="UserId" Type="Object" />
            </SelectParameters>
        </asp:SqlDataSource>

        <asp:ListView runat="server" ID="ProductsListView"
            GroupItemCount="3"
            DataSourceID="ProductsSqlDataSource" DataKeyNames="ProductID" >
            <LayoutTemplate>
                <table cellpadding="2" runat="server"
                    id="tblProducts" style="height: 320px">
                    <tr runat="server" id="groupPlaceholder">
                    </tr>
                </table>
                <asp:DataPager runat="server" ID="DataPager"
                    PageSize="9">
                    <Fields>
                        <asp:NumericPagerField ButtonCount="3"
                            PreviousPageText="<--"
                            NextPageText="-->" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="productRow"
                    style="height: 80px">
                    <td runat="server" id="itemPlaceholder"></td>
                </tr>
            </GroupTemplate>
            <ItemTemplate>
                <td id="Td1" valign="top" align="center" runat="server">
                    <asp:Image ID="ProductImage" runat="server"
                        ImageUrl='<%#"~/images/thumbnails/" + 
               Eval("ThumbnailPhotoFileName") %>'
                        Height="49" /><br />
                    <asp:HyperLink ID="ProductLink" runat="server"
                        Target="_blank" Text='<% #Eval("Name")%>'
                        NavigateUrl='<%#"ShowProduct.aspx?ProductID=" + 
              Eval("ProductID") %>' />
                </td>
            </ItemTemplate>
        </asp:ListView>

    </div>
</asp:Content>
