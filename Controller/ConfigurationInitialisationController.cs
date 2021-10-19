using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using TypeEnumerator;



namespace Controller
{
    public class ConfigurationInitialisationController
    {
        public static void InitialiseConfiguration()
        {
            foreach (ConfigurationNameEnumerator configName in ConfigurationNameEnumerator.GetEnumList())
            {
                if (ConfigurationInterface.GetConfigurationByConfigurationName(configName.StrKey) == null)
                {
                    string strInitValue = string.Empty;

                    if (configName.ObjDefaultValue != null)
                    {
                        if (configName.FuncFormatter != null)
                            strInitValue = configName.FuncFormatter(configName.ObjDefaultValue);
                        else
                            strInitValue = configName.ObjDefaultValue.ToString();
                    }
                    else
                    {
                        switch (configName.DtDataType)
                        {
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_STRING:
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_URL:
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_PASSWORD:
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_EMAIL:
                                strInitValue = string.Empty;
                                break;
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_INT:
                            case ConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DECIMAL:
                                strInitValue = (0).ToString();
                                break;
                            case GeneralConfigurationNameEnumerator.ConfigurationDataType.DATA_TYPE_DATE:
                                strInitValue = DateTime.Now.ToString();
                                break;
                        }
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
