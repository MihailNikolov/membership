<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="Server">
    <div>
        <h1>Register</h1>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Default.aspx">
            <ContinueButtonStyle CssClass="ShopaButton" />
            <CreateUserButtonStyle CssClass="ShopaButton" />
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
            <CancelButtonStyle CssClass="ShopaButton" />
            <FinishCompleteButtonStyle CssClass="ShopaButton" />
        </asp:CreateUserWizard>
        &nbsp;
        
    </div>
    <br />
</asp:Content>
