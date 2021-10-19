using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Utility;
using Entity;
using TypeEnumerator;
using System.Resources;
using Controller;
using General;
using System.Threading;
using System.Web.Security;
using System.Globalization;
using Security;

namespace RevNetwork
{
    public partial class Dashboard : System.Web.UI.Page
    {
        private static readonly List<UserRoleEnumerator> m_LstAuthorisedRoles
             = new List<UserRoleEnumerator>(AdminRoleEnumerator.GetEnumList());

        public UserInfo m_usriCurrent = new UserInfo();

        public string m_strDoughnutData = string.Empty;
        public string m_strDoughnutData_previousMonth = string.Empty;

        public string m_strLineChartMonthLabels = string.Empty;
        public string m_strLineChartData_totalSubmission = string.Empty;
        public string m_strLineChartData_totalSignedUp = string.Empty;
        public string m_strLineChartData_totalExpired = string.Empty;
        public string m_strLineChartData_totalCommission = string.Empty;

        protected void Page_Init(object sender, EventArgs e)
        {
            m_usriCurrent = UserInfo.GetUserInfo();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Page pgReference = (Page)HttpContext.Current.Handler;

                //ScriptManager.RegisterClientScriptBlock(pgReference, pgReference.GetType(), "PromptMsg", "alert('" + Common.FormatScriptValue("ccccc") + "')", true);


                if (!UserAccess.CheckRoleAuthorisation(m_LstAuthorisedRoles))
                    Response.Redirect(UserAccess.DEFAULT_LANDING_PAGE);

                if (HttpContext.Current.Session["UserInfo"] != null)
                {
                    //Member
                    List<ContactEntity> contactList = new List<ContactEntity>();

                    contactList = ContactInterface.ListContact();

                    LblTotalSignedUp.Text = contactList.Count().ToString();
                    //LblTotalReferred.Text = contactList.Where(x => !String.IsNullOrEmpty(x.StrContactReferralCode)).Count().ToString();



                    //Active members within 24 hrs
                    LblTotalActiveMember24Hours.Text = contactList.Where(x => !String.IsNullOrEmpty(x.DteContactLastLogin.ToString()) && DateTime.Compare(DateTime.Now, (DateTime)x.DteContactLastLogin.Value.AddDays(1)) <= 0).Count().ToString();



                    //Wallet
                    //List<WalletPocketMasterTransactionEntity> masterPocketTransactionList = new List<WalletPocketMasterTransactionEntity>();

                    //masterPocketTransactionList = WalletPocketMasterTransactionInterface.ListAll();




                    //Total topped up today
                    //LblTotalMasterTopupToday.Text = masterPocketTransactionList.Where(x => x.TransactionDescriptionEnumeratorTransactionDescription == TransactionDescriptionEnumerator.TransactionDescriptionTopup && x.DteWalletPocketTransactionCreatedDate.Value.ToString("dd/MMM/yyyy") == DateTime.Now.ToString("dd/MMM/yyyy")).Sum(x => x.DecCredit).ToString();



                    //Total registered today

                    //Total interest given today

                    //Total logged in today





                    //Total topped up of the month
                    //lblTotalMasterTopupMonth.Text = masterPocketTransactionList.Where(x => x.TransactionDescriptionEnumeratorTransactionDescription == TransactionDescriptionEnumerator.TransactionDescriptionTopup && x.DteWalletPocketTransactionCreatedDate.Value.ToString("MMM/yyyy") == DateTime.Now.ToString("MMM/yyyy")).Sum(x => x.DecCredit).ToString();




                    //Total registered of the month

                    //Today interest given of the month

                    //Today logged in of the month


                }
                else
                {
                    FormsAuthentication.SignOut();
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
            catch (Exception ex)
            {
                Common.LogToFile(ex.Message.ToString() + ex.StackTrace.ToString());
            }
        }
    }
}