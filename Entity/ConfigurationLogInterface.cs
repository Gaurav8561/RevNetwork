using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using System.Data;
using System.Data.SqlClient;
using Utility;



namespace Entity
{
    public class ConfigurationLogInterface : BaseInterface
    {
        private static readonly EntityToTableMapping tableMapping
            = new EntityToTableMapping
                (typeof(ConfigurationLogEntity),
                    "tbl_ConfigurationLog",
                    "CONFIGLOG",
                    "ConfigurationLogId",
                    null,
                    "ConfigurationLogCreatedBy",
                    "ConfigurationLogCreatedDate",
                    null,
                    null,
                    new List<EntityToTableMapping.PropertyToColumnPair>
                    {
                        new EntityToTableMapping.PropertyToColumnPair("StrConfigurationLogId", "ConfigurationLogId"),
                        new EntityToTableMapping.PropertyToColumnPair("StrConfigurationLogName", "ConfigurationLogName"),
                        new EntityToTableMapping.PropertyToColumnPair("StrConfigurationLogOldValue", "ConfiguartionLogOldValue"),
                        new EntityToTableMapping.PropertyToColumnPair("StrConfigurationLogNewValue", "ConfiguartionLogNewValue"),
                        new EntityToTableMapping.PropertyToColumnPair("StrConfigurationLogCreatedBy", "ConfigurationLogCreatedBy"),
                        new EntityToTableMapping.PropertyToColumnPair("DteConfigurationLogCreatedDate", "ConfigurationLogCreatedDate")
                    });

        public static void New(ConfigurationLogEntity configurationLog)
        {
            New(tableMapping, configurationLog);
        }

    }
}
