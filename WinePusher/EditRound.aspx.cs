using System;
using System.Web.Security;
using WinePusher.BusinessLogic;
using WinePusher.Models;

namespace WinePusher
{
    public partial class EditRound : System.Web.UI.Page
    {
        private int _roundId;
        private int _wineId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            _roundId = Convert.ToInt32(Request.QueryString["RoundId"]);

            RoundHandler rh = new RoundHandler();
            Round round = rh.GetRound(_roundId);

            _wineId = round.WineId;

            if (!Page.IsPostBack)
            {
                ddWineTypes.SelectedValue = round.WineType;
                tbWineName.Text = round.WineName;
                tbStore.Text = round.Store;
                tbUrl.Text = round.Url;
                tbWinePrice.Text = round.WinePrice.ToString("0.00");
                tbCost.Text = round.Cost.ToString("0.00");
                ddStatus.SelectedValue = round.Status;
            }
        }

        protected void btnSaveRound_Click(object sender, EventArgs e)
        {
            WineHandler wh = new WineHandler();
            wh.UpdateWine(_wineId,
                ddWineTypes.SelectedValue,
                tbWineName.Text,
                tbStore.Text,
                tbUrl.Text,
                Convert.ToDecimal(tbWinePrice.Text));

            RoundHandler rh = new RoundHandler();
            rh.UpdateRound(_roundId,
                           Convert.ToDecimal(tbCost.Text),
                           ddStatus.SelectedValue);

            Response.Redirect("WinePusher.aspx");
        }
        protected void btnDeleteRound_Click(object sender, EventArgs e)
        {
            RoundHandler rh = new RoundHandler();
            rh.UpdateRound(_roundId,
                           "D");

            Response.Redirect("WinePusher.aspx");
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("WinePusher.aspx");
        }
    }
}