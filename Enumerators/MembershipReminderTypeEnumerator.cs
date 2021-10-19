using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class MembershipReminderTypeEnumerator  : BaseEnumerator
    {
        public static readonly MembershipReminderTypeEnumerator ReminderTypeBefore = new MembershipReminderTypeEnumerator("B", "Before", "typeEnum.remindertype.before");
        public static readonly MembershipReminderTypeEnumerator ReminderTypeAfter = new MembershipReminderTypeEnumerator("A", "After", "typeEnum.remindertype.after");      

        private static readonly Dictionary<string, MembershipReminderTypeEnumerator> dict
            = new Dictionary<string, MembershipReminderTypeEnumerator>{{ ReminderTypeBefore.StrKey, ReminderTypeBefore },
                                                        { ReminderTypeAfter.StrKey, ReminderTypeAfter }};

        public MembershipReminderTypeEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static MembershipReminderTypeEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out MembershipReminderTypeEnumerator value))
                return value;
            else
                return null;
        }



        public static List<MembershipReminderTypeEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
