using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using TypeEnumerator;
using Entity;
using General;
using System.Resources;
using Utility;
using System.Data.SqlTypes;
using System.Web.Security;
using Security;
using Controller;



namespace RevNetwork
{
    public partial class Contact : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
            = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList().Where(x => x.StrKey == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey));

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
                Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    Session[Constant.SESSION_NAME_SUBMIT_MODE] = null;
                    DivErrorDisplay.Visible = false;

                    ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx"));

                    DdlIDType.DataSource = from p in IDTypeEnumerator.GetEnumList()
                                           select new { StrResxDispText = resxSet.GetString(p.StrResxKey), p.StrKey };
                    DdlIDType.DataTextField = "StrResxDispText";
                    DdlIDType.DataValueField = "StrKey";
                    DdlIDType.DataBind();


                    DdlMaritalStatus.DataSource = from p in MaritalStatusEnumerator.GetEnumList()
                                                  select new { StrResxDispText = resxSet.GetString(p.StrResxKey), p.StrKey };
                    DdlMaritalStatus.DataTextField = "StrResxDispText";
                    DdlMaritalStatus.DataValueField = "StrKey";
                    DdlMaritalStatus.DataBind();

                    RblGender.DataSource = from p in GenderEnumerator.GetEnumList()
                                           select new { StrResxDispText = resxSet.GetString(p.StrResxKey), p.StrKey };
                    RblGender.DataTextField = "StrResxDispText";
                    RblGender.DataValueField = "StrKey";
                    RblGender.DataBind();


                    //if (UserInfo.GetUserInfo().IsAgent)
                    //{
                    //    DdlBranch.DataSource = AgentInterface.GetAgentByLoginName(UserInfo.GetUserInfo().Username).BranchAgentBranch.GetTopParent().getAllBranchIncludingChild().Where(x => x.BranchRoleBranchRole == BranchRoleEnumerator.BranchRoleCentre).ToList();
                    //}
                    //else
                    //{
                    //    DdlBranch.DataSource = AdminInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username).BranchUserBranch.GetTopParent().getAllBranchIncludingChild().Where(x => x.BranchRoleBranchRole == BranchRoleEnumerator.BranchRoleCentre).ToList();
                    //}

                    //DdlBranch.DataTextField = "StrBranchName";
                    //DdlBranch.DataValueField = "StrBranchID";
                    //DdlBranch.DataBind();

                    //DdlProgramme.DataSource = ProgrammeInterface.List();
                    //DdlProgramme.DataTextField = "StrProgrammeTitle";
                    //DdlProgramme.DataValueField = "StrProgrammeID";
                    //DdlProgramme.DataBind();


                    //DdlAddressCountry.DataSource = GeoDataList_CountryInterface.getCountryList();
                    //DdlAddressCountry.DataTextField = "StrCountryName";
                    //DdlAddressCountry.DataValueField = "StrCountryName";
                    //DdlAddressCountry.DataBind();

                    RblStatus.DataSource = from p in StatusEnumerator.GetEnumList()
                                           select new { StrResxDispText = resxSet.GetString(p.StrResxKey), p.StrKey };
                    RblStatus.DataTextField = "StrResxDispText";
                    RblStatus.DataValueField = "StrKey";
                    RblStatus.DataBind();

                    if (!string.IsNullOrEmpty(Session[Constant.SESSION_NAME_CONTACT_ID] as string))
                    {
                        ContactEntity contact = ContactInterface.GetContactByPrimaryKey(Session[Constant.SESSION_NAME_CONTACT_ID] as string);

                        if (contact != null)
                        {
                            TxtPhoneNumber.Text = contact.StrContactLoginUserName;
                            TxtPhoneNumber.ReadOnly = true;

                            //TxtCreditBalance.Text = contact.ContactContactWalletPocketMaster.DecCreditBalance.ToString();

                            TxtContactName.Text = contact.StrContactName;
                            TxtContactName.ReadOnly = true;

                            TxtEmail.Text = contact.StrContactEmail;
                            TxtEmail.ReadOnly = true;

                            RblGender.SelectedValue = contact.GenderEnumeratorContactGender == null? null : contact.GenderEnumeratorContactGender.StrKey;
                            RblGender.Visible = false;
                            TxtGender.Text = contact.GenderEnumeratorContactGender == null ? null : contact.GenderEnumeratorContactGender.StrDispText;
                            TxtGender.Visible = true;

                            TxtDateOfBirth.Text = contact.DteContactDOB == null? null :((DateTime)contact.DteContactDOB).ToString("yyyy-MM-dd");
                            TxtDateOfBirth.ReadOnly = true;

                            DdlMaritalStatus.SelectedValue = contact.MaritalStatusEnumeratorContactMaritalStat.StrKey;
                            DdlMaritalStatus.Visible = false;
                            TxtMaritalStatus.Text = resxSet.GetString(contact.MaritalStatusEnumeratorContactMaritalStat.StrResxKey);
                            TxtMaritalStatus.Visible = true;

                            DdlIDType.SelectedValue = contact.IDTypeEnumeratorContactIDType.StrKey;
                            DdlIDType.Visible = false;
                            TxtIDType.Text = resxSet.GetString(contact.IDTypeEnumeratorContactIDType.StrResxKey);
                            TxtIDType.Visible = true;

                            TxtIdNumber.Text = contact.StrContactIDNumber;
                            TxtIdNumber.ReadOnly = true;

                            TxtAddressLine1.Text = contact.AddContactAddress.StrAddLine1;
                            TxtAddressLine1.ReadOnly = true;

                            TxtAddressLine2.Text = contact.AddContactAddress.StrAddLine2;
                            TxtAddressLine2.ReadOnly = true;

                            TxtAddressLine3.Text = contact.AddContactAddress.StrAddLine3;
                            TxtAddressLine3.ReadOnly = true;

                            TxtAddressPostcode.Text = contact.AddContactAddress.StrAddPostcode;
                            TxtAddressPostcode.ReadOnly = true;

                            TxtAddressCity.Text = contact.AddContactAddress.StrAddCity;
                            TxtAddressCity.ReadOnly = true;

                            TxtAddressState.Text = contact.AddContactAddress.StrAddState;
                            TxtAddressState.ReadOnly = true;





                            //TxtEmail.Text = potenStud.StrPotenStudEmail;
                            //TxtEmail.ReadOnly = true;





                            //TxtPhoneNumber.Text = potenStud.StrPotenStudContactNo;
                            //TxtPhoneNumber.ReadOnly = true;

                            //DdlBranch.SelectedValue = potenStud.BranchPotenStudBranch.StrBranchID;
                            //DdlBranch.Visible = false;
                            //TxtBranch.Text = potenStud.BranchPotenStudBranch.StrBranchName;
                            //TxtBranch.Visible = true;



                            //DdlAddressCountry.SelectedValue = potenStud.AddPotenStudAddress.StrAddCountry;
                            //DdlAddressCountry.Visible = false;
                            //TxtAddressCountry.Text = potenStud.AddPotenStudAddress.StrAddCountry;
                            //TxtAddressCountry.Visible = true;

                            //TxtProgramme.Text = potenStud.ProgrammePotenStudProgramme.StrProgrammeTitle;
                            //DdlProgramme.SelectedValue = potenStud.ProgrammePotenStudProgramme.StrProgrammeID;
                            //TxtProgramme.Visible = true;
                            //DdlProgramme.Visible = false;

                            //DivStatus.Visible = true;
                            //RblStatus.SelectedValue = potenStud.StatusPotenStudStatus.StrKey;
                            //RblStatus.Visible = false;
                            //TxtStatus.Text = resxSet.GetString(potenStud.StatusPotenStudStatus.StrResxKey);
                            //TxtStatus.Visible = true;

                            //TxtAgentName.Text = potenStud.AgentPotenStudReferrer.StrAgentName;
                            //TxtCommissionToPay.Text = potenStud.DecPotenStudCommissionRate.ToString();
                            //TxtAgentBankName.Text = potenStud.AgentPotenStudReferrer.StrAgentBankName;
                            //TxtAgentBankACNumber.Text = potenStud.AgentPotenStudReferrer.StrAgentBankAccNo;

                            //DivRegisterBy.Visible = UserInfo.GetUserInfo().IsAdmin;

                            //DivStudentSignUp.Visible = UserInfo.GetUserInfo().IsAdmin;
                            //if (potenStud.DtePotenStudSignUpDate != null)
                            //{
                            //    TxtSignUpDate.Text = ((DateTime)potenStud.DtePotenStudSignUpDate).ToString("yyyy-MM-dd");
                            //    TxtSignUpDate.ReadOnly = true;
                            //    ChkIsSignedUp.Checked = true;
                            //    DivStudentSignUpDate.Visible = true;
                            //}
                            //else
                            //{
                            //    DivStudentSignUpDate.Visible = false;
                            //    ChkIsSignedUp.Checked = false;
                            //}



                            //if (ChkIsSignedUp.Checked && TxtSignUpDate.ReadOnly == true && UserInfo.GetUserInfo().IsAdmin)
                            //{
                            //    DivStudentRegistration.Visible = true;
                            //}

                            //if (potenStud.DtePotenStudRegFormalisationDate != null)
                            //{
                            //    TxtRegistrationDate.Text = ((DateTime)potenStud.DtePotenStudRegFormalisationDate).ToString("yyyy-MM-dd");
                            //    TxtRegistrationDate.ReadOnly = true;
                            //    ChkIsRegistered.Checked = true;
                            //    DivStudentRegistrationDate.Visible = true;
                            //}
                            //else
                            //{
                            //    DivStudentRegistrationDate.Visible = false;
                            //    ChkIsRegistered.Checked = false;
                            //}


                            //TxtRegisterBy.Text = ((DateTime)potenStud.DtePotenStudRegByDate).ToString("yyyy-MM-dd");
                            //TxtRegisterBy.ReadOnly = true;

                            //DivAgentCommission.Visible = (potenStud.DtePotenStudRegFormalisationDate != null);

                            //ChkIsSignedUp.Enabled = false;
                            //ChkIsRegistered.Enabled = false;

                            //DivNewRegRequirement.Visible = false;

                            //string str = UserInfo.GetUserInfo().Role;

                            //if(potenStud.LstCommentLogs != null && potenStud.LstCommentLogs.Count > 0)
                            //{
                            //    LoadCommentLogs(potenStud);
                            //    DivCommentList.Visible = true;
                            //}
                            //else
                            //{
                            //    DivCommentList.Visible = false;
                            //}

                            //DivCommentTextArea.Visible = false;

                            BtnEdit.Visible = UserInfo.GetUserInfo().Role == AdminRoleEnumerator.UserRoleGroupAdmin.StrKey;
                            BtnSubmit.Visible = false;

                            Session[Constant.SESSION_NAME_CONTACT] = contact;
                            Session[Constant.SESSION_NAME_CONTACT_ID] = null;
                        }
                    }
                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strContactMobile = string.Empty;
            string strContactName = string.Empty;
            string strContactEmail = string.Empty;
            string strContactDateOfBirth = string.Empty;
            string strContactIdNumber = string.Empty;


            string strAddressLine1 = string.Empty;
            string strAddressLine2 = string.Empty;
            string strAddressLine3 = string.Empty;
            string strAddressPostcode = string.Empty;
            string strAddressCity = string.Empty;
            string strAddressState = string.Empty;



            //string strIdNumber = string.Empty;
            //string strEmail = string.Empty;
            //string strPhoneNumber = string.Empty;

            ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources.resx"));

            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;

            LblPhoneNumber.ForeColor = System.Drawing.Color.Black;
            LblContactName.ForeColor = System.Drawing.Color.Black;
            LblEmail.ForeColor = System.Drawing.Color.Black;
            LblIdNumber.ForeColor = System.Drawing.Color.Black;


            //
            //LblDateOfBirth.ForeColor = System.Drawing.Color.Black;
            //
            //LblPhoneNumber.ForeColor = System.Drawing.Color.Black;
            //LblGender.ForeColor = System.Drawing.Color.Black;
            //LblAddressLine1.ForeColor = System.Drawing.Color.Black;
            //LblAddressPostcode.ForeColor = System.Drawing.Color.Black;
            //LblAddressCity.ForeColor = System.Drawing.Color.Black;
            //LblAddressState.ForeColor = System.Drawing.Color.Black;
            //LblSignUpDate.ForeColor = System.Drawing.Color.Black;
            //LblRegistrationDate.ForeColor = System.Drawing.Color.Black;
            //LblAgreePDPA.ForeColor = System.Drawing.Color.Black;

            //Assign var
            strContactMobile = TxtPhoneNumber.Text.Trim();
            strContactName = TxtContactName.Text.Trim();
            strContactEmail = TxtEmail.Text.Trim();
            strContactIdNumber = TxtIdNumber.Text.Trim();

            strAddressLine1 = TxtAddressLine1.Text.Trim();
            strAddressLine2 = TxtAddressLine2.Text.Trim();
            strAddressLine3 = TxtAddressLine3.Text.Trim();
            strAddressPostcode = TxtAddressPostcode.Text.Trim();
            strAddressCity = TxtAddressCity.Text.Trim();
            strAddressState = TxtAddressState.Text.Trim();


            //strIdNumber = TxtIdNumber.Text.Trim();
            //strEmail = TxtEmail.Text.Trim();
            //strPhoneNumber = TxtPhoneNumber.Text.Trim();

            List<string> lstRequiredEmptyField = new List<string>();

            if (string.IsNullOrWhiteSpace(strContactMobile))
            {
                lstRequiredEmptyField.Add(LblPhoneNumber.Text);
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrWhiteSpace(strContactName))
            {
                lstRequiredEmptyField.Add(LblContactName.Text);
                LblContactName.ForeColor = System.Drawing.Color.Red;
            }

            //if (string.IsNullOrWhiteSpace(strIdNumber))
            //{
            //    lstRequiredEmptyField.Add(LblIdNumber.Text);
            //    LblIdNumber.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(TxtDateOfBirth.Text))
            //{
            //    lstRequiredEmptyField.Add(LblDateOfBirth.Text);
            //    LblDateOfBirth.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(strEmail))
            //{
            //    lstRequiredEmptyField.Add(LblEmail.Text);
            //    LblEmail.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(strPhoneNumber))
            //{
            //    lstRequiredEmptyField.Add(LblPhoneNumber.Text);
            //    LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(RblGender.SelectedValue))
            //{
            //    lstRequiredEmptyField.Add(LblGender.Text);
            //    LblGender.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(TxtAddressLine1.Text))
            //{
            //    lstRequiredEmptyField.Add(LblAddressLine1.Text);
            //    LblAddressLine1.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(TxtAddressPostcode.Text))
            //{
            //    lstRequiredEmptyField.Add(LblAddressPostcode.Text);
            //    LblAddressPostcode.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(TxtAddressCity.Text))
            //{
            //    lstRequiredEmptyField.Add(LblAddressCity.Text);
            //    LblAddressCity.ForeColor = System.Drawing.Color.Red;
            //}

            //if (string.IsNullOrWhiteSpace(TxtAddressState.Text))
            //{
            //    lstRequiredEmptyField.Add(LblAddressState.Text);
            //    LblAddressState.ForeColor = System.Drawing.Color.Red;
            //}

            //if (ChkIsSignedUp.Checked && string.IsNullOrWhiteSpace(TxtSignUpDate.Text))
            //{
            //    lstRequiredEmptyField.Add(LblSignUpDate.Text);
            //    LblSignUpDate.ForeColor = System.Drawing.Color.Red;
            //}

            //if (ChkIsRegistered.Checked && string.IsNullOrWhiteSpace(TxtRegistrationDate.Text))
            //{
            //    lstRequiredEmptyField.Add(LblRegistrationDate.Text);
            //    LblRegistrationDate.ForeColor = System.Drawing.Color.Red;
            //}

            if (lstRequiredEmptyField.Count > 0)
            {
                LblErrorDisplay.Text += resxSet.GetString("errorRequiredCompulsoryFieldsHeading") + ":<br />";

                foreach (string strFieldLabel in lstRequiredEmptyField)
                {
                    LblErrorDisplay.Text += "- " + strFieldLabel + "<br />";
                }

                LblErrorDisplay.Text += "<br />";
            }

            if (!string.IsNullOrWhiteSpace(strContactIdNumber))
            {
                IDTypeEnumerator idType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue);
                if (idType != null)
                {
                    if (idType.Validator != null)
                    {
                        List<IDTypeEnumerator.ErrorCodes> errorList = idType.Validator(new IDTypeEnumerator.Inputs
                        {
                            strIdNum = strContactIdNumber,
                        });

                        if (errorList.Count() > 0)
                        {
                            foreach (IDTypeEnumerator.ErrorCodes code in errorList)
                            {
                                switch (code)
                                {
                                    case IDTypeEnumerator.ErrorCodes.INVALID_FORMAT:
                                        LblErrorDisplay.Text += "- " + string.Format(Resources.Resources.errorFieldInvalidIdNumber, strContactIdNumber, (new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx")).GetString(idType.StrResxKey))) + " <br />";
                                        LblIdNumber.ForeColor = System.Drawing.Color.Red;
                                        break;
                                }
                            }

                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(strContactEmail) && !Common.IsValidEmail(strContactEmail))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidEmail") + "<br />";
                LblEmail.ForeColor = System.Drawing.Color.Red;
            }

            if (!string.IsNullOrWhiteSpace(strContactMobile) && !Common.IsValidPhone(strContactMobile))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidPhoneNumber") + "<br />";
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            if (!Constant.SESSION_NAME_SUBMIT_MODE_EDIT.Equals(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && !string.IsNullOrWhiteSpace(strContactMobile) && IsDuplicateContactMobile(strContactMobile))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldDuplicatePhoneNumber") + "<br />";
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            //if (!Constant.SESSION_NAME_SUBMIT_MODE_EDIT.Equals(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && !string.IsNullOrWhiteSpace(strContactEmail) && IsDuplicateEmail(strContactEmail))
            //{
            //    LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldDuplicateEmail") + "<br />";
            //    LblEmail.ForeColor = System.Drawing.Color.Red;
            //}

            //if (!string.IsNullOrWhiteSpace(strIdNumber))
            //{
            //    IDTypeEnumerator idType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue);
            //    if (idType != null)
            //    {
            //        if (idType.Validator != null)
            //        {
            //            List<IDTypeEnumerator.ErrorCodes> errorList = idType.Validator(new IDTypeEnumerator.Inputs
            //            {
            //                strIdNum = strIdNumber,
            //                dteDateOfBirth = DateTime.TryParse(TxtDateOfBirth.Text, out DateTime testDob) ? (DateTime?)testDob : null,
            //                gender = GenderEnumerator.GetEnumByKey(RblGender.SelectedValue)
            //            });

            //            if (errorList.Count() > 0)
            //            {
            //                foreach (IDTypeEnumerator.ErrorCodes code in errorList)
            //                {
            //                    switch (code)
            //                    {
            //                        case IDTypeEnumerator.ErrorCodes.INVALID_FORMAT:
            //                            LblErrorDisplay.Text += "- " + string.Format(Resources.Resources.errorFieldInvalidIdNumber, strIdNumber, (new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx")).GetString(idType.StrResxKey))) + " <br />";
            //                            LblIdNumber.ForeColor = System.Drawing.Color.Red;
            //                            break;
            //                        case IDTypeEnumerator.ErrorCodes.INCORESPOND_DOB:
            //                            LblErrorDisplay.Text += "- " + string.Format(Resources.Resources.errorFieldIncorespondDobtoIdNumber, strIdNumber, (new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx")).GetString(idType.StrResxKey)), TxtDateOfBirth.Text) + " <br />";
            //                            LblIdNumber.ForeColor = System.Drawing.Color.Red;
            //                            LblDateOfBirth.ForeColor = System.Drawing.Color.Red;
            //                            break;
            //                        case IDTypeEnumerator.ErrorCodes.INCORESPOND_GENDER:
            //                            LblErrorDisplay.Text += "- " + string.Format(Resources.Resources.errorFieldIncorespondGendertoIdNumber, strIdNumber, (new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx")).GetString(idType.StrResxKey)), (new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx")).GetString(GenderEnumerator.GetEnumByKey(RblGender.SelectedValue).StrResxKey))) + " <br />";
            //                            LblIdNumber.ForeColor = System.Drawing.Color.Red;
            //                            LblGender.ForeColor = System.Drawing.Color.Red;
            //                            break;
            //                    }
            //                }

            //            }
            //        }
            //    }
            //}

            //if (!string.IsNullOrWhiteSpace(strEmail) && !Common.IsValidEmail(strEmail))
            //{
            //    LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidEmail") + "<br />";
            //    LblEmail.ForeColor = System.Drawing.Color.Red;
            //}

            //if (!string.IsNullOrWhiteSpace(strPhoneNumber) && !Common.IsValidPhone(strPhoneNumber))
            //{
            //    LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidPhoneNumber") + "<br />";
            //    LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            //}

            //if (!string.IsNullOrWhiteSpace(TxtDateOfBirth.Text))
            //{
            //    if (DateTime.TryParse(TxtDateOfBirth.Text, out DateTime dob))
            //    {
            //        int intMinAge = int.Parse(ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationMiniumStudentAge.StrKey).StrConfigurationValue);

            //        if (DateTime.Today < dob || (DateTime)SqlDateTime.MinValue > dob)
            //        {
            //            LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidDateOfBirth") + "<br />";
            //            LblDateOfBirth.ForeColor = System.Drawing.Color.Red;
            //        }
            //        else if (DateTime.Today.Year - dob.Year < intMinAge)
            //        {
            //            LblErrorDisplay.Text += "- " + string.Format(resxSet.GetString("errorFieldInvalidMinimumAge"), intMinAge) + "<br />";
            //            LblDateOfBirth.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidDateOfBirth") + "<br />";
            //        LblDateOfBirth.ForeColor = System.Drawing.Color.Red;
            //    }
            //}

            //if (DivNewRegRequirement.Visible == true)
            //{
            //    if (!IsReCaptchValid())
            //    {
            //        LblErrorDisplay.Text += "- " + resxSet.GetString("captchaFailed") + "<br />";

            //        LblRecaptchaMessage.InnerHtml = string.Format("<span style='color:red'>{0}</span>", resxSet.GetString("captchaFailed"));
            //    }
            //    else
            //    {
            //        LblRecaptchaMessage.InnerHtml = string.Format("<span style='color:green'>{0}</span>", resxSet.GetString("captchaSuccess"));
            //    }

            //    //if (!ChkAgreePDPA.Checked)
            //    //{
            //    //    LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldPdpaRequire") + "<br />";
            //    //    LblAgreePDPA.ForeColor = System.Drawing.Color.Red;
            //    //}
            //}

            //if (!string.IsNullOrWhiteSpace(TxtRegistrationDate.Text))
            //{
            //    if (DateTime.TryParse(TxtRegistrationDate.Text, out DateTime regDate))
            //    {
            //        if (regDate < Convert.ToDateTime(((PotentialStudentEntity)Session[Constant.SESSION_NAME_POTEN_STUD]).DtePotenStudCreatedDate).Date || regDate > DateTime.Now.Date)
            //        {
            //            LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidRegistrationDate") + "<br />";
            //            LblRegistrationDate.ForeColor = System.Drawing.Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidRegistrationDate") + "<br />";
            //        LblRegistrationDate.ForeColor = System.Drawing.Color.Red;
            //    }
            //}

            //if (!Constant.SESSION_NAME_SUBMIT_MODE_EDIT.Equals(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && !string.IsNullOrWhiteSpace(strIdNumber) && !string.IsNullOrWhiteSpace(strEmail))
            //{
            //    if (PotentialStudentInterface.IsStudentRegisteredLast30Days(new PotentialStudentEntity
            //    {
            //        IDTypePotenStudIDType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue),
            //        StrPotenStudIDNumber = strIdNumber,
            //        StrPotenStudEmail = strEmail
            //    }))
            //    {
            //        LblErrorDisplay.Text += "- " + resxSet.GetString("errorEmailOrIdRegisteredLast30Days") + "<br />";
            //        LblIdNumber.ForeColor = System.Drawing.Color.Red;
            //        LblEmail.ForeColor = System.Drawing.Color.Red;
            //    }
            //}

            if (string.IsNullOrEmpty(LblErrorDisplay.Text))
            {
                if (!string.IsNullOrEmpty(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && (Session[Constant.SESSION_NAME_SUBMIT_MODE] as string).Equals(Constant.SESSION_NAME_SUBMIT_MODE_EDIT))
                {
                    ContactEntity contact = Session[Constant.SESSION_NAME_CONTACT] as ContactEntity;

                    contact.StrContactLoginUserName = strContactMobile;
                    contact.StrContactName = strContactName;
                    contact.StrContactEmail = strContactEmail;
                    contact.GenderEnumeratorContactGender = GenderEnumerator.GetEnumByKey(RblGender.SelectedValue);
                    contact.DteContactDOB = String.IsNullOrEmpty(TxtDateOfBirth.Text) ? (DateTime?)null : DateTime.Parse(TxtDateOfBirth.Text);
                    contact.MaritalStatusEnumeratorContactMaritalStat = MaritalStatusEnumerator.GetEnumByKey(DdlMaritalStatus.SelectedValue);

                    contact.IDTypeEnumeratorContactIDType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue);
                    contact.StrContactIDNumber = strContactIdNumber;

                    contact.AddContactAddress.StrAddLine1 = strAddressLine1;
                    contact.AddContactAddress.StrAddLine2 = strAddressLine2;
                    contact.AddContactAddress.StrAddLine3 = strAddressLine3;
                    contact.AddContactAddress.StrAddPostcode = strAddressPostcode;
                    contact.AddContactAddress.StrAddCity = strAddressCity;
                    contact.AddContactAddress.StrAddState = strAddressState;


                    //potenStud.StrPotenStudName = strName;
                    //potenStud.IDTypePotenStudIDType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue);
                    //potenStud.StrPotenStudIDNumber = strIdNumber;
                    //potenStud.DtePotenStudDOB = DateTime.Parse(TxtDateOfBirth.Text);
                    //potenStud.StrPotenStudEmail = strEmail;
                    //potenStud.GenderPotenStudGender = GenderEnumerator.GetEnumByKey(RblGender.SelectedValue);
                    //potenStud.MarStatPotenStudMaritalStat = MaritalStatusEnumerator.GetEnumByKey(DdlMaritalStatus.SelectedValue);
                    //potenStud.StrPotenStudContactNo = strPhoneNumber;
                    ////potenStud.AddPotenStudAddress.StrAddLine1 = TxtAddressLine1.Text;
                    ////potenStud.AddPotenStudAddress.StrAddLine3 = TxtAddressLine2.Text;
                    ////potenStud.AddPotenStudAddress.StrAddLine3 = TxtAddressLine3.Text;
                    ////potenStud.AddPotenStudAddress.StrAddPostcode = TxtAddressPostcode.Text;
                    ////potenStud.AddPotenStudAddress.StrAddCity = TxtAddressCity.Text;
                    ////potenStud.AddPotenStudAddress.StrAddState = TxtAddressState.Text;
                    ////potenStud.AddPotenStudAddress.StrAddCountry = DdlAddressCountry.SelectedValue;
                    //potenStud.StrPotenStudBranch_BranchID = DdlBranch.SelectedValue;
                    //potenStud.StrPotenStudProgramme_ProgrammeID = DdlProgramme.SelectedValue;
                    //potenStud.DecPotenStudCommissionRate = ProgrammeInterface.GetByPrimaryKey(DdlProgramme.SelectedValue).DecProgrammeCommission;
                    //potenStud.StatusPotenStudStatus = StatusEnumerator.GetEnumByKey(RblStatus.SelectedValue);
                    //potenStud.DtePotenStudSignUpDate = ChkIsSignedUp.Checked ? (DateTime?)DateTime.Parse(TxtSignUpDate.Text) : null;
                    //potenStud.DtePotenStudRegFormalisationDate = ChkIsRegistered.Checked ? (DateTime?)DateTime.Parse(TxtRegistrationDate.Text) : null;
                    //potenStud.DecPotenStudCommissionTotalPaidOut = ChkIsRegistered.Checked ? potenStud.DecPotenStudCommissionRate : 0;

                    //if (!string.IsNullOrEmpty(TxtComment.Text))
                    //{
                    //    UserEntity user = UserInterface.GetUserByLoginName(UserInfo.GetUserInfo().Username);
                    //    PotentialStudentCommentLogInterface.New(
                    //        new PotentialStudentCommentLogEntity
                    //        {
                    //            StrPotentialStudentCommentLogContent = TxtComment.Text,
                    //            StrPotentialStudentCommentLog_PotenStudID = potenStud.StrPotenStudID,
                    //            StrPotentialStudentCommentLog_UserID = user is AdminEntity ? (user as AdminEntity).StrUserID : (user is AgentEntity ? (user as AgentEntity).StrAgentID : null)
                    //        }); ;
                    //}

                    contact = ContactInterface.UpdateContact(contact);

                    //if (ChkIsRegistered.Checked)
                    //{
                    //    EmailSendingController.SendEmail(potenStud.StrPotenStudEmail, Resources.Resources.emailSubjectStudentRegistrationFinalised_Student, string.Format(Resources.Resources.emailBodyStudentRegistrationFinalised_Student, potenStud.StrPotenStudName));
                    //    EmailSendingController.SendEmail(potenStud.AgentPotenStudReferrer.StrAgentLoginName, Resources.Resources.emailSubjectStudentRegistrationFinalised_AgentAdmin, string.Format(Resources.Resources.emailBodyStudentRegistrationFinalised_AgentAdmin, potenStud.AgentPotenStudReferrer.StrAgentName, potenStud.StrPotenStudName, potenStud.StrPotenStudIDNumber, potenStud.StrPotenStudEmail, potenStud.DecPotenStudCommissionTotalPaidOut));
                        
                    //    foreach(AdminEntity user in AdminInterface.ListUser())
                    //        EmailSendingController.SendEmail(user.StrUserLoginName, Resources.Resources.emailSubjectStudentRegistrationFinalised_AgentAdmin, string.Format(Resources.Resources.emailBodyStudentRegistrationFinalised_AgentAdmin, potenStud.AgentPotenStudReferrer.StrAgentName, potenStud.StrPotenStudName, potenStud.StrPotenStudIDNumber, potenStud.StrPotenStudEmail, potenStud.DecPotenStudCommissionTotalPaidOut));
                    //}

                    if (contact != null)
                    {
                        Session[Constant.SESSION_NAME_CONTACT_ID] = contact.StrContactID;

                        Session[Constant.SESSION_NAME_SUBMIT_MODE] = null;
                        Session[Constant.SESSION_NAME_CONTACT] = null;

                        Response.Redirect("Contact.aspx");
                    }
                    else
                    {
                        Response.Redirect("ContactList.aspx");
                    }
                }
                else
                {
                    ContactEntity contact = ContactInterface.NewContact(new ContactEntity
                    {
                        StrContactLoginUserName = strContactMobile,
                        StrContactName = strContactName,
                        StrContactEmail = strContactEmail,
                        GenderEnumeratorContactGender = GenderEnumerator.GetEnumByKey(RblGender.SelectedValue),
                        DteContactDOB = String.IsNullOrEmpty(TxtDateOfBirth.Text) ? (DateTime?)null : DateTime.Parse(TxtDateOfBirth.Text),
                        MaritalStatusEnumeratorContactMaritalStat = MaritalStatusEnumerator.GetEnumByKey(DdlMaritalStatus.SelectedValue),

                        IDTypeEnumeratorContactIDType = IDTypeEnumerator.GetEnumByKey(DdlIDType.SelectedValue),
                        StrContactIDNumber = strContactIdNumber,
                        AddContactAddress = new Address(strAddressLine1,
                                                        strAddressLine2,
                                                        strAddressLine3,
                                                        strAddressPostcode,
                                                        strAddressCity,
                                                        strAddressState,
                                                        null),
                        StrMembershipPlanID = Constant.MEMBERSHIP_PLAN_ID_FREE
                    });



                    //WalletPocketConfigEntity masterPocketConfig = WalletPocketConfigInterface.GetByCustomColumn("TableName", "tbl_ContactWalletPocketMaster");
                    //WalletPocketConfigEntity bonusPocketConfig = WalletPocketConfigInterface.GetByCustomColumn("TableName", "tbl_ContactWalletPocketBonus");
                    //WalletPocketConfigEntity earningPocketConfig = WalletPocketConfigInterface.GetByCustomColumn("TableName", "tbl_ContactWalletPocketEarning");

                    //List<WalletPocketConfigEntity> pocketConfig = new List<WalletPocketConfigEntity>();
                    //pocketConfig.Add(masterPocketConfig);
                    //pocketConfig.Add(bonusPocketConfig);
                    //pocketConfig.Add(earningPocketConfig);

                    //for (int i = 1; ContactWalletPocketInterface.TableExists(i); i++)
                    //{
                    //    ContactWalletPocketInterface.UpdateTableMapping(i);
                    //    WalletPocketConfigEntity subPocketConfig = WalletPocketConfigInterface.GetByCustomColumn("TableName", "tbl_ContactWalletPocket" + i.ToString());
                    //    pocketConfig.Add(subPocketConfig);
                    //}



                    //PocketEntity contactWalletPocketMaster = ContactWalletPocketMasterInterface.New(new PocketEntity
                    //{
                    //    StrWalletPocketConfigID = pocketConfig[0].StrWalletPocketConfigID,
                    //    StrContactID = contact.StrContactID,
                    //    DecCreditBalance = 0.0M,
                    //    StatusContactWalletPocketStatus = StatusEnumerator.StatusActive
                    //});

                    //PocketEntity contactWalletPocketBonus = ContactWalletPocketBonusInterface.New(new PocketEntity
                    //{
                    //    StrWalletPocketConfigID = pocketConfig[1].StrWalletPocketConfigID,
                    //    StrContactID = contact.StrContactID,
                    //    DecCreditBalance = 0.0M,
                    //    StatusContactWalletPocketStatus = StatusEnumerator.StatusActive
                    //});

                    //PocketEntity contactWalletPocketEarning = ContactWalletPocketEarningInterface.New(new PocketEntity
                    //{
                    //    StrWalletPocketConfigID = pocketConfig[2].StrWalletPocketConfigID,
                    //    StrContactID = contact.StrContactID,
                    //    DecCreditBalance = 0.0M,
                    //    StatusContactWalletPocketStatus = StatusEnumerator.StatusActive
                    //});

                    //for (int i = 1; ContactWalletPocketInterface.TableExists(i); i++)
                    //{
                    //    ContactWalletPocketInterface.UpdateTableMapping(i);

                    //    PocketEntity contactWalletPocketSub = ContactWalletPocketInterface.New(new PocketEntity
                    //    {
                    //        StrWalletPocketConfigID = pocketConfig[i+2].StrWalletPocketConfigID,
                    //        StrContactID = contact.StrContactID,
                    //        DecCreditBalance = 0.0M,
                    //        StatusContactWalletPocketStatus = StatusEnumerator.StatusActive
                    //    });
                    //}


                    //EmailSendingController.SendEmail(student.StrPotenStudEmail, Resources.Resources.emailSubjectReferralRegistration, string.Format(Resources.Resources.emailBodyReferralRegistration, student.StrPotenStudName));

                    Response.Redirect("ContactList.aspx");
                }
            }
            else
            {
                LblErrorDisplay.Text = resxSet.GetString("errorRequiredCheckErrorBeforeProceed") + ":<br /><br />" + LblErrorDisplay.Text;
                DivErrorDisplay.Visible = true;
            }
        }



        //protected bool IsDuplicateEmail(string strUserLoginName)
        //{
        //    AgentEntity agent = AgentInterface.GetAgentByLoginName(strUserLoginName);

        //    if (agent != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        AdminEntity user = AdminInterface.GetUserByLoginName(strUserLoginName);

        //        if (user != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}



        protected bool IsDuplicateContactMobile(string strContactMobile)
        {
            ContactEntity contact = ContactInterface.GetContactByLoginUserName(strContactMobile);

            if (contact != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //public bool IsReCaptchValid()
        //{
        //    var result = false;
        //    var captchaResponse = Request.Form["g-recaptcha-response"];
        //    var secretKey = ConfigurationManager.AppSettings["SecretKey"];
        //    var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        //    var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
        //    var request = (HttpWebRequest)WebRequest.Create(requestUri);

        //    using (WebResponse response = request.GetResponse())
        //    {
        //        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        //        {
        //            JObject jResponse = JObject.Parse(stream.ReadToEnd());
        //            var isSuccess = jResponse.Value<bool>("success");
        //            result = (isSuccess) ? true : false;
        //        }
        //    }

        //    return result;
        //}



        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            Session[Constant.SESSION_NAME_SUBMIT_MODE] = Constant.SESSION_NAME_SUBMIT_MODE_EDIT;

            TxtPhoneNumber.ReadOnly = false;
            TxtContactName.ReadOnly = false;
            TxtEmail.ReadOnly = false;

            RblGender.Visible = true;
            TxtGender.Visible = false;

            TxtDateOfBirth.ReadOnly = false;

            DdlMaritalStatus.Visible = true;
            TxtMaritalStatus.Visible = false;

            DdlIDType.Visible = true;
            TxtIDType.Visible = false;

            TxtIdNumber.ReadOnly = false;

            TxtAddressLine1.ReadOnly = false;

            TxtAddressLine2.ReadOnly = false;

            TxtAddressLine3.ReadOnly = false;

            TxtAddressPostcode.ReadOnly = false;

            TxtAddressCity.ReadOnly = false;

            TxtAddressState.ReadOnly = false;









            //TxtRegisterBy.ReadOnly = false;



            //DdlAddressCountry.Visible = true;
            //TxtAddressCountry.Visible = false;

            //DdlBranch.Visible = true;
            //TxtBranch.Visible = false;

            //RblStatus.Visible = true;
            //TxtStatus.Visible = false;


            //PotentialStudentEntity potenStud = (PotentialStudentEntity)Session[Constant.SESSION_NAME_POTEN_STUD];

            //if (potenStud.DtePotenStudSignUpDate == null)
            //{
            //    ChkIsSignedUp.Enabled = true;
            //    TxtSignUpDate.ReadOnly = false;
            //}

            //if (potenStud.DtePotenStudSignUpDate != null && potenStud.DtePotenStudRegFormalisationDate == null)
            //{
            //    ChkIsRegistered.Enabled = true;
            //    TxtRegistrationDate.ReadOnly = false;
            //}

            //TxtProgramme.Visible = false;
            //DdlProgramme.Visible = true;

            //DivCommentTextArea.Visible = true;

            BtnEdit.Visible = false;
            BtnSubmit.Visible = true;
        }



        //protected void ChkIsRegistered_CheckedChanged(object sender, EventArgs e)
        //{
        //    DivStudentRegistrationDate.Visible = ChkIsRegistered.Checked;
        //    DivAgentCommission.Visible = ChkIsRegistered.Checked;
        //}



        //protected void ChkIsSignedUp_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ChkIsSignedUp.Checked && TxtSignUpDate.ReadOnly == true && UserInfo.GetUserInfo().IsAdmin)
        //    {
        //        DivStudentRegistration.Visible = true;
        //    }

        //    DivStudentSignUpDate.Visible = ChkIsSignedUp.Checked;
        //}



        protected void LbtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactList.aspx");
        }

        //private void LoadCommentLogs(PotentialStudentEntity stud)
        //{
        //    gvCommentList.DataSource = stud.LstCommentLogs;
        //    gvCommentList.DataBind();
        //}

        //protected void gvList_PreRender(object sender, EventArgs e)
        //{
        //    if (gvCommentList.HeaderRow != null)
        //        gvCommentList.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}

        //protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvCommentList.PageIndex = e.NewPageIndex;
        //    LoadCommentLogs(Session[Constant.SESSION_NAME_POTEN_STUD] as PotentialStudentEntity);
        //}
    }
}