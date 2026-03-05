using EETMS_DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class CategoriesQueriesDAL
    {

        #region Setting Data Access Categories
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        #region All Methods Category Queries 

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
                                                                RIGHT OUTER JOIN Categories CAT 
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
                throw;
            }


            return CategoriesDT;
        }

        public static DataTable GetAllInformationCategoriesGroupByCategoryname()
            => _GetAllInformationCategoriesGroupByCategoryname();

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
                throw;
            }


            return CategoriesDT;
        }

        public static DataTable GetAllInformationCategories()
             => _GetAllInformationCategories();

        private static CategoryDTO _FindTheCategoryBy(int IDCategory)
        {

            CategoryDTO CategoryInfo = null;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"
                                             SELECT 

                                                    CAT.CategoryID ,
                                                    CAT.CategoryName ,
                                                    CAT.Discripation 

                                                                FROM Categories CAT 

                                             WHERE   CAT.CategoryID = @CategoryID ; 


                                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = IDCategory;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            CategoryInfo = new CategoryDTO();

                            CategoryInfo.CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0;
                            CategoryInfo.CategoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : null;
                            CategoryInfo.DescripationCategory = reader["Discripation"] != DBNull.Value ? reader["Discripation"].ToString() : null;

                        }
                    }
                }
            }

            return CategoryInfo;
        }

        public static CategoryDTO FindTheCategoryBy(int IDCategory)
            => _FindTheCategoryBy(IDCategory);

        private static DataTable _SearchCategoryFullInfo(string NameCategory)
        {

            DataTable dt = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {
                string Query = @"


                                                 SELECT 
                                                                  CAT.CategoryID,
                                                                  CAT.CategoryName,
                                                                  CAT.Discripation,
                                                                  COUNT(EVE.EventID) AS CountEventForCategory


                                                                          FROM Categories CAT
                                                                          LEFT JOIN Events EVE
                                                                          ON CAT.CategoryID = EVE.CategoryID

                                                                                 WHERE LOWER ( CAT.CategoryName ) LIKE '%' + LOWER ( @CategoryName ) + '%'

                                                                   GROUP BY 
                                                                       CAT.CategoryID,
                                                                       CAT.CategoryName,
                                                                       CAT.Discripation



                                  ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@CategoryName", NameCategory);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            dt.Load(reader);
                    }
                }
            }

            return dt;
        }

        public static DataTable SearchCategoryFullInfo(string NameCategory)
            => _SearchCategoryFullInfo(NameCategory);

        private static List<string> _GetAllCategoryNames()
        {

            List<string> LI_AllCategoryName = new List<string>();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


		                            SELECT Distinct CAT.CategoryName
		                            FROM Categories CAT 

                    ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                            LI_AllCategoryName.Add(reader["CategoryName"].ToString());


                    }
                }
            }

            return LI_AllCategoryName;

        }

        public static List<string> GetAllCategoryNames()
            => _GetAllCategoryNames();




        #endregion


    }

}
