using System;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Net;

namespace DVLD.DataAccess
{
    public class ClsCountryData
    {
         static string ConnectionString =DataAccessSettings.ConnectionString;

        public static bool GetCountryInfoByID(int CountryID ,ref string CountryName)
        {
            bool isFound = false;

             SqlConnection Connection = new SqlConnection(ConnectionString);

            string query = "Select CountryName from Countries where CountryID =@CountryID";

            SqlCommand Command = new SqlCommand(query,Connection);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    CountryName = (string)reader["CountryName"];
                    
                    isFound = true;
                }

                reader.Close();




            }catch (Exception ex)
            {
                //Console.WriteLine("Error while Geting CountryName :" +ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;
        }



        public static bool GetCountryInfoByCountryName(string CountryName,ref int CountryID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(ConnectionString);

            string query = "Select CountryID from Countries where CountryName =@CountryName";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    CountryID = (int)reader["CountryID"];

                    isFound = true;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error while Geting CountryID :" +ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;
        }



        public static DataTable GetAllCountries()
        {
            DataTable dtCountriesTable = new DataTable();

           

            SqlConnection Connection = new SqlConnection(ConnectionString);

            string query = "select * from Countries order by CountryName";

            SqlCommand Command = new SqlCommand(query,Connection);

            try
            {
                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    
                    dtCountriesTable.Load(reader);
                }
                reader.Close();


            }catch(Exception ex)
            {
                //Console.WriteLine("Error While featching  Countries Data :"+ ex.Message);
            }
            finally
            {
                Connection.Close();
            }


            return dtCountriesTable;

        }


    }
}
