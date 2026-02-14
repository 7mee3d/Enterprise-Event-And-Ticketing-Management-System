
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

        private static DataTable _GetAllInformationCategoriesGroupByCategoryname()
        {

            DataTable CategoriesDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

			                   
                                             SELECT 
                                                        CAT.CategoryName , 
                                                        COUNT(EVE.EventID) AS [CountEventForCategory]


                                                                FROM Events EVE
                                                                INNER JOIN Categories CAT 
                                                                ON EVE.CategoryID = CAT.CategoryID 

                                                                GROUP BY CAT.CategoryName

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

        public static DataTable GetAllInformationCategoriesGroupByCategoryname()
        {
            return _GetAllInformationCategoriesGroupByCategoryname();
        }

        private static DataTable _GetAllInformationCategories()
        {

            DataTable CategoriesDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

			                   
                                             SELECT CAT.CategoryID ,
                                                    CAT.CategoryName ,
                                                    CAT.Discripation 

                                                                FROM Categories CAT 


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
