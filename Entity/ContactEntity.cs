using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General;
using TypeEnumerator;



namespace Entity
{
    public class ContactEntity : UserEntity
    {
        public string StrContactID { get; set; }
        public string StrContactLoginUserName { get; set; }
        public string StrContactLoginPassword { get; set; }
        public string StrContactName { get; set; }
        public GenderEnumerator GenderEnumeratorContactGender { get; set; }
        //public string StrContactEmail { get; set; }
        public string StrContactEmail { get; set; }
        public IDTypeEnumerator IDTypeEnumeratorContactIDType { get; set; }
        public string StrContactIDNumber { get; set; }

        public Address AddContactAddress { get; set; }

        public DateTime? DteContactDOB { get; set; }
        public MaritalStatusEnumerator MaritalStatusEnumeratorContactMaritalStat { get; set; }
        public string StrContactCreditCard { get; set; }
        public DateTime? DteContactLastLogin { get; set; }

        public string StrContactReferralCode { get; set; }
        public string StrContactReferrerContactID { get; set; }
        public string StrContactFirstTimeTopup { get; set; }



        public decimal DecContactTotalTopup { get; set; }
        public decimal DecContactPaymentPoint { get; set; }
        public string StrMembershipPlanID { get; set; }

        public DateTime? DteContactMembershipSignupDate { get; set; }

        public DateTime? DteContactMembershipLastPaymentDate { get; set; }
        public DateTime? DteContactMembershipNextPaymentDate { get; set; }

        public StatusEnumerator StatusEnumeratorContactStatus { get; set; }
        public string StrContactCreatedBy { get; set; }
        public DateTime? DteContactCreatedDate { get; set; }
        public string StrContactModifiedBy { get; set; }
        public DateTime? DteContactModifiedDate { get; set; }


        //private ContactWalletPocketMasterEntity field_contactWalletPocketMaster;
        //public ContactWalletPocketMasterEntity ContactContactWalletPocketMaster
        //{
        //    get
        //    {
        //        if (field_contactWalletPocketMaster == null)
        //        {
        //            field_contactWalletPocketMaster = ContactWalletPocketMasterInterface.GetByCustomColumn("ContactID", this.StrContactID);
        //        }

        //        return field_contactWalletPocketMaster;
        //    }
        //}



        private MembershipPlanEntity field_contactMembershipPlan;
        public MembershipPlanEntity ContactMembershipPlan
        {
            get
            {
                if (field_contactMembershipPlan == null)
                {
                    field_contactMembershipPlan = MembershipPlanInterface.GetByPrimaryKey(this.StrMembershipPlanID);
                }
                return field_contactMembershipPlan;
            }
        }



        //private ContactWalletPocketMasterEntity field_contactContactWalletPocketMaster;
        //public ContactWalletPocketMasterEntity ContactContactWalletPocketMaster
        //{
        //    get
        //    {
        //        if (field_contactContactWalletPocketMaster == null)
        //        {
        //            field_contactContactWalletPocketMaster = ContactWalletPocketMasterInterface.GetByCustomColumn("ContactID", this.StrContactID);
        //        }
        //        return field_contactContactWalletPocketMaster;
        //    }
        //}



        private List<ReferralCodeEntity> field_lstReferralCodes;
        public List<ReferralCodeEntity> LstReferralCodes
        {
            get
            {
                if (field_lstReferralCodes == null)
                {
                    field_lstReferralCodes = ReferralCodeInterface.listReferralCode(new ReferralCodeEntity
                    {
                        StrRefCodeOwner_ContactID = this.StrContactID
                    });
                }
                return field_lstReferralCodes;
            }
        }

        //private TransactionEntity field_contactWalletPocketMasterTransaction;
        //public TransactionEntity ContactWalletPocketMasterTransaction
        //{
        //    get
        //    {
        //        if (field_contactWalletPocketMasterTransaction == null)
        //        {
        //            field_contactWalletPocketMasterTransaction = WalletPocketMasterTransactionInterface.GetByCustomColumn("ContactID", this.StrContactID);
        //        }
        //        return field_contactWalletPocketMasterTransaction;
        //    }
        //}



