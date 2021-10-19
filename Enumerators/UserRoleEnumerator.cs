using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public abstract class UserRoleEnumerator : BaseEnumerator
    {
        protected UserRoleEnumerator(string strKey, string strResxKey) : base(strKey, strResxKey)
        {
            RegisterChildEnumerator(typeof(UserRoleEnumerator), this.GetType());
        }



        public static UserRoleEnumerator GetEnumByKey(string strKey)
        {
            return (UserRoleEnumerator)GetEnumByKey(typeof(UserRoleEnumerator), strKey);
        }



        public static List<UserRoleEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(UserRoleEnumerator)).Cast<UserRoleEnumerator>().ToList();
        }
    }
}
