<%@ Page Title="" Language="C#" MasterPageFile="~/AdmMaster.Master" AutoEventWireup="true" CodeBehind="PopulateIssue.aspx.cs" Inherits="ALifeNews.Admin.PopulateIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <br />

    <asp:Button ID="btnPopulate" runat="server" Text="Populate" OnClick="btnPopulate_Click" />
    <br />
    <asp:Literal ID="ltrResult" runat="server"></asp:Literal>
</asp:Content>
