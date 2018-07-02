using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibDomain.Business;
using System.Data;

namespace Bibweb.Leden
{
    public partial class Ontlening : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                //ipv
                //grvOntleningen.DataSource = _controller.GetOntleningen(lid);
                //grvOntleningen.DataBind();
            }
        }
        private void BindData()
        {
            Controller _controller = (Controller)Session["Controller"];
            BibDomain.Business.Lid lid = _controller.CurrentUser as BibDomain.Business.Lid;

            //deze grid kan niet rechtstreeks via datasource gekoppeld worden
            //we verzamelen hier de gewenste info...
            DataTable dt = new DataTable("ontleningen");

            dt.Columns.Add("exemplaarId", typeof(Int32));
            dt.Columns.Add("titel", typeof(string));
            dt.Columns.Add("Vanaf", typeof(DateTime));

            foreach (BibDomain.Business.Ontlening ontlening in _controller.GetOntleningen(lid.Id))
            {
                DataRow dr = dt.NewRow();
                dr["exemplaarId"] = ontlening.Exemplaar.Id;
                dr["titel"] = ontlening.Exemplaar.Item.Titel;
                dr["Vanaf"] = ontlening.Vanaf;
                dt.Rows.Add(dr);
            }
            //koppel deze datatable aan de gridview
            grvOntleningen.DataSource = dt;
            grvOntleningen.DataBind();
        }
        protected void grvOntleningen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller _controller = (Controller)Session["Controller"];
            int exemplaarId = (Int32)grvOntleningen.SelectedDataKey[0];
            BibDomain.Business.Lid lid = (BibDomain.Business.Lid)_controller.CurrentUser;
            _controller.Terugbrengen(lid, exemplaarId, DateTime.Today);
            BindData();
        }
        protected void grvOntleningen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.EditIndex = e.NewEditIndex;
            BindData();
        }
        
        
        protected void grvOntleningen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            gv.EditIndex = -1;
            BindData();
        }

        protected void grvOntleningen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 rijNr = e.RowIndex;
            GridViewRow gr = grvOntleningen.Rows[rijNr];
            //Int32 exemplaarId = Convert.ToInt32(gr.Cells[1].Text);
            Int32 exemplaarId = Convert.ToInt32(e.Keys["exemplaarId"]);
            Calendar c = (Calendar)gr.FindControl("calVanaf");
            DateTime vanaf = c.SelectedDate;
            Controller _controller = (Controller)Session["Controller"];
            _controller.WijzigOntlening(exemplaarId, vanaf, null);
            gv.EditIndex = -1;
            BindData();

        }
        

    }
}