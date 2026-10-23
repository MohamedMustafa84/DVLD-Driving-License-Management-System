using DVLD.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD.BusinessLogic
{
    public class ClsCountry
    {

        public int ID { get; set; }
        public string CountryName { get; set; }

        ClsCountry()
        {
            ID = 0;
            CountryName = null;
        }
        ClsCountry(int id ,string countryName)
        {
            ID=id; 
            CountryName = countryName;
        }


        public static ClsCountry Find(int ID)
        {
            string CountryName= "";

            if(ClsCountryData.GetCountryInfoByID(ID,ref CountryName))
            {
                return new ClsCountry(ID ,CountryName);

            }
            else
            {
                return null;
            }

        }
        
        
        public static ClsCountry Find(string CountryName)
        {
            int ID = -1;

            if(ClsCountryData.GetCountryInfoByCountryName(CountryName,ref ID)){
                return new ClsCountry(ID ,CountryName);
            }
            else
            {
                return null;
            }
        }
        
        
        
        public static DataTable GetCountries()
        {
            return ClsCountryData.GetAllCountries();
        }
    }
}
