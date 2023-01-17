<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueEdit.aspx.cs" Inherits="ALifeNews.Home.IssueEdit" %>

<%@ Register Src="~/Home/IssueDate.ascx" TagPrefix="uc1" TagName="IssueDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <a href="IssueList.aspx" class="btn btn-primary">Back to List</a>
    <br />
    <br />
    <uc1:IssueDate runat="server" id="IssueDate" />
    <br />
    <br />
    
    <asp:HyperLink ID="lnkPost"  runat="server" NavigateUrl='<%# String.Format("~/Home/EditPost.aspx?IssueNum={0}", Request["IssueNum"]) %>' 
        CssClass="btn btn-primary">Edit Posts</asp:HyperLink>

    &nbsp;&nbsp;

    <asp:HyperLink ID="lnkPhoto" runat="server" NavigateUrl='<%# String.Format("~/Home/EditPhoto.aspx?IssueNum={0}", Request["IssueNum"]) %>'
        CssClass="btn btn-primary">Edit Photos</asp:HyperLink>

    &nbsp;&nbsp;

    <a href='Preview.aspx?IssueNum=<%: Request["IssueNum"] %>' target="_blank" class="btn btn-primary">Preview</a> 

    <br />
    
    <table border="0">
        <tr>
            <td style="width:600px; vertical-align:top;">
                <asp:Literal ID="ltrChMemo" runat="server"></asp:Literal>  
            </td>
            <td style="width:600px; vertical-align:top;">
                 <asp:Literal ID="ltrMemo" runat="server"></asp:Literal> 
            </td>
        </tr>
    </table>

   



</asp:Content>
