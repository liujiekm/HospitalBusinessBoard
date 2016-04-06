using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HBB.Web
{
    public partial class Content : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var user = HttpContext.Current.GetOwinContext().Authentication.User;
            //if (!user.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("Login.aspx",true);
            //}
        }
    }
}