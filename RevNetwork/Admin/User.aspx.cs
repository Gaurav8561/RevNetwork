using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
using TypeEnumerator;
using Entity;
using Utility;
using Controller;
using System.Web.Security;
using Security;

namespace RevNetwork
{
    public partial class User : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
            = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList().Where(x => x.StrKey == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey));

        //string strAgentActivationURL = string.Empty;
        //string strEncryptedUserName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
                Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    Session[Constant.SESSION_NAME_SUBMIT_MODE] = null;

                    DdlRole.DataSource = AdminRoleEnumerator.GetEnumList();
                    DdlRole.DataTextField = "StrDispText";
                    DdlRole.DataValueField = "StrKey";
                    DdlRole.DataBind();

                    //DdlBranch.DataSource 
                    //    = BranchInterface.ListBranch(new BranchEntity
                    //    {
                    //        BranchRoleBranchRole = BranchRoleEnumerator.BranchRoleGroup
                    //    }).OrderBy(x => x.StrBranchName).ToList();
                    //DdlBranch.DataTextField = "StrBranchName";
                    //DdlBranch.DataValueField = "StrBranchID";
                    //DdlBranch.DataBind();

                    RblStatus.DataSource = StatusEnumerator.GetEnumList();
                    RblStatus.DataTextField = "StrDispText";
                    RblStatus.DataValueField = "StrKey";
                    RblStatus.DataBind();


                    if (!String.IsNullOrEmpty(Session[Constant.SESSION_NAME_USER_ID] as string))
                    {
                        AdminEntity user = AdminInterface.GetUserByPrimaryKey(Session[Constant.SESSION_NAME_USER_ID] as string);

                        if (user != null)
                        {
                            TxtEmail.Text = user.StrUserLoginName;
                            TxtEmail.ReadOnly = true;

                            TxtName.Text = user.StrUserName;
                            TxtName.ReadOnly = true;

                            TxtNewPassword.ReadOnly = true;
                            TxtRetypeNewPassword.ReadOnly = true;

                            DdlRole.SelectedValue = user.UserRoleUserRole.StrKey;
                            DdlRole.Visible = false;

                            TxtRole.Text = user.UserRoleUserRole.StrDispText;
                            TxtRole.Visible = true;

                            //DdlBranch.SelectedValue = user.StrUserBranch_BranchID;
                            //DdlBranch.Visible = false;

                            //TxtBranch.Text = user.BranchUserBranch.StrBranchName;
                            //TxtBranch.Visible = true;



                            DivStatus.Visible = true;
                            RblStatus.SelectedValue = user.StatusUserStatus.StrKey;
                            RblStatus.Visible = false;
                            TxtStatus.Text = user.StatusUserStatus.StrDispText;
                            TxtStatus.Visible = true;


                            BtnEdit.Visible = UserInfo.GetUserInfo().Role == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey;
                            BtnSubmit.Visible = false;

                            Session[Constant.SESSION_NAME_USER] = user;
                            Session[Constant.SESSION_NAME_USER_ID] = null;
                        }
                        else
                        {
                            //To address deleted user showing submit button
                            BtnSubmit.Visible = false;
                        }
                    }
                    else
                    {
                        //DivShowNotice.Visible = true;
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }



        protected bool IsDuplicateEmail(string strUserLoginName)
        {
            AdminEntity user = AdminInterface.GetUserByLoginName(strUserLoginName);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;

                //AgentEntity agent = AgentInterface.GetAgentByLoginName(strUserLoginName);

                //if (agent != null)
                //{
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }



        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strEmail = string.Empty;
            string strName = string.Empty;
            string strNewPassword = string.Empty;
            string strRetypeNewPassword = string.Empty;

            ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources.resx"));

            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;


            LblEmail.ForeColor = System.Drawing.Color.Black;
            LblName.ForeColor = System.Drawing.Color.Black;
            LblNewPassword.ForeColor = System.Drawing.Color.Black;
            LblRetypeNewPassword.ForeColor = System.Drawing.Color.Black;
            LblCurrentPassword.ForeColor = System.Drawing.Color.Black;
            LblNewPassword.ForeColor = System.Drawing.Color.Black;
            LblRetypeNewPassword.ForeColor = System.Drawing.Color.Black;

            //Assign var
            strEmail = TxtEmail.Text.Trim();
            strName = TxtName.Text.Trim();
            strNewPassword = TxtNewPassword.Text.Trim();
            strRetypeNewPassword = TxtRetypeNewPassword.Text.Trim();

            List<string> lstRequiredEmptyField = new List<string>();

            if (string.IsNullOrWhiteSpace(strEmail))
            {
                lstRequiredEmptyField.Add(LblEmail.Text);
                LblEmail.ForeColor = System.Drawing.Color.Red;
            }

            if (!Constant.SESSION_NAME_SUBMIT_MODE_EDIT.Equals(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string))
            {
                if (string.IsNullOrWhiteSpace(strNewPassword))
                {
                    lstRequiredEmptyField.Add(LblNewPassword.Text);
                    LblNewPassword.ForeColor = System.Drawing.Color.Red;
                }

                if (string.IsNullOrWhiteSpace(strRetypeNewPassword))
                {
                    lstRequiredEmptyField.Add(LblRetypeNewPassword.Text);
                    LblRetypeNewPassword.ForeColor = System.Drawing.Color.Red;
                }
            }

            if (string.IsNullOrWhiteSpace(strName))
            {
                lstRequiredEmptyField.Add(LblName.Text);
                LblName.ForeColor = System.Drawing.Color.Red;
            }



            if (lstRequiredEmptyField.Count > 0)
            {
                LblErrorDisplay.Text += resxSet.GetString("errorRequiredCompulsoryFieldsHeading") + ":<br />";

                foreach (string strFieldLabel in lstRequiredEmptyField)
                {
                    LblErrorDisplay.Text += "- " + strFieldLabel + "<br />";
                }

                LblErrorDisplay.Text += "<br />";
            }

            if (!Common.IsEqualPassword(strNewPassword, strRetypeNewPassword))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldPasswordNotEqual") + "<br />";
                LblNewPassword.ForeColor = System.Drawing.Color.Red;
                LblRetypeNewPassword.ForeColor = System.Drawing.Color.Red;
            }

            if (!string.IsNullOrWhiteSpace(strEmail) && !Common.IsValidEmail(strEmail))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidEmail") + "<br />";
                LblEmail.ForeColor = System.Drawing.Color.Red;
            }

            if (!Constant.SESSION_NAME_SUBMIT_MODE_EDIT.Equals(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && !string.IsNullOrWhiteSpace(strEmail) && IsDuplicateEmail(strEmail))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldDuplicateEmail") + "<br />";
                LblEmail.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(LblErrorDisplay.Text))
            {
                if (!string.IsNullOrEmpty(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && (Session[Constant.SESSION_NAME_SUBMIT_MODE] as string).Equals(Constant.SESSION_NAME_SUBMIT_MODE_EDIT))
                {
                    //update
                    AdminEntity user = Session[Constant.SESSION_NAME_USER] as AdminEntity;

                    user.StrUserLoginName = strEmail;
                    user.StrUserName = strName;

                    if (!string.IsNullOrEmpty(strNewPassword) && !string.IsNullOrEmpty(strRetypeNewPassword))
                    {
                        user.StrUserLoginPassword = strNewPassword;
                    }


                    //AdminEntity unRole = new AdminEntity();

                    



                    //if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleGroup.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleGroupAdmin;
                    //}
                    //else if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleCentre.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleCentreAdmin;
                    //}
                    //else if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleBranch.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleBranchAdmin;
                    //}


                    //user.StrUserBranch_BranchID = DdlBranch.SelectedValue;
                    user.UserRoleUserRole = AdminRoleEnumerator.GetEnumByKey(DdlRole.SelectedValue);
                    user.StatusUserStatus = StatusEnumerator.GetEnumByKey(RblStatus.SelectedValue);


                    user = AdminInterface.UpdateUser(user);

                    if (user != null)
                    {
                        Session[Constant.SESSION_NAME_USER_ID] = user.StrUserID;

                        Session[Constant.SESSION_NAME_SUBMIT_MODE] = null;
                        Session[Constant.SESSION_NAME_USER] = null;

                        Response.Redirect("User.aspx");
                    }
                    else
                    {
                        Response.Redirect("UserList.aspx");
                    }

                    
                }
                else
                {
                    //insert

                    //AdminEntity unRole = new AdminEntity();

                    //if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleGroup.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleGroupAdmin;
                    //}
                    //else if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleCentre.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleCentreAdmin;
                    //}
                    //else if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleBranch.StrKey)
                    //{
                    //    unRole.UserRoleUserRole = UserRoleEnumerator.UserRoleBranchAdmin;
                    //}


                    AdminEntity user = AdminInterface.NewUser(new AdminEntity
                    {
                        StrUserLoginName = strEmail,
                        StrUserName = strName,
                        StrUserLoginPassword = strNewPassword,
                        //UserRoleUserRole = AdminRoleEnumerator.UserRoleGroupAdmin
                        UserRoleUserRole = AdminRoleEnumerator.GetEnumByKey(DdlRole.SelectedValue),
                        //StrUserBranch_BranchID = DdlBranch.SelectedValue
                    });

                    //strEncryptedUserName = Common.ConvertStringToHex(TxtEmail.Text);

                    //string strSubject = Resources.Resources.noteAdminAccountSubject;

                    //if (HttpContext.Current.Request.Url.Port == 80)
                    //{
                    //    strAgentActivationURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + "/accountactivation.aspx?param=" + strEncryptedUserName;
                    //}
                    //else
                    //{
                    //    strAgentActivationURL = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port + "/accountactivation.aspx?param=" + strEncryptedUserName;
                    //}

                    //string strBody = String.Format(Resources.Resources.noteAdminAccountBody, strAgentActivationURL);

                    //EmailSendingController.SendEmail(TxtEmail.Text, strSubject, strBody);

                    //EmailSendingController.SendEmail(user.StrUserLoginName, Resources.Resources.noteAgentAccountSubject, string.Format(Resources.Resources.noteAgentAccountBody, string.Format("{0}://{1}{2}/accountactivation.aspx?param={3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, (HttpContext.Current.Request.Url.Port == 80 ? "" : ":" + HttpContext.Current.Request.Url.Port), Encryption.EncryptToHex(user.StrUserLoginName))));

                    Response.Redirect("UserList.aspx");

                    //booEmailSent = EmailSendingController.SendEmail(TxtEmail.Text, strSubject, strBody);

                    //if (booEmailSent)
                    //{
                    //    Response.Redirect("adminlist.aspx");
                    //}
                    //else
                    //{
                    //    lblWarning.Text = Resources.Resources.noteAdminAccountWarning;
                    //}
                }
            }
            else
            {
                LblErrorDisplay.Text = resxSet.GetString("errorRequiredCheckErrorBeforeProceed") + ":<br /><br />" + LblErrorDisplay.Text;
                DivErrorDisplay.Visible = true;
            }
        }



        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Session[Constant.SESSION_NAME_SUBMIT_MODE] = Constant.SESSION_NAME_SUBMIT_MODE_EDIT;

            TxtEmail.ReadOnly = false;

            TxtName.ReadOnly = false;

            TxtNewPassword.ReadOnly = false;
            TxtRetypeNewPassword.ReadOnly = false;

            //enable and disable fields
            DdlRole.Visible = true;
            TxtRole.Visible = false;

            //DdlBranch.Visible = true;
            //TxtBranch.Visible = false;

            RblStatus.Visible = true;
            TxtStatus.Visible = false;

            BtnEdit.Visible = false;
            BtnSubmit.Visible = true;
        }



        //protected void RblBranchRole_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DdlBranch.Items.Clear();

        //    BranchEntity beBranch = new BranchEntity();

        //    //if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleBranch.StrKey)
        //    //{
        //    //    beBranch.BranchRoleBranchRole = BranchRoleEnumerator.BranchRoleBranch;
        //    //}
        //    //if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleCentre.StrKey)
        //    //{
        //    //    beBranch.BranchRoleBranchRole = BranchRoleEnumerator.BranchRoleCentre;
        //    //}
        //    //else if (RblBranchRole.SelectedValue == BranchRoleEnumerator.BranchRoleGroup.StrKey)
        //    //{
        //    //    beBranch.BranchRoleBranchRole = BranchRoleEnumerator.BranchRoleGroup;
        //    //}


        //    DdlBranch.DataSource = BranchInterface.ListBranch(


        //        beBranch
        //    //BranchRoleBranchRole = RblBranchRole.SelectedValue
        //    ).OrderBy(x => x.StrBranchName).ToList();

        //    DdlBranch.DataTextField = "StrBranchName";
        //    DdlBranch.DataValueField = "StrBranchID";
        //    DdlBranch.DataBind();
        //}
    }
}