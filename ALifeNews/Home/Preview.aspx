<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preview.aspx.cs" Inherits="ALifeNews.Home.Preview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title></title>
    <link href="~/Content/bootstrap.css" rel="stylesheet"/>
    <link href="~/Content/Site.css" rel="stylesheet"/>
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
</head>
<body>
    
   
<div class="row">
    <div class="col-md-1"></div>
    <div class="col-md-10">
        <h5> Newsletter Published Date: <br />
            <b><asp:Literal ID="ltrIssueDate" runat="server"></asp:Literal></b>
        </h5>
        <br />
    </div>
    <div class="col-md-1"></div>
</div>

<!-- Reading Plan -->

<div class="row">
    <div class="col-md-1"></div>
    <div class="col-md-5">


        <div class="card bg-secondary mb-3" style="max-width: 20rem;">
          <div class="card-header">
            <h5 class="card-title">
              <b>Bible Reading Plan (Ch)</b>
            </h5>
          </div>
          <div class="card-body">
    
            <p class="card-text">
                <b>Week #: <asp:Literal ID="ltrIssueWkCh" runat="server"></asp:Literal></b><br />
                <b>Date</b> &nbsp;&nbsp;<b>Chapter</b><br />
                <!--Start_Chinese_Verses-->
                <asp:Literal ID="ltrChBibleVerses" runat="server"></asp:Literal>
                <!--End_Chinese_Verses-->
            </p>
          </div>
        </div>

    </div>
    <div class="col-md-5">

        <div class="card bg-secondary mb-3" style="max-width: 20rem;">
          <div class="card-header">
            <h5 class="card-title">
              <b>Bible Reading Plan (En)</b>
            </h5>
          </div>
          <div class="card-body">

            <p class="card-text">
                <b>Week #:<asp:Literal ID="ltrIssueWk" runat="server"></asp:Literal> </b><br />
                <b>Date</b> &nbsp;&nbsp;<b>Chapter</b><br />
                <!--Start_English_Verses-->
                <asp:Literal ID="ltrBibleVerses" runat="server"></asp:Literal>
                <!--End_English_Verses-->
            </p>
          </div>
        </div>

    </div>
    <div class="col-md-1"></div>
</div>

<!-- Activities -->

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <h4>Activities</h4>
        </div>
        <div class="col-md-1"></div>
    </div>
                            

    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-5">
            <!--Start_Chinese_Memo-->
            <asp:Literal ID="ltrChMemo" runat="server"></asp:Literal>
            <!--End_Chinese_Memo-->
        </div>
        <div class="col-md-5">
            <!--Start_English_Memo-->
            <asp:Literal ID="ltrMemo" runat="server"></asp:Literal>
            <!--End_English_Memo-->
        </div>
        <div class="col-md-1"></div>
    </div>
 
       
<!--Activities Advertisement-->

<asp:Literal ID="ltrPosters" runat="server"></asp:Literal>


        <%--

    Topic:       <asp:Literal ID="ltrTopic" runat="server"></asp:Literal>

    Speaker:     <asp:Literal ID="ltrSpeaker" runat="server"></asp:Literal> 

    Scriptures： <asp:Literal ID="ltrChapters" runat="server"></asp:Literal>

        --%>

<!-- Fellowship This Week -->
       
<div class="row align-items-md-stretch">
    <div class="col-md-1"></div>
    <div class="col-md-10">
    <div class="h-100 p-5 bg-light border rounded-3">
        <h2>Fellowship This Week</h2>
        <p>

            <!--Discussion Questions -->            
            <asp:Literal ID="ltrQuestions" runat="server"></asp:Literal>

        </p>
    </div>
    </div>
    <div class="col-md-1"></div>
</div>

<div>&nbsp;</div>

<!-- Volunteers Schedule -->

<div class="row align-items-md-stretch">
    <div class="col-md-1"></div>
    <div class="col-md-10">
    <div class="h-100 p-5 bg-light border rounded-3">
        <h2>Volunteers Schedule</h2>
        <table class="table">
            <tr>
                <td>
                    Date:
                </td>
                <td>
						    <asp:Literal ID="ltrDateNum1" runat="server"></asp:Literal>
                </td>
                <td>
                            <asp:Literal ID="ltrDateNum2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    Speaker:
                </td>
                <td>
                            <asp:Literal ID="ltrSpeaker1" runat="server"></asp:Literal>
                </td>
                <td>
                            <asp:Literal ID="ltrSpeaker2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    Praise:
                </td>
                <td>
                            <asp:Literal ID="ltrWorship1" runat="server"></asp:Literal>
                </td>
                <td>
                            <asp:Literal ID="ltrWorship2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    Presider:
                </td>
                <td>
                            <asp:Literal ID="ltrPresider1" runat="server"></asp:Literal>
                </td>
                <td>
			                <asp:Literal ID="ltrPresider2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                   Dinner Chefs:
                </td>
                <td>
                            <asp:Literal ID="ltrCooking1" runat="server"></asp:Literal>
                </td>
                <td>
                            <asp:Literal ID="ltrCooking2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr>
                <td>
                    Clean-up:
                </td>
                <td>
			                <asp:Literal ID="ltrCleanup1" runat="server"></asp:Literal>
                </td>
                <td>
			                <asp:Literal ID="ltrCleanup2" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>

        
    </div>
    </div>
    <div class="col-md-1"></div>
</div>

<div>&nbsp;</div>

<!-- Photo Gallery -->

<div class="row align-items-md-stretch">
    <div class="col-md-1"></div>
    <div class="col-md-10">
        <div class="h-100 p-5 bg-light border rounded-3">
            <h2>Photo Gallery</h2>

                
                <!--Photo1 -->
                <asp:Literal ID="ltrPhoto1" runat="server"></asp:Literal>
                &nbsp;
                <!--Photo2 -->
                <asp:Literal ID="ltrPhoto2" runat="server"></asp:Literal>
                <br /><br />
                           
                <!--Photo3 -->
                <asp:Literal ID="ltrPhoto3" runat="server"></asp:Literal>
                &nbsp;
                          
                <!--Photo4 -->
                <asp:Literal ID="ltrPhoto4" runat="server"></asp:Literal>
           
        </div>
    </div>
    <div class="col-md-1"></div>
</div>

                    

    
</body>
</html>
