using System;
using System.Web.Security;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WinePusher
{
    public partial class Logon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ValidateUser(object sender, EventArgs e)
        {
            if ((Login1.UserName == "Henrik") && (Login1.Password == "winep"))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
            }
            else
            {
                Login1.FailureText = "Brugernavn og/eller password er forkert.";
            }
        }
    }
}