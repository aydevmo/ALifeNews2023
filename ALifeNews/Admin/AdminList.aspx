<%@ Page Title="" Language="C#" MasterPageFile="~/AdmMaster.Master" AutoEventWireup="true" CodeBehind="AdminList.aspx.cs" Inherits="ALifeNews.Admin.AdminList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">

    <br />

    <asp:HyperLink runat="server" 
        NavigateUrl="~/Home/IssueList.aspx"
      Text="Issue List" Target="_blank" CssClass="btn btn-primary" />
    <br /><br />

<asp:GridView runat="server" id="gv1" AllowPaging="True" AllowSorting="True" CssClass="table"
    PageSize="5" SelectedRowStyle-CssClass="table-primary"
    AutoGenerateColumns="False" DataKeyNames="IssueID" DataSourceID="ds1">
    <Columns>
        <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
        <asp:BoundField DataField="IssueID" HeaderText="IssueID" ReadOnly="True" SortExpression="IssueID" />
        <asp:BoundField DataField="IssueNum" HeaderText="IssueNum" SortExpression="IssueNum" />
        <asp:BoundField DataField="IssueWeek" HeaderText="Week" SortExpression="IssueWeek" />
        <asp:BoundField DataField="IssueYear" HeaderText="Year" SortExpression="IssueYear" />
        <asp:BoundField DataField="IssueMonth" HeaderText="Month" SortExpression="IssueMonth" />
        <asp:BoundField DataField="IssueDay" HeaderText="Day" SortExpression="IssueDay" />
        <asp:CheckBoxField DataField="IssueReadOnly" HeaderText="IsReadOnly" SortExpression="IssueReadOnly" />
        <asp:CheckBoxField DataField="IsDeleted" HeaderText="Deleted" SortExpression="IsDeleted" />
        <asp:TemplateField HeaderText = "">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("IssueNum", "~/Admin/PopulateIssue.aspx?IssueNum={0}") %>'
                    Text='Populate' Target="_blank" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("IssueNum", "~/Home/Preview.aspx?IssueNum={0}") %>'
                    Text='Preview' Target="_blank" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText = "">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# Eval("IssueNum", "~/Admin/MailPage.aspx?IssueNum={0}") %>'
                    Text='Send' Target="_blank" />
            </ItemTemplate>
        </asp:TemplateField>

    </Columns>

</asp:GridView>


