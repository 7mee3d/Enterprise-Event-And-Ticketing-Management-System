

using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class UserCommandsDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion

        private static int _InsertNewUser(UserDTO InformationNewUser)
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

        public static int InsertNewUser(UserDTO InformationNewUser)
        {
            return _InsertNewUser(InformationNewUser);
        }

        private static int _UpdateInformationUser(int IDUser, UserDTO InformationNewUser)
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
                        command.Parameters.AddWithValue("@LastLoginAccountDate", DateTime.Now);

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

        public static int UpdateInformationUser(int IDUser, UserDTO InformationNewUser)
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

        private static int _UpdateInformationUserActiveAccountInactiveBy(int IDUser, UserDTO InformationNewUser)
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

        public static int UpdateInformationUserActiveAccountInactiveBy(int IDUser, UserDTO InformationNewUser)
            => _UpdateInformationUserActiveAccountInactiveBy(IDUser, InformationNewUser);



    }
}
