using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews.Admin
{
    public partial class PopulateIssue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            int issueNum, lastIssueNum;
            string result = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + "<br><br>\n";

            if (Request.QueryString["IssueNum"] != null)
            {
                if (int.TryParse(Request.QueryString["IssueNum"], out issueNum))
                {
                    lastIssueNum = issueNum - 1;

                    //Populate posts.

                    result += "Posts: <br>\n";

                    DAL.IssueDataTableAdapters.NoteTableAdapter nta = new DAL.IssueDataTableAdapters.NoteTableAdapter();
                    if (nta.GetCountByIssueNum(issueNum)==0)
                    { 
                        DAL.IssueData.NoteDataTable ndt = nta.GetDataByIssueNum(lastIssueNum);
                        if (ndt.Rows.Count > 0)
                        {
                            for (int i = 0; i < ndt.Rows.Count; i++)
                            {
                                nta.InsertNote(issueNum, ndt[i].OrderNum, ndt[i].NoteTitleCh, ndt[i].NoteTextCh, ndt[i].NoteTitle, ndt[i].NoteText, false);
                                result += "\""+ ndt[i].NoteTitle + " \" is added. <br>\n";
                            }
                        }
                    }
                    else
                    {
                        result += "This issue had existing posts. Action is cancelled. <br>\n";
                    }
                    result += "<br><br>\n";

                    //Populate photos.

                    result += "Photos: <br>\n";

                    DAL.IssueDataTableAdapters.PhotoTableAdapter pta = new DAL.IssueDataTableAdapters.PhotoTableAdapter();
                    if (pta.GetCountByIssueNum(issueNum) == 0)
                    {
                        DAL.IssueData.PhotoDataTable pdt = pta.GetDataByIssueNum(lastIssueNum);
                        if (pdt.Rows.Count > 0)
                        {
                            for (int i = 0; i < pdt.Rows.Count; i++)
                            {
                                pta.Insert(issueNum, pdt[i].PhotoURL, pdt[i].PhotoWidth, pdt[i].PhotoHeight, false, pdt[i].OrderNum);
                                result += "\"" + pdt[i].PhotoURL + " \" is added. <br>\n";
                            }
                        }
                    }
                    else
                    {
                        result += "This issue had existing photos. Action is cancelled. <br>\n";
                    }
                    result += "<br><br>\n";

                    //Populate posters. 

                    result += "Posters: <br>\n";

                    DAL.IssueDataTableAdapters.PromotionTableAdapter pmta = new DAL.IssueDataTableAdapters.PromotionTableAdapter();
                    if (pmta.GetCountByIssueNum(issueNum) == 0)
                    {
                        DAL.IssueData.PromotionDataTable pmdt = pmta.GetDataByIssueNum(lastIssueNum);
                        if (pmdt.Rows.Count > 0)
                        {
                            for (int i = 0; i < pmdt.Rows.Count; i++)
                            {
                                pmta.Insert(issueNum, pmdt[i].Title, pmdt[i].PMURL, pmdt[i].PMWidth, pmdt[i].PMHeight, false, pmdt[i].OrderNum, pmdt[i].LinkURL);
                                result += "\"" + pmdt[i].PMURL + " \" is added. <br>\n";
                            }
                        }
                    }
                    else
                    {
                        result += "This issue had existing posters. Action is cancelled. <br>\n";
                    }
                    result += "<br><br>\n";
                }
            }

            ltrResult.Text = result;
            btnPopulate.Enabled = false;
        }
    }
}