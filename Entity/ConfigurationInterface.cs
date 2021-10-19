using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using General;
using TypeEnumerator;
using Utility;



namespace Entity
{
    public class ConfigurationInterface
    {
        private const string CONFIGURATION_TABLE_NAME = "tbl_Configuration";

        private const string CONFIGURATION_PRIMARY_KEY_PREFIX = "CONFIG";

        private const string CONFIGURATION_ID_COLUMN_NAME_PK = "ConfigurationID";
        private const string CONFIGURATION_NAME_COLUMN_NAME = "ConfigurationName";
        private const string CONFIGURATION_VALUE_COLUMN_NAME = "ConfigurationValue";
        private const string CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME = "ConfigurationLastModifiedBy";
        private const string CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME = "ConfigurationLastModifiedDate";

        private static ConfigurationEntity NewConfiguration(ConfigurationEntity configuration)
        {
            configuration.StrConfigurationID = CONFIGURATION_PRIMARY_KEY_PREFIX + "_" + configuration.ConfigNameConfigurationName.StrKey;

            CommonDB.ExecuteNonQuery(QueryStringBuilder.GetInsertStatement(CONFIGURATION_TABLE_NAME, new string[] { CONFIGURATION_ID_COLUMN_NAME_PK,
                                                                                                                        CONFIGURATION_NAME_COLUMN_NAME,
                                                                                                                        CONFIGURATION_VALUE_COLUMN_NAME,
                                                                                                                        CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME,
                                                                                                                        CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME}),
                                        IsolationLevel.Serializable,
                                        new SqlParameter[] { CommonDB.SetParameter(CONFIGURATION_ID_COLUMN_NAME_PK, configuration.StrConfigurationID),
                                                                CommonDB.SetParameter(CONFIGURATION_NAME_COLUMN_NAME, configuration.ConfigNameConfigurationName.StrKey),
                                                                CommonDB.SetParameter(CONFIGURATION_VALUE_COLUMN_NAME, configuration.StrConfigurationValue),
                                                                CommonDB.SetParameter(CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME, null),
                                                                CommonDB.SetParameter(CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME, null) },
                                        out string strErrMsg);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            return GetConfigurationByConfigurationName(configuration.ConfigNameConfigurationName.StrKey);
        }



        public static ConfigurationEntity GetConfigurationByConfigurationName(string strConfigname)
        {
            List<GeneralConfigurationNameEnumerator> configNameList = new List<GeneralConfigurationNameEnumerator>();

            //configNameList.AddRange(GeneralConfigurationNameEnumerator.GetEnumList());
            //configNameList.AddRange(EmailConfigurationNameEnumerator.GetEnumList());

            //Dictionary<string ,GeneralConfigurationNameEnumerator> configDict = configNameList.ToDictionary(x => x.StrKey, x=> x);

            DataSet dataSet = CommonDB.ExecuteReader(QueryStringBuilder.GetSelectStatementByConstraints(CONFIGURATION_TABLE_NAME, new string[] { CONFIGURATION_NAME_COLUMN_NAME }, null),
                                                         new SqlParameter[] { CommonDB.SetParameter(CONFIGURATION_NAME_COLUMN_NAME, strConfigname) },
                                                         out string strErrMsg, out int intTotalRows);

            if (!String.IsNullOrEmpty(strErrMsg))
                throw new Exception(strErrMsg);

            if (intTotalRows <= 0)
                return null;
            else
                return new ConfigurationEntity(dataSet.Tables[0].Rows[0][CONFIGURATION_ID_COLUMN_NAME_PK].ToString(),
                                                ConfigurationNameEnumerator.GetEnumByKey(dataSet.Tables[0].Rows[0][CONFIGURATION_NAME_COLUMN_NAME].ToString()),
                                                dataSet.Tables[0].Rows[0][CONFIGURATION_VALUE_COLUMN_NAME].ToString(),
                                                dataSet.Tables[0].Rows[0][CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME].ToString(),
                                                Common.ParseDateFromDatabase(dataSet.Tables[0].Rows[0][CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME].ToString()));
        }



        public static ConfigurationEntity UpdateConfiguration(ConfigurationEntity configuration)
        {
            ConfigurationEntity existingConfiguration = GetConfigurationByConfigurationName(configuration.ConfigNameConfigurationName.StrKey);
            List<string> columnList = new List<string>();
            List<SqlParameter> paramList = new List<SqlParameter>();

            if (existingConfiguration == null)
            {
                existingConfiguration = NewConfiguration(new ConfigurationEntity(null, configuration.ConfigNameConfigurationName, null, null, new DateTime()));
                configuration.StrConfigurationID = existingConfiguration.StrConfigurationID;
            }

            if (!configuration.StrConfigurationValue.Equals(existingConfiguration.StrConfigurationValue))
            {
                configuration.StrConfigurationLastModifiedBy = UserInfo.GetUserInfo().Username;
                configuration.DteConfigurationLastModifiedDate = DateTime.Now;

                columnList.Add(CONFIGURATION_VALUE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(CONFIGURATION_VALUE_COLUMN_NAME, configuration.StrConfigurationValue));

                columnList.Add(CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(CONFIGURATION_LAST_MODIFIED_BY_COLUMN_NAME, configuration.StrConfigurationLastModifiedBy));

                columnList.Add(CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME);
                paramList.Add(CommonDB.SetParameter(CONFIGURATION_LAST_MODIFIED_DATE_COLUMN_NAME, configuration.DteConfigurationLastModifiedDate));

                paramList.Add(CommonDB.SetParameter(CONFIGURATION_ID_COLUMN_NAME_PK, configuration.StrConfigurationID));

                CommonDB.ExecuteNonQuery(QueryStringBuilder.GetUpdateStatement(CONFIGURATION_TABLE_NAME, CONFIGURATION_ID_COLUMN_NAME_PK, columnList.ToArray()),
                                            IsolationLevel.Serializable,
                                            paramList.ToArray(),
                                            out string strErrMsg);

                if (!String.IsNullOrEmpty(strErrMsg))
                    throw new Exception(strErrMsg);

                ConfigurationLogInterface.New(new ConfigurationLogEntity(null, 
                                                                                            configuration.ConfigNameConfigurationName.StrKey, 
                                                                                            existingConfiguration.StrConfigurationValue,
                                                                                            configuration.StrConfigurationValue,
                                                                                            configuration.StrConfigurationLastModifiedBy,
                                                                                            configuration.DteConfigurationLastModifiedDate));
            }

            return GetConfigurationByConfigurationName(configuration.ConfigNameConfigurationName.StrKey);
        }
    }
}
