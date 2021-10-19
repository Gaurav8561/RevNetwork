using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entity;
using Utility;
using System.Globalization;
using TypeEnumerator;
using System.Web.Security;
using Security;

namespace RevNetwork
{
    public partial class UserList : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
            = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList().Where(x => x.StrKey == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
                Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

            if (!this.IsPostBack)
            {
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    lbtNewUser.Visible = UserInfo.GetUserInfo().Role == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey;
                    LoadGrid();
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }             
            }
        }

        private void LoadGrid()
        {
            //if (AdminInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username) != null && AdminInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username).BranchUserBranch != null)
            if (AdminInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username) != null)
            {
                List<AdminEntity> lstUser;

                if (UserInfo.GetUserInfo().IsAdmin)
                    //lstUser = UserInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username).BranchUserBranch.getAllUserIncludingChild().OrderByDescending(x => x.DteUserCreatedDate).ToList();
                    lstUser = AdminInterface.ListUser().OrderByDescending(x => x.DteUserCreatedDate).ToList();
                else
                    lstUser = new List<AdminEntity>();

                //if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(ddlFilterBy.SelectedValue))
                //    lstUser = lstUser.Where(x => (new CultureInfo(string.Empty)).CompareInfo.IndexOf(Common.FollowPropertyPath(x, ddlFilterBy.SelectedValue).ToString(), txtSearch.Text, CompareOptions.IgnoreCase) >= 0).ToList();

                gvList.DataSource = lstUser;
                gvList.DataBind();
            }
        }



        protected void gvList_PreRender(object sender, EventArgs e)
        {
            if (gvList.HeaderRow != null)
                gvList.HeaderRow.TableSection = TableRowSection.TableHeader;
        }



        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            LoadGrid();
        }



        protected void lbtNewUser_Click(object sender, EventArgs e)
        {
            Session[Constant.SESSION_NAME_USER_ID] = null;
            Response.Redirect("User.aspx");
        }



        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectUser")
            {
                Session[Constant.SESSION_NAME_USER_ID] = Convert.ToString(e.CommandArgument.ToString());
                Response.Redirect("User.aspx");
            }
        }



        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}