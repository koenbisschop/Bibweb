using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Medewerkers
{
    public partial class LidInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailsView1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {

        }
        
        
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
           int LidId = Convert.ToInt32(DropDownList1.SelectedValue);
           Controller _controller = (Controller)Session["Controller"];
            BibDomain.Business.Lid geselecteerd = (BibDomain.Business.Lid) _controller.GetLeden().Find(l => l.Id == LidId);
            List<BibDomain.Business.Lid> geselecteerdLijst = new List<BibDomain.Business.Lid>();
            geselecteerdLijst.Add(geselecteerd);
            DataList1.DataSource = geselecteerdLijst;
            DataList1.DataBind();
        }



    }
}