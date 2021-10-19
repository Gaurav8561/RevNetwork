using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeEnumerator;
using Entity;
using Utility;
using System.Threading;
using System.Globalization;

namespace Controller
{
    public class ArchiveController
    { 
        public static bool IsTriggerArchive()
        {
            ConfigurationEntity configEntNextRun = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate.StrKey);

            //if (configEntNextRun == null)
            //{
            //    configEntNextRun = ConfigurationInterface.UpdateConfiguration(
            //        new ConfigurationEntity
            //        {
            //            ConfigNameConfigurationName = GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate,
            //            StrConfigurationValue = DateTime.Today.ToString()
            //        });
            //}

            DateTime dteNextRunDate = (DateTime)Common.ParseDateFromDatabase(configEntNextRun.StrConfigurationValue);

            return (DateTime.Now >= dteNextRunDate);
        }



        public static void TriggerArchive()
        {
            Thread t1 = new Thread(new ThreadStart(ArchiveController.PeformArchive));
            t1.Start();
        }



        internal static void PeformArchive()
        {
            ConfigurationEntity configEntNextRun = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate.StrKey);

            //if (configEntNextRun == null)
            //{
            //    configEntNextRun = ConfigurationInterface.UpdateConfiguration(
            //        new ConfigurationEntity
            //        {
            //            ConfigNameConfigurationName = GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate,
            //            StrConfigurationValue = DateTime.Today.ToString()
            //        });
            //}

            DateTime dteNextRunDate = (DateTime)GeneralConfigurationNameEnumerator.ConfigurationNotificationBeforeExpiryNextRunDate.FuncParser(configEntNextRun.StrConfigurationValue);

            if (DateTime.Now >= dteNextRunDate)
            {
                configEntNextRun.StrConfigurationValue = GeneralConfigurationNameEnumerator.ConfigurationArchiveNextRunDate.FuncFormatter(new DateTime(DateTime.Today.AddMonths(1).Year, DateTime.Today.AddMonths(1).Month, 1));
                ConfigurationInterface.UpdateConfiguration(configEntNextRun);

                ConfigurationEntity configEntDataAgeToArchiveInMonths = ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationDataAgeToArchiveInMonths.StrKey);

                //if (configEntDataAgeToArchiveInMonths == null)
                //{
                //    configEntDataAgeToArchiveInMonths = ConfigurationInterface.UpdateConfiguration(
                //    new ConfigurationEntity
                //    {
                //        ConfigNameConfigurationName = GeneralConfigurationNameEnumerator.ConfigurationDataAgeToArchiveInMonths,
                //        StrConfigurationValue = (12).ToString()
                //    });
                //}

                int intDataAgeMonthsToArchive = (int)Common.ParseDecimalFromDatabase(configEntDataAgeToArchiveInMonths.StrConfigurationValue);

                DateTime dteCutOffDate = DateTime.Today.AddMonths(-1 * intDataAgeMonthsToArchive);

                //Call to interfaces where tables need to be archived
                //PotentialStudentInterface.ArchivePotentialStudent(dteCutOffDate, dteNextRunDate);
            }
        }
    }

    
}
