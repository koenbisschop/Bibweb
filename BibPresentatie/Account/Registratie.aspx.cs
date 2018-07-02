using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;
using BibDomain.Business;

namespace Bibweb.Account
{
    public partial class Registratie : System.Web.UI.Page
    {

        protected void btnNieuweGebruiker_Click(object sender, EventArgs e)
        {
            if (paswoord.Value == confirmPaswoord.Value)
            {
                try
                {
                    Controller c = (Controller)Session["Controller"];
                    BibDomain.Business.Lid lid = (BibDomain.Business.Lid) GebruikerBuilder.BuildGebruiker(gebruikersnaam.Value, paswoord.Value, voornaam.Value, achternaam.Value, Rol.Lid);
                    FormsAuthentication.RedirectFromLoginPage(lid.Achternaam, false);
                }
                catch (Exception exception)
                {
                    foutboodschap.Text = exception.Message;
                }
            }
            else
            {
                foutboodschap.Text = "De paswoorden komen niet overeen.";
            }
        }

   

       
     
    }
}