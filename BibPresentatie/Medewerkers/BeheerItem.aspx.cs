using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Medewerkers
{
    public partial class NieuwExemplaar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "nieuwExemplaar_click")
            {
                Controller c = (Controller)Session["Controller"];
                int rijNr = Convert.ToInt32(e.CommandArgument);
                int itemId = Int32.Parse(GridView1.Rows[rijNr].Cells[2].Text);
                ExemplaarBuilder.BuildExemplaar(itemId);
                GridView2.DataBind();
            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rijNr = e.RowIndex;
            if (GridView2.Rows[rijNr].Cells[2].Text != OntleenStatus.Beschikbaar.ToString())
            {
                //gebruik eventueel een label om een foutmelding weer te geven
                e.Cancel = true; //weiger door te gaan met de huidige gebeurtenis (dit exemplaar te verwijderen)
            }
        }


    }
}