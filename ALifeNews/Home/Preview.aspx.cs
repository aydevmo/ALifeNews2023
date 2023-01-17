using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALifeNews.Helper;

namespace ALifeNews.Home
{
    public partial class Preview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int issueNum;
                if (! int.TryParse(Request["IssueNum"], out issueNum))
                {
                    issueNum = -1;
                }
                ltrChBibleVerses.Text = Helper.StudyPlan.GetHtmlByIssueNum(issueNum, Constants.LanguageType.Chinese);
                ltrBibleVerses.Text = Helper.StudyPlan.GetHtmlByIssueNum(issueNum, Constants.LanguageType.English);

                DAL.IssueDataTableAdapters.IssueTableAdapter ita = new DAL.IssueDataTableAdapters.IssueTableAdapter();
                DAL.IssueData.IssueDataTable idt = ita.GetDataByIssueNum(issueNum);

                //if an issue is found.
                if(idt.Rows.Count > 0)
                {
                    int year, month, day;
                    DateTime date, nextDate;

                    year = idt[0].IssueYear;
                    month = idt[0].IssueMonth;
                    day = idt[0].IssueDay;
                    date = new DateTime(year, month, day);
                    nextDate = date.AddDays(7);
                    ltrIssueDate.Text = date.ToString("MMM d, yyyy");
                    ltrIssueWkCh.Text = idt[0].IssueWeekCh;
                    ltrIssueWk.Text = idt[0].IssueWeek.ToString();

                    //ltrTopic.Text = idt[0].IssueBibleTopic;
                    //ltrSpeaker.Text = idt[0].IssueSpeaker;
                    //ltrChapters.Text= idt[0].IssueBibleChapter;
                    ltrQuestions.Text = Helper.Tools.ConvertToHtml(idt[0].IssueGroupQuestions);

                    ltrDateNum1.Text = date.ToString("M/d");
                    ltrDateNum2.Text = nextDate.ToString("M/d");

                    string duty1 = idt[0].Week1Duty;
                    string duty2 = idt[0].Week2Duty;

                    string[] duty = duty1.Split('\t');
                    if (duty.Length >= 1) ltrSpeaker1.Text = Helper.Tools.ConvertToHtml(duty[0]);
                    if (duty.Length >= 2) ltrPresider1.Text = Helper.Tools.ConvertToHtml(duty[1]);
                    if (duty.Length >= 3) ltrCleanup1.Text = Helper.Tools.ConvertToHtml(duty[2]);
                    if (duty.Length >= 4) ltrWorship1.Text = Helper.Tools.ConvertToHtml(duty[3]);
                    if (duty.Length >= 5) ltrCooking1.Text = Helper.Tools.ConvertToHtml(duty[4]);

                    duty = duty2.Split('\t');
                    if (duty.Length >= 1) ltrSpeaker2.Text = Helper.Tools.ConvertToHtml(duty[0]);
                    if (duty.Length >= 2) ltrPresider2.Text = Helper.Tools.ConvertToHtml(duty[1]);
                    if (duty.Length >= 3) ltrCleanup2.Text = Helper.Tools.ConvertToHtml(duty[2]);
                    if (duty.Length >= 4) ltrWorship2.Text = Helper.Tools.ConvertToHtml(duty[3]);
                    if (duty.Length >= 5) ltrCooking2.Text = Helper.Tools.ConvertToHtml(duty[4]);

                    DAL.IssueDataTableAdapters.PhotoTableAdapter pta = new DAL.IssueDataTableAdapters.PhotoTableAdapter();
                    DAL.IssueData.PhotoDataTable pdt = pta.GetDataByIssueNum(issueNum);

                    string imgHead = "<img style ='outline:invert;border:0px;padding-bottom:0px;text-decoration:none;vertical-align:bottom;max-width:4032px' width='264' alt='' src='";
                    string imgTail = "'>";

                    if (pdt.Rows.Count >= 1)
                    {
                        ltrPhoto1.Text = imgHead + pdt[0].PhotoURL+imgTail;
                    }

                    if (pdt.Rows.Count >= 2)
                    {
                        ltrPhoto2.Text = imgHead + pdt[1].PhotoURL + imgTail;
                    }

                    if (pdt.Rows.Count >= 3)
                    {
                        ltrPhoto3.Text = imgHead + pdt[2].PhotoURL + imgTail;
                    }

                    if (pdt.Rows.Count >= 4)
                    {
                        ltrPhoto4.Text = imgHead + pdt[3].PhotoURL + imgTail;
                    }

                    DAL.IssueDataTableAdapters.PromotionTableAdapter pmta = new DAL.IssueDataTableAdapters.PromotionTableAdapter();
                    DAL.IssueData.PromotionDataTable pmdt = pmta.GetDataByIssueNum(issueNum);

                    if(pmdt.Rows.Count>0)
                    {
                        string promo = "";

                        for(int i=0;i<pmdt.Rows.Count;i++)
                        {
                            if (i > 0) { promo += "<br>\n"; }

                            string holder = "";
                            holder += "<img src='" + pmdt[i].PMURL + "' alt='" + pmdt[i].Title + "' ";
                            if (pmdt[i].PMWidth > 0)  { holder += "width='" + pmdt[i].PMWidth.ToString() + "' "; }
                            if (pmdt[i].PMHeight > 0) { holder += "height='" + pmdt[i].PMHeight.ToString() + "' "; }
                            holder += ">";

                            if(! String.IsNullOrEmpty(pmdt[i].LinkURL))
                            {
                                holder = "<a href='" + pmdt[i].LinkURL + "' target='_blank'>" + holder + "</a>";
                            }

                            promo += holder;
                        }

                        ltrPosters.Text = promo;
                    }

                    //Posts/Memos are inserted here.
                    ltrMemo.Text = Helper.Html.GetPosts(issueNum, Constants.LanguageType.English);
                    ltrChMemo.Text= Helper.Html.GetPosts(issueNum, Constants.LanguageType.Chinese);
                }

                Page.DataBind();
            }
        }
    }
}