using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class MembershipHistoryEntity : BaseEntity
    {
        public string StrMembershipHistoryID { get; set; }
        public string StrContactID { get; set; }
        public string StrExistingMembershipPlanID { get; set; }
        public string StrNewMembershipPlanID { get; set; }
        public DateTime? DteContactMembershipSignupDate { get; set; }

        public string StrMembershipPlanCreatedBy { get; set; }
        public DateTime? DteMembershipPlanCreatedDate { get; set; }
        public string StrMembershipPlanModifiedBy { get; set; }
        public DateTime? DteMembershipPlanModifiedDate { get; set; }
    }
}
