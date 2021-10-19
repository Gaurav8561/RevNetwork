using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Xml;
using System.Data.Common;
using System.DirectoryServices;
using Database;
using Utility;
using Entity;
using TypeEnumerator;



namespace Security
{
    public class UserAccess
    {
        //public const string DEFAULT_LANDING_PAGE = "~/Landing.aspx";
        public static string DEFAULT_LANDING_PAGE = string.Empty;

        public static bool AuthenticateLogin(string sUsername, string sPassword)
        {
            //bool bValid = false;

            //UserInfo usriCurrent = UserInfo.GetUserInfo();

            //AgentEntity ueAgent = AgentInterface.GetAgentByLoginName(sUsername);
            //AdminEntity ueUser = AdminInterface.GetUserByLoginName(sUsername);

            UserEntity ueUser = UserInterface.GetUserByLoginName(sUsername);

            if(ueUser != null)
            {
                if (ueUser is AdminEntity)
                {
                    if (Encryption.IsPasswordMatch((ueUser as AdminEntity).StrUserLoginPassword, sPassword) && (ueUser as AdminEntity).StatusUserStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
                    {
                        HttpContext.Current.Session["UserInfo"] = new UserInfo()
                        {
                            UserID = (ueUser as AdminEntity).StrUserID,
                            Username = (ueUser as AdminEntity).StrUserLoginName,
                            Name = (ueUser as AdminEntity).StrUserName,
                            Role = (ueUser as AdminEntity).UserRoleUserRole.StrKey,
                            LastLogin = (ueUser as AdminEntity).DteUserLastLogin
                        };

                        (ueUser as AdminEntity).DteUserLastLogin = DateTime.Now;

                        AdminInterface.UpdateUser(ueUser as AdminEntity);

                        DEFAULT_LANDING_PAGE = "~/Landing.aspx";

                        return true;
                    }
                }
                //else if (ueUser is AgentEntity)
                //{
                //    if (Encryption.IsPasswordMatch((ueUser as AgentEntity).StrAgentLoginPassword, sPassword) && (ueUser as AgentEntity).StatusAgentStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
                //    {
                //        HttpContext.Current.Session["UserInfo"] = new UserInfo()
                //        {
                //            UserID = (ueUser as AgentEntity).StrAgentID,
                //            Username = (ueUser as AgentEntity).StrAgentLoginName,
                //            Name = (ueUser as AgentEntity).StrAgentName,
                //            Role = AgentRoleEnumerator.AgentRoleAgent.StrKey,
                //            LastLogin = (ueUser as AgentEntity).StrAgentLastLogin
                //        };

                //        (ueUser as AgentEntity).StrAgentLastLogin = DateTime.Now;

                //        AgentInterface.UpdateAgent(ueUser as AgentEntity);

                //        DEFAULT_LANDING_PAGE = "~/Landing.aspx";

                //        return true;
                //    }
                //}
                else if (ueUser is ContactEntity)
                {
                    if (Encryption.IsPasswordMatch((ueUser as ContactEntity).StrContactLoginPassword, sPassword))
                    {
                        HttpContext.Current.Session["UserInfo"] = new UserInfo()
                        {
                            UserID = (ueUser as ContactEntity).StrContactID,
                            Username = (ueUser as ContactEntity).StrContactLoginUserName,
                            Name = (ueUser as ContactEntity).StrContactName,
                            Role = ContactRoleEnumerator.ContactRoleContact.StrKey,
                            MembershipPlanID = (ueUser as ContactEntity).StrMembershipPlanID,
                            MembershipPlanTitle = (ueUser as ContactEntity).ContactMembershipPlan.StrMembershipPlanTitle,
                            MembershipPlanSequence = (ueUser as ContactEntity).ContactMembershipPlan.IntMembershipPlanSequence,
                            MembershipExpiryDate = (ueUser as ContactEntity).DteContactMembershipNextPaymentDate,
                            LastLogin = (ueUser as ContactEntity).DteContactLastLogin,
                            CreatedDate = (ueUser as ContactEntity).DteContactCreatedDate
                        };

                        (ueUser as ContactEntity).DteContactLastLogin = DateTime.Now;

                        ContactInterface.UpdateContact(ueUser as ContactEntity);

                        DEFAULT_LANDING_PAGE = "~/ContactLanding.aspx";

                        return true;
                    }
                }
            }

            return false;

            //if (ueAgent != null)
            //{
            //    if (Encryption.IsPasswordMatch(ueAgent.StrAgentLoginPassword, sPassword) && ueAgent.StatusAgentStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
            //    {
            //        HttpContext.Current.Session["UserInfo"] = new UserInfo()
            //        {
            //            Username = ueAgent.StrAgentLoginName,
            //            Name = ueAgent.StrAgentName,
            //            Role = AgentRoleEnumerator.AgentRoleAgent.StrKey,
            //            LastLogin = ueAgent.StrAgentLastLogin
            //        };

            //        ueAgent.StrAgentLastLogin = DateTime.Now;

            //        AgentInterface.UpdateAgent(ueAgent);
            //    }
            //    else
            //    {
            //        bValid = false;
            //    }
            //}
            //else if (ueUser != null)
            //{
            //    if (Encryption.IsPasswordMatch(ueUser.StrUserLoginPassword, sPassword) && ueUser.StatusUserStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
            //    {
            //        HttpContext.Current.Session["UserInfo"] = new UserInfo()
            //        {
            //            Username = ueUser.StrUserLoginName,
            //            Name = ueUser.StrUserName,
            //            Role = ueUser.UserRoleUserRole.StrKey,
            //            LastLogin = ueUser.DteUserLastLogin
            //        };

            //        ueUser.DteUserLastLogin = DateTime.Now;

            //        AdminInterface.UpdateUser(ueUser);
            //    }
            //    else
            //    {
            //        bValid = false;
            //    }
            //}
            //else
            //{
            //    bValid = false;
            //}

            //return bValid;
        }

        public static bool CheckRoleAuthorisation(List<UserRoleEnumerator> authorisedRoles)
        {
            if (authorisedRoles != null)
                return authorisedRoles.Any(x => x.StrKey == UserInfo.GetUserInfo().Role);
            else
                return false;
        }
    }
}
