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
using Controller;

namespace RevNetwork
{
    public partial class ContactMaster : System.Web.UI.MasterPage
    {
        public UserInfo m_usriCurrent = new UserInfo();
        public string m_strUserRoleTitle = string.Empty;
        public string m_strWalletBalance = string.Empty;
        public string m_strPointBalance = string.Empty;

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
            string strCreditBalance = string.Empty;
            
            if (HttpContext.Current.Session["UserInfo"] != null && ((Utility.UserInfo)HttpContext.Current.Session["UserInfo"]).IsContact)
            {
                //PnlHamburger.Visible = true;

                m_usriCurrent = UserInfo.GetUserInfo();
                ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx"));

                if (Session[Constant.SESSION_NAME_QR_TIMER_STATUS] == null || Session[Constant.SESSION_NAME_QR_TIMER_STATUS] as string == "false")
                {                    
                    Session[Constant.SESSION_NAME_CREDIT_BALANCE] = strCreditBalance;

                    m_strWalletBalance = strCreditBalance;
                }
                else
                {
                    m_strWalletBalance = Session[Constant.SESSION_NAME_CREDIT_BALANCE] as string;
                }

                

           

                //if (ContactInfo.GetContactInfo().IsAdmin)
                //{
                //    m_strUserRoleTitle = resxSet.GetString(AdminRoleEnumerator.GetEnumByKey(m_usriCurrent.Role).StrResxKey);
                //    //parentMenuUser.Visible = true;
                //    //parentMenuSetup.Visible = true;
                //    //childMenuAgentPerformanceReport.Visible = true;
                //    //childMenuBrachPerformanceReport.Visible = true;
                //}
                //else if (UserInfo.GetUserInfo().IsAgent)
                //{
                //    m_strUserRoleTitle = resxSet.GetString(AgentRoleEnumerator.GetEnumByKey(m_usriCurrent.Role).StrResxKey);
                //    //parentMenuUser.Visible = false;
                //    //parentMenuSetup.Visible = false;
                //    //childMenuAgentPerformanceReport.Visible = false;
                //    //childMenuBrachPerformanceReport.Visible = false;
                //}
                //else
                //{
                //    m_strUserRoleTitle = string.Empty;
                //    //parentMenuUser.Visible = false;
                //    //parentMenuSetup.Visible = false;
                //    //childMenuAgentPerformanceReport.Visible = false;
                //    //childMenuBrachPerformanceReport.Visible = false;
                //}
            }
            else
            {
                //PnlHamburger.Visible = false;
                //FormsAuthentication.SignOut();
                //FormsAuthentication.RedirectToLoginPage();
                if (HttpContext.Current.Session["UserInfo"] != null && !((Utility.UserInfo)HttpContext.Current.Session["UserInfo"]).IsContact)
                {
                    Response.Redirect("Admin/Dashboard.aspx");
                }

                
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
                Response.Redirect("ContactDefault.aspx", false);
                //FormsAuthentication.RedirectToLoginPage("");
                //FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}