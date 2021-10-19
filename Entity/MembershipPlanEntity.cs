using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class MembershipPlanEntity : BaseEntity
    {
        public string StrMembershipPlanID { get; set; }
        public string StrMembershipPlanTitle { get; set; }
        public string StrMembershipPlanDesc { get; set; }
        public int IntMembershipPlanSequence { get; set; }
        public int IntMembershipPlanMinEntitlementDay { get; set; }
        public decimal DecMembershipPlanMinTransactionValue { get; set; }
        public decimal DecMembershipPlanCreditToPurchase { get; set; }
        public decimal DecMembershipPlanPaymentAmountToPoint { get; set; }
        public decimal DecMembershipPlanBonusCreditMultiplier { get; set; }
        public decimal DecMembershipPlanEarningCredit { get; set; }
        public MembershipPlanPaymentIntervalEnumerator MembershipPlanPaymentIntervalEnumeratorMembershipPlanPaymentInterval { get; set; }
        public bool BlnMembershipPlanPaymentReminder { get; set; }
        public string StrMembershipPlanPaymentReminder10DaysBefore { get; set; }
        public string StrMembershipPlanPaymentReminder5DaysBefore { get; set; }
        public string StrMembershipPlanPaymentReminderSame { get; set; }
        public MembershipPlanUnpaidActionEnumerator MembershipPlanUnpaidActionEnumeratorMembershipPlanUnpaidAction { get; set; }
        public MembershipPlanActionAfterWarningEnumerator MembershipPlanActionAfterWarningEnumeratorMembershipPlanActionAfterWarning { get; set; }
        public int IntDayToCancelAfterWarning { get; set; }
        public string StrMembershipPlanPaymentReminder5DaysAfter { get; set; }
        public string StrMembershipPlanPaymentReminder10DaysAfter { get; set; }
        public StatusEnumerator StatusMembershipPlanStatus { get; set; }
        public string StrMembershipPlanCreatedBy { get; set; }
        public DateTime? DteMembershipPlanCreatedDate { get; set; }
        public string StrMembershipPlanModifiedBy { get; set; }
        public DateTime? DteMembershipPlanModifiedDate { get; set; }

        private MembershipReminderEntity field_membershipPlanMembershipReminder10DaysBefore;
        public MembershipReminderEntity MembershipPlanMembershipReminder10DaysBefore
        {
            get
            {
                if (field_membershipPlanMembershipReminder10DaysBefore == null)
                {
                    field_membershipPlanMembershipReminder10DaysBefore = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder10DaysBefore);
                }
                return field_membershipPlanMembershipReminder10DaysBefore;
            }
        }

        private MembershipReminderEntity field_membershipPlanMembershipReminder5DaysBefore;
        public MembershipReminderEntity MembershipPlanMembershipReminder5DaysBefore
        {
            get
            {
                if (field_membershipPlanMembershipReminder5DaysBefore == null)
                {
                    field_membershipPlanMembershipReminder5DaysBefore = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder5DaysBefore);
                }
                return field_membershipPlanMembershipReminder5DaysBefore;
            }
        }

        private MembershipReminderEntity field_membershipPlanMembershipReminderSame;
        public MembershipReminderEntity MembershipPlanMembershipReminderSame
        {
            get
            {
                if (field_membershipPlanMembershipReminderSame == null)
                {
                    field_membershipPlanMembershipReminderSame = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminderSame);
                }
                return field_membershipPlanMembershipReminderSame;
            }
        }

        private MembershipReminderEntity field_membershipPlanMembershipReminder5DaysAfter;
        public MembershipReminderEntity MembershipPlanMembershipReminder5DaysAfter
        {
            get
            {
                if (field_membershipPlanMembershipReminder5DaysAfter == null)
                {
                    field_membershipPlanMembershipReminder5DaysAfter = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder5DaysAfter);
                }
                return field_membershipPlanMembershipReminder5DaysAfter;
            }
        }

        private MembershipReminderEntity field_membershipPlanMembershipReminder10DaysAfter;
        public MembershipReminderEntity MembershipPlanMembershipReminder10DaysAfter
        {
            get
            {
                if (field_membershipPlanMembershipReminder10DaysAfter == null)
                {
                    field_membershipPlanMembershipReminder10DaysAfter = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder10DaysAfter);
                }
                return field_membershipPlanMembershipReminder10DaysAfter;
            }
        }
    }
}
