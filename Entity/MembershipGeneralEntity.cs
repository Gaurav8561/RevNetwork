using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class MembershipGeneralEntity : BaseEntity
    {
        public string StrMembershipConfigID { get; set; }
        public string StrMembershipConfigName { get; set; }
        public string StrMembershipConfigValue { get; set; }
        public string StrMembershipConfigModifiedBy { get; set; }
        public DateTime? DteMembershipConfigModifiedDate { get; set; }

        //private MembershipReminderEntity field_membershipPlanMembershipReminder10DaysBefore;
        //public MembershipReminderEntity MembershipPlanMembershipReminder10DaysBefore
        //{
        //    get
        //    {
        //        if (field_membershipPlanMembershipReminder10DaysBefore == null)
        //        {
        //            field_membershipPlanMembershipReminder10DaysBefore = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder10DaysBefore);
        //        }
        //        return field_membershipPlanMembershipReminder10DaysBefore;
        //    }
        //}

        //private MembershipReminderEntity field_membershipPlanMembershipReminder5DaysBefore;
        //public MembershipReminderEntity MembershipPlanMembershipReminder5DaysBefore
        //{
        //    get
        //    {
        //        if (field_membershipPlanMembershipReminder5DaysBefore == null)
        //        {
        //            field_membershipPlanMembershipReminder5DaysBefore = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder5DaysBefore);
        //        }
        //        return field_membershipPlanMembershipReminder5DaysBefore;
        //    }
        //}

        //private MembershipReminderEntity field_membershipPlanMembershipReminderSame;
        //public MembershipReminderEntity MembershipPlanMembershipReminderSame
        //{
        //    get
        //    {
        //        if (field_membershipPlanMembershipReminderSame == null)
        //        {
        //            field_membershipPlanMembershipReminderSame = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminderSame);
        //        }
        //        return field_membershipPlanMembershipReminderSame;
        //    }
        //}

        //private MembershipReminderEntity field_membershipPlanMembershipReminder5DaysAfter;
        //public MembershipReminderEntity MembershipPlanMembershipReminder5DaysAfter
        //{
        //    get
        //    {
        //        if (field_membershipPlanMembershipReminder5DaysAfter == null)
        //        {
        //            field_membershipPlanMembershipReminder5DaysAfter = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder5DaysAfter);
        //        }
        //        return field_membershipPlanMembershipReminder5DaysAfter;
        //    }
        //}

        //private MembershipReminderEntity field_membershipPlanMembershipReminder10DaysAfter;
        //public MembershipReminderEntity MembershipPlanMembershipReminder10DaysAfter
        //{
        //    get
        //    {
        //        if (field_membershipPlanMembershipReminder10DaysAfter == null)
        //        {
        //            field_membershipPlanMembershipReminder10DaysAfter = MembershipReminderInterface.GetByPrimaryKey(this.StrMembershipPlanPaymentReminder10DaysAfter);
        //        }
        //        return field_membershipPlanMembershipReminder10DaysAfter;
        //    }
        //}
    }
}