        //public string StrPotenStudID { get; set; }
        //public string StrPotenStudName { get; set; }
        //public IDTypeEnumerator IDTypePotenStudIDType { get; set; }
        //public string StrPotenStudIDNumber { get; set; }
        //public DateTime? DtePotenStudDOB { get; set; }
        //public string StrPotenStudEmail { get; set; }
        //public GenderEnumerator GenderPotenStudGender { get; set; }
        //public MaritalStatusEnumerator MarStatPotenStudMaritalStat { get; set; }
        //public string StrPotenStudContactNo { get; set; }
        //public Address AddPotenStudAddress { get; set; }
        //public DateTime? DtePotenStudRegByDate { get; set; }
        //public DateTime? DtePotenStudSignUpDate { get; set; }
        //public DateTime? DtePotenStudRegFormalisationDate { get; set; }
        //public decimal? DecPotenStudCommissionRate { get; set; }
        //public decimal? DecPotenStudCommissionTotalPaidOut { get; set; }
        //public DateTime? DtePotenStudCommissionPaidOutDate { get; set; }
        //public string StrPotenStudReferrer_AgentID { get; set; }
        //public string StrPotenStudBranch_BranchID { get; set; }
        //public string StrPotenStudProgramme_ProgrammeID { get; set; }
        //public StatusEnumerator StatusPotenStudStatus { get; set; }
        //public string StrPotenStudCreatedBy { get; set; }
        //public DateTime? DtePotenStudCreatedDate { get; set; }
        //public string StrPotenStudModifiedBy { get; set; }
        //public DateTime? DtePotenStudModifiedDate { get; set; }

        //private AgentEntity field_agentPotenStudReferrer;
        //public AgentEntity AgentPotenStudReferrer
        //{
        //    get
        //    {
        //        if (field_agentPotenStudReferrer == null)
        //        {
        //            field_agentPotenStudReferrer = AgentInterface.GetAgentByPrimaryKey(this.StrPotenStudReferrer_AgentID);
        //        }
        //        return field_agentPotenStudReferrer;
        //    }
        //}



        //private BranchEntity field_branchPotenStudBranch;
        //public BranchEntity BranchPotenStudBranch
        //{
        //    get
        //    {
        //        if (field_branchPotenStudBranch == null)
        //        {
        //            field_branchPotenStudBranch = BranchInterface.GetBranchByPrimaryKey(this.StrPotenStudBranch_BranchID);
        //        }
        //        return field_branchPotenStudBranch;
        //    }
        //}

        //private ProgrammeEntity field_programmePotenStudProgramme;
        //public ProgrammeEntity ProgrammePotenStudProgramme
        //{
        //    get
        //    {
        //        if (field_programmePotenStudProgramme == null)
        //        {
        //            field_programmePotenStudProgramme = ProgrammeInterface.GetByPrimaryKey(this.StrPotenStudProgramme_ProgrammeID);
        //        }
        //        return field_programmePotenStudProgramme;
        //    }
        //}

        //private List<PotentialStudentCommentLogEntity> field_LstCommentLogs;
        //public List<PotentialStudentCommentLogEntity> LstCommentLogs
        //{
        //    get
        //    {
        //        if (field_LstCommentLogs == null)
        //        {
        //            field_LstCommentLogs = PotentialStudentCommentLogInterface.List(new PotentialStudentCommentLogEntity { StrPotentialStudentCommentLog_PotenStudID = this.StrPotenStudID });
        //        }
        //        return field_LstCommentLogs;
        //    }
        //}

        //public StudentRegistrationStatusEnumerator RegistrationStatus
        //{
        //    get
        //    {
        //        if (DtePotenStudRegFormalisationDate != null)
        //            return StudentRegistrationStatusEnumerator.StudentRegistrationRegistered;
        //        else
        //        {
        //            if (((DateTime)DtePotenStudRegByDate) >= DateTime.Now)
        //                return StudentRegistrationStatusEnumerator.StudentRegistrationPending;
        //            else
        //                return StudentRegistrationStatusEnumerator.StudentRegistrationExpired;

        //        }
        //    }
        //}

