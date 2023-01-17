<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IssueList.aspx.cs" Inherits="ALifeNews.Home.IssueList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="row"><div class="col-md-8">
    <br />
    <asp:GridView runat="server" id="gv1" AllowPaging="True" AllowSorting="True" 
     PageSize="10" CssClass="table table-hover" SelectedRowStyle-CssClass="table-primary" HeaderStyle-CssClass="table-active"
    AutoGenerateColumns="False" DataKeyNames="IssueID" DataSourceID="ds1">
    <Columns>
        <asp:TemplateField HeaderText = "" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("IssueNum", "~/Home/IssueEdit.aspx?IssueNum={0}") %>'
                    Text='Open' CssClass="btn btn-primary"/>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="IssueNum" HeaderText="Issue#" SortExpression="IssueNum"/>
        <asp:BoundField DataField="IssueWeek" HeaderText="Week"/>
        <%--
        <asp:BoundField DataField="IssueYear" HeaderText="Year" ItemStyle-Width="60px"/>
        <asp:BoundField DataField="IssueMonth" HeaderText="Month" ItemStyle-Width="60px"/>
        <asp:BoundField DataField="IssueDay" HeaderText="Day"  ItemStyle-Width="60px"/>
        --%>
        <asp:TemplateField HeaderText = "Date">
            <ItemTemplate>
                <%# Eval("IssueYear") + "/"  + Eval("IssueMonth") + "/" + Eval("IssueDay")%>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:CheckBoxField DataField="IssueReadOnly" HeaderText="Read Only?" ItemStyle-Width="60px"/>
        <asp:TemplateField HeaderText = "" ItemStyle-Width="100px">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("IssueNum", "~/Home/Preview.aspx?IssueNum={0}") %>'
                    Text='Preview' Target="_blank" CssClass="btn btn-primary" />
            </ItemTemplate>
        </asp:TemplateField>


    </Columns>

</asp:GridView>


<asp:ObjectDataSource runat="server" id="ds1" DeleteMethod="Delete" 
    InsertMethod="Insert" OldValuesParameterFormatString="Original_{0}" SelectMethod="GetData" 
    TypeName="ALifeNews.DAL.IssueDataTableAdapters.IssueAdminTableAdapter" UpdateMethod="Update">
    </asp:ObjectDataSource>


  </div></div>

</asp:Content>
