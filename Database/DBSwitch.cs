using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Database
{
    public class DBSwitch
    {
        private static readonly DBType CURRENT_DB = (DBType)Enum.Parse(typeof(DBType), ConfigurationManager.AppSettings["DBType"]);

        public enum DBType
        {
            [DBSwitchVariables("MSSQLExecution", "MSSQLQueryStringBuilder")]
            MSSQLServer,
            [DBSwitchVariables("MySQLExecution", "MySQLQueryStringBuilder")]
            MySQL
        }




        public static DBSwitchVariablesAttribute GetVariables()
        {
            return (DBSwitchVariablesAttribute)typeof(DBType).GetMember(CURRENT_DB.ToString()).Single(m => m.DeclaringType == typeof(DBType)).GetCustomAttribute(typeof(DBSwitchVariablesAttribute), false);
        }

        public class DBSwitchVariablesAttribute : Attribute
        {
            public IDBExecutionInterface ExecutionInterface { get; private set; }
            public IQueryStringBuilderInterface QueryStringBuilder { get; private set; }

            public DBSwitchVariablesAttribute(string strExecutionInterfaceClassName, string strQueryStringBuilderClassName)
            {
                this.ExecutionInterface = (IDBExecutionInterface)typeof(IDBExecutionInterface).Assembly.GetTypes().Single(x => x.Name == strExecutionInterfaceClassName).GetConstructor(new Type[] { }).Invoke(null);
                this.QueryStringBuilder = (IQueryStringBuilderInterface)typeof(IQueryStringBuilderInterface).Assembly.GetTypes().Single(x => x.Name == strQueryStringBuilderClassName).GetConstructor(new Type[] { }).Invoke(null);
            }
        }

    }
}
