
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DataAccessLayer;
using EETMS_Models;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class CategoriesBL
    {

        public static DataTable GetAllInformationCategories() => CategoriesDAL.GetAllInformationCategories();

        public static DataTable GetAllInformationCategoriesGroupByNameForEvent() => CategoriesDAL.GetAllInformationCategoriesGroupByCategoryname();

        public static MCategory FindTheCategoryBy(int IDCategory) => CategoriesDAL.FindTheCategoryBy(IDCategory);

        private static bool _AddNewCategory(MCategory NewInformationCategory) => CategoriesDAL.InsertTheNewCategory(NewInformationCategory) > clsEETMS_Constants.kZERO;

        private static bool _UpdateInformationCategory(int IDCategory, MCategory NewInformationCategory) => CategoriesDAL.UpdateInformationCategoryBy(IDCategory, NewInformationCategory) > clsEETMS_Constants.kZERO;

        public static bool DeleteTheCategoryBy(int IDCategory) => CategoriesDAL.DeleteTheCategoryBy(IDCategory) > clsEETMS_Constants.kZERO;

        public static bool SaveInformationCategory(MCategory NewInformationCategory)
        {

            switch (NewInformationCategory.EnMode)
            {

                case MCategory._EnModeCategory._kAADD_NEW_CATEGORY:
                    return (_AddNewCategory(NewInformationCategory));

                case MCategory._EnModeCategory._kUPDATE_INFORMATION_CATEGORY:
                    return (_UpdateInformationCategory(NewInformationCategory.CategoryID, NewInformationCategory));

            }

            return false;
        }

        public static DataTable GetAllInformationCategoryFullInformation(string CategoryNameToBeSearch) => CategoriesDAL.SearchCategoryFullInfo(CategoryNameToBeSearch);

    }
}
