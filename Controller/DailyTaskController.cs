using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Controller
{
    public class DailyTaskController
    {
        public static void TriggerDailyTasks()
        {
            (new Thread(new ThreadStart(DailyTaskController.PeformDailyTasks))).Start();
        }

        private static void PeformDailyTasks()
        {
            //Trigger notification checking and perform necessary email notification
            if (ExpiringRegistrationNotificationController.IsTriggerNotification())
                ExpiringRegistrationNotificationController.PeformNotification();

            //Trigger archive checking and perform necessary archiving
            if (ArchiveController.IsTriggerArchive())
                ArchiveController.PeformArchive();
        }
    }
}
