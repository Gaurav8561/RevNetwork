using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Entity
{
    public class ConfigurationLogEntity : BaseEntity
    {
        public string StrConfigurationLogId { get; set; }
        public string StrConfigurationLogName { get; set; }
        public string StrConfigurationLogOldValue { get; set; }
        public string StrConfigurationLogNewValue { get; set; }
        public string StrConfigurationLogCreatedBy { get; set; }
        public DateTime? DteConfigurationLogCreatedDate { get; set; }

        public ConfigurationLogEntity()
        {
            this.StrConfigurationLogId = string.Empty;
            this.StrConfigurationLogName = string.Empty;
            this.StrConfigurationLogOldValue = string.Empty;
            this.StrConfigurationLogNewValue = string.Empty;
            this.StrConfigurationLogCreatedBy = string.Empty;
            this.DteConfigurationLogCreatedDate = new DateTime();
        }

        public ConfigurationLogEntity(string strConfigurationLogId,
                                        string strConfigurationLogName,
                                        string strConfigurationLogOldValue,
                                        string strConfigurationLogNewValue,
                                        string strConfigurationLogCreatedBy,
                                        DateTime? dteConfigurationLogCreatedDate)
        {
            this.StrConfigurationLogId = strConfigurationLogId;
            this.StrConfigurationLogName = strConfigurationLogName;
            this.StrConfigurationLogOldValue = strConfigurationLogOldValue;
            this.StrConfigurationLogNewValue = strConfigurationLogNewValue;
            this.StrConfigurationLogCreatedBy = strConfigurationLogCreatedBy;
            this.DteConfigurationLogCreatedDate = dteConfigurationLogCreatedDate;
        }
    }
}
