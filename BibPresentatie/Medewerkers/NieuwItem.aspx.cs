using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Medewerkers
{
    public partial class Nieuw_item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNieuwItem_Click(object sender, EventArgs e)
        {
            try
            {
                Controller c = (Controller)Session["Controller"];
                string soort = soortDrager.SelectedValue;
                DragerType drager = soort == "boek" ? DragerType.Boek : DragerType.CD;
                string strTitel = this.titel.Text;
                ItemBuilder.BuildItem(strTitel, drager);
                //this.titel.Text = "";
                boodschap.Text = "item toegevoegd";
                this.titel.AutoPostBack= true;
            }
            catch (Exception exception)
            {
                boodschap.Text = exception.Message;
            }

        }

        protected void titel_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            boodschap.Text = "";
            tb.AutoPostBack = false;
        }
    }
}