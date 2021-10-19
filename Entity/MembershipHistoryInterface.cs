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
    public class MembershipHistoryInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
            (typeof(MembershipHistoryEntity),
                "tbl_MembershipHistory",
                "MBH",
                "MembershipHistoryID",
                null,
                "CreatedBy",
                "CreatedDate",
                "ModifiedBy",
                "ModifiedDate",
                new List<EntityToTableMapping.PropertyToColumnPair>
                {
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipHistoryID", "MembershipHistoryID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrContactID", "ContactID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrExistingMembershipPlanID", "ExistingMembershipPlanID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrNewMembershipPlanID", "NewMembershipPlanID"),
                    new EntityToTableMapping.PropertyToColumnPair("DteContactMembershipSignupDate", "ContactMembershipSignupDate"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanCreatedBy", "CreatedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipPlanCreatedDate", "CreatedDate"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipPlanModifiedBy", "ModifiedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipPlanModifiedDate", "ModifiedDate")
                });


        public static MembershipHistoryEntity GetByPrimaryKey(string strMembershipHistoryID)
        {
            return (MembershipHistoryEntity)GetByPrimaryKey(tableMapping, strMembershipHistoryID);
        }

        public static MembershipHistoryEntity GetByCustomColumn(string strCustomColumn, string strColumnValue)
        {
            return (MembershipHistoryEntity)GetByCustomColumn(tableMapping, strCustomColumn, strColumnValue);
        }

        public static MembershipHistoryEntity New(MembershipHistoryEntity membershipHistoryInterface)
        {
            return (MembershipHistoryEntity)New(tableMapping, membershipHistoryInterface);
        }

        public static MembershipHistoryEntity Update(MembershipHistoryEntity membershipHistoryInterface)
        {
            return (MembershipHistoryEntity)Update(tableMapping, membershipHistoryInterface);
        }

        public static List<MembershipHistoryEntity> List(MembershipHistoryEntity membershipHistoryInterface)
        {
            return List(tableMapping, membershipHistoryInterface).Cast<MembershipHistoryEntity>().ToList();
        }

        public static List<MembershipHistoryEntity> List()
        {
            return List(new MembershipHistoryEntity());
        }

        public static List<MembershipHistoryEntity> ListAll()
        {
            return ListAll(tableMapping, new MembershipHistoryEntity()).Cast<MembershipHistoryEntity>().ToList();
        }
    }
}
