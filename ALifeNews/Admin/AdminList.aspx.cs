using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALifeNews.DAL;


namespace ALifeNews.Admin
{
    public partial class AdminList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // ALifeNews.DAL.IssueDataTableAdapters.IssueAdminTableAdapter
            if(!Page.IsPostBack)
            {
                gv1.PageIndex = Int32.MaxValue;
            }
        }

        protected void fv1_ItemUpdated(Object sender, FormViewUpdatedEventArgs e)
        {
            gv1.DataBind();

        }

        protected void gv1_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
        {
            fv1.DataBind();
        }

        protected void fv1_ItemInserted(Object sender, FormViewInsertedEventArgs e)
        {
            gv1.DataBind();
        }
    }

}