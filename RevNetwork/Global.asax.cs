using Controller;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TypeEnumerator;
using UIEntityMap;
using Utility;

namespace RevNetwork
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Evaluate all Enumerators
            BaseEnumerator.EvaluateAllEnumerators();

            //Evaluate all UIEntityMap
            //BaseUIEntityMap.EvaluateAllUIEntityMap();
            //BaseUIEntityListMap.EvaluateAllUIEntityListMap();

            //Initialise Configurations
            ConfigurationInitialisationController.InitialiseConfiguration();

            //Initialise Empty Database
            //EmptyDatabaseInitialisationController.InitialiseDatabase();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Trigger archive checking and perform necessary archiving
            //ArchiveController.TriggerArchive();

            //Trigger notification checking and perform necessary email notification
            //ExpiringRegistrationNotificationController.TriggerNotification();

            //Perform Daily Tasks
            //DailyTaskController.TriggerDailyTasks();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.AppRelativeCurrentExecutionFilePath == "~/")
                HttpContext.Current.RewritePath("ContactDefault.aspx");
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            try
            {
                //Common.LogToFile(Server.GetLastError().GetBaseException().Message.ToString() + Server.GetLastError().GetBaseException().StackTrace.ToString().Replace("at ", "<br>at "));
                MessageSendingController.SendEmail(ConfigurationInterface.GetConfigurationByConfigurationName(GeneralConfigurationNameEnumerator.ConfigurationSystemAdminEmail.StrKey).StrConfigurationValue, Resources.Resources.emailSubjectErrorReport, String.Format(Resources.Resources.emailBodyErrorReport, Request.Url.ToString(), Server.GetLastError().GetBaseException().Message.ToString(), Server.GetLastError().GetBaseException().StackTrace.ToString().Replace("at ", "<br>at ")));
            }
            catch (Exception)
            {
            }
}

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}