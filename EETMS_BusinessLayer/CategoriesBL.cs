
using EETMS_DataAccessLayer;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class CategoriesBL
    {

        public static DataTable GetAllInformationCategories() => CategoriesDAL.GetAllInformationCategories();

        public static DataTable GetAllInformationCategoriesGroupByNameForEvent() => CategoriesDAL.GetAllInformationCategoriesGroupByCategoryname();

    }
}
