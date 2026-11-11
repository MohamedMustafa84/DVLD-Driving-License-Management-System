using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class ClsUserData
    {

        public static bool  GitUserInfoByUserID(int  userID, ref string userName,ref string password,ref int personID,ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select * From Users where UserID=@userID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);

            bool IsFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    personID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error geting User Info By User ID :"+ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }



        public static bool GitUserInfoByPersonID(int personID,ref int userID, ref string userName, ref string password, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select * From Users where PersonID=@personID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@personID", personID);

            bool IsFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    userID = (int)reader["UserID"];
                    userName = (string)reader["UserName"];
                    password = (string)reader["Password"];
                    isActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error geting User Info By Person ID :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

    }
}
