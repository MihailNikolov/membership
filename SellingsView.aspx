<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SellingsView.aspx.cs" Inherits="MemberPages_SellingsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <table>
        <tr>
            <td>Заглавие:</td>
            <td>
                <asp:Label ID="SellingTitle" CssClass="ShopaText" runat="server" Width="211px" />
        </tr>
        <tr>
            <td>Цена:</td>
            <td>
                <asp:Label ID="Price" CssClass="ShopaText" runat="server" Width="65px" />    
                <asp:Label ID="BoughtEmail" CssClass="ShopaText" Visible="false" runat="server" Width="211px" />
            </td>
        </tr>
        <tr>
            <td>Снимка: </td>
            <td>
                <asp:Image ID="ImagePic" runat="server"
                                        width="300" 
                                        height="300" 
                                        style="border: solid"  />
            </td>
        </tr>
        <tr>
            <td>Описание:</td>
            <td>
                <asp:TextBox ReadOnly="true" ID="Description" CssClass="ShopaField" runat="server" Height="71px" TextMode="MultiLine" Width="300" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Buy" Text="Купи" Visible="false" CssClass="ShopaButton" runat="server" OnClick="Buy_Click"/>
                <asp:Button ID="Edit" Text="Редакция" Visible="false" CssClass="ShopaButton" runat="server" OnClick="Edit_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
        <link rel="stylesheet" type="text/css" href="/membership/default.css" media="screen" runat="Server"/>
    <style type="text/css">
        .ShopaField {}
    </style>
</asp:Content>


