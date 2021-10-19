using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class StatusEnumerator : BaseEnumerator
    {
        public static readonly StatusEnumerator StatusActive = new StatusEnumerator("ACT", "Active", "typeEnum.status.active");
        public static readonly StatusEnumerator StatusSuspended = new StatusEnumerator("SUS", "Suspended", "typeEnum.status.suspended");
        public static readonly StatusEnumerator StatusDeleted = new StatusEnumerator("DEL", "Deleted", "typeEnum.status.deleted");

        private static readonly Dictionary<string, StatusEnumerator> dict
            = new Dictionary<string, StatusEnumerator>{{ StatusActive.StrKey, StatusActive },
                                                        { StatusSuspended.StrKey, StatusSuspended },
                                                        { StatusDeleted.StrKey, StatusDeleted }};

        public StatusEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static StatusEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out StatusEnumerator value))
                return value;
            else
                return null;
        }



        public static List<StatusEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
