using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TypeEnumerator;



namespace Utility
{
    public class ContactInfo1
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime? LastLogin { get; set; }

        //public bool IsAdmin
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.Role))
        //            return AdminRoleEnumerator.GetEnumList().Any(x => x.StrKey == this.Role);
        //        else
        //            return false;
        //    }
        //}

        //public bool IsAgent
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(this.Role))
        //            return AgentRoleEnumerator.AgentRoleAgent.StrKey == this.Role;
        //        else
        //            return false;
        //    }
        //}

        public static ContactInfo1 GetContactInfo()
        {
            if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["UserInfo"] != null)
            {
                return (ContactInfo1)HttpContext.Current.Session["UserInfo"];
            }
            return new ContactInfo1();
        }
    }
}
