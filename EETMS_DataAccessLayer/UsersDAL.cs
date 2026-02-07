
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;

namespace EETMS_DataAccessLayer
{
    public class UsersDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion    
    
    
        private static bool _IsExsitsTheUserByEmail (string EmailUser , string Password )
        {


            int FinialResult  = -1; 

            try
            {
                //UserName = @EmailOrUsername OR
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                        SELECT 1 AS [Found User] 
                                        FROM Users 
                                        WHERE (
                                                    (EmailUser = @EmailUser)
                                               AND
                                                    (PasswordUser = @Password) 

                                                ) ; 
                                                    


                                     ";


                    using (SqlCommand command = new SqlCommand(Query , connection ))
                    {

                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = EmailUser;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 350).Value = Password;

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Result))
                            FinialResult = Result;



                    }
                }


            }catch (Exception Ex )
            {

            }

            return FinialResult > 0; 
        }
        
        public static bool IsExsitsTheUserByEmail(string EmailUser, string Password)
        {
            return _IsExsitsTheUserByEmail(EmailUser, Password);
        }

        private static bool _IsExsitsTheUserByUsername(string Username, string Password)
        {


            int FinialResult = -1;

            try
            {
               
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                        SELECT 1 AS [Found User] 
                                        FROM Users 
                                        WHERE (
                                                    (UserName = @Username)
                                               AND
                                                    (PasswordUser = @Password) 

                                                ) ; 
                                                    


                                     ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 400).Value = Username;
                        command.Parameters.Add("@Password", SqlDbType.NVarChar, 350).Value = Password;

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Result))
                            FinialResult = Result;



                    }
                }


            }
            catch (Exception Ex)
            {

            }

            return FinialResult > 0;
        }

        public static bool IsExsitsTheUserByUsername(string Username, string Password)
        {
            return _IsExsitsTheUserByUsername(Username, Password);
        }

    }
}
