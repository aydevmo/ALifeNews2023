using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews.Home
{
    public partial class IssueDate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int issueNum;
                if (int.TryParse(Request["IssueNum"], out issueNum))
                {
                    ltr1.Text = Helper.Html.GetIssueDate(issueNum);
                }
            }
        }
    }
}