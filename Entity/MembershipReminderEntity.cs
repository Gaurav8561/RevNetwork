using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class MembershipReminderEntity : BaseEntity
    {
        public string StrMembershipReminderID { get; set; }
        public string StrMembershipReminderSubject { get; set; }
        public string StrMembershipReminderBody { get; set; }
        public MembershipReminderTypeEnumerator MembershipReminderTypeEnumeratorMembershipReminderType { get; set; }
        public StatusEnumerator StatusMembershipReminderStatus { get; set; }
        public string StrMembershipReminderCreatedBy { get; set; }
        public DateTime? DteMembershipReminderCreatedDate { get; set; }
        public string StrMembershipReminderModifiedBy { get; set; }
        public DateTime? DteMembershipReminderModifiedDate { get; set; }
    }
}
