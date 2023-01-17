using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews.Home
{
    public partial class EditPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int issueNum, orderNum, width, height;
            string url;
            url = tbURL.Text.Trim();
            if (url.Length > 7)
            {
                if (int.TryParse(Request["IssueNum"], out issueNum))
                {
                    if (!int.TryParse(tbHeight.Text, out height)) { height = 0; }
                    if (!int.TryParse(tbWidth.Text, out width)) { width = 0; }
                    if (!int.TryParse(tbOrderNum.Text, out orderNum)) { orderNum = 0; }

                    DAL.IssueDataTableAdapters.PhotoTableAdapter phta = new DAL.IssueDataTableAdapters.PhotoTableAdapter();
                    phta.Insert(issueNum, url, width, height, false, orderNum);
                    gv1.DataBind();
                    tbURL.Text = "";
                }
                else
                {

                    //show failed message.
                }
            }
        }
    }
}