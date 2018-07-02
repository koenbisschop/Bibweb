using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;
using System.Web.Security;

namespace Bibweb
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //public event RoleManagerEventHandler GetRoles;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Controller c = (Controller)Session["Controller"];
            c.Afmelden();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Account/Login.aspx");
        }
    }
}