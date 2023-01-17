using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALifeNews.Helper
{
    public class Html
    {
        public static string GetPosts(int issueNum, Helper.Constants.LanguageType language)
        {
            DAL.IssueDataTableAdapters.NoteTableAdapter nta = new DAL.IssueDataTableAdapters.NoteTableAdapter();
            DAL.IssueData.NoteDataTable ndt = nta.GetDataByIssueNum(issueNum);
            string html = "";

            string[] colors = { "primary", "success", "danger", "warning", "info" };

            for(int i = 0; i<ndt.Rows.Count; i++)
            {
                html += "<div class=\"card border-" + colors[ i % colors.Length] + " mb-3\" style=\"max-width:20rem; \"> \n";
                html += "  <div class=\"card-header\"><b> \n";
                if (language == Constants.LanguageType.English)
                    html += ndt[i].NoteTitle;
                else
                    html += ndt[i].NoteTitleCh;

                html += "\n  </b></div> \n";
                html += "  <div class=\"card-body\"> \n";
                html += "    <p class=\"card-text\"> \n";

                if (language == Constants.LanguageType.English)
                    html += Tools.ConvertToHtml(ndt[i].NoteText);
                else
                    html += Tools.ConvertToHtml(ndt[i].NoteTextCh);
                html += "\n    </p> \n";
                html += "  </div> \n";
                html += "</div> \n";
            }

            return (html);
        }

        public static string GetIssueDate(int issueNum)
        {
            string html = "";

            DAL.IssueDataTableAdapters.IssueAdminTableAdapter iata = new DAL.IssueDataTableAdapters.IssueAdminTableAdapter();
            DAL.IssueData.IssueAdminDataTable iadt = iata.GetDataByIssueNum(issueNum);
            if(iadt.Rows.Count>0)
            {
                html += "Issue#: " + issueNum.ToString() + " | Year: " + iadt[0].IssueYear.ToString() + " | Week#: " +
                    iadt[0].IssueWeek.ToString() + " | Date: " + iadt[0].IssueMonth.ToString() + "/" + iadt[0].IssueDay.ToString();
            }

            return (html);
        }
    }
}