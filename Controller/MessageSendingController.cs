using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Entity;
using Utility;
using TypeEnumerator;
using System.Threading;
using System.IO;

namespace Controller
{
    public class MessageSendingController
    {
        public static void SendEmail(string strRecipientEmail, string strSubject, string strBody)
        {
            if (Common.IsValidEmail(strRecipientEmail))
                (new Thread(() => PeformSendEmail(strRecipientEmail, strSubject, strBody))).Start();
        }
        private static void PeformSendEmail(string strRecipientEmail, string strSubject, string strBody)
        {
            try
            {
                var fromAddress = new MailAddress(ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailAddress.StrKey).StrConfigurationValue, ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailName.StrKey).StrConfigurationValue);
                var toAddress = new MailAddress(strRecipientEmail);

                string fromPassword = Encryption.Decrypt(ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailPassword.StrKey).StrConfigurationValue);

                var smtp = new SmtpClient
                {
                    Host = ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailHost.StrKey).StrConfigurationValue,
                    Port = int.Parse(ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailPort.StrKey).StrConfigurationValue),
                    EnableSsl = bool.Parse(ConfigurationInterface.GetConfigurationByConfigurationName(EmailConfigurationNameEnumerator.EmailConfigNameEmailEnableSSL.StrKey).StrConfigurationValue),

                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = strSubject,
                    Body = strBody,

                })
                {
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;

                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                //Commented throw to prevent server from stopping
                //throw;
            }
        }



        public static void SendSMS(string strRecipientNumber, string strMessageBody)
        {
            new Thread(() => PerformSendSMS(strRecipientNumber, strMessageBody)).Start();
        }



        public static string PerformSendSMS(string strRecipientNumber, string strMessageBody)
        {
            string strValueUri = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayValueUri"];

            string strAttributeUsername = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayAttributeUsername"];
            string strAttributePassword = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayAttributePassword"];
            string strAttributeRecipientNumber = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayAttributeRecipientNumber"];
            string strAttributeMessageBody = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayAttributeMessageBody"];

            string strValueUsername = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayValueUsername"];
            string strValuePassword = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayValuePassword"];

            string strOtherParam = System.Configuration.ConfigurationManager.AppSettings["SMSGatewayOtherParam"];

            string strFinalUri = strValueUri + "?" + strAttributeUsername + "=" + strValueUsername + "&" + strAttributePassword + "=" + strValuePassword + "&" + strAttributeRecipientNumber + "=" + strRecipientNumber + "&" + strAttributeMessageBody + "=" + strMessageBody + strOtherParam;

            string strSendResult = String.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strFinalUri);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());

            String resultmsg = responseReader.ReadToEnd();
            responseReader.Close();

            int StartIndex = 0;
            int LastIndex = resultmsg.Length;

            if (LastIndex > 0)
                strSendResult = resultmsg.Substring(StartIndex, LastIndex);

            responseReader.Dispose();

            return strSendResult;     
        }
    }
}
