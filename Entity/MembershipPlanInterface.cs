using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using TypeEnumerator;
using Utility;



namespace Entity
{
    public class MembershipPlanInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
            (typeof(MembershipPlanEntity),
                "tbl_MembershipPlan",
                "MBP",
                "MembershipPlanID",
                "Status",
                "CreatedBy",
                "CreatedDate",
                "ModifiedBy",
                "ModifiedDate",
                new List<EntityToTableMapping.PropertyToColumnPair>
                {
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanID", "MembershipPlanID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanTitle", "MembershipPlanTitle"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanDesc", "MembershipPlanDesc"),
                    new EntityToTableMapping.PropertyToColumnPair("IntMembershipPlanSequence", "MembershipPlanSequence"),
                    new EntityToTableMapping.PropertyToColumnPair("IntMembershipPlanMinEntitlementDay", "MembershipPlanMinEntitlementDay"),
                    new EntityToTableMapping.PropertyToColumnPair("DecMembershipPlanMinTransactionValue", "MembershipPlanMinTransactionValue"),
                    new EntityToTableMapping.PropertyToColumnPair("DecMembershipPlanCreditToPurchase", "MembershipPlanCreditToPurchase"),
                    new EntityToTableMapping.PropertyToColumnPair("DecMembershipPlanPaymentAmountToPoint", "MembershipPlanPaymentAmountToPoint"),
                    new EntityToTableMapping.PropertyToColumnPair("DecMembershipPlanBonusCreditMultiplier", "MembershipPlanBonusCreditMultiplier"),
                    new EntityToTableMapping.PropertyToColumnPair("DecMembershipPlanEarningCredit", "MembershipPlanEarningCredit"),
                    new EntityToTableMapping.PropertyToColumnPair("MembershipPlanPaymentIntervalEnumeratorMembershipPlanPaymentInterval", "MembershipPlanPaymentInterval"),
                    new EntityToTableMapping.PropertyToColumnPair("BlnMembershipPlanPaymentReminder", "MembershipPlanPaymentReminder"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanPaymentReminder10DaysBefore", "MembershipPlanPaymentReminder10DaysBefore"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanPaymentReminder5DaysBefore", "MembershipPlanPaymentReminder5DaysBefore"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanPaymentReminderSame", "MembershipPlanPaymentReminderSame"),
                    new EntityToTableMapping.PropertyToColumnPair("MembershipPlanUnpaidActionEnumeratorMembershipPlanUnpaidAction", "MembershipPlanUnpaidAction"),
                    new EntityToTableMapping.PropertyToColumnPair("MembershipPlanActionAfterWarningEnumeratorMembershipPlanActionAfterWarning", "MembershipPlanActionAfterWarning"),
                    new EntityToTableMapping.PropertyToColumnPair("IntDayToCancelAfterWarning", "DayToCancelAfterWarning"),                    
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanPaymentReminder5DaysAfter", "MembershipPlanPaymentReminder5DaysAfter"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanPaymentReminder10DaysAfter", "MembershipPlanPaymentReminder10DaysAfter"),                    
                    new EntityToTableMapping.PropertyToColumnPair("StatusMembershipPlanStatus", "Status"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanCreatedBy", "CreatedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipPlanCreatedDate", "CreatedDate"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanModifiedBy", "ModifiedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipPlanModifiedDate", "ModifiedDate")
                });


        public static MembershipPlanEntity GetByPrimaryKey(string strMembershipPlanID)
        {
            return (MembershipPlanEntity)GetByPrimaryKey(tableMapping, strMembershipPlanID);
        }

        public static MembershipPlanEntity GetByCustomColumn(string strCustomColumn, string strColumnValue)
        {
            return (MembershipPlanEntity)GetByCustomColumn(tableMapping, strCustomColumn, strColumnValue);
        }

        public static MembershipPlanEntity New(MembershipPlanEntity membershipPlanInterface)
        {
            return (MembershipPlanEntity)New(tableMapping, membershipPlanInterface);
        }

        public static MembershipPlanEntity Update(MembershipPlanEntity membershipPlanInterface)
        {
            return (MembershipPlanEntity)Update(tableMapping, membershipPlanInterface);
        }

        public static List<MembershipPlanEntity> List(MembershipPlanEntity membershipPlanInterface)
        {
            return List(tableMapping, membershipPlanInterface).Cast<MembershipPlanEntity>().ToList();
        }

        public static List<MembershipPlanEntity> List()
        {
            return List(new MembershipPlanEntity());
        }

        public static List<MembershipPlanEntity> ListAll()
        {
            return ListAll(tableMapping, new MembershipPlanEntity()).Cast<MembershipPlanEntity>().ToList();
        }
    }
}
