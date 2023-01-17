<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPhoto.aspx.cs" Inherits="ALifeNews.Home.EditPhoto" %>
<%@ Register Src="~/Home/IssueLink.ascx" TagPrefix="uc1" TagName="IssueLink" %>
<%@ Register Src="~/Home/IssueDate.ascx" TagPrefix="uc1" TagName="IssueDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <uc1:IssueLink runat="server" ID="IssueLink" />
    <br /><br />
    <uc1:IssueDate runat="server" ID="IssueDate" />
    <br /><br />

    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" DataKeyNames="PhotoID" DataSourceID="dsrc1"
        CssClass="table">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <%--<asp:BoundField DataField="PhotoID" HeaderText="PhotoID" InsertVisible="False" ReadOnly="True" SortExpression="PhotoID" />--%>
            <%--<asp:BoundField DataField="IssueNum" HeaderText="IssueNum"/>--%>
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="hid1" runat="server" Value='<%# Eval("IssueNum")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:HiddenField ID="hid2" runat="server" Value='<%# Bind("IssueNum")%>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>URL</HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbURL" runat="server" Text='<%# Eval("PhotoURL").ToString().Substring(0,25) + "..." %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="tbURL" runat="server" Text='<%# Bind("PhotoURL") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PhotoWidth" HeaderText="Width" SortExpression="PhotoWidth" />
            <asp:BoundField DataField="PhotoHeight" HeaderText="Height" SortExpression="PhotoHeight" />
            <asp:CheckBoxField DataField="IsDeleted" HeaderText="Deleted" SortExpression="IsDeleted" />
            <asp:BoundField DataField="OrderNum" HeaderText="Order#" SortExpression="OrderNum" />
            <asp:TemplateField>
                <HeaderTemplate>Preview</HeaderTemplate>
                <ItemTemplate>
                    <asp:Image ID="ImgURL" ImageUrl='<%# Eval("PhotoURL")%>' Width="400px" Height="300px" runat="server" />
                </ItemTemplate>
                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="dsrc1" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByIssueNum" TypeName="ALifeNews.DAL.IssueDataTableAdapters.PhotoTableAdapter" UpdateMethod="Update">
        <InsertParameters>
            <asp:Parameter Name="IssueNum" Type="Int32" />
            <asp:Parameter Name="PhotoURL" Type="String" />
            <asp:Parameter Name="PhotoWidth" Type="Int32" />
            <asp:Parameter Name="PhotoHeight" Type="Int32" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="OrderNum" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="-1" Name="IssueNum" QueryStringField="IssueNum" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IssueNum" Type="Int32" />
            <asp:Parameter Name="PhotoURL" Type="String" />
            <asp:Parameter Name="PhotoWidth" Type="Int32" />
            <asp:Parameter Name="PhotoHeight" Type="Int32" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="OrderNum" Type="Int32" />
            <asp:Parameter Name="Original_PhotoID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <br />
    New Photo URL (Starts with "http://"): 
    <asp:TextBox ID="tbURL" runat="server"  Width="2400px"></asp:TextBox>
    <br />
    Photo Width:
    <asp:TextBox ID="tbWidth" runat="server"></asp:TextBox>
    <br />
    Photo Height:
    <asp:TextBox ID="tbHeight" runat="server"></asp:TextBox>
    <br />
    Order Number:
    <asp:TextBox ID="tbOrderNum" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="btnAdd" runat="server" Text="Add Photo" OnClick="btnAdd_Click" />
    
</asp:Content>
