using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ALifeNews.Home
{
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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