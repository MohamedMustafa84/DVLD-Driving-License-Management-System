using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.BusinessLogic
{
    public class ClsUsers
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int PersonID { get;}
        public ClsPerson PersonInfo;

        ClsUsers(int userID, string userName, string password, bool isActive, int personID)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            PersonID = personID;
            PersonInfo = ClsPerson.Find(personID);
        }

        ClsUsers()
        {

        }

        public static ClsUsers GetUserByUserID(int userID)
        {
            string UserName = "";
            string Password = "";
            int PersonID = -1;
            bool IsActive = false;


            if (ClsUserData.getUserInfoByUserID(userID,ref UserName,ref Password,ref PersonID,ref IsActive))
            {
                return  new ClsUsers(userID,UserName,Password,IsActive,PersonID);
            }
            return null;
        }


        public static ClsUsers GetUserByPersonID(int personID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;


            if (ClsUserData.getUserInfoByPersonID (personID,ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new ClsUsers(UserID, UserName, Password, IsActive, personID);
            }
            return null;
        }


        public static ClsUsers GetUserByUserNameAndPassword(string userName,string password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;


            if (ClsUserData.getUserInfoByUserNameAndPassword(userName, password, ref UserID, ref PersonID, ref IsActive))
            {
                return new ClsUsers(UserID, userName, password, IsActive, PersonID);
            }
            return null;
        }

    }
}
