using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class AdminRoleEnumerator : UserRoleEnumerator
    {
        //public static readonly UserRoleEnumerator UserRoleBranchAdmin = new UserRoleEnumerator("BRANCH_ADMIN", "Branch Admin", "typeEnum.userRole.branchAdmin");

        //public static readonly AdminRoleEnumerator UserRoleCentreAdmin 
        //    = new AdminRoleEnumerator("CENTRE_ADMIN", "typeEnum.userRole.centreAdmin");
        public static readonly AdminRoleEnumerator UserRoleUserAdmin
            = new AdminRoleEnumerator("USER_ADMIN", "typeEnum.userRole.userAdmin");
        public static readonly AdminRoleEnumerator UserRoleGroupAdmin 
            = new AdminRoleEnumerator("GROUP_ADMIN", "typeEnum.userRole.groupAdmin");

        private AdminRoleEnumerator(string strKey, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static new AdminRoleEnumerator GetEnumByKey(string strKey)
        {
            return (AdminRoleEnumerator)GetEnumByKey(typeof(AdminRoleEnumerator), strKey);
        }



        public static new List<AdminRoleEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(AdminRoleEnumerator)).Cast<AdminRoleEnumerator>().ToList();
        }
    }
}
