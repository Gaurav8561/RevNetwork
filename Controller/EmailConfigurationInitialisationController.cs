using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using TypeEnumerator;



namespace Controller
{
    public class EmailConfigurationInitialisationController
    {
        public static void InitialiseConfiguration()
        {
            foreach (EmailConfigurationNameEnumerator configName in EmailConfigurationNameEnumerator.GetEnumList())
            {
                if (ConfigurationInterface.GetConfigurationByConfigurationName(configName.StrKey) == null)
                {
                    string strInitValue = string.Empty;
                    switch (configName.StrDataType)
                    {
                        case EmailConfigurationNameEnumerator.DATA_TYPE_STRING:
                        case EmailConfigurationNameEnumerator.DATA_TYPE_URL:
                        case EmailConfigurationNameEnumerator.DATA_TYPE_PASSWORD:
                        case EmailConfigurationNameEnumerator.DATA_TYPE_EMAIL:
                            strInitValue = string.Empty;
                            break;
                        case EmailConfigurationNameEnumerator.DATA_TYPE_INT:
                        case EmailConfigurationNameEnumerator.DATA_TYPE_DECIMAL:
                            strInitValue = (0).ToString();
                            break;
                        case EmailConfigurationNameEnumerator.DATA_TYPE_DATE:
                            strInitValue = DateTime.Now.ToString();
                            break;
                    }
                    ConfigurationInterface.UpdateConfiguration(
                    new ConfigurationEntity
                    {
                        ConfigNameConfigurationName = configName,
                        StrConfigurationValue = strInitValue
                    }); ;
                }
            }
        }
    }
}