        public ContactEntity()
        {
            this.StrContactID = string.Empty;
            this.StrContactLoginUserName = string.Empty;
            this.StrContactLoginPassword = string.Empty;
            this.StrContactName = string.Empty;
            this.GenderEnumeratorContactGender = null;
            //this.StrContactEmail = string.Empty;
            this.StrContactEmail = string.Empty;
            this.IDTypeEnumeratorContactIDType = null;
            this.StrContactIDNumber = string.Empty;

            this.AddContactAddress = new Address();

            this.DteContactDOB = null;
            this.MaritalStatusEnumeratorContactMaritalStat = null;
            this.StrContactCreditCard = string.Empty;
            this.DteContactLastLogin = null;

            this.StrContactReferralCode = string.Empty;
            this.StrContactReferrerContactID = string.Empty;
            this.StrContactFirstTimeTopup = string.Empty;
            this.DecContactTotalTopup = 0.0M;
            this.DecContactPaymentPoint = 0.0M;
            this.StrMembershipPlanID = string.Empty;

            this.DteContactMembershipSignupDate = null;

            this.DteContactMembershipNextPaymentDate = null;

            this.StatusEnumeratorContactStatus = null;
            this.StrContactCreatedBy = string.Empty;
            this.DteContactCreatedDate = null;
            this.StrContactModifiedBy = string.Empty;
            this.DteContactModifiedDate = null;
        }



        public ContactEntity(
            string strContactID,
            string strContactLoginUserName,
            string strContactLoginPassword,
            string strContactName,
            GenderEnumerator genderEnumeratorContactGender,
            //string strContactEmail,
            string strContactEmail,
            IDTypeEnumerator iDTypeEnumeratorContactIDType,
            string strContactIDNumber,

            Address addContactAddress,

            DateTime? dteContactDOB,
            MaritalStatusEnumerator maritalStatusEnumeratorContactMaritalStat,
            string strContactCreditCard,
            DateTime? dteContactLastLogin,

            string strContactReferralCode,
            string strContactReferrerContactID,
            string strContactFirstTimeTopup,
            decimal decContactTotalTopup,
            decimal decContactPaymentPoint,
            string strMembershipPlanID,

            DateTime? dteContactMembershipSignupDate,

            DateTime? dteContactMembershipNextPaymentDate,

            StatusEnumerator statusEnumeratorContactStatus,
            string strContactCreatedBy,
            DateTime? dteContactCreatedDate,
            string strContactModifiedBy,
            DateTime? dteContactModifiedDate)
        {
            this.StrContactID = strContactID;
            this.StrContactLoginUserName = strContactLoginUserName;
            this.StrContactLoginPassword = strContactLoginPassword;
            this.StrContactName = strContactName;
            this.GenderEnumeratorContactGender = genderEnumeratorContactGender;
            //this.StrContactEmail = strContactEmail;
            this.StrContactEmail = strContactEmail;
            this.IDTypeEnumeratorContactIDType = iDTypeEnumeratorContactIDType;
            this.StrContactIDNumber = strContactIDNumber;

            this.AddContactAddress = addContactAddress;

            this.DteContactDOB = dteContactDOB;
            this.MaritalStatusEnumeratorContactMaritalStat = maritalStatusEnumeratorContactMaritalStat;
            this.StrContactCreditCard = strContactCreditCard;
            this.DteContactLastLogin = dteContactLastLogin;

            this.StrContactReferralCode = strContactReferralCode;
            this.StrContactReferrerContactID = strContactReferrerContactID;
            this.StrContactFirstTimeTopup = strContactFirstTimeTopup;
            this.DecContactTotalTopup = decContactTotalTopup;
            this.DecContactPaymentPoint = decContactPaymentPoint;
            this.StrMembershipPlanID = strMembershipPlanID;

            this.DteContactMembershipSignupDate = dteContactMembershipSignupDate;

            this.DteContactMembershipNextPaymentDate = dteContactMembershipNextPaymentDate;

            this.StatusEnumeratorContactStatus = statusEnumeratorContactStatus;
            this.StrContactCreatedBy = strContactCreatedBy;
            this.DteContactCreatedDate = dteContactCreatedDate;
            this.StrContactModifiedBy = strContactModifiedBy;
            this.DteContactModifiedDate = dteContactModifiedDate;
        }
    }
}
