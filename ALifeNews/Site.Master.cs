using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews
{
    public partial class SiteMaster : MasterPage
    {
        protected bool _issueNumExists = false;
        protected bool _issueNumReadOnly = true;

        protected override void OnInit(EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                int issueNum;
                if (Request.QueryString["IssueNum"] != null)
                {
                    if (int.TryParse(Request["IssueNum"], out issueNum))
                    {
                        DAL.IssueDataTableAdapters.IssueAdminTableAdapter iata = new DAL.IssueDataTableAdapters.IssueAdminTableAdapter();
                        DAL.IssueData.IssueAdminDataTable iadt = iata.GetDataByIssueNum(issueNum);

                        if (iadt.Rows.Count > 0)
                        {
                            if (iadt[0].IsDeleted == false)
                            {
                                _issueNumExists = true;
                            }
                            else
                            {
                                Response.Redirect("~/Home/IssueList.aspx");
                            }
                            if (iadt[0].IssueReadOnly == false)
                            {
                                _issueNumReadOnly = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/Home/IssueList.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Home/IssueList.aspx");
                    }
                }
            }

            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public bool IssueNumExists()
        {

            return (_issueNumExists);
        }

        public bool IssueNumReadOnly()
        {

            return (_issueNumReadOnly);
        }
    }
}