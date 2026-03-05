using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class CategoriesCommandsDAL
    {


        #region Setting Data Access Categories
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Methods Categories Commands 

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
    }

    #endregion

}
