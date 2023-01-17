<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ALifeNews._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <p class="lead">For co-workers to brwose and edit newsletter posts.</p>
        <p>
            <asp:HyperLink ID="lnk1" runat="server" NavigateUrl="~/Home/IssueList.aspx" CssClass="btn btn-primary btn-lg">Issue List &raquo;</asp:HyperLink>
        </p>
    </div>

    <div class="jumbotron">
        <p class="lead">For Admin to create new newsletter publications.</p>
        <p>
            <asp:HyperLink ID="link2" runat="server" NavigateUrl="~/Admin/AdminList.aspx" CssClass="btn btn-warning btn-lg">Admin List &raquo;</asp:HyperLink>
        </p>
    </div>

    <br />

     <div class="row">
          <div class="col-lg-4">
            <div class="bs-component">

<div class="card text-white bg-primary mb-3" style="max-width: 20rem;">
  <div class="card-header">Header</div>
  <div class="card-body">
    <h4 class="card-title">Primary card title</h4>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>

                </div></div></div>

<div class="card border-primary mb-3" style="max-width: 20rem;">
  <div class="card-header">Header</div>
  <div class="card-body">
    <h4 class="card-title">Primary card title</h4>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>

    <div class="row align-items-md-stretch">
      <div class="col-md-2"></div>
      <div class="col-md-8">
        <div class="h-100 p-5 bg-light border rounded-3">
          <h2>Add borders</h2>
          <p>Or, keep it light and add a border for some added definition to the boundaries of your content. Be sure to look under the hood at the source HTML here as we've adjusted the alignment and sizing of both column's content for equal-height.</p>
          <button class="btn btn-outline-secondary" type="button">Example button</button>
        </div>
      </div>
      <div class="col-md-2"></div>
    </div>


</asp:Content>
