using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class UserInterface
    {
        public static UserEntity GetUserByPrimaryKey(string strUserID)
        {
            AdminEntity admin = AdminInterface.GetUserByPrimaryKey(strUserID);
            //AgentEntity agent = AgentInterface.GetAgentByPrimaryKey(strUserID);
            ContactEntity contact = ContactInterface.GetContactByPrimaryKey(strUserID);

            //if (admin != null && agent != null)
            //if (admin != null && agent != null || admin != null && contact != null || agent != null && contact != null)
            if (admin != null && contact != null)
                throw new Exception("Similar Primary Key found in two or more tables");
            else if (admin != null)
                return admin;
            //else if (agent != null)
            //    return agent;
            else if (contact != null)
                return contact;
            else
                return null;
        }

        public static UserEntity GetUserByLoginName(string strLoginName)
        {
            AdminEntity admin = AdminInterface.GetUserByLoginName(strLoginName);
            //AgentEntity agent = AgentInterface.GetAgentByLoginName(strLoginName);
            ContactEntity contact = ContactInterface.GetContactByLoginUserName(strLoginName);

            //if (admin != null && agent != null)
            //if (admin != null && agent != null || admin != null && contact != null || agent != null && contact != null)
            if (admin != null && contact != null)
                throw new Exception("Similar Primary Key found in two or more tables");
            else if (admin != null)
                return admin;
            //else if (agent != null)
            //    return agent;
            else if (contact != null)
                return contact;
            else
                return null;
        }

        public static UserEntity UpdateUser(UserEntity user)
        {
            if (user is AdminEntity)
                return AdminInterface.UpdateUser(user as AdminEntity);
            //else if (user is AgentEntity)
            //    return AgentInterface.UpdateAgent(user as AgentEntity);
            else if (user is ContactEntity)
                return ContactInterface.UpdateContact(user as ContactEntity);
            else
                return null;
        }
    }
}
