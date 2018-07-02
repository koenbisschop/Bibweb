using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;
namespace Bibweb
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller c = (Controller)Session["Controller"];
            if (c.CurrentUser != null)
                switch (c.CurrentUser.Rol)
                {
                    case Rol.Lid:
                        Response.Redirect("~/Leden/Zoekpagina.aspx");
                        break;
                    case Rol.Medewerker:
                        Response.Redirect("~/Medewerkers/BeheerItem.aspx");
                        break;
                    default:
                        break;
                }
        }
    }
}