
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer.Roles_Data_Access_Layer
{
    public class RoleDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



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

    }
}
