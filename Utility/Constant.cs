using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Utility
{
    public class Constant
    {
        public const string g_sDBEntity = "dbEntity";
        public const string strYES = "Yes";
        public const string strNO = "No";

        //Session
        //QR Topup
        public const string SESSION_NAME_QR_TOPUP_TOKEN = "SessionQRTopupToken";
        public const string SESSION_NAME_QR_TOPUP_DATETIME = "SessionQRTopupDateTime";
        public const string SESSION_NAME_QR_TOPUP_AMOUNT = "SessionQRTopupAmount";
        public const string SESSION_NAME_QR_TOPUP_USERID = "SessionQRTopupUserID";


        //Contact
        public const string SESSION_NAME_CONTACT_ID = "SessionContactID";
        public const string SESSION_NAME_CONTACT = "SessionContact";


        //ContactWalletPocketMaster
        public const string SESSION_NAME_CONTACT_WALLET_POCKET_MASTER = "SessionContactWalletPocketMaster";

        //Membership General
        public const string SESSION_NAME_MEMBERSHIP_UPGRADE_MODE = "SessionMembershipUpgradeMode";

        //Membership Plan
        public const string SESSION_NAME_MEMBERSHIP_PLAN_ID = "SessionMembershipPlanId";
        public const string SESSION_NAME_MEMBERSHIP_PLAN = "SessionMembershipPlan";
        public const string SESSION_NAME_SELECTED_MEMBERSHIP_PLAN = "SessionSelectedMembershipPlan";
        public const string MEMBERSHIP_PLAN_ID_FREE = "MBP-FREE";

        //Membership Reminder
        public const string SESSION_NAME_MEMBERSHIP_REMINDER_ID = "SessionMembershipReminderId";
        public const string SESSION_NAME_MEMBERSHIP_REMINDER = "SessionMembershipReminder";


        //Pocket
        public const string SESSION_NAME_WALLET_POCKET_ID = "SessionWalletPocketId";
        public const string SESSION_NAME_WALLET_POCKET = "SessionWalletPocket";

        //Payment
        public const string SESSION_NAME_PAYMENT_PASSWORD_VERIFIED = "SessionPaymentPasswordVerified";

        public const string SESSION_NAME_PAYMENT_MODE = "SessionPaymentMode";
        public const string SESSION_NAME_PAYMENT_AMOUNT = "SessionPaymentAmount";
        public const string SESSION_NAME_PAYMENT_TRANS_NO = "SessionPaymentTransNo";

        public const string SESSION_NAME_PAYMENT_CONTACT_ID = "SessionPaymentContactId";
        public const string SESSION_NAME_PAYMENT_MERCHANT_TRANSACTION_TOKEN = "SessionPaymentMerchantTransactionToken";
        public const string SESSION_NAME_PAYMENT_CONTACT_TRANSACTION_TOKEN = "SessionPaymentContactTransactionToken";

        //Topup
        public const string SESSION_NAME_TOPUP_PASSWORD_VERIFIED = "SessionTopupPasswordVerified";

        public const string SESSION_NAME_TOPUP_CONTACT_ID = "SessionTopupContactId";
        public const string SESSION_NAME_TOPUP_MERCHANT_TRANSACTION_TOKEN = "SessionTopupMerchantTransactionToken";
        public const string SESSION_NAME_TOPUP_CONTACT_TRANSACTION_TOKEN = "SessionTopupContactTransactionToken";
		
		public const string SESSION_NAME_TOPUP_MODE = "SessionTopupMode";
        public const string SESSION_NAME_TOPUP_AMOUNT = "SessionTopupAmount";
        public const string SESSION_NAME_TOPUP_TRANS_NO = "SessionTopupTransNo";
		
        //Timer
        public const string SESSION_NAME_QR_TIMER_STATUS = "SessionQRTimerStatus";

        //Credit
        public const string SESSION_NAME_CREDIT_BALANCE = "SessionCreditBalance";


        //Potential Student
        public const string SESSION_NAME_POTEN_STUD_ID = "SessionPotentStudId";
        public const string SESSION_NAME_POTEN_STUD = "SessionPotentStud";
        public const string SESSION_NAME_BRANCH_ID = "SessionBranchId";
        public const string SESSION_NAME_BRANCH = "SessionBranch";
        public const string SESSION_NAME_REFERRAL_CODE = "SessionReferralCode";
		public const string SESSION_NAME_SUBMIT_MODE = "SessionSubmitMode";
		public const string SESSION_NAME_SUBMIT_MODE_EDIT = "SessionSubmitModeEdit";
        public const string SESSION_NAME_BRANCH_MODE = "SessionBranchMode";

        //Agent
        public const string SESSION_NAME_AGENT_ID = "SessionAgentId";
        public const string SESSION_NAME_AGENT = "SessionAgent";

        //User
        public const string SESSION_NAME_USER_ID = "SessionUserId";
        public const string SESSION_NAME_USER = "SessionUser";

        //Programme
        public const string SESSION_NAME_PROGRAMME_ID = "SessionProgrammeId";
        public const string SESSION_NAME_PROGRAMME = "SessionProgramme";

        //Query String
        public const string QUERY_STRING_NAME_REFERRAL_CODE = "RefCode";
        public const string QUERY_STRING_NAME_PARAM = "param";

        //Dashboard Metrics
        //Month
        public const string FLAG_CURRENT_MONTH = "cm";
        public const string FLAG_PREVIOUS_MONTH = "pm";

        //Status
        public const string FLAG_CURRENT_REG_STATUS_PENDING = "p";
        public const string FLAG_CURRENT_REG_STATUS_SIGNEDUP = "s";
        public const string FLAG_CURRENT_REG_STATUS_EXPIRED = "e";
        public const string FLAG_CURRENT_REG_STATUS_ALL = "a";

        //current month
        public const string QUERY_STRING_NAME_CURRENT_MONTH_PENDING = FLAG_CURRENT_MONTH + FLAG_CURRENT_REG_STATUS_PENDING;
        public const string QUERY_STRING_NAME_CURRENT_MONTH_SIGNEDUP = FLAG_CURRENT_MONTH + FLAG_CURRENT_REG_STATUS_SIGNEDUP;
        public const string QUERY_STRING_NAME_CURRENT_MONTH_EXPIRED = FLAG_CURRENT_MONTH + FLAG_CURRENT_REG_STATUS_EXPIRED;
        public const string QUERY_STRING_NAME_CURRENT_MONTH_ALL = FLAG_CURRENT_MONTH + FLAG_CURRENT_REG_STATUS_ALL;

        //previous month
        public const string QUERY_STRING_NAME_PREVIOUS_MONTH_PENDING = FLAG_PREVIOUS_MONTH + FLAG_CURRENT_REG_STATUS_PENDING;
        public const string QUERY_STRING_NAME_PREVIOUS_MONTH_SIGNEDUP = FLAG_PREVIOUS_MONTH + FLAG_CURRENT_REG_STATUS_SIGNEDUP;
        public const string QUERY_STRING_NAME_PREVIOUS_MONTH_EXPIRED = FLAG_PREVIOUS_MONTH + FLAG_CURRENT_REG_STATUS_EXPIRED;
        public const string QUERY_STRING_NAME_PREVIOUS_MONTH_ALL = FLAG_PREVIOUS_MONTH + FLAG_CURRENT_REG_STATUS_ALL;

        //Pocket Table
        public const string TABLE_NAME_CONTACT_WALLET_POCKET_MASTER = "tbl_ContactWalletPocketMaster";
        public const string TABLE_NAME_CONTACT_WALLET_POCKET_BONUS = "tbl_ContactWalletPocketBonus";
        public const string TABLE_NAME_CONTACT_WALLET_POCKET_EARNING = "tbl_ContactWalletPocketEarning";
        public const string TABLE_NAME_CONTACT_WALLET_POCKET = "tbl_ContactWalletPocket";
    }
}
