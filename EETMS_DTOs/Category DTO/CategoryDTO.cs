
namespace EETMS_DTOs
{
    public class CategoryDTO
    {

        public enum _EnModeCategory
        {
            _kAADD_NEW_CATEGORY = 1,
            _kUPDATE_INFORMATION_CATEGORY = 2
        };


        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string DescripationCategory { get; set; }
        public _EnModeCategory EnMode { get; set; }

        public CategoryDTO(int categoryID, string categoryName, string descripationCategory)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.DescripationCategory = descripationCategory;

            EnMode = _EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
        }


        public CategoryDTO()
        {
            this.CategoryID = default(int);
            this.CategoryName = default(string);
            this.DescripationCategory = default(string);

            EnMode = _EnModeCategory._kAADD_NEW_CATEGORY;
        }

    }
}
