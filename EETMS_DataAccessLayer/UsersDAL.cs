
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using EETMS_Models;

namespace EETMS_DataAccessLayer
{
    public class UsersDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion    
    
        private static MUser _FindTheUserByUserNameOrEmail (string UsernameOrEmail )
        {

            MUser InfoUser = null; 

            try
            {
                //UserName = @EmailOrUsername OR
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                        SELECT  UserID
                                                UserFullName ,
                                                UserName ,
                                                PasswordUser  ,
                                                EmailUser   ,
                                                ActiveAccount ,
                                                PermissionUser   ,
                                                NumberAttempt  

                                        FROM Users 
                                        WHERE (

                                                 (UserName = @UsernameOrEmail)
                                           OR    (EmailUser = @UsernameOrEmail)

                                              ) ; 
                                                    


                                     ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UsernameOrEmail", SqlDbType.NVarChar, 400).Value = UsernameOrEmail;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader() )
                        {


                            if (reader.Read () )
                            {

                                InfoUser = new MUser()
                                {

                                    UserID = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : 0,
                                    UserFullName = reader["UserFullName"] != DBNull.Value ? (string)reader["UserFullName"] : null,
                                    Username = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null,
                                    PasswordUser = reader["PasswordUser"] != DBNull.Value ? (string)reader["PasswordUser"] : null,
                                    EmailUser = reader["EmailUser"] != DBNull.Value ? (string)reader["EmailUser"] : null,
                                    IsActiveAccount = reader["ActiveAccount"] != DBNull.Value ? (bool)reader["ActiveAccount"] : false,
                                    PermissionUser = reader["PermissionUser"] != DBNull.Value ? (int)reader["PermissionUser"] : 0,
                                    NumberAttempts = reader["NumberAttempt"] != DBNull.Value ? (int)reader["NumberAttempt"] : 0,

                                };

                            }
                        }



                    }
                }


            }
            catch (Exception Ex)
            {

            }

            return InfoUser; 
        }

        public static MUser FindTheUserByUserNameOrEmail(string UsernameOrEmail)
        {
            return FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

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

        private static int _InsertNewUser (MUser InformationNewUser)
        {
            int NewID = -1;


            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"
                                                        
                                        INSERT INTO Users (UserFullName , UserName , PasswordUser , EmailUser , PermissionUser )
                                        VALUES            (@UserFullName , @UserName , @PasswordUser , @EmailUser , @PermissionUser);



                                        SELECT SCOPE_IDENTITY() ; 


                                   ";

                    using (SqlCommand command = new SqlCommand(Query , connection ))
                    {

                        command.Parameters.Add("@UserFullName", SqlDbType.NVarChar, 400).Value = InformationNewUser.UserFullName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = InformationNewUser.Username;
                        command.Parameters.Add("@PasswordUser", SqlDbType.NVarChar, 350).Value = InformationNewUser.PasswordUser;
                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = InformationNewUser.EmailUser;
                        command.Parameters.Add("@PermissionUser", SqlDbType.SmallInt).Value = InformationNewUser.PermissionUser;


                        connection.Open();

                        object resultInsertNewUser = command.ExecuteScalar();

                        if (resultInsertNewUser != null && int.TryParse(resultInsertNewUser.ToString(), out int NewIDUser))
                            NewID = NewIDUser;

                        InformationNewUser.UserID = NewID;

                    }

                }
 

            }catch(Exception Ex) { }


            return NewID;

        }
   
        public static int InsertNewUser(MUser InformationNewUser)
        {
            return _InsertNewUser(InformationNewUser);
        }

        private static int _UpdateInformationUser(MUser InformationNewUser)
        {

            int RowAfective = -1; 


            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"
                                                        
                                        UPDATE Users 

                                        SET     UserFullName = @UserFullName ,
                                                UserName = @UserName ,
                                                PasswordUser = @PasswordUser ,
                                                EmailUser  = @EmailUser ,
                                                PermissionUser  = @PermissionUser ,
                                                NumberAttempt = @NumberAttempt 



                                        WHERE UserID = @UserID ;


                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UserID", SqlDbType.Int).Value = InformationNewUser.UserID;
                        command.Parameters.Add("@UserFullName", SqlDbType.NVarChar, 400).Value = InformationNewUser.UserFullName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = InformationNewUser.Username;
                        command.Parameters.Add("@PasswordUser", SqlDbType.NVarChar, 350).Value = InformationNewUser.PasswordUser;
                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = InformationNewUser.EmailUser;
                        command.Parameters.Add("@PermissionUser", SqlDbType.SmallInt).Value = InformationNewUser.PermissionUser;
                        command.Parameters.Add("@NumberAttempt", SqlDbType.TinyInt).Value = InformationNewUser.NumberAttempts;


                        connection.Open();

                        RowAfective = command.ExecuteNonQuery();

                    }

                }


            }
            catch (Exception Ex) { }


            return RowAfective;

        }

        public static int UpdateInformationUser(MUser InformationNewUser)
        {
           return  _UpdateInformationUser(InformationNewUser);
        }
   


    }
}
