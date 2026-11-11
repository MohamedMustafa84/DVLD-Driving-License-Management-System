using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.BusinessLogic
{
    public class ClsUser
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int PersonID { get; set; }
        public ClsPerson PersonInfo;

        public enum enMode { AddNew = 1, Update = 2 }
        enMode Mode = enMode.AddNew;


        public ClsUser(int userID, string userName, string password, bool isActive, int personID)
        {

            this.Mode = enMode.Update;
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            this.PersonID = personID;
            this.PersonInfo = ClsPerson.Find(personID);
        }

        public ClsUser()
        {

        }

        public static ClsUser GetUserByUserID(int userID)
        {
            string UserName = "";
            string Password = "";
            int PersonID = -1;
            bool IsActive = false;


            if (ClsUserData.getUserInfoByUserID(userID,ref UserName,ref Password,ref PersonID,ref IsActive))
            {
                return  new ClsUser(userID,UserName,Password,IsActive,PersonID);
            }
            return null;
        }


        public static ClsUser GetUserByPersonID(int personID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;


            if (ClsUserData.getUserInfoByPersonID (personID,ref UserID, ref UserName, ref Password, ref IsActive))
            {
                return new ClsUser(UserID, UserName, Password, IsActive, personID);
            }
            return null;
        }


        public static ClsUser GetUserByUserNameAndPassword(string userName,string password)
        {
            int UserID = -1;
            int PersonID = -1;
            bool IsActive = false;


            if (ClsUserData.getUserInfoByUserNameAndPassword(userName, password, ref UserID, ref PersonID, ref IsActive))
            {
                return new ClsUser(UserID, userName, password, IsActive, PersonID);
            }
            return null;
        }


        private bool _AddNewUser()
        {
            return ClsUserData.AddNewUser(PersonID, UserName, Password, IsActive);
        }

        private bool _UpdateUser()
        {
            return ClsUserData.UpdateUser(UserID,PersonID, UserName, Password, IsActive);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                            return _UpdateUser();

                        }
            return false;
        }

        public static DataTable GetAllUsers()
        {
            return ClsUserData.GetAllUsers();
        }

    }
}
