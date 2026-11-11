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

        public static bool  getUserInfoByUserID(int  userID, ref string userName,ref string password,ref int personID,ref bool isActive)
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
                    password = (string)reader["UserPassword"];
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



        public static bool getUserInfoByPersonID(int personID,ref int userID, ref string userName, ref string password, ref bool isActive)
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
                    password = (string)reader["UserPassword"];
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

        public static bool getUserInfoByUserNameAndPassword(string userName ,string password,ref int userID, ref int personID, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select * From Users where UserName=@userName and UserPassword =@password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", password);

            bool IsFound = false;
            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    userID = (int)reader["UserID"];
                    personID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error geting User Info By username and Password :" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }



        public static bool AddNewUser(int personID,string userName, string password, bool isActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"insert into Users(PersonID,UserName,UserPassword,IsActive)
                            values
                                    (@personID,@userName,@password,@isActive);
                                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@isActive", isActive);

            int UserID = -1;
            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if(Result !=null && int.TryParse(Result.ToString(), out int InsertedUserID))
                {
                    UserID= InsertedUserID;
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Adding New User:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (UserID !=-1);
        }



        public static bool UpdateUser(int userID ,int personID, string userName, string password, bool isActive)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"update Users set
                                     PersonID=@personID,
                                     UserName=@userName,
                                     UserPassword=@password,
                                     IsActive=@isActive
                            where UserID=@userID;";
                                    

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@userName", userName);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@isActive", isActive);

            int effectedRows = 0;
            try
            {
                connection.Open();

                effectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error Updating User Data:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (effectedRows != 0);
        }


    }
}
