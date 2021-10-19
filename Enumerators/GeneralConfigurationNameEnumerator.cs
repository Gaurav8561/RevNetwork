using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TypeEnumerator
{
    public class GeneralConfigurationNameEnumerator : ConfigurationNameEnumerator
    {
        //public static readonly GeneralConfigurationNameEnumerator ConfigurationNameCommissionRate 
            //= new GeneralConfigurationNameEnumerator("COMMISION_RATE", "typeEnum.configurationName.commissionRate", ConfigurationDataType.DATA_TYPE_DECIMAL, 0);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationNameDaysToFormaliseRegistration 
            = new GeneralConfigurationNameEnumerator("REG_FORMALISATION_DAYS_DURATION", "typeEnum.configurationName.regFormalisationDaysDuration", ConfigurationDataType.DATA_TYPE_INT, 30);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationNotificationDaysBeforeExpiry 
            = new GeneralConfigurationNameEnumerator("NOTIFY_DAYS_BEFORE_EXPIRY", "typeEnum.configurationName.notifyDaysBeforeExpiry", ConfigurationDataType.DATA_TYPE_INT, 30);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationNotificationBeforeExpiryNextRunDate 
            = new GeneralConfigurationNameEnumerator("NOTIFY_BEFORE_EXPIRY_NEXT_RUN_DATE", "typeEnum.configurationName.notifyBeforeExpiryNextRunDate", ConfigurationDataType.DATA_TYPE_DATE, DateTime.Now);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationMiniumStudentAge 
            = new GeneralConfigurationNameEnumerator("MIN_STUDENT_AGE", "typeEnum.configurationName.minStudentAge", ConfigurationDataType.DATA_TYPE_INT, 0);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationArchiveNextRunDate 
            = new GeneralConfigurationNameEnumerator("ARCHIVE_NEXT_RUN_DATE", "typeEnum.configurationName.archiveNextRunDate", ConfigurationDataType.DATA_TYPE_DATE, DateTime.Now);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationDataAgeToArchiveInMonths 
            = new GeneralConfigurationNameEnumerator("DATA_AGE_TOARCHIVE_IN_MONTHS", "typeEnum.configurationName.dataAgeToArchiveInMonths", ConfigurationDataType.DATA_TYPE_INT, 12);
        public static readonly GeneralConfigurationNameEnumerator ConfigurationSystemAdminEmail 
            = new GeneralConfigurationNameEnumerator("SYSTEM_ADMIN_EMAIL", "typeEnum.configurationName.systemAdminEmail", ConfigurationDataType.DATA_TYPE_EMAIL, "unilinguatech@gmail.com");

        private const string StrConfigPageTitleResxKey = "titlePageGeneralConfigurationSetup";
        public static string StrConfigPageTitleDispText
        {
            get
            {
                return EnumeratorResourceManager.ResourceManager.GetString(StrConfigPageTitleResxKey);
            }
        }

        private GeneralConfigurationNameEnumerator(string strKey, string strResxKey, ConfigurationDataType dtDataType, object objDefaultValue) : base(strKey, strResxKey, dtDataType, objDefaultValue)
        {
        }



        public static new GeneralConfigurationNameEnumerator GetEnumByKey(string strKey)
        {
            return (GeneralConfigurationNameEnumerator)GetEnumByKey(typeof(GeneralConfigurationNameEnumerator), strKey);
        }



        public static new List<GeneralConfigurationNameEnumerator> GetEnumList()
        {
            return GetEnumList(typeof(GeneralConfigurationNameEnumerator)).Cast<GeneralConfigurationNameEnumerator>().ToList();
        }
    }
}
