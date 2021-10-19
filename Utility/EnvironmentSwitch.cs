using System;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace Utility
{
    public class EnviromentSwitch
    {
        public static readonly EnvironmentType CURRENT_ENVIRONMENT = (EnvironmentType)Enum.Parse(typeof(EnvironmentType), ConfigurationManager.AppSettings["CurrentEnvironment"]);

        public enum EnvironmentType
        {
            [EnvironmentVariables("ConnString_Local")]
            LOCAL_DEVELOPMENT,
            [EnvironmentVariables("ConnString_SIT")]
            SYSTEM_INTERGRATION_TEST,
            [EnvironmentVariables("ConnString_UAT")]
            USER_ACCEPTANCE_TEST,
            [EnvironmentVariables("ConnString_Prod")]
            PRODUCTION
        }

        public class EnvironmentVariablesAttribute : Attribute
        {
            public string StrConnStringName { get; private set; }

            public EnvironmentVariablesAttribute(string strConnStringName)
            {
                this.StrConnStringName = strConnStringName;
            }
        }

        public static EnvironmentVariablesAttribute GetVariables()
        {
            return (EnvironmentVariablesAttribute)typeof(EnvironmentType).GetMember(CURRENT_ENVIRONMENT.ToString()).Single(m => m.DeclaringType == typeof(EnvironmentType)).GetCustomAttribute(typeof(EnvironmentVariablesAttribute), false);
        }
    }

    
}
