using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class EmailConfigurationNameEnumerator : ConfigurationNameEnumerator
    {
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailAddress 
            = new EmailConfigurationNameEnumerator("EMAIL_ADDRESS", "typeEnum.emailConfigName.emailAddress", ConfigurationDataType.DATA_TYPE_EMAIL, "unilinguatech@gmail.com");
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailName 
            = new EmailConfigurationNameEnumerator("EMAIL_NAME", "typeEnum.emailConfigName.emailName", ConfigurationDataType.DATA_TYPE_STRING, "Unilingua Technologies Sdn Bhd");
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailPassword 
            = new EmailConfigurationNameEnumerator("EMAIL_PASSWORD", "typeEnum.emailConfigName.emailPassword", ConfigurationDataType.DATA_TYPE_PASSWORD, null);
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailHost 
            = new EmailConfigurationNameEnumerator("EMAIL_HOST", "typeEnum.emailConfigName.emailHost", ConfigurationDataType.DATA_TYPE_URL, "smtp.gmail.com");
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailPort 
            = new EmailConfigurationNameEnumerator("EMAIL_PORT", "typeEnum.emailConfigName.emailPort", ConfigurationDataType.DATA_TYPE_INT, 587);
        public static readonly EmailConfigurationNameEnumerator EmailConfigNameEmailEnableSSL 
            = new EmailConfigurationNameEnumerator("EMAIL_ENABLE_SSL", "typeEnum.emailConfigName.emailEnableSSL", ConfigurationDataType.DATA_TYPE_BOOLEAN, true);

        private const string StrConfigPageTitleResxKey = "titlePageEmailConfigurationSetup";

        public static string StrConfigPageTitleDispText
        {
            get
            {
                return EnumeratorResourceManager.ResourceManager.GetString(StrConfigPageTitleResxKey);
            }
        }

        private EmailConfigurationNameEnumerator(string strKey, string strResxKey, ConfigurationDataType dtDataType, object objDefaultValue) : base(strKey, strResxKey, dtDataType, objDefaultValue)
        {
        }



        public new static EmailConfigurationNameEnumerator GetEnumByKey(string strKey)
        {
            return (EmailConfigurationNameEnumerator)GetEnumByKey(typeof(EmailConfigurationNameEnumerator), strKey);
        }



        public new static List<EmailConfigurationNameEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(EmailConfigurationNameEnumerator)).Cast<EmailConfigurationNameEnumerator>().ToList();
        }
    }
}
