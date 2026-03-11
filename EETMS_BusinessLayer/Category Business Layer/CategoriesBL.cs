
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System.Collections.Generic;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class CategoriesBL
    {

        public static DataTable GetAllInformationCategories()
            => CategoriesQueriesDAL.GetAllInformationCategories();

        public static DataTable GetAllInformationCategoriesGroupByNameForEvent()
            => CategoriesQueriesDAL.GetAllInformationCategoriesGroupByCategoryname();

        public static CategoryDTO FindTheCategoryBy(int IDCategory)
            => CategoriesQueriesDAL.FindTheCategoryBy(IDCategory);

        private static bool _AddNewCategory(CategoryDTO NewInformationCategory)
            => CategoriesCommandsDAL.InsertTheNewCategory(NewInformationCategory) > clsEETMS_Constants.kZERO;

        private static bool _UpdateInformationCategory(int IDCategory, CategoryDTO NewInformationCategory)
            => CategoriesCommandsDAL.UpdateInformationCategoryBy(IDCategory, NewInformationCategory) > clsEETMS_Constants.kZERO;

        public static bool DeleteTheCategoryBy(int IDCategory)
            => CategoriesCommandsDAL.DeleteTheCategoryBy(IDCategory) > clsEETMS_Constants.kZERO;

        public static bool SaveInformationCategory(CategoryDTO NewInformationCategory)
        {

            switch (NewInformationCategory.EnMode)
            {

                case CategoryDTO._EnModeCategory._kAADD_NEW_CATEGORY:
                    return (_AddNewCategory(NewInformationCategory));

                case CategoryDTO._EnModeCategory._kUPDATE_INFORMATION_CATEGORY:
                    return (_UpdateInformationCategory(NewInformationCategory.CategoryID, NewInformationCategory));

            }

            return false;
        }

        public static DataTable GetAllInformationCategoryFullInformation(string CategoryNameToBeSearch)
            => CategoriesQueriesDAL.SearchCategoryFullInfo(CategoryNameToBeSearch);

        public static List<string> AllCategoryNames()
            => CategoriesQueriesDAL.GetAllCategoryNames();

        public static bool IsCategoryExistsBy(string CategoryName)
            => CategoriesQueriesDAL.IsTheCategoryIsExistsBy(CategoryName);

    }
}
