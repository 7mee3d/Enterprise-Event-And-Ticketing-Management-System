using EETMS_DTOs;
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



        #region All Methods Operation CRUD ( Create , Read , Update , Delete ) The Category 

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

        private static int _InsertTheNewCategory(CategoryDTO NewInformationCategory)
        {

            int NewIDCategory = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {
                    string Query = @"


                                    INSERT INTO Categories (CategoryName , Discripation)
                                    VALUES (@CategoryName , @Descripation) ;
    



                                    SELECT SCOPE_IDENTITY();



    

                       ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 250).Value = NewInformationCategory.CategoryName;

                        if (string.IsNullOrEmpty(NewInformationCategory.DescripationCategory))
                            command.Parameters.AddWithValue("@Descripation", DBNull.Value);
                        else
                            command.Parameters.AddWithValue("@Descripation", NewInformationCategory.DescripationCategory);

                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                            NewIDCategory = NewID;


                        NewInformationCategory.CategoryID = NewIDCategory;


                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            ;


            return NewIDCategory;

        }

        public static int InsertTheNewCategory(CategoryDTO NewInformationCategory)
             => _InsertTheNewCategory(NewInformationCategory);

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

        private static int _UpdateInformationCategoryBy(int IDCategory, CategoryDTO NewInformationCategory)
        {
            int RowAffective = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @" 
                                                    
                                                UPDATE Categories   
                                                SET CategoryName = @CategoryName , Discripation = @Descripation 
                                                WHERE CategoryID = @CategoryID ; 



                                 ";



                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.AddWithValue("@CategoryID", IDCategory);
                        command.Parameters.AddWithValue("@CategoryName", NewInformationCategory.CategoryName);
                        command.Parameters.AddWithValue("@Descripation", NewInformationCategory.DescripationCategory);

                        connection.Open();

                        RowAffective = command.ExecuteNonQuery();

                    }

                }


            }
            catch (Exception ex)
            {
                throw;
            }


            return RowAffective;
        }

        public static int UpdateInformationCategoryBy(int IDCategory, CategoryDTO NewInformationCategory)
            => _UpdateInformationCategoryBy(IDCategory, NewInformationCategory);

        private static int _DeleteTheCategoryBy(int IDCategory)
        {

            int RowAffecive = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"           
                                
                                            DELETE FROM Categories 
                                            WHERE CategoryID = @CategoryID ; 



                              ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@CategoryID", SqlDbType.Int).Value = IDCategory;

                        connection.Open();

                        RowAffecive = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return RowAffecive;
        }

        public static int DeleteTheCategoryBy(int IDCategory)
            => _DeleteTheCategoryBy(IDCategory);

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


        #endregion


    }

}
