using Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Resources;
using System.Web;
using System.Web.UI;
using TypeEnumerator;
using Utility;
using Newtonsoft.Json;



namespace RevNetwork
{
    public partial class ContactExtv3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DivErrorDisplay.Visible = false;

                ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources_TypeEnumerator.resx"));

                DivMainContactForm.Visible = true;
            }
        }


        public class ReCaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }



        string GetIpAddress()
        {
            var ipAddress = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                ipAddress = Request.UserHostAddress;
            }

            return ipAddress;
        }



        public bool ValidateReCaptcha(ref string strRecaptchaErrorMessage)
        {
            var gresponse = Request["g-recaptcha-response"];
            string secret = "6LeTiVwcAAAAAMKk3CamwAG3tlb896vmhndSeU7a";
            string ipAddress = GetIpAddress();

            var client = new WebClient();

            string url = string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}&remoteip={2}", secret, gresponse, ipAddress);

            var response = client.DownloadString(url);

            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaResponse>(response);

            if (captchaResponse.Success)
            {
                return true;
            }
            else
            {
                var error = captchaResponse.ErrorCodes[0].ToLower();
                switch (error)
                {
                    case ("missing-input-secret"):
                        strRecaptchaErrorMessage = "The secret key parameter is missing";
                        break;
                    case ("invalid-input-secret"):
                        strRecaptchaErrorMessage = "The given secret key parameter is invalid";
                        break;
                    case ("missing-input-response"):
                        strRecaptchaErrorMessage = "The g-recaptcha-response parameter is missing";
                        break;
                    case ("invalid-input-response"):
                        strRecaptchaErrorMessage = "Invalid reCAPTCHA response";
                        break;
                    default:
                        strRecaptchaErrorMessage = "reCAPTCHA Error";
                        break;
                }

                return false;
            }
        }



        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string strRecaptchaErrorMessage = string.Empty;
            string strContactNewPassword = string.Empty;
            string strContactIdNumber = string.Empty;
            string strContactMobile = string.Empty;

            ResXResourceSet resxSet = new ResXResourceSet(HttpContext.Current.Server.MapPath("~/App_GlobalResources/Resources.resx"));

            DivErrorDisplay.Visible = false;
            LblErrorDisplay.Text = string.Empty;

            LblNewPassword.ForeColor = System.Drawing.Color.Black;
            LblPhoneNumber.ForeColor = System.Drawing.Color.Black;

            //Assign var
            strContactNewPassword = TxtNewPassword.Text.Trim();
            strContactMobile = TxtPhoneNumber.Text.Trim();

            List<string> lstRequiredEmptyField = new List<string>();

            if (string.IsNullOrWhiteSpace(strContactMobile))
            {
                lstRequiredEmptyField.Add(LblPhoneNumber.Text);
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(Session[Constant.SESSION_NAME_CONTACT_ID] as string))
            {
                if (string.IsNullOrWhiteSpace(strContactNewPassword))
                {
                    lstRequiredEmptyField.Add(LblNewPassword.Text);
                    LblNewPassword.ForeColor = System.Drawing.Color.Red;
                }
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

            if (!string.IsNullOrWhiteSpace(strContactMobile) && !Common.IsValidPhone(strContactMobile))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldInvalidPhoneNumber") + "<br />";
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            if (!string.IsNullOrWhiteSpace(strContactMobile) && IsDuplicateContactMobile(strContactMobile))
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldDuplicatePhoneNumber") + "<br />";
                LblPhoneNumber.ForeColor = System.Drawing.Color.Red;
            }

            if (!ValidateReCaptcha(ref strRecaptchaErrorMessage))
            {
                LblErrorDisplay.Text += "- " + strRecaptchaErrorMessage + "<br />";
            }

            if (!ChkAgreePDPA.Checked)
            {
                LblErrorDisplay.Text += "- " + resxSet.GetString("errorFieldPdpaRequire") + "<br />";
                LblAgreePDPA.ForeColor = System.Drawing.Color.Red;
            }

            if (string.IsNullOrEmpty(LblErrorDisplay.Text))
            {
                if (!string.IsNullOrEmpty(Session[Constant.SESSION_NAME_SUBMIT_MODE] as string) && (Session[Constant.SESSION_NAME_SUBMIT_MODE] as string).Equals(Constant.SESSION_NAME_SUBMIT_MODE_EDIT))
                {
                    
                }
                else
                {
                    ContactEntity contact = ContactInterface.NewContact(new ContactEntity
                    {
                        StrContactLoginUserName = strContactMobile,
                        StrContactLoginPassword = strContactNewPassword,
                        StrContactName = strContactMobile,
                        IDTypeEnumeratorContactIDType = IDTypeEnumerator.GetEnumByKey("MYS-IC-NEW"),
                        DteContactDOB = (DateTime?)null,
                        MaritalStatusEnumeratorContactMaritalStat = MaritalStatusEnumerator.GetEnumByKey("SIN"),
                        StrMembershipPlanID = Constant.MEMBERSHIP_PLAN_ID_FREE,
                    });

                    contact.StatusEnumeratorContactStatus = StatusEnumerator.StatusActive;
                    contact = ContactInterface.UpdateContact(contact);

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
                    //        StrWalletPocketConfigID = pocketConfig[i + 2].StrWalletPocketConfigID,
                    //        StrContactID = contact.StrContactID,
                    //        DecCreditBalance = 0.0M,
                    //        StatusContactWalletPocketStatus = StatusEnumerator.StatusActive
                    //    });
                    //}

                    DivThankYou.Visible = true;
                    DivMainContactForm.Visible = false;
                }
            }
            else
            {
                LblErrorDisplay.Text = resxSet.GetString("errorRequiredCheckErrorBeforeProceed") + ":<br /><br />" + LblErrorDisplay.Text;
                DivErrorDisplay.Visible = true;

                TxtPhoneNumber.Focus();
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



        protected void LbtBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}