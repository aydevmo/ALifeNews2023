<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="ALifeNews.Home.EditPost" %>

<%@ Register Src="~/Home/IssueLink.ascx" TagPrefix="uc1" TagName="IssueLink" %>
<%@ Register Src="~/Home/IssueDate.ascx" TagPrefix="uc1" TagName="IssueDate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <div class="row"> <div class="col-md-6">
    <br />
    <uc1:IssueLink runat="server" ID="IssueLink" />
    <br /><br />
    <uc1:IssueDate runat="server" ID="IssueDate" />
    <br /><br />

    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" DataKeyNames="NoteID" 
        OnRowUpdated="gv1_RowUpdated" CssClass="table table-hover" SelectedRowStyle-CssClass="table-primary"
        DataSourceID="dsrc1">
        <Columns>
            <%--
            <asp:BoundField DataField="NoteID" HeaderText="NoteID" InsertVisible="False" ReadOnly="True" SortExpression="NoteID" />
            --%>
            <asp:CommandField ShowEditButton="False" ShowSelectButton="True" />
            <asp:BoundField DataField="NoteTitleCh" HeaderText="Chinese Title"  />
            <asp:BoundField DataField="NoteTitle" HeaderText="English Title"  />
            <asp:BoundField DataField="OrderNum" HeaderText="Order#"  />
            <%--
            <asp:CheckBoxField DataField="IsDeleted" HeaderText="Delete"  />
            --%>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource ID="dsrc1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByIssueNum" TypeName="ALifeNews.DAL.IssueDataTableAdapters.NotePartTableAdapter" UpdateMethod="Update">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="-1" Name="IssueNum" QueryStringField="IssueNum" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="OrderNum" Type="Int32" />
            <asp:Parameter Name="NoteTitleCh" Type="String" />
            <asp:Parameter Name="NoteTitle" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="Original_NoteID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <br />
    </div>
    <div class="col-md-6">
        <br /><br />

    <asp:FormView ID="fv1" runat="server" 
         DataKeyNames="NoteID" 
        OnItemUpdated="fv1_ItemUpdated"
        OnItemInserted="fv1_ItemInserted"
        DataSourceID="dsrc2"
        CssClass="table" EditRowStyle-CssClass="table">
        <EditItemTemplate>
            <%--
            NoteID:
            <asp:Label ID="NoteIDLabel1" runat="server" Text='<%# Eval("NoteID") %>' />
            <br />
            IssueNum:
            <asp:TextBox ID="IssueNumTextBox" runat="server" Text='<%# Bind("IssueNum") %>' />
            <br />
            --%>
            <asp:HiddenField ID="IssueNumTextBox" runat="server" Value='<%# Bind("IssueNum") %>' />

            Chinese Title:
            <asp:TextBox ID="NoteTitleChTB" runat="server" Text='<%# Bind("NoteTitleCh") %>' Columns="100"/>
            <asp:RequiredFieldValidator ID="rfv1"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTitleChTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Chinese Post:
            <asp:TextBox ID="NoteTextChTB" runat="server" Text='<%# Bind("NoteTextCh") %>' 
                Rows="10" Columns="100"
                Wrap="false" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ID="rfv2"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTextChTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            English Title:
            <asp:TextBox ID="NoteTitleTB" runat="server" Text='<%# Bind("NoteTitle") %>' Columns="100"/>
            <asp:RequiredFieldValidator ID="rfv3"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTitleTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            English Post:
            <asp:TextBox ID="NoteTextTB" runat="server" Text='<%# Bind("NoteText") %>' 
                Rows="10" Columns="100"
                Wrap="false" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ID="rfv4"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTextTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Order#:
            <asp:TextBox ID="OrderNumTB" runat="server" Text='<%# Bind("OrderNum") %>' />
            <asp:RequiredFieldValidator ID="rfv5"  runat="server" ErrorMessage="Required!" ControlToValidate="OrderNumTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rgv1" runat="server" MaximumValue="1000" MinimumValue="0" ErrorMessage="Max:1000. Min:0." 
                Type="Integer" ControlToValidate="OrderNumTB" ForeColor="Red"></asp:RangeValidator>
            <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="OrderNumTB" ValidationExpression="\d+"
                ForeColor="Red" ErrorMessage="Numbers only!"></asp:RegularExpressionValidator>
            <br />
            Delete:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Save" CssClass="btn btn-primary"/>
            &nbsp;
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary"/>
        </EditItemTemplate>
        <InsertItemTemplate>
            <%--
            IssueNum:
            <asp:TextBox ID="IssueNumTextBox" runat="server" Text='<%# Bind("IssueNum") %>' />
            <br />
            --%>
            Chinese Title:
            <asp:TextBox ID="NoteTitleChTB" runat="server" Text='<%# Bind("NoteTitleCh") %>' Columns="100" />
            <asp:RequiredFieldValidator ID="rfv1"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTitleChTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Chinese Post:
            <asp:TextBox ID="NoteTextChTB" runat="server" Text='<%# Bind("NoteTextCh") %>' 
                Rows="10" Columns="100"
                Wrap="false" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ID="rfv2"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTextChTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            English Title:
            <asp:TextBox ID="NoteTitleTB" runat="server" Text='<%# Bind("NoteTitle") %>' Columns="100"/>
            <asp:RequiredFieldValidator ID="rfv3"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTitleTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            English Post:
            <asp:TextBox ID="NoteTextTB" runat="server" Text='<%# Bind("NoteText") %>' 
                Rows="10" Columns="100"
                Wrap="false" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ID="rfv4"  runat="server" ErrorMessage="Required!" ControlToValidate="NoteTextTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            Order#:
            <asp:TextBox ID="OrderNumTB" runat="server" Text='<%# Bind("OrderNum") %>' />
            <asp:RequiredFieldValidator ID="rfv5"  runat="server" ErrorMessage="Required!" ControlToValidate="OrderNumTB"
                ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rgv1" runat="server" MaximumValue="1000" MinimumValue="0" ErrorMessage="Max:1000. Min:0." 
                Type="Integer" ControlToValidate="OrderNumTB" ForeColor="Red"></asp:RangeValidator>
            <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="OrderNumTB" ValidationExpression="\d+"
                ForeColor="Red" ErrorMessage="Numbers only!"></asp:RegularExpressionValidator>
            <br />
            Delete:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Save" CssClass="btn btn-primary" />
            &nbsp;
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary" />
        </InsertItemTemplate>
        <ItemTemplate>

            Chinese Title:
            <asp:Label ID="NoteTitleChLabel" runat="server" Text='<%# ALifeNews.Helper.Tools.AddBoldUnderLine(Eval("NoteTitleCh").ToString()) %>' />
            <br />
            Chinese Post:<br />
            <asp:Label ID="NoteTextChLabel" runat="server" Text='<%# ALifeNews.Helper.Tools.ConvertToHtml(Eval("NoteTextCh").ToString()) %>' />
            <br /><br />
            English Title:
            <asp:Label ID="NoteTitleLabel" runat="server" Text='<%# ALifeNews.Helper.Tools.AddBoldUnderLine(Eval("NoteTitle").ToString()) %>' />
            <br />
            English Post:<br />
            <asp:Label ID="NoteTextLabel" runat="server" Text='<%# ALifeNews.Helper.Tools.ConvertToHtml(Eval("NoteText").ToString()) %>' />
            <br /><br />
            Order#:
            <asp:Label ID="OrderNumLabel" runat="server" Text='<%# Bind("OrderNum") %>' />
            <br />
            Delete:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' Enabled="false" />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
            <%--&nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />--%>
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New Post" CssClass="btn btn-primary" />
        </ItemTemplate>
        <EmptyDataTemplate>
            Select a post to edit or create a new post.
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New Post" CssClass="btn btn-primary" />
        </EmptyDataTemplate>
    </asp:FormView>

    <asp:ObjectDataSource ID="dsrc2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByNoteID" TypeName="ALifeNews.DAL.IssueDataTableAdapters.NoteTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_NoteID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:QueryStringParameter Name="IssueNum" Type="Int32" QueryStringField="IssueNum" DefaultValue="-1" />
            
            <asp:Parameter Name="OrderNum" Type="Int32" />
            <asp:Parameter Name="NoteTitleCh" Type="String" />
            <asp:Parameter Name="NoteTextCh" Type="String" />
            <asp:Parameter Name="NoteTitle" Type="String" />
            <asp:Parameter Name="NoteText" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="gv1" DefaultValue="-1" Name="NoteID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IssueNum" Type="Int32" />
            <asp:Parameter Name="OrderNum" Type="Int32" />
            <asp:Parameter Name="NoteTitleCh" Type="String" />
            <asp:Parameter Name="NoteTextCh" Type="String" />
            <asp:Parameter Name="NoteTitle" Type="String" />
            <asp:Parameter Name="NoteText" Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="Original_NoteID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>

    <br />
    <hr />
    Order#: Order# is a number (integer) from 0 to 1000 for sorting purpose. "0" will bring a post to the top. "1000" will bring a post to the bottom. 
    <br />
  </div>

  </div>
    <hr />
    Markup Tag Usage:
    (Use the following markup tags in a post to create bold text, underlined text, or hyperlinked text.)
    <table border="1">
        <tr>
            <td><b>Markup Tag</b></td>
            <td><b>Purpose</b></td>
            <td><b>Example</b></td>
            <td><b>Result</b></td>
        </tr>
        <tr>
            <td><br />[b] [/b]<br /><br /></td>
            <td>Bold text</td>
            <td>[b]text[/b]</td>
            <td><b>text</b></td>
        </tr>
        <tr>
            <td><br />[u] [/u]<br /><br /></td>
            <td>Underlined text</td>
            <td>[u]text[/u]</td>
            <td><u>text</u></td>
        </tr>
        <tr>
            <td><br />[b][u] [/u][/b]<br /><br /></td>
            <td>Bold and underlined text</td>
            <td>[b][u]text[/u][/b]</td>
            <td><b><u>text</u></b></td>
        </tr>
        <tr>
            <td><br />[a] [/a]<br /><br /></td>
            <td>Hyperlinked text <br /> (must put http://... or https://...)</td>
            <td>[a]http://google.com[/a]</td>
            <td><a href="http://google.com" target="_blank">http://google.com</a></td>
        </tr>
        <tr>
            <td><br />[a] [/a][n] [/n]<br /><br /></td>
            <td>Hyperlinked text with a name <br />(must put http://... or https://...)</td>
            <td>[a]http://google.com[/a][n]Search Engine[/n]</td>
            <td><a href="http://google.com" target="_blank">Search Engine</a></td>
        </tr>
        <tr>
            <td><br />[e] [/e]<br /><br /></td>
            <td>Email</td>
            <td>[e]user@mail.com[/e]</td>
            <td><a href="mailto:user@mail.com" target="_blank">user@mail.com</a></td>
        </tr>
        <tr>
            <td><br />[e] [/e][n] [/n]<br /><br /></td>
            <td>Email with a name</td>
            <td>[e]user@mail.com[/e][n]John Doe[/n]</td>
            <td><a href="mailto:user@mail.com" target="_blank">John Doe</a></td>
        </tr>
        <tr>
            <td><br />&amp;nbsp;<br /><br /></td>
            <td>Extra space</td>
            <td>Wide &amp;nbsp; &amp;nbsp; &amp;nbsp; &amp;nbsp;Space</td>
            <td>Wide &nbsp; &nbsp; &nbsp; &nbsp;Space</td>
        </tr>
        <tr>
            <td><br />[br]<br /><br /></td>
            <td>Line break</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td><br />[i][w:200][h:50][alt:alt-text]image-url[/i]<br /><br /></td>
            <td>Embed an image</td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>

</asp:Content>
