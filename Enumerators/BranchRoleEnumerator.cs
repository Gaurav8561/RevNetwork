using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;



namespace TypeEnumerator
{
    public class BranchRoleEnumerator : BaseEnumerator
    {
        //public static readonly BranchRoleEnumerator BranchRoleBranch = new BranchRoleEnumerator("BRANCH", "Branch", "typeEnum.branchRole.branch");
        public static readonly BranchRoleEnumerator BranchRoleCentre = new BranchRoleEnumerator("CENTRE", "Centre", "typeEnum.branchRole.centre");
        public static readonly BranchRoleEnumerator BranchRoleGroup = new BranchRoleEnumerator("GROUP", "Group", "typeEnum.branchRole.group");


        //private static readonly Dictionary<string, BranchRoleEnumerator> dict
        //    = new Dictionary<string, BranchRoleEnumerator>{{ BranchRoleBranch.StrKey, BranchRoleBranch },
        //                                                   { BranchRoleCentre.StrKey, BranchRoleCentre },
        //                                                   { BranchRoleGroup.StrKey, BranchRoleGroup }};
        private static readonly Dictionary<string, BranchRoleEnumerator> dict
        = new Dictionary<string, BranchRoleEnumerator>{{ BranchRoleCentre.StrKey, BranchRoleCentre },
                                                           { BranchRoleGroup.StrKey, BranchRoleGroup }};

        public BranchRoleEnumerator(string strKey, string strDispText, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static BranchRoleEnumerator GetEnumByKey(string strKey)
        {
            if (dict.TryGetValue(strKey.Trim(), out BranchRoleEnumerator value))
                return value;
            else
                return null;
        }



        public static List<BranchRoleEnumerator> GetEnumList()
        {
            return dict.Values.ToList();
        }
    }
}
