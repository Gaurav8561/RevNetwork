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
    public class MembershipGeneralInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
            (typeof(MembershipGeneralEntity),
                "tbl_MembershipConfig",
                "MBC",
                "MembershipConfigID",
                null,
                null,
                null,
                "ModifiedBy",
                "ModifiedDate",
                new List<EntityToTableMapping.PropertyToColumnPair>
                {
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipConfigID", "MembershipConfigID"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipConfigName", "MembershipConfigName"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipConfigValue", "MembershipConfigValue"),
                    new EntityToTableMapping.PropertyToColumnPair("StrMembershipConfigModifiedBy", "ModifiedBy"),
                    new EntityToTableMapping.PropertyToColumnPair("DteMembershipConfigModifiedDate", "ModifiedDate")
                });


        public static MembershipGeneralEntity GetByPrimaryKey(string strMembershipConfigID)
        {
            return (MembershipGeneralEntity)GetByPrimaryKey(tableMapping, strMembershipConfigID);
        }

        public static MembershipGeneralEntity GetByCustomColumn(string strCustomColumn, string strColumnValue)
        {
            return (MembershipGeneralEntity)GetByCustomColumn(tableMapping, strCustomColumn, strColumnValue);
        }

        public static MembershipGeneralEntity New(MembershipGeneralEntity membershipConfigInterface)
        {
            return (MembershipGeneralEntity)New(tableMapping, membershipConfigInterface);
        }

        public static MembershipGeneralEntity Update(MembershipGeneralEntity membershipConfigInterface)
        {
            return (MembershipGeneralEntity)Update(tableMapping, membershipConfigInterface);
        }

        public static List<MembershipGeneralEntity> List(MembershipGeneralEntity membershipConfigInterface)
        {
            return List(tableMapping, membershipConfigInterface).Cast<MembershipGeneralEntity>().ToList();
        }

        public static List<MembershipGeneralEntity> List()
        {
            return List(new MembershipGeneralEntity());
        }

        public static List<MembershipGeneralEntity> ListAll()
        {
            return ListAll(tableMapping, new MembershipGeneralEntity()).Cast<MembershipGeneralEntity>().ToList();
        }
    }
}
