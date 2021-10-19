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
    public class ContactAccess1
    {
        public const string DEFAULT_LANDING_PAGE = "~/ContactLanding.aspx";

        public static bool AuthenticateLogin1(string sUsername, string sPassword)
        {
            ContactEntity ceContact = ContactInterface.GetContactByLoginUserName(sUsername);

            if (ceContact != null)
            {
                if (Encryption.IsPasswordMatch((ceContact as ContactEntity).StrContactLoginPassword, sPassword)) //&& (ceContact as ContactEntity).StatusUserStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
                {
                    HttpContext.Current.Session["UserInfo"] = new UserInfo()
                    {
                        UserID = (ceContact as ContactEntity).StrContactID,
                        Username = (ceContact as ContactEntity).StrContactLoginUserName,
                        Name = (ceContact as ContactEntity).StrContactName,
                        Role = ContactRoleEnumerator.ContactRoleContact.StrKey,
                        LastLogin = (ceContact as ContactEntity).DteContactLastLogin
                    };

                    (ceContact as ContactEntity).DteContactLastLogin = DateTime.Now;

                    ContactInterface.UpdateContact(ceContact as ContactEntity);

                    return true;
                }
            }






            //UserEntity ueUser = UserInterface.GetUserByLoginName(sUsername);

            //if(ueUser != null)
            //{
            //    if(ueUser is AdminEntity)
            //    {
            //        if (Encryption.IsPasswordMatch((ueUser as AdminEntity).StrUserLoginPassword, sPassword) && (ueUser as AdminEntity).StatusUserStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
            //        {
            //            HttpContext.Current.Session["UserInfo"] = new UserInfo()
            //            {
            //                Username = (ueUser as AdminEntity).StrUserLoginName,
            //                Name = (ueUser as AdminEntity).StrUserName,
            //                Role = (ueUser as AdminEntity).UserRoleUserRole.StrKey,
            //                LastLogin = (ueUser as AdminEntity).DteUserLastLogin
            //            };

            //            (ueUser as AdminEntity).DteUserLastLogin = DateTime.Now;

            //            AdminInterface.UpdateUser(ueUser as AdminEntity);

            //            return true;
            //        }
            //    }
            //    else if (ueUser is AgentEntity)
            //    {
            //        if (Encryption.IsPasswordMatch((ueUser as AgentEntity).StrAgentLoginPassword, sPassword) && (ueUser as AgentEntity).StatusAgentStatus.StrKey == StatusEnumerator.StatusActive.StrKey)
            //        {
            //            HttpContext.Current.Session["UserInfo"] = new UserInfo()
            //            {
            //                Username = (ueUser as AgentEntity).StrAgentLoginName,
            //                Name = (ueUser as AgentEntity).StrAgentName,
            //                Role = AgentRoleEnumerator.AgentRoleAgent.StrKey,
            //                LastLogin = (ueUser as AgentEntity).StrAgentLastLogin
            //            };

            //            (ueUser as AgentEntity).StrAgentLastLogin = DateTime.Now;

            //            AgentInterface.UpdateAgent(ueUser as AgentEntity);

            //            return true;
            //        }
            //    }
            //}

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

        public static bool CheckRoleAuthorisation1(List<UserRoleEnumerator> authorisedRoles)
        {
            if (authorisedRoles != null)
                return authorisedRoles.Any(x => x.StrKey == UserInfo.GetUserInfo().Role);
            else
                return false;
        }
    }
}
