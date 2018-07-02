using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Lid
{
    public partial class ZoekPagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemId = (int) GridView1.SelectedValue;
            Session["itemId"] = itemId;
            //GridView2.DataSource = _controller.GetExemplarenForItem(itemId);
            GridView2.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller _controller = (Controller) Session["Controller"];
            
            int exemplaarId = (int) GridView2.SelectedDataKey[0];
            //ontleen dit exemplaar voor de huidige gebruiker
            BibDomain.Business.Lid lid = (BibDomain.Business.Lid)_controller.CurrentUser;
            Ontlening ontlening = _controller.Ontlenen( (int) lid.Id, exemplaarId, DateTime.Today);
            //Session["_ontlening"] = ontlening;
            Response.Redirect("./Ontlening.aspx");
        }
    }
}