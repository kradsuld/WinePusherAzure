using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using WinePusher.BusinessLogic;
using WinePusher.Models;

namespace WinePusher
{
    public partial class CreateOrder : System.Web.UI.Page
    {
        private int _roundId;
        private decimal _roundCost;
        private decimal _winePrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            _roundId = Convert.ToInt32(Request.QueryString["RoundId"]);

            if (!IsPostBack)
            {
                MemberHandler mh = new MemberHandler();
                ddMembers.DataSource = mh.ListMembers();
                ddMembers.DataBind();

                ddMembers.Items.Insert(0, new ListItem("Vælg medlem", "NA"));
                ddMembers.SelectedIndex = 0;
            }

            RoundHandler rh = new RoundHandler();
            Wine wine = rh.GetRoundWine(_roundId);
            _winePrice = (decimal)wine.Price;

            lbloWineName.Text = wine.Name;
            lbloStore.Text = wine.Store;
            lbloPrice.Text = Convert.ToString(_winePrice);
            lbloTotalWinePrice.Text = GetTotalWinePrice(Convert.ToInt32(ddBottles.SelectedValue));

            _roundCost = rh.GetRoundCostPerOrder(_roundId);
            lbloTotalAmount.Text = GetTotalOrderAmount(Convert.ToInt32(ddBottles.SelectedValue));
            lbloCost.Text = _roundCost.ToString("0.00");
        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            OrderHandler oh = new OrderHandler();
            oh.CreateOrder(Convert.ToInt16(_roundId), 
                           Convert.ToInt16(ddMembers.SelectedValue), 
                           Convert.ToInt16(ddBottles.SelectedValue), 
                           "N", 
                           "N", 
                           "A");

            Response.Redirect("ListOrders.aspx?RoundId=" + _roundId);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListOrders.aspx?RoundId=" + _roundId);
        }
        protected void ddBottles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbloTotalWinePrice.Text = GetTotalWinePrice(Convert.ToInt32(ddBottles.SelectedValue));
            lbloTotalAmount.Text = GetTotalOrderAmount(Convert.ToInt32(ddBottles.SelectedValue));
        }
        private string GetTotalWinePrice(int bottles)
        {            
            return ((decimal)_winePrice * bottles).ToString("0.00");
        }
        private string GetTotalOrderAmount(int bottles)
        {
            return (((decimal)_winePrice * bottles) + _roundCost).ToString("0.00");
        }
    }
}