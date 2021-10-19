using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;
using Security;
using System.Web.Security;
using System.Resources;
using TypeEnumerator;



namespace RevNetwork
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public UserInfo m_usriCurrent = new UserInfo();
        public string m_strUserRoleTitle = string.Empty;

        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;

            if (requestCookie != null
            && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };

                if (FormsAuthentication.RequireSSL &&
                Request.IsSecureConnection)
                    responseCookie.Secure = true;

                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }



        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;

                ViewState[AntiXsrfUserNameKey] =
                Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] !=
                (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti - XSRF token failed.");
                }
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["UserInfo"] != null)
            {
                m_usriCurrent = UserInfo.GetUserInfo();

                ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx"));

                if (UserInfo.GetUserInfo().IsGroupAdmin)
                {
                    m_strUserRoleTitle = resxSet.GetString(AdminRoleEnumerator.GetEnumByKey(m_usriCurrent.Role).StrResxKey);
                    parentMenuDashboard.Visible = true;
                    //parentMenuContact.Visible = true;
                    //parentMenuMembership.Visible = true;
                    //parentMenuWallet.Visible = true;
                    parentMenuUser.Visible = true;
                    //parentMenuUser.Visible = true;
                    //parentMenuSetup.Visible = true;
                    //childMenuAgentPerformanceReport.Visible = true;
                    //childMenuBrachPerformanceReport.Visible = true;
                }
                else if (UserInfo.GetUserInfo().IsUserAdmin)
                {
                    m_strUserRoleTitle = resxSet.GetString(AdminRoleEnumerator.GetEnumByKey(m_usriCurrent.Role).StrResxKey);
                    parentMenuDashboard.Visible = true;
                    //parentMenuContact.Visible = false;
                    //parentMenuMembership.Visible = false;
                    //parentMenuWallet.Visible = false;
                    parentMenuUser.Visible = false;
                    //parentMenuUser.Visible = false;
                    //parentMenuSetup.Visible = false;
                    //childMenuAgentPerformanceReport.Visible = false;
                    //childMenuBrachPerformanceReport.Visible = false;
                }
                else
                {
                    m_strUserRoleTitle = string.Empty;
                    parentMenuDashboard.Visible = false;
                    //parentMenuContact.Visible = false;
                    //parentMenuMembership.Visible = false;
                    //parentMenuWallet.Visible = false;
                    parentMenuUser.Visible = false;
                    //parentMenuUser.Visible = false;
                    //parentMenuSetup.Visible = false;
                    //childMenuAgentPerformanceReport.Visible = false;
                    //childMenuBrachPerformanceReport.Visible = false;
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }



        protected void lbtLogoutDesktop_Click(object sender, EventArgs e)
        {
            logout();
        }



        protected void lbtLogoutMobile_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void logout()
        {
            try
            {
                HttpContext.Current.Session["UserInfo"] = null;
            }
            catch (Exception ex)
            {
                Common.LogToFile(ex.Message.ToString() + ex.StackTrace.ToString());

                Page pgReference = (Page)HttpContext.Current.Handler;

                ScriptManager.RegisterClientScriptBlock(pgReference, pgReference.GetType(), "PromptMsg", "alert('" + Common.FormatScriptValue(ex.Message) + "')", true);
            }
            finally
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Redirect("~/Admin/Default.aspx", false);
                //FormsAuthentication.RedirectToLoginPage("");
                //FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}