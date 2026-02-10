
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class CategoriesDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion

        private static DataTable _GetAllInformationCategories()
        {

            DataTable CategoriesDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

                                
			                    SELECT 
					                    Categories.CategoryID ,
					                    Categories.CategoryName , 
					                    Categories.Discripation 

							                             FROM Categories ; 

                                ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                                CategoriesDT.Load(reader);


                        }

                    }

                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return CategoriesDT;
        }

        public static DataTable GetAllInformationCategories()
        {
            return _GetAllInformationCategories();
        }



    }
}
