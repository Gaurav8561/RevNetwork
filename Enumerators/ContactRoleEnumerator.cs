using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class ContactRoleEnumerator : UserRoleEnumerator
    {
        public static readonly ContactRoleEnumerator ContactRoleContact 
            = new ContactRoleEnumerator("CONTACT", "typeEnum.contactRole.contact");

        private ContactRoleEnumerator(string strKey, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static new ContactRoleEnumerator GetEnumByKey(string strKey)
        {
            return (ContactRoleEnumerator)GetEnumByKey(typeof(ContactRoleEnumerator), strKey);
        }



        public static new List<ContactRoleEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(ContactRoleEnumerator)).Cast<ContactRoleEnumerator>().ToList();
        }
    }
}
