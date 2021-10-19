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
    public partial class ContactList : System.Web.UI.Page
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
                    //lbtNewContact.Visible = UserInfo.GetUserInfo().IsAgent;
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
            List<ContactEntity> lstContact;

            //if (UserInfo.GetUserInfo().IsAdmin)
                //lstAgent = UserInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username).BranchUserBranch.getAllAgentIncludingChild().OrderByDescending(x => x.StrAgentCreatedDate).ToList();
                lstContact = ContactInterface.ListContact().OrderByDescending(x => x.StrContactCreatedBy).ToList();
            //else
                //lstAgent = new List<AgentEntity>();

            //if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(ddlFilterBy.SelectedValue))
                //lstAgent = lstAgent.Where(x => (new CultureInfo(string.Empty)).CompareInfo.IndexOf(Common.FollowPropertyPath(x, ddlFilterBy.SelectedValue).ToString(), txtSearch.Text, CompareOptions.IgnoreCase) >= 0).ToList();

            gvList.DataSource = lstContact;
            gvList.DataBind();





            //List<ContactEntity> lstContact = new List<ContactEntity>();

            //if (UserInfo.GetUserInfo().IsAdmin)
            //{
            //    lstPotentialStudents = AdminInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username).BranchUserBranch.GetTopParent().getAllPotentialStudentIncludingChild();
            //}
            //else if (UserInfo.GetUserInfo().IsAgent)
            //{
            //    //lstPotentialStudents = AgentInterface.GetAgentByLoginName(UserInfo.GetUserInfo().Username).BranchAgentBranch.GetTopParent().getAllPotentialStudentIncludingChild().ToList();
            //    //lstPotentialStudents = AgentInterface.GetAgentByLoginName(UserInfo.GetUserInfo().Username).BranchAgentBranch.GetTopParent().getAllPotentialStudentIncludingChild().Where(x => (x.StrPotenStudReferrer_AgentID == AgentInterface.GetAgentByLoginName(UserInfo.GetUserInfo().Username).StrAgentID)).ToList();                
            //    lstPotentialStudents = AgentInterface.GetAgentByLoginName(UserInfo.GetUserInfo().Username).LstPotentialStudents;
            //}

            //if (!string.IsNullOrEmpty(Request.QueryString[Constant.QUERY_STRING_NAME_PARAM] as string))
            //{
            //    int intMonthDiff = 0;
            //    StudentRegistrationStatusEnumerator regStatus = null;

            //    if (Request.QueryString[Constant.QUERY_STRING_NAME_PARAM].StartsWith(Constant.FLAG_PREVIOUS_MONTH))
            //        intMonthDiff = -1;

            //    switch (Request.QueryString[Constant.QUERY_STRING_NAME_PARAM][2].ToString())
            //    {
            //        case Constant.FLAG_CURRENT_REG_STATUS_PENDING:
            //            regStatus = StudentRegistrationStatusEnumerator.StudentRegistrationPending;
            //            break;
            //        case Constant.FLAG_CURRENT_REG_STATUS_SIGNEDUP:
            //            regStatus = StudentRegistrationStatusEnumerator.StudentRegistrationRegistered;
            //            break;
            //        case Constant.FLAG_CURRENT_REG_STATUS_EXPIRED:
            //            regStatus = StudentRegistrationStatusEnumerator.StudentRegistrationExpired;
            //            break;
            //    }

            //    lstPotentialStudents = lstPotentialStudents.Where(x => (regStatus != null ? x.RegistrationStatus == regStatus : true) && DateTime.Now.AddMonths(intMonthDiff).ToString("MM/yyyy").Equals(((DateTime)x.DtePotenStudCreatedDate).ToString("MM/yyyy"))).ToList();
            //}

            //if (!string.IsNullOrWhiteSpace(txtSearch.Text) && !string.IsNullOrWhiteSpace(ddlFilterBy.SelectedValue))                
            //    lstPotentialStudents = lstPotentialStudents.Where(x => (new CultureInfo(string.Empty)).CompareInfo.IndexOf(Common.FollowPropertyPath(x, ddlFilterBy.SelectedValue).ToString(), txtSearch.Text, CompareOptions.IgnoreCase) >= 0).ToList();

            //lstPotentialStudents = lstPotentialStudents.OrderByDescending(x => x.DtePotenStudCreatedDate).ToList();

            //gvList.DataSource = lstPotentialStudents;
            //gvList.DataBind();
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



        protected void lbtNewContact_Click(object sender, EventArgs e)
        {
            Session[Constant.SESSION_NAME_CONTACT_ID] = null;
            Response.Redirect("Contact.aspx");
        }



        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selectContact")
            {
                Session[Constant.SESSION_NAME_CONTACT_ID] = Convert.ToString(e.CommandArgument.ToString());
                Response.Redirect("Contact.aspx");
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}