using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using TypeEnumerator;
using System.Web.Security;
using Controller;
using Entity;

namespace RevNetwork
{
    public partial class ContactLanding : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isValid = false;

            if (ContactInterface.GetContactByLoginUserName(UserInfo.GetUserInfo().Username) != null)
            {
                if (UserRoleEnumerator.GetEnumList().Any(x => x.StrKey == UserInfo.GetUserInfo().Role))
                {
                    isValid = true;

                    Response.Redirect("ContactDefault.aspx");
                }
            }

            if(!isValid)
            {
                HttpContext.Current.Session["UserInfo"] = null;

                if (Request.Cookies["UserInfo"] != null)
                {
                    Response.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(-1);
                }

                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}