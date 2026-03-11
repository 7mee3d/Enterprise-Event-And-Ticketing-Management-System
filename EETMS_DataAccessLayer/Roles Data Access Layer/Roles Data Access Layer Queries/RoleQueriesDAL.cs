
using EETMS_DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer.Roles_Data_Access_Layer
{
    public class RoleQueriesDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        #region All Methods Role Queries 

        private static DataTable _GetTheAllInformationRoles()
        {

            DataTable DT_AllInformationRoles = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                            SELECT
                                            				RO.RoleID , 
                                            				RO.RoleName ,
                                            				RO.Permssions ,
                                            				RO.IsActiveRole 
                                            FROM Roles RO


                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllInformationRoles.Load(reader);



                }

            }

            return DT_AllInformationRoles;
        }

        public static DataTable GetTheAllInformationRoles()
            => _GetTheAllInformationRoles();

        private static List<string> _GetAllNameRole()
        {


            List<string> LI_AllRoleName = new List<string>();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {



                string Query = @"


                                SELECT DISTINCT 
                                                    RO.RoleName 
		                        FROM Roles RO;


                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                        while (reader.Read())
                            LI_AllRoleName.Add(reader["RoleName"].ToString());
                }

            }

            return LI_AllRoleName;
        }

        public static List<string> GetAllNameRole()
            => _GetAllNameRole();

        private static DataTable _GetAllInformationRoleWithStatusWord()
        {

            DataTable DT_AllRoles = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"



                                            SELECT 
                                            				RO.RoleID ,
                                            				RO.RoleName ,
                                            				RO.DescripationRole ,
                                            				RO.Permssions , 
                                            									(
                                            												CASE 
                                            												
                                            														WHEN RO.IsActiveRole = 1 THEN 'Active' 
                                            														ELSE 'Inactive'
                                            												END 
                                            									) AS StatusRole
                                            
                                            FROM Roles RO;


                                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_AllRoles.Load(reader);

                    }

                }


            }

            return DT_AllRoles;

        }

        public static DataTable GetAllInformationRoleWithStatusWord()
            => _GetAllInformationRoleWithStatusWord();

        private static int _GetTotalRoles()
        {

            int TotalRole = 0;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"



                                SELECT 
                                		COUNT(RO.RoleID) AS [TotalRoles] 
                                FROM Roles RO


                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();



                    object result = command.ExecuteScalar();


                    if (result != null && int.TryParse(result.ToString(), out int ResultTotalRoles))
                        TotalRole = ResultTotalRoles;






                }


            }

            return TotalRole;

        }

        public static int GetTotalRoles()
            => _GetTotalRoles();

        private static int _GetTotalRolesActive()
        {

            int TotalActiveRoles = 0;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                    SELECT 
                                    		COUNT(RO.RoleID) AS [TotalRoles] 
                                    FROM Roles RO
                                    WHERE RO.IsActiveRole = 1 



                    ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int ResultTotalActiveRoles))
                        TotalActiveRoles = ResultTotalActiveRoles;

                }

            }

            return TotalActiveRoles;


        }

        public static int GetTotalRolesActive()
            => _GetTotalRolesActive();

        private static RoleDTO _FindTheRoleBy(int IDRole)
        {

            RoleDTO roleDTO = null;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                            SELECT 
                                            				RO.RoleID ,
                                            				RO.RoleName ,
                                            				RO.DescripationRole ,
                                            				RO.Permssions ,
                                            				RO.IsActiveRole 
                                            
                                            FROM Roles RO
                                            WHERE RO.RoleID = @RoleID 

                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@RoleID", IDRole);

                    connection.Open();



                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            roleDTO = new RoleDTO()
                            {

                                RoleID = IDRole,
                                RoleName = reader["RoleName"] != DBNull.Value ? reader["RoleName"].ToString() : null,
                                DescripationRole = reader["DescripationRole"] != DBNull.Value ? reader["DescripationRole"].ToString() : null,
                                PermssionsRole = reader["Permssions"] != DBNull.Value ? (int)reader["Permssions"] : 0,
                                isActiveRole = reader["IsActiveRole"] != DBNull.Value ? (bool)reader["IsActiveRole"] : false

                            };
                        }
                    }
                }


            }

            return roleDTO;


        }

        public static RoleDTO FindTheRoleBy(int IDRole)
            => _FindTheRoleBy(IDRole);

        #endregion

    }
}
