using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.BusinessLogic
{
    public class ClsPerson
    {
        public enum enMode { AddNew=0, Update=1}
        public enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; } }

        public string NationalNo { get; set; }
        public int NationalityID { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ClsCountry CountryInfo;
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PersonAddress { get; set; }
        public int Gender { get; set; }
        public string ImagePath { get; set; }


        ClsPerson()
        {
            PersonID = -1;
            FirstName = null;
            SecondName = null;
            ThirdName = null;
            LastName = null;
            NationalNo = null;
            NationalityID = -1;
            DateOfBirth = DateTime.MinValue;
            Phone = null;
            Email = null;
            PersonAddress = null;
            Gender = 0;
            ImagePath = null;
        }

        ClsPerson(int personID, string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, int nationaltyID, DateTime dateOfBirth, string phone, string email, string personAddress, int gender, string imagePath)
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNo = nationalNo;
            NationalityID = nationaltyID;
            CountryInfo = ClsCountry.Find(nationaltyID);
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            PersonAddress = personAddress;
            Gender = gender;
            ImagePath = imagePath;
        }

        public static ClsPerson Find(int ID)
        {
            string firstName = null;
            string secondName = null;
            string thirdName = null;
            string lastName = null;
            string nationalNo = null;
            int nationalityID = -1;
            DateTime dateOfBirth = DateTime.MinValue;
            string phone = null;
            string email = null;
            string personAddress = null;
            int gender = 0;
            string imagePath = null;

            bool isFound = ClsPersonData.FindPersonByID(ID, ref firstName, ref secondName, ref thirdName, ref lastName,
            ref nationalNo, ref nationalityID, ref dateOfBirth, ref phone, ref email, ref personAddress, ref gender, ref imagePath);

            if (isFound)
            {
                return new ClsPerson(ID, firstName, secondName, thirdName, lastName,
                             nationalNo, nationalityID, dateOfBirth, phone, email, personAddress, gender, imagePath);
            }
            else
            {
                return null;
            }


        }





        public static ClsPerson Find(string nationalNo)
        {
            int ID = -1;
            string firstName = null;
            string secondName = null;
            string thirdName = null;
            string lastName = null;
            int nationalityID = -1;
            DateTime dateOfBirth = DateTime.MinValue;
            string phone = null;
            string email = null;
            string personAddress = null;
            int gender = 0;
            string imagePath = null;

            bool isFound = ClsPersonData.FindPersonByNationalNo(ref ID, ref firstName, ref secondName, ref thirdName, ref lastName,
            nationalNo, ref nationalityID, ref dateOfBirth, ref phone, ref email, ref personAddress, ref gender, ref imagePath);

            if (isFound)
            {
                return new ClsPerson(ID, firstName, secondName, thirdName, lastName,
                             nationalNo, nationalityID, dateOfBirth, phone, email, personAddress, gender, imagePath);
            }
            else
            {
                return null;
            }


        }

         bool _AddNewPerson() { 
            this.PersonID= ClsPersonData.AddNewPerson(this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                 this.NationalNo, this.NationalityID, this.DateOfBirth, this.Phone, this.Email, this.PersonAddress, this.Gender, this.ImagePath);
         
            return PersonID !=-1;
        
        }

        bool _UpdateInfo()
        {
            return ClsPersonData.UpdatePerson (this.PersonID,this.FirstName, this.SecondName, this.ThirdName, this.LastName,
                                 this.NationalNo, this.NationalityID, this.DateOfBirth, this.Phone, this.Email, this.PersonAddress, this.Gender, this.ImagePath);


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;  
                    }
                case enMode.Update:

                    return _UpdateInfo();

                default:
                    return false;
            }
        }

        public static bool Delete(int personID)
        {
            return ClsPersonData.DeletePerson(personID);
        }


        public static bool IsPersonExist(int PersonID)
        {
            return ClsPersonData.IsPersonExist(PersonID);
        }


        public static bool IsPersonExist(string NationalNo)
        {
            return ClsPersonData.IsPersonExist(NationalNo);
        }
        public static DataTable GetPeopleInfo()
        {
            return ClsPersonData.GetAllPeople();
        }
    }
}
