using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TypeEnumerator;

namespace Utility
{
    public class UserInfo
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string MembershipPlanID { get; set; }
        public string MembershipPlanTitle { get; set; }
        public int MembershipPlanSequence { get; set; }
        public DateTime? MembershipExpiryDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreatedDate { get; set; }

        public bool IsAdmin
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Role))
                    return AdminRoleEnumerator.GetEnumList().Any(x => x.StrKey == this.Role);
                else
                    return false;
            }
        }



        public bool IsGroupAdmin
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Role))
                    return AdminRoleEnumerator.UserRoleGroupAdmin.StrKey == this.Role;
                else
                    return false;
            }
        }



        public bool IsUserAdmin
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Role))
                    return AdminRoleEnumerator.UserRoleUserAdmin.StrKey == this.Role;
                else
                    return false;
            }
        }



        public bool IsAgent
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Role))
                    return AgentRoleEnumerator.AgentRoleAgent.StrKey == this.Role;
                else
                    return false;
            }
        }



        public bool IsContact
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Role))
                    return ContactRoleEnumerator.ContactRoleContact.StrKey == this.Role;
                else
                    return false;
            }
        }



        public static UserInfo GetUserInfo()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["UserInfo"] != null)
            {
                return (UserInfo)HttpContext.Current.Session["UserInfo"];
            }
            return new UserInfo();
        }
    }
}
