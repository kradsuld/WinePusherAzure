using System;
using System.Web.Security;
using WinePusher.BusinessLogic;
using WinePusher.Models;

namespace WinePusher
{
    public partial class EditOrder : System.Web.UI.Page
    {
        private int _roundId;
        private decimal _roundCost;
        private decimal _winePrice;
        private int _orderId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            _orderId = Convert.ToInt32(Request.QueryString["OrderId"]);

            OrderHandler oh = new OrderHandler();
            Order order = oh.GetOrder(_orderId);

            _roundId = order.RoundId;
            _winePrice = order.WinePrice;

            RoundHandler rh = new RoundHandler();
            _roundCost = rh.GetRoundCostPerOrder(_roundId);

            if (!IsPostBack)
            {
                lbloMemberName.Text = order.MemberName;
                lbloOrderDate.Text = order.OrderDate.ToString();
                lbloWineName.Text = order.WineName;
                lbloWinePrice.Text = order.WinePrice.ToString();
                lbloWineType.Text = order.WineType;
                ddBottles.SelectedValue = order.Bottles.ToString();
                ddDeliveredMark.SelectedValue = order.Delivered;
                ddPaidMark.SelectedValue = order.Paid;
                
                lbloRoundCost.Text = _roundCost.ToString("0.00");
                lbloOrderAmount.Text = GetTotalOrderAmount(Convert.ToInt32(ddBottles.SelectedValue));
            }
        }

        protected void btnSaveOrder_Click(object sender, EventArgs e)
        {
            OrderHandler oh = new OrderHandler();
            oh.UpdateOrder(_orderId,
                           Convert.ToInt32(ddBottles.SelectedValue),
                           ddDeliveredMark.SelectedValue,
                           ddPaidMark.SelectedValue);

            Response.Redirect("ListOrders.aspx?RoundId=" + _roundId);
        }
        protected void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            OrderHandler oh = new OrderHandler();
            oh.UpdateOrder(_orderId,
                           "D"
                           );

            Response.Redirect("ListOrders.aspx?RoundId=" + _roundId);
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListOrders.aspx?RoundId=" + _roundId);
        }
        protected void ddBottles_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbloOrderAmount.Text = GetTotalOrderAmount(Convert.ToInt32(ddBottles.SelectedValue));
        }
        private string GetTotalOrderAmount(int bottles)
        {
            return (((decimal)_winePrice * bottles) + _roundCost).ToString("0.00");
        }
    }
}