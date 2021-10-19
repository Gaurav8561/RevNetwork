using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class AgentRoleEnumerator : UserRoleEnumerator
    {
        public static readonly AgentRoleEnumerator AgentRoleAgent 
            = new AgentRoleEnumerator("AGENT", "typeEnum.agentRole.agent");

        private AgentRoleEnumerator(string strKey, string strResxKey) : base(strKey, strResxKey)
        {
        }



        public static new AgentRoleEnumerator GetEnumByKey(string strKey)
        {
            return (AgentRoleEnumerator)GetEnumByKey(typeof(AgentRoleEnumerator), strKey);
        }



        public static new List<AgentRoleEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(AgentRoleEnumerator)).Cast<AgentRoleEnumerator>().ToList();
        }
    }
}
