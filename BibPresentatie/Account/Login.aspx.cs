using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void wcAanmelden_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Controller c = (Controller) Session["Controller"];

            if (c.Aanmelden(wcAanmelden.UserName, wcAanmelden.Password)) //geldige aanmelding
            {
                Session["User"] = c.CurrentUser;
                FormsAuthentication.RedirectFromLoginPage(wcAanmelden.UserName, false);
            }
            else
            {
                wcAanmelden.FailureText = "Foutieve aanmelding. Probeer opnieuw!";
            }
        }
    }
}