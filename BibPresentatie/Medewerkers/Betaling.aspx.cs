using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;

namespace Bibweb.Medewerkers
{
    public partial class Betaling : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller _controller = (Controller)Session["Controller"];
            if (!IsPostBack) { 
                DropDownList1.DataTextField = "Achternaam";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataSource = _controller.GetLeden();
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = 0;
                ToonSaldo();
            }
        }

        protected void btnInnen_Click(object sender, EventArgs e)
        {
            Controller _controller = (Controller)Session["Controller"];
            Int32 lidId = Convert.ToInt32(DropDownList1.SelectedValue);
            BibDomain.Business.Lid lid = (BibDomain.Business.Lid)_controller.GetLeden().Find(l => l.Id == lidId);

            decimal saldo = Convert.ToDecimal(lblSaldo.Text);
            decimal betaald = Convert.ToDecimal(txtBetaald.Text);
            decimal terug;
            //bewaar nieuwe saldo
            terug = _controller.Afrekenen(lidId, betaald);
            //uitvoer
            lblTerug.Text = terug.ToString();
            lblSaldo.Text = lid.Saldo.ToString();
            txtBetaald.Text = 0.0M.ToString();
        }

        protected void ToonSaldo() 
        {
            Controller _controller = (Controller)Session["Controller"];
            Int32 lidId = Convert.ToInt32(DropDownList1.SelectedValue);
            BibDomain.Business.Lid lid = (BibDomain.Business.Lid)_controller.GetLeden().Find(l => l.Id == lidId);
            if (lid != null)
                lblSaldo.Text = lid.Saldo.ToString();
            else
                lblSaldo.Text = "***";
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToonSaldo();
        }


    }
}