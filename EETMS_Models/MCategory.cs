

namespace EETMS_Models
{
    public  class MCategory
    {

        public enum _EnModeCategory
        {
            _kAADD_NEW_CATEGORY = 1 ,
            _kUPDATE_INFORMATION_CATEGORY = 2 
        };


        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string DescripationCategory  { get; set; }
        public _EnModeCategory EnMode  { get; set; }

        public MCategory(int categoryID, string categoryName, string descripationCategory)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.DescripationCategory = descripationCategory;

            EnMode = _EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
        }


        public MCategory()
        {
            this.CategoryID = default(int);
            this.CategoryName = default(string);
            this.DescripationCategory = default(string);

            EnMode = _EnModeCategory._kAADD_NEW_CATEGORY;
        }

    }
}
