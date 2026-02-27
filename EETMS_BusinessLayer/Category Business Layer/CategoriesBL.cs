
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_DTOs;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class CategoriesBL
    {

        public static DataTable GetAllInformationCategories() => CategoriesDAL.GetAllInformationCategories();

        public static DataTable GetAllInformationCategoriesGroupByNameForEvent() => CategoriesDAL.GetAllInformationCategoriesGroupByCategoryname();

        public static CategoryDTO FindTheCategoryBy(int IDCategory) => CategoriesDAL.FindTheCategoryBy(IDCategory);

        private static bool _AddNewCategory(CategoryDTO NewInformationCategory) => CategoriesDAL.InsertTheNewCategory(NewInformationCategory) > clsEETMS_Constants.kZERO;

        private static bool _UpdateInformationCategory(int IDCategory, CategoryDTO NewInformationCategory) => CategoriesDAL.UpdateInformationCategoryBy(IDCategory, NewInformationCategory) > clsEETMS_Constants.kZERO;

        public static bool DeleteTheCategoryBy(int IDCategory) => CategoriesDAL.DeleteTheCategoryBy(IDCategory) > clsEETMS_Constants.kZERO;

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

        public static DataTable GetAllInformationCategoryFullInformation(string CategoryNameToBeSearch) => CategoriesDAL.SearchCategoryFullInfo(CategoryNameToBeSearch);

    }
}
