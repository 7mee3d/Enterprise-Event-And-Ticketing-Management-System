
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using EETMS_Models;
using System.Security.Cryptography;

namespace EETMS_DataAccessLayer
{
    public class UsersDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion

        private static MUser _FindTheUserByUserNameOrEmail(string UsernameOrEmail)
        {

            MUser InfoUser = null;

            try
            {
                //UserName = @EmailOrUsername OR
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                     
                                                       SELECT  US.UserID,
                                                               US.UserFullName ,
                                                               US.UserName ,
                                                               US.PasswordUser  ,
                                                               US.EmailUser   ,
                                                               US.ActiveAccount ,
                                                               US.NumberAttempts  ,
                                                               RO.RoleName ,
                                                    		   RO.RoleID , 
                                                    		   US.ImagePath 
           

                                                                                     FROM Users US
                                                                                     INNER JOIN Roles RO
                                                                                     ON US.RoleID = RO.RoleID


                                                         WHERE (

                                                                  (UserName = @UsernameOrEmail)
                                                            OR    (EmailUser = @UsernameOrEmail)

                                                               ) ; 
                                                    


                                     ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UsernameOrEmail", SqlDbType.NVarChar, 400).Value = UsernameOrEmail;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {

                                InfoUser = new MUser()
                                {

                                    UserID = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : 0,
                                    UserFullName = reader["UserFullName"] != DBNull.Value ? (string)reader["UserFullName"] : null,
                                    Username = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null,
                                    PasswordUser = reader["PasswordUser"] != DBNull.Value ? (string)reader["PasswordUser"] : null,
                                    EmailUser = reader["EmailUser"] != DBNull.Value ? (string)reader["EmailUser"] : null,
                                    IsActiveAccount = reader["ActiveAccount"] != DBNull.Value ? (bool)reader["ActiveAccount"] : false,
                                    NumberAttempts = reader["NumberAttempts"] != DBNull.Value ? (int)reader["NumberAttempts"] : 0,
                                    RoleName = reader["RoleName"] != DBNull.Value ? (string)reader["RoleName"] : null,
                                    RoleID = reader["RoleID"] != DBNull.Value ? Convert.ToInt32(reader["RoleID"]) : 0,
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null,
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
            return _FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        private static MUser _FindTheUserBy(int IDUser)
        {

            MUser InfoUser = null;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                         SELECT   
                                                    US.UserID,
                                                    US.UserFullName ,
                                                    US.UserName ,
                                                    US.PasswordUser  ,
                                                    US.EmailUser   ,
                                                    US.ActiveAccount ,
                                                    US.NumberAttempts  ,
                                                    RO.RoleID,
                                                    RO.RoleName ,
                                                    US.ImagePath
         

                                                                FROM Users US
                                                                INNER JOIN Roles RO

                                        ON US.RoleID = RO.RoleID

                                        WHERE UserID = @UserID ;
                                                    


                                     ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UserID", SqlDbType.Int).Value = IDUser;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {

                                InfoUser = new MUser()
                                {

                                    UserID = reader["UserID"] != DBNull.Value ? (int)reader["UserID"] : 0,
                                    UserFullName = reader["UserFullName"] != DBNull.Value ? (string)reader["UserFullName"] : null,
                                    Username = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null,
                                    PasswordUser = reader["PasswordUser"] != DBNull.Value ? (string)reader["PasswordUser"] : null,
                                    EmailUser = reader["EmailUser"] != DBNull.Value ? (string)reader["EmailUser"] : null,
                                    IsActiveAccount = reader["ActiveAccount"] != DBNull.Value ? (bool)reader["ActiveAccount"] : false,
                                    NumberAttempts = reader["NumberAttempts"] != DBNull.Value ? (int)reader["NumberAttempts"] : 0,
                                    RoleID = reader["RoleID"] != DBNull.Value ? (int)reader["RoleID"] : 0,
                                    RoleName = reader["RoleName"] != DBNull.Value ? (string)reader["RoleName"] : null,
                                    ImagePath = reader["ImagePath"] != DBNull.Value ? (string)reader["ImagePath"] : null
                                };

                            }
                        }



                    }
                }


            }
            catch (Exception Ex)
            {
                throw;
            }

            return InfoUser;
        }

        public static MUser FindTheUserBy(int IDUser)
            => _FindTheUserBy(IDUser);

        private static bool _IsExsitsTheUserByEmail(string EmailUser, string Password)
        {


            int FinialResult = -1;

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


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = EmailUser;
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

        private static int _InsertNewUser(MUser InformationNewUser)
        {
            int NewID = -1;


            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"
                                                        
                                        INSERT INTO Users (UserFullName , UserName , PasswordUser , EmailUser , RoleID , ImagePath )
                                        VALUES            (@UserFullName , @UserName , @PasswordUser , @EmailUser , @RoleID , @ImagePath);



                                        SELECT SCOPE_IDENTITY() ; 


                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UserFullName", SqlDbType.NVarChar, 400).Value = InformationNewUser.UserFullName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = InformationNewUser.Username;
                        command.Parameters.Add("@PasswordUser", SqlDbType.NVarChar, 350).Value = InformationNewUser.PasswordUser;
                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = InformationNewUser.EmailUser;
                        command.Parameters.Add("@RoleID", SqlDbType.Int).Value = InformationNewUser.RoleID;

                        if (string.IsNullOrEmpty(InformationNewUser.ImagePath))
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@ImagePath", InformationNewUser.ImagePath);


                        connection.Open();

                        object resultInsertNewUser = command.ExecuteScalar();

                        if (resultInsertNewUser != null && int.TryParse(resultInsertNewUser.ToString(), out int NewIDUser))
                            NewID = NewIDUser;

                        InformationNewUser.UserID = NewID;

                    }

                }


            }
            catch (Exception Ex) { throw; }


            return NewID;

        }

        public static int InsertNewUser(MUser InformationNewUser)
        {
            return _InsertNewUser(InformationNewUser);
        }

        private static int _UpdateInformationUser(int IDUser, MUser InformationNewUser)
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
                                                RoleID  = @RoleID ,
                                                NumberAttempts = @NumberAttempts ,
                                                ImagePath = @ImagePath , 
                                                ActiveAccount = @ActiveAccount,
                                                LastLoginAccountDate = @LastLoginAccountDate



                                        WHERE UserID = @UserID ;


                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UserID", SqlDbType.Int).Value = IDUser;
                        command.Parameters.Add("@UserFullName", SqlDbType.NVarChar, 400).Value = InformationNewUser.UserFullName;
                        command.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = InformationNewUser.Username;
                        command.Parameters.Add("@PasswordUser", SqlDbType.NVarChar, 350).Value = InformationNewUser.PasswordUser;
                        command.Parameters.Add("@EmailUser", SqlDbType.NVarChar, 400).Value = InformationNewUser.EmailUser;
                        command.Parameters.Add("@RoleID", SqlDbType.SmallInt).Value = InformationNewUser.RoleID;
                        command.Parameters.Add("@NumberAttempts", SqlDbType.TinyInt).Value = InformationNewUser.NumberAttempts;
                        command.Parameters.Add("@ActiveAccount", SqlDbType.TinyInt).Value = (InformationNewUser.IsActiveAccount) ? 1 : 0;
                        command.Parameters.AddWithValue("@LastLoginAccountDate", DateTime.UtcNow);

                        if (InformationNewUser.ImagePath != null)
                            command.Parameters.AddWithValue("@ImagePath", InformationNewUser.ImagePath);
                        else
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


                        connection.Open();

                        RowAfective = command.ExecuteNonQuery();

                    }

                }


            }
            catch (Exception Ex) { throw; }


            return RowAfective;

        }

        public static int UpdateInformationUser(int IDUser, MUser InformationNewUser)
        {
            return _UpdateInformationUser(IDUser, InformationNewUser);
        }

        private static int _DeleteTheUserBy(int IDUser)
        {

            int RowAffective = -1;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                    DELETE FROM Users 
                                    WHERE 
                                                Users.UserID = @IDUser 
                                                        AND 
                                                    RoleID <> 1 



                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@IDUser", SqlDbType.Int).Value = IDUser;


                    connection.Open();


                    RowAffective = command.ExecuteNonQuery();




                }


            }

            return RowAffective;


        }

        public static int DeleteTheUserBy(int IDUser)
            => _DeleteTheUserBy(IDUser);

        private static int _GetTheTotalUsers()
        {

            int TotalUsers = 0;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                                 SELECT 
		                                                     ISNULL ( COUNT ( US.UserID ) , 0 )  
                                                 FROM Users US

                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int CTotalUsers))
                        TotalUsers = CTotalUsers;

                }

            }


            return TotalUsers;
        }

        public static int GetTheTotalUsers()
            => _GetTheTotalUsers();

        private static int _GetTheTotalActiveAdmin()
        {

            int TotalActiveAdmin = 0;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                                 SELECT 
		                                                ISNULL (COUNT(US.UserID) , 0 )  AS [TotalActiveAdmin]

                                                FROM Users US

                                                INNER JOIN Roles RO
                                                ON RO.RoleID = US.RoleID 

                                                WHERE US.ActiveAccount = 1 AND RO.RoleID = 1 

                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int CTotalActiveAdmin))
                        TotalActiveAdmin = CTotalActiveAdmin;

                }

            }


            return TotalActiveAdmin;
        }

        public static int GetTheTotalActiveAdmin()
            => _GetTheTotalActiveAdmin();

        private static int _GetTheTotalBlockedUsers()
        {

            int TotalBlockedUsers = 0;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                                 SELECT 
		                                                 ISNULL (COUNT(US.UserID) , 0 )  AS [TotalBlockedUsers]

                                                 FROM Users US

                                                 WHERE US.ActiveAccount = 0 

                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int CTotalBlockedUserAccounts))
                        TotalBlockedUsers = CTotalBlockedUserAccounts;

                }

            }


            return TotalBlockedUsers;
        }

        public static int GetTheTotalBlockedUsers()
            => _GetTheTotalBlockedUsers();

        private static DataTable _GetAllInformationUsers()
        {


            DataTable DT_AllInofrmationUser = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"




                                         SELECT 
                                        
                                        					US.UserID ,
                                        					US.UserFullName ,
                                        					US.UserName ,
                                        					US.PasswordUser ,
                                        					US.EmailUser ,
                                        					US.ActiveAccount ,
                                        					RO.RoleName ,
                                        					US.LastLoginAccountDate,
                                                            DATEDIFF ( DAY , US.LastLoginAccountDate,  GETDATE () ) AS [LastLoginForDay]


                                         FROM Users US 
                                         INNER JOIN Roles RO

                                         ON US.RoleID = RO.RoleID 




                           ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows) DT_AllInofrmationUser.Load(reader);



                }
            }

            return DT_AllInofrmationUser;

        }

        public static DataTable GetAllInformationUsers()
            => _GetAllInformationUsers();

        private static int _UpdateInformationUserActiveAccountInactiveBy(int IDUser, MUser InformationNewUser)
        {

            int RowAfective = -1;


            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"
                                                        
                                        UPDATE Users 

                                        SET    
                                                ActiveAccount = @ActiveAccount



                                        WHERE UserID = @UserID AND RoleID <> 1  ;


                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@UserID", SqlDbType.Int).Value = IDUser;
                        command.Parameters.Add("@ActiveAccount", SqlDbType.TinyInt).Value = (InformationNewUser.IsActiveAccount) ? 1 : 0;


                        connection.Open();

                        RowAfective = command.ExecuteNonQuery();

                    }

                }


            }
            catch (Exception Ex) { throw; }


            return RowAfective;

        }

        public static int UpdateInformationUserActiveAccountInactiveBy(int IDUser, MUser InformationNewUser)
            => _UpdateInformationUserActiveAccountInactiveBy(IDUser, InformationNewUser);
    }
}
