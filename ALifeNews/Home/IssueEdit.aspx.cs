using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews.Home
{
    public partial class IssueEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int issueNum;
                if (int.TryParse(Request["IssueNum"], out issueNum))
                {
                    ltrMemo.Text = Helper.Html.GetPosts(issueNum, Helper.Constants.LanguageType.English);
                    ltrChMemo.Text = Helper.Html.GetPosts(issueNum, Helper.Constants.LanguageType.Chinese);
                }

                if((this.Master as SiteMaster).IssueNumReadOnly())
                {
                    lnkPost.Text = "Posts";
                    lnkPhoto.Text = "Photos";

                    lnkPost.Enabled = false;
                    lnkPhoto.Enabled = false;
                }

                Page.DataBind();

            }
        }
    }
}