
using System.Configuration;
using System;
using System.Data.SqlClient;
using System.Data;
using EETMS_DTOs;

namespace EETMS_DataAccessLayer
{
    public class UsersQueriesDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion

        private static UserDTO _FindTheUserByUserNameOrEmail(string UsernameOrEmail)
        {

            UserDTO InfoUser = null;

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

                                InfoUser = new UserDTO()
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

        public static UserDTO FindTheUserByUserNameOrEmail(string UsernameOrEmail)
        {
            return _FindTheUserByUserNameOrEmail(UsernameOrEmail);
        }

        private static UserDTO _FindTheUserBy(int IDUser)
        {

            UserDTO InfoUser = null;

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

                                InfoUser = new UserDTO()
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

        public static UserDTO FindTheUserBy(int IDUser)
            => _FindTheUserBy(IDUser);

        private static DataTable _GetAllAfterSearchUsersBy(string SearchUserByNameOrUsername)
        {

            DataTable DT_AllUsersAfterSearch = new DataTable();


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

                                        WHERE
                                                    LOWER (US.UserFullName) LIKE '%' + LOWER ( @SearchUserByNameOrUsername ) +'%' 
                                        OR
                                                    LOWER (US.UserName) LIKE '%' + LOWER ( @SearchUserByNameOrUsername ) +'%' ;

                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@SearchUserByNameOrUsername", SearchUserByNameOrUsername);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows) DT_AllUsersAfterSearch.Load(reader);

                }
            }

            return DT_AllUsersAfterSearch;

        }

        public static DataTable GetAllAfterSearchUsersBy(string SearchUserByNameOrUsername)
            => _GetAllAfterSearchUsersBy(SearchUserByNameOrUsername);

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

        private static DataTable _GetAllStatus()
        {
            DataTable DT_AllStatus = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"

                            SELECT  DISTINCT (
                                
		                                        	CASE 
		                                        			WHEN US.ActiveAccount = 1 THEN 'Active' 
		                                        			ELSE 'Inactive'
		                                        	END 

		                                      ) AS [TypeStatusUser] 


                                            FROM Users US




                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    adapter.Fill(DT_AllStatus);

                }



            }

            return DT_AllStatus;

        }

        public static DataTable GetAllStatus()
            => _GetAllStatus();

        private static DataTable _GetTheUserActiveAccount(string TypeFilterUserStatus)
        {

            DataTable DT_userActiveAccount = new DataTable();

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
                                    ON RO.RoleID = US.RoleID 

                                    WHERE  (

                                                CASE 
                                    		    	WHEN US.ActiveAccount = 1 THEN 'Active'
                                    		    	ELSE 'Inactive' 
                                    		    END 


                                    		) = @TypeFilterUserStatus

                                    
                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@TypeFilterUserStatus", TypeFilterUserStatus);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DT_userActiveAccount.Load(reader);

                    }

                }
            }

            return DT_userActiveAccount;

        }

        public static DataTable GetTheUserActiveAccount(string TypeFilterUserStatus)
            => _GetTheUserActiveAccount(TypeFilterUserStatus);

        private static DataTable _GetUserAccordingheRoleName(string RoleName)
        {

            DataTable DT_UserAccrodingRoleName = new DataTable();


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
                                     ON RO.RoleID = US.RoleID 


                                     WHERE  RO.RoleName = @RoleName ; 


                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@RoleName", RoleName);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            DT_UserAccrodingRoleName.Load(reader);
                    }
                }
            }

            return DT_UserAccrodingRoleName;

        }

        public static DataTable GetUserAccordingheRoleName(string RoleName)
            => _GetUserAccordingheRoleName(RoleName);
    }

}