<asp:ObjectDataSource runat="server" id="ds1" DeleteMethod="Delete" 
    InsertMethod="Insert" OldValuesParameterFormatString="Original_{0}" SelectMethod="GetData" 
    TypeName="ALifeNews.DAL.IssueDataTableAdapters.IssueAdminTableAdapter" UpdateMethod="Update">
    <DeleteParameters>
        <asp:Parameter Name="Original_IssueID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IssueID" Type="Int32" />
        <asp:Parameter Name="IssueNum" Type="Int32" />
        <asp:Parameter Name="IssueWeek" Type="Int32" />
        <asp:Parameter Name="IssueYear" Type="Int32" />
        <asp:Parameter Name="IssueMonth" Type="Int32" />
        <asp:Parameter Name="IssueDay" Type="Int32" />
        <asp:Parameter Name="IssueReadOnly" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="IssueNum" Type="Int32" />
        <asp:Parameter Name="IssueWeek" Type="Int32" />
        <asp:Parameter Name="IssueYear" Type="Int32" />
        <asp:Parameter Name="IssueMonth" Type="Int32" />
        <asp:Parameter Name="IssueDay" Type="Int32" />
        <asp:Parameter Name="IssueReadOnly" Type="Boolean" />
        <asp:Parameter Name="IsDeleted" Type="Boolean" />
        <asp:Parameter Name="Original_IssueID" Type="Int32" />
    </UpdateParameters>
    </asp:ObjectDataSource>


    <asp:FormView ID="fv1" runat="server" DataKeyNames="IssueID" CssClass="table" 
        OnItemUpdated="fv1_ItemUpdated"
        OnItemInserted="fv1_ItemInserted"
        DataSourceID="ds2">

        <EmptyDataTemplate>
            <asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Add New Issue" CssClass="btn btn-primary" />
        </EmptyDataTemplate>

        <EditItemTemplate>
            IssueID:
            <asp:Label ID="IssueIDLabel1" runat="server" Text='<%# Eval("IssueID") %>' />
            <br />
            IssueNum:
            <asp:TextBox ID="IssueNumTextBox" runat="server" Text='<%# Bind("IssueNum") %>' />
            <br />
            IssueYear:
            <asp:TextBox ID="IssueYearTextBox" runat="server" Text='<%# Bind("IssueYear") %>' />
            <br />
            IssueMonth:
            <asp:TextBox ID="IssueMonthTextBox" runat="server" Text='<%# Bind("IssueMonth") %>' />
            <br />
            IssueDay:
            <asp:TextBox ID="IssueDayTextBox" runat="server" Text='<%# Bind("IssueDay") %>' />
            <br />
            IssueWeek:
            <asp:TextBox ID="IssueWeekTextBox" runat="server" Text='<%# Bind("IssueWeek") %>' />
            <br />
            IssueWeekCh:
            <asp:TextBox ID="IssueWeekChTextBox" runat="server" Text='<%# Bind("IssueWeekCh") %>' />
            <br />
            IssueReadOnly:
            <asp:CheckBox ID="IssueReadOnlyCheckBox" runat="server" Checked='<%# Bind("IssueReadOnly") %>' />
            <br />
            IsDeleted:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' />
            <br />
            IssueSpeaker:
            <asp:TextBox ID="IssueSpeakerTextBox" runat="server" Text='<%# Bind("IssueSpeaker") %>' />
            <br />
            IssueBibleChapter:
            <asp:TextBox ID="IssueBibleChapterTextBox" runat="server" Text='<%# Bind("IssueBibleChapter") %>' />
            <br />
            IssueBibleTopic:
            <asp:TextBox ID="IssueBibleTopicTextBox" runat="server" Text='<%# Bind("IssueBibleTopic") %>' />
            <br />
            IssueGroupQuestions:
            <asp:TextBox ID="IssueGroupQuestionsTextBox" runat="server" TextMode="MultiLine" Rows="10" Columns="100" Wrap="false"
                Text='<%# Bind("IssueGroupQuestions") %>' />
            <br />
            <br />
            Speaker [tab] Presider [tab] Cleanup [tab] Worship [tab] Cooking
            <br />
            Week1Duty: 
            <asp:TextBox ID="Week1DutyTextBox" runat="server" Text='<%# Bind("Week1Duty") %>' 
                 Columns="100"/>
            <br />
            Week2Duty:
            <asp:TextBox ID="Week2DutyTextBox" runat="server" Text='<%# Bind("Week2Duty") %>'
                 Columns="100" />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="btn btn-primary"/>
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary"/>
        </EditItemTemplate>
        <InsertItemTemplate>
            IssueNum:
            <asp:TextBox ID="IssueNumTextBox" runat="server" Text='<%# Bind("IssueNum") %>' />
            <br />
            IssueYear:
            <asp:TextBox ID="IssueYearTextBox" runat="server" Text='<%# Bind("IssueYear") %>' />
            <br />
            IssueMonth:
            <asp:TextBox ID="IssueMonthTextBox" runat="server" Text='<%# Bind("IssueMonth") %>' />
            <br />
            IssueDay:
            <asp:TextBox ID="IssueDayTextBox" runat="server" Text='<%# Bind("IssueDay") %>' />
            <br />
            IssueWeek:
            <asp:TextBox ID="IssueWeekTextBox" runat="server" Text='<%# Bind("IssueWeek") %>' />
            <br />
            IssueWeekCh:
            <asp:TextBox ID="IssueWeekChTextBox" runat="server" Text='<%# Bind("IssueWeekCh") %>' />
            <br />
            IssueReadOnly:
            <asp:CheckBox ID="IssueReadOnlyCheckBox" runat="server" Checked='<%# Bind("IssueReadOnly") %>' />
            <br />
            IsDeleted:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' />
            <br />
            IssueSpeaker:
            <asp:TextBox ID="IssueSpeakerTextBox" runat="server" Text='<%# Bind("IssueSpeaker") %>' />
            <br />
            IssueBibleChapter:
            <asp:TextBox ID="IssueBibleChapterTextBox" runat="server" Text='<%# Bind("IssueBibleChapter") %>' />
            <br />
            IssueBibleTopic:
            <asp:TextBox ID="IssueBibleTopicTextBox" runat="server" Text='<%# Bind("IssueBibleTopic") %>' />
            <br />
            IssueGroupQuestions:
            <asp:TextBox ID="IssueGroupQuestionsTextBox" runat="server"  TextMode="MultiLine" Rows="10" Columns="100" Wrap="false"
                Text='<%# Bind("IssueGroupQuestions") %>' />
            <br />
            <br />
            Speaker [tab] Presider [tab] Cleanup [tab] Worship [tab] Cooking
            <br />
            Week1Duty:
            <asp:TextBox ID="Week1DutyTextBox" runat="server" Text='<%# Bind("Week1Duty") %>' 
                 Columns="100"/>
            <br />
            Week2Duty:
            <asp:TextBox ID="Week2DutyTextBox" runat="server" Text='<%# Bind("Week2Duty") %>' 
                 Columns="100"/>

            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" CssClass="btn btn-primary"/>
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="btn btn-primary"/>
        </InsertItemTemplate>
        <ItemTemplate>
            IssueID:
            <asp:Label ID="IssueIDLabel" runat="server" Text='<%# Eval("IssueID") %>' />
            <br />
            IssueNum:
            <asp:Label ID="IssueNumLabel" runat="server" Text='<%# Bind("IssueNum") %>' />
            <br />
            IssueYear:
            <asp:Label ID="IssueYearLabel" runat="server" Text='<%# Bind("IssueYear") %>' />
            <br />
            IssueMonth:
            <asp:Label ID="IssueMonthLabel" runat="server" Text='<%# Bind("IssueMonth") %>' />
            <br />
            IssueDay:
            <asp:Label ID="IssueDayLabel" runat="server" Text='<%# Bind("IssueDay") %>' />
            <br />
            IssueWeek:
            <asp:Label ID="IssueWeekLabel" runat="server" Text='<%# Bind("IssueWeek") %>' />
            <br />
            IssueWeekCh:
            <asp:Label ID="IssueWeekChLabel" runat="server" Text='<%# Bind("IssueWeekCh") %>' />
            <br />
            IssueReadOnly:
            <asp:CheckBox ID="IssueReadOnlyCheckBox" runat="server" Checked='<%# Bind("IssueReadOnly") %>' Enabled="false" />
            <br />
            IsDeleted:
            <asp:CheckBox ID="IsDeletedCheckBox" runat="server" Checked='<%# Bind("IsDeleted") %>' Enabled="false" />
            <br />
            IssueSpeaker:
            <asp:Label ID="IssueSpeakerLabel" runat="server" Text='<%# Bind("IssueSpeaker") %>' />
            <br />
            IssueBibleChapter:
            <asp:Label ID="IssueBibleChapterLabel" runat="server" Text='<%# Bind("IssueBibleChapter") %>' />
            <br />
            IssueBibleTopic:
            <asp:Label ID="IssueBibleTopicLabel" runat="server" Text='<%# Bind("IssueBibleTopic") %>' />
            <br />
            IssueGroupQuestions:<br />
            <asp:Label ID="IssueGroupQuestionsLabel" runat="server" Text='<%# ALifeNews.Helper.Tools.ConvertToHtml(Eval("IssueGroupQuestions").ToString()) %>' />
            <br />
            Week1Duty:
            <asp:Label ID="Week1DutyLabel" runat="server" Text='<%# Bind("Week1Duty") %>' />
            <br />
            Week2Duty:
            <asp:Label ID="Week2DutyLabel" runat="server" Text='<%# Bind("Week2Duty") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="btn btn-primary"/>
            
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" CssClass="btn btn-primary"/>
        </ItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource ID="ds2" runat="server" InsertMethod="InsertIssue" 
        OldValuesParameterFormatString="Original_{0}" SelectMethod="GetDataByIssueID" 
        TypeName="ALifeNews.DAL.IssueDataTableAdapters.IssueTableAdapter" UpdateMethod="UpdateByIssueID">
        
        <InsertParameters>

            <asp:Parameter Name="IssueNum" Type="Int32" DefaultValue="0"/>
            <asp:Parameter Name="IssueYear" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="IssueMonth" Type="Int32" />
            <asp:Parameter Name="IssueDay" Type="Int32" />
            <asp:Parameter Name="IssueWeek" Type="Int32" />
            <asp:Parameter Name="IssueWeekCh" Type="String" DefaultValue="0"/>
            <asp:Parameter Name="IssueReadOnly" Type="Boolean" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="IssueSpeaker" Type="String" DefaultValue="TBA"/>
            <asp:Parameter Name="IssueBibleChapter" Type="String" DefaultValue="TBA"/>
            <asp:Parameter Name="IssueBibleTopic" Type="String" DefaultValue="TBA"/>
            <asp:Parameter Name="IssueGroupQuestions" Type="String" DefaultValue="TBA"/>
            <asp:Parameter Name="Week1Duty" Type="String" DefaultValue="TBA"/>
            <asp:Parameter Name="Week2Duty" Type="String" DefaultValue="TBA"/>
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="gv1" DefaultValue="0" Name="IssueID" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IssueNum" Type="Int32" />
            <asp:Parameter Name="IssueYear" Type="Int32" />
            <asp:Parameter Name="IssueMonth" Type="Int32" />
            <asp:Parameter Name="IssueDay" Type="Int32" />
            <asp:Parameter Name="IssueWeek" Type="Int32" />
            <asp:Parameter Name="IssueWeekCh" Type="String" />
            <asp:Parameter Name="IssueReadOnly" Type="Boolean" />
            <asp:Parameter Name="IsDeleted" Type="Boolean" />
            <asp:Parameter Name="IssueSpeaker" Type="String" />
            <asp:Parameter Name="IssueBibleChapter" Type="String" />
            <asp:Parameter Name="IssueBibleTopic" Type="String" />
            <asp:Parameter Name="IssueGroupQuestions" Type="String" />
            <asp:Parameter Name="Week1Duty" Type="String" />
            <asp:Parameter Name="Week2Duty" Type="String" />
            <asp:Parameter Name="IssueID" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
