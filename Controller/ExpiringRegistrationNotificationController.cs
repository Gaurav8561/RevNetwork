using Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TypeEnumerator;
using Utility;

namespace Controller
{
    public class ExpiringRegistrationNotificationController
    {
        public static bool IsTriggerNotification()
        {
            ConfigurationEntity configEntNextRun = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationNotificationBeforeExpiryNextRunDate.StrKey);

            DateTime dteNextRunDate = (DateTime)Common.ParseDateFromDatabase(configEntNextRun.StrConfigurationValue);

            return (DateTime.Now >= dteNextRunDate);
        }

        public static void TriggerNotification()
        {
            Thread t1 = new Thread(new ThreadStart(PeformNotification));
            t1.Start();
        }

        internal static void PeformNotification()
        {
            ConfigurationEntity configEntNextRun = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationNotificationBeforeExpiryNextRunDate.StrKey);

            DateTime dteNextRunDate = (DateTime)GeneralConfigurationNameEnumerator.ConfigurationNotificationBeforeExpiryNextRunDate.FuncParser(configEntNextRun.StrConfigurationValue);

            if (DateTime.Now >= dteNextRunDate)
            {
                configEntNextRun.StrConfigurationValue = GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate.FuncFormatter(new DateTime(DateTime.Today.AddDays(1).Year, DateTime.Today.AddDays(1).Month, DateTime.Today.AddDays(1).Day));
                ConfigurationInterface.UpdateConfiguration(configEntNextRun);

                ConfigurationEntity configEntNotifyDaysBeforeExpiry = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationNotificationDaysBeforeExpiry.StrKey);

                int intDaysBeforeExpiry = (int)Common.ParseDecimalFromDatabase(configEntNotifyDaysBeforeExpiry.StrConfigurationValue);

                DateTime dteCutOffDate = Common.GetNextBusinessDayAfter(DateTime.Today, (uint)intDaysBeforeExpiry, null, true);
                dteCutOffDate = new DateTime(dteCutOffDate.Year, dteCutOffDate.Month, dteCutOffDate.Day, 23, 59, 59, 999);

                //foreach (PotentialStudentEntity stud in PotentialStudentInterface.ListPotentialStudentCodeByRegByDate(DateTime.Today, dteCutOffDate))
                //    if(stud.RegistrationStatus == StudentRegistrationStatusEnumerator.StudentRegistrationPending)
                //        EmailSendingController.SendEmail(stud.AgentPotenStudReferrer.StrAgentLoginName, string.Format(ResxManager.ResourceManager.GetString("emailSubjectStudentRegistrationExpiring_Agent"), stud.StrPotenStudName), string.Format(ResxManager.ResourceManager.GetString("emailBodyStudentRegistrationExpiring_Agent"), stud.AgentPotenStudReferrer.StrAgentName, stud.StrPotenStudName, stud.StrPotenStudIDNumber, stud.StrPotenStudEmail, stud.DtePotenStudRegByDate));
            
            
            }
        }
    }
}
