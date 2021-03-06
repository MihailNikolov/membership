﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DeactivateUser.aspx.cs" Inherits="MemberPages_DeactivateUser" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
  
    <h3>Delete User</h3>
  <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
  <p style="color:red">Are you sure you want to deactivate your account, <b><%=User.Identity.Name%></b>?</p>
  <asp:Button id="YesButton" Text="Yes" OnClick="YesButton_OnClick" runat="server" CssClass="ShopaButton" />
  <asp:Button id="CancelButton" Text="Cancel" OnClick="CancelButton_OnClick" runat="server" CssClass="ShopaButton" />

</asp:Content>

