using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb
{
    public partial class LidSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["Controller"];
            if (c != null) 
            {
                Gebruiker user = c.CurrentUser;
                if (user == null)
                {
                    Server.Transfer("~/Account/Login.aspx");
                }
                else
                {
                    if (user.GetType() != typeof(BibDomain.Business.Lid))
                    {
                        Server.Transfer("~/Account/Login.aspx");
                    }
                }
            }
        }
    }
}