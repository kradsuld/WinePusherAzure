using System;
using System.Web.Security;
using WinePusher.BusinessLogic;
using WinePusher.Models;

namespace WinePusher
{
    public partial class EditRound : System.Web.UI.Page
    {
        private int _roundId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            _roundId = Convert.ToInt32(Request.QueryString["RoundId"]);

            RoundHandler rh = new RoundHandler();
            //Round round = rh.GetRound(_roundId);

            if (!IsPostBack)
            {
                //ddWineTypes.SelectedValue
                //tbWineName.Text = 
                //tbStore.Text =
                //tbUrl.Text = 
                //tbWinePrice.Text = 
                //tbCost.Text = 
                //ddStatus.SelectedValue =
            }
        }

        protected void btnSaveRound_Click(object sender, EventArgs e)
        {
            //TODO
            WineHandler wh = new WineHandler();
            int wineId = wh.CreateWine(ddWineTypes.SelectedValue,
                                       tbWineName.Text,
                                       Convert.ToDecimal(tbWinePrice.Text),
            tbStore.Text,
            tbUrl.Text);

            RoundHandler rh = new RoundHandler();
            rh.CreateRound(wineId,
                           DateTime.Now,
                           Convert.ToDecimal(tbCost.Text),
                           "A");

            Response.Redirect("WinePusher.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Request.UrlReferrer.ToString());
            Response.Redirect("WinePusher.aspx");
        }
    }
}