

using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class RolesCommandsDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Methods Role Commands 

        private static int _InsertNewRole(RoleDTO InformationNewRole)
        {

            int IDNewRole = 0;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                    INSERT INTO Roles (RoleName , DescripationRole , Permssions )
                                    VALUES (@RoleName , @DescripationRole , @Permssions ) ;
                                    
                                    SELECT SCOPE_IDENTITY(); 


                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@RoleName", InformationNewRole.RoleName);
                    if (!string.IsNullOrWhiteSpace(InformationNewRole.DescripationRole))
                        command.Parameters.AddWithValue("@DescripationRole", InformationNewRole.DescripationRole);
                    else command.Parameters.AddWithValue("@DescripationRole", DBNull.Value);

                    if (InformationNewRole.PermssionsRole == 0)
                        command.Parameters.AddWithValue("@Permssions", -1);
                    else command.Parameters.AddWithValue("@Permssions", InformationNewRole.PermssionsRole);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ResultNewIDRole))
                        IDNewRole = ResultNewIDRole;

                    InformationNewRole.RoleID = IDNewRole;
                }



            }

            return IDNewRole;

        }

        public static int InsertNewRole(RoleDTO InformationNewRole)
            => _InsertNewRole(InformationNewRole);

        private static int _UpdateInformationRole(int RoleID, RoleDTO InfromationNewRole)
        {

            int RowAffective = -1;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                            UPDATE Roles 
                                            SET RoleName  = @RoleName  , DescripationRole = @DescripationRole , Permssions = @Permssions 

                                            WHERE RoleID = @RoleID ; 

                           ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@RoleName", InfromationNewRole.RoleName);

                    if (!string.IsNullOrWhiteSpace(InfromationNewRole.DescripationRole))
                        command.Parameters.AddWithValue("@DescripationRole", InfromationNewRole.DescripationRole);
                    else command.Parameters.AddWithValue("@DescripationRole", DBNull.Value);

                    if (InfromationNewRole.PermssionsRole == 0)
                        command.Parameters.AddWithValue("@Permssions", -1);
                    else command.Parameters.AddWithValue("@Permssions", InfromationNewRole.PermssionsRole);

                    connection.Open();

                    RowAffective = command.ExecuteNonQuery();

                }
            }

            return RowAffective;

        }

        public static int UpdateInformationRole(int RoleID, RoleDTO InfromationNewRole)
            => _UpdateInformationRole(RoleID, InfromationNewRole);

        private static int _DeleteRoleBy(int RoleID)
        {

            int RowAffective = -1;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                    DELETE FROM Roles 
                                    WHERE RoleID = @RoleID;

                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    connection.Open();


                    RowAffective = command.ExecuteNonQuery();



                }

            }

            return RowAffective;

        }

        public static int DeleteRoleBy(int RoleID)
            => _DeleteRoleBy(RoleID);

        #endregion
    }
}
