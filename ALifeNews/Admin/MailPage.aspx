<%@ Page Title="" Language="C#" MasterPageFile="~/AdmMaster.Master" AutoEventWireup="true" CodeBehind="MailPage.aspx.cs" Inherits="ALifeNews.Admin.MailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">

    <br />

    Recipient:<asp:TextBox ID="txtRecipient" runat="server" Columns="80"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv1" runat="server" 
        ControlToValidate="txtRecipient" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    URL:<asp:TextBox ID="txtUrl" runat="server" Columns="80"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv2" runat="server" 
        ControlToValidate="txtUrl" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    Pass Phrase:<asp:TextBox ID="txtPass" runat="server" Columns="80"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfv3" runat="server" 
        ControlToValidate="txtPass" ErrorMessage="Required!" ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
    <br />
    <br />
    <asp:Literal ID="ltrFeedback" runat="server"></asp:Literal>
</asp:Content>
