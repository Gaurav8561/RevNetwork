using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;



namespace Entity
{
    public class ConfigurationEntity
    {
        public string StrConfigurationID { get; set; }
        public ConfigurationNameEnumerator ConfigNameConfigurationName { get; set; }
        public string StrConfigurationValue { get; set; }
        public string StrConfigurationLastModifiedBy { get; set; }
        public DateTime? DteConfigurationLastModifiedDate { get; set; }

        public ConfigurationEntity()
        {
            this.StrConfigurationID = string.Empty;
            this.ConfigNameConfigurationName = null;
            this.StrConfigurationValue = string.Empty;
            this.StrConfigurationLastModifiedBy = string.Empty;
            this.DteConfigurationLastModifiedDate = new DateTime();
        }



        public ConfigurationEntity(string strConfigurationID,
                                    ConfigurationNameEnumerator configNameConfigurationName,
                                    string strConfigurationValue,
                                    string strConfigurationLastModifiedBy,
                                    DateTime? dteConfigurationLastModifiedDate)
        {
            this.StrConfigurationID = strConfigurationID;
            this.ConfigNameConfigurationName = configNameConfigurationName;
            this.StrConfigurationValue = strConfigurationValue;
            this.StrConfigurationLastModifiedBy = strConfigurationLastModifiedBy;
            this.DteConfigurationLastModifiedDate = dteConfigurationLastModifiedDate;
        }

    }
}
