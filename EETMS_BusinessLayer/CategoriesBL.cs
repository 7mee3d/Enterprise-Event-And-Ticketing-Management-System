
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

        private static bool _AddNewCategory(MCategory NewInformationCategory) => CategoriesDAL.InsertTheNewCategory(NewInformationCategory) > 0; 

        public static bool SaveInformationCategory (MCategory NewInformationCategory)
        {

            switch (NewInformationCategory.EnMode )
            {

                case MCategory._EnModeCategory._kAADD_NEW_CATEGORY:
                    return (_AddNewCategory(NewInformationCategory));
            }

            return false; 
        }


    } 
}
