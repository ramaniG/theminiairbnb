using System;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace TheRooms
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (Business.Business.Instance.AuthenticateAdmin(UserLogin.UserName, UserLogin.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(UserLogin.UserName, UserLogin.RememberMeSet);
            } 
            else if (Business.Business.Instance.AuthenticateStaff(UserLogin.UserName, UserLogin.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(UserLogin.UserName, UserLogin.RememberMeSet);
            }
            else
            {
                UserLogin.FailureText = "Username and/or password is incorrect.";
            }
        }
    }
}