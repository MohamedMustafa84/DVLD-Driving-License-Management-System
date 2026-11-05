using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class ClsPersonData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dtPeopleTable = new DataTable();

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT People.FirstName,People.SecondName,People.ThirdName,People.LastName,
                    People.NationalNo ,People.DateOFBirth,People.Gender,
                CASE
                        WHEN People.Gender =0 THEN 'Male'
                
                 ELSE  'Female' 
                 END as GenderCaption,
                        People.PersonAddress,People.Phone,People.Email,
                        People.NationaltyID,Countries.CountryName,People.ImagePath

                    From       People INNER JOIN Countries 
                            ON People.NationaltyID = Countries.CountryID 
                    ORDER BY People.FirstName";

            SqlCommand Command = new SqlCommand(query, Connection);




            try
            {

                Connection.Open();

                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    dtPeopleTable.Load(reader);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error  While Getting People Data : " + ex.Message);
            }
            finally
            {
                Connection.Close();

            }

            return dtPeopleTable;
        }

        public static bool FindPersonByID(int personID, ref string firstName, ref string secondName, ref string thirdName, ref string lastName,
            ref string nationalNo, ref int nationaltyID, ref DateTime dateOfBirth, ref string phone, ref string email, ref string personAddress, ref byte gender, ref string imagePath)
        {

            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select * from People where PersonID= @personID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue(@"personID", personID);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];
                    nationalNo = (string)reader["NationalNo"];

                    nationaltyID = (int)reader["NationaltyID"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    phone = (string)reader["Phone"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];

                    }
                    else
                    {
                        email = null;
                    }


                    personAddress = (string)reader["PersonAddress"];
                    gender =  (byte)reader["Gender"];
                    personAddress = (string)reader["PersonAddress"];


                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = (string)reader["ImagePath"];

                    }
                    else
                    {
                        imagePath = null;
                    }




                }
                reader.Close();

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While getting Person info by Person ID :"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;

        }


        public static bool FindPersonByNationalNo(ref int personID, ref string firstName, ref string secondName, ref string thirdName, ref string lastName,
             string nationalNo, ref int nationaltyID, ref DateTime dateOfBirth, ref string phone, ref string email, ref string personAddress, ref byte gender, ref string imagePath)
        {

            bool isFound = false;

            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select * from People where NationalNo= @nationalNo";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue(@"nationalNo", nationalNo);

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    personID = (int)reader["PersonID"];

                    firstName = (string)reader["FirstName"];
                    secondName = (string)reader["SecondName"];
                    thirdName = (string)reader["ThirdName"];
                    lastName = (string)reader["LastName"];

                    nationaltyID = (int)reader["NationaltyID"];
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    phone = (string)reader["Phone"];

                    if (reader["Phone"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];

                    }
                    else
                    {
                        email = null;
                    }


                    personAddress = (string)reader["PersonAddress"];
                    gender = (byte)reader["Gender"];
                    personAddress = (string)reader["PersonAddress"];


                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = (string)reader["ImagePath"];

                    }
                    else
                    {
                        imagePath = null;
                    }




                }
                reader.Close();

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While getting Person info by National No :"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;

        }



        public static int AddNewPerson(string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, int nationaltyID, DateTime dateOfBirth, string phone, string email, string personAddress, byte gender, string imagePath)
        {


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"insert into People (FirstName,SecondName,ThirdName,LastName,
                             NationalNo,NationaltyID,DateOfBirth,Phone,Email,PersonAddress,Gender,ImagePath) 
                                values
                                    (@firstName, @secondName,@thirdName,@lastName,
                                       @nationalNo, @nationaltyID, @dateOfBirth,@phone,@email,@personAddress,@gender,@imagePath);
                                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue(@"firstName", firstName);
            command.Parameters.AddWithValue(@"secondName", secondName);
            command.Parameters.AddWithValue(@"thirdName", thirdName);
            command.Parameters.AddWithValue(@"lastName", lastName);
            command.Parameters.AddWithValue(@"nationalNo", nationalNo);
            command.Parameters.AddWithValue(@"nationaltyID", nationaltyID);
            command.Parameters.AddWithValue(@"dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue(@"phone", phone);

            if(email != "" && email != null)
            {
                command.Parameters.AddWithValue(@"email", email);

            }
            else
            {
                command.Parameters.AddWithValue(@"email",System.DBNull.Value);

            }

            command.Parameters.AddWithValue(@"personAddress", personAddress);
            command.Parameters.AddWithValue(@"gender", gender);

            if(imagePath !=""&& imagePath!=null)
            {
                command.Parameters.AddWithValue(@"imagePath", imagePath);

            }
            else
            {
                command.Parameters.AddWithValue(@"imagePath",System.DBNull.Value);

            }


            int personID = -1;

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if(result !=null && int.TryParse(result.ToString(),out int InsertedID))
                {
                    personID = InsertedID;
                }

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While Adding New Person:"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return personID;

        }


        public static bool UpdatePerson(int personID ,string firstName, string secondName, string thirdName, string lastName,
            string nationalNo, int nationaltyID, DateTime dateOfBirth, string phone, string email, string personAddress, byte gender, string imagePath)
        {


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Update People set 
                        
                            FirstName = @firstName,
                            SecondName = @secondName,
                            ThirdName = @thirdName,
                            LastName = @lastName,
                            NationalNo = @nationalNo,
                            NationaltyID = @nationaltyID,
                            DateOfBirth = @dateOfBirth,
                            Phone = @phone,
                            Email = @email,
                            PersonAddress = @personAddress,
                            Gender = @gender,
                            ImagePath = @imagePath
                                where PersonID=@personID
                        ";

            SqlCommand command = new SqlCommand(query, Connection);
            
            command.Parameters.AddWithValue(@"personID", personID);
            command.Parameters.AddWithValue(@"firstName", firstName);
            command.Parameters.AddWithValue(@"secondName", secondName);
            command.Parameters.AddWithValue(@"thirdName", thirdName);
            command.Parameters.AddWithValue(@"lastName", lastName);
            command.Parameters.AddWithValue(@"nationalNo", nationalNo);
            command.Parameters.AddWithValue(@"nationaltyID", nationaltyID);
            command.Parameters.AddWithValue(@"dateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue(@"phone", phone);

            if (email != "" && email != null)
            {
                command.Parameters.AddWithValue(@"email", email);

            }
            else
            {
                command.Parameters.AddWithValue(@"email", System.DBNull.Value);

            }

            command.Parameters.AddWithValue(@"personAddress", personAddress);
            command.Parameters.AddWithValue(@"gender", gender);

            if (imagePath != "" && imagePath != null)
            {
                command.Parameters.AddWithValue(@"imagePath", imagePath);

            }
            else
            {
                command.Parameters.AddWithValue(@"imagePath", System.DBNull.Value);

            }


            int EffectedRows= 0;

            try
            {
                Connection.Open();

                EffectedRows =command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While Updating Person Info :"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return (EffectedRows>0);

        }


        public static bool DeletePerson(int personID)
        { 


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"delete People where PersonID=@personID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue(@"personID", personID);


            int EffectedRows = 0;

            try
            {
                Connection.Open();

                EffectedRows = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While Deleting Person Info :"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return (EffectedRows > 0);

        }



        public static bool IsPersonExist(int personID)
        {


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select found =1 from People where PersonID=@personID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue(@"personID", personID);


            bool isFound = false;

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
                reader.Close();


            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While Checking if Person Exist :"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;

        }





        public static bool IsPersonExist(string nationalNo)
        {


            SqlConnection Connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"select found =1 from People where NationalNo=@nationalNo";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue(@"nationalNo", nationalNo);


            bool isFound = false;

            try
            {
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();

            }
            catch (Exception ex)
            {

                //Console.WriteLine("Error While Checking if Person Exist by its NationalNo:"+ex.Message);
            }
            finally
            {
                Connection.Close();

            }
            return isFound;

        }

    }
}
