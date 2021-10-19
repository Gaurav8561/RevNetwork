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
    public class MembershipReminderInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
            (typeof(MembershipReminderEntity),
                "tbl_MembershipReminder",
                "MBR",
                "MembershipReminderID",
                "Status",
                "CreatedBy",
                "CreatedDate",
                "ModifiedBy",
                "ModifiedDate",
                new List<EntityToTableMapping.PropertyToColumnPair>
                {
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipReminderID", "MembershipReminderID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipReminderSubject", "MembershipReminderSubject"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipReminderBody", "MembershipReminderBody"),
                    new EntityToTableMapping.PropertyToColumnPair("MembershipReminderTypeEnumeratorMembershipReminderType", "MembershipReminderType"),
                    new EntityToTableMapping.PropertyToColumnPair("StatusMembershipReminderStatus", "Status"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipReminderCreatedBy", "CreatedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipReminderCreatedDate", "CreatedDate"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipReminderModifiedBy", "ModifiedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipReminderModifiedDate", "ModifiedDate")
                });


        public static MembershipReminderEntity GetByPrimaryKey(string strMembershipReminderID)
        {
            return (MembershipReminderEntity)GetByPrimaryKey(tableMapping, strMembershipReminderID);
        }

        public static MembershipReminderEntity GetByCustomColumn(string strCustomColumn, string strColumnValue)
        {
            return (MembershipReminderEntity)GetByCustomColumn(tableMapping, strCustomColumn, strColumnValue);
        }

        public static MembershipReminderEntity New(MembershipReminderEntity membershipReminderInterface)
        {
            return (MembershipReminderEntity)New(tableMapping, membershipReminderInterface);
        }

        public static MembershipReminderEntity Update(MembershipReminderEntity membershipReminderInterface)
        {
            return (MembershipReminderEntity)Update(tableMapping, membershipReminderInterface);
        }

        public static List<MembershipReminderEntity> List(MembershipReminderEntity membershipReminderInterface)
        {
            return List(tableMapping, membershipReminderInterface).Cast<MembershipReminderEntity>().ToList();
        }

        public static List<MembershipReminderEntity> List()
        {
            return List(new MembershipReminderEntity());
        }

        public static List<MembershipReminderEntity> ListAll()
        {
            return ListAll(tableMapping, new MembershipReminderEntity()).Cast<MembershipReminderEntity>().ToList();
        }
    }
}
