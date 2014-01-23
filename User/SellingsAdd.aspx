<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SellingsAdd.aspx.cs" Inherits="MemberPages_SellingsAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table>
        <tr>
            <td>Заглавие:</td>
            <td>
                <asp:TextBox ID="SellingTitle" CssClass="ShopaField" runat="server" Width="211px" /></td>
        </tr>
        <tr>
            <td>Цена:</td>
            <td>
                <asp:TextBox ID="Price" CssClass="ShopaField" runat="server" Width="212px" />

                <asp:RangeValidator ID="valRange" runat="server"
                    ControlToValidate="Price"
                    MaximumValue="1000000"
                    MinimumValue="0"
                    Type="Double"
                    ErrorMessage="* Enter correct price 0 - 1000000"
                    Display="static">*</asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>Снимка: </td>
            <td>
                <asp:FileUpload ID="fileuploadImage" runat="server" />
            </td>
        </tr>
        <tr>
            <td>Описание:</td>
            <td>
                <asp:TextBox ID="Description" CssClass="ShopaField" runat="server" Height="56px" TextMode="MultiLine" Width="450px" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnUpload" runat="server" CssClass="ShopaButton" Text="Добави" OnClick="btnUpload_Click" />
                <asp:Button ID="btnClear" runat="server" CssClass="ShopaButton" OnClick="btnClear_Click" Text="Изчисти" />
            </td>
        </tr>
    </table>
</asp:Content>
