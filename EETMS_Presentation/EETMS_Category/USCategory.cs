using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using EETMS_BusinessLayer;
using EETMS_Models;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;


namespace EETMS_Presentation.EETMS_Category
{
    public partial class USCategory : UserControl
    {


        private MCategory _CategoryInfo = null;

        private int IDCategory ; 

        private enum _EnModeCategory
        {
            _ADD_NEW_CATEGORY = 1 , 
            _UPDATE_INFORMATION_CATEGORY = 2 
        };

        private _EnModeCategory _ModeCategory ;

        public USCategory()
        {
            InitializeComponent();
            _ModeCategory = _EnModeCategory._ADD_NEW_CATEGORY;
            IDCategory = 0;

        }

        private void _ClearTheTextBoxies ()
        {

            foreach(Control outterControl  in this.Controls ){

                foreach (Control innerControl in outterControl.Controls)
                {
                    if (innerControl is Guna2TextBox G2TB)
                        G2TB.Text = ""; 

                }
            }
        }
     
        private int _GetTheIDCategoryAfterSelectedDGV ()
        {
            return (GDataGridViewCategoriesInformation.SelectedRows.Count > 0) ? _SplitTheCategoryIDString ( GDataGridViewCategoriesInformation.SelectedRows[0].Cells[0].Value.ToString() ) : -1; 
        }

        private void _AddNewCategoryOrUpdate ()
        {


            _CategoryInfo.CategoryName = GTextBoxCategoryName.Text; 
            _CategoryInfo.DescripationCategory = GTextBoxCategoryDescripation.Text;

            if (CategoriesBL.SaveInformationCategory(_CategoryInfo))
                if (_CategoryInfo.EnMode == MCategory._EnModeCategory._kAADD_NEW_CATEGORY) MessageBox.Show("The Category Addedd Successfully", "Note of Add new Category");
                else MessageBox.Show("The Category Updated Successfully", "Note of Update Category");
            else
            { 
                MessageBox.Show("Connot Be Added This Category Becouse The Category Already Exsits", "Note of Add/Update Category");
                _ClearTheTextBoxies();
                return;
            }


            GTextBoxCategoryName.Text = _CategoryInfo.CategoryName;
            GTextBoxCategoryDescripation.Text = _CategoryInfo.DescripationCategory;
            _ModeCategory = _EnModeCategory._UPDATE_INFORMATION_CATEGORY;
            _CategoryInfo.EnMode = MCategory._EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
            GGButtonAddNewCategory.Text = "Update Information Category";
            GGButtonAddNewCategory.Image = Resources.Update_Icon_EETMS;

            _IntialSettingsAfterLoadTheSection();
        }

        private void _LoadAllInformationCategoryAfterLoadTheSection()
        {

            IDCategory = _GetTheIDCategoryAfterSelectedDGV();

            if (_ModeCategory == _EnModeCategory._ADD_NEW_CATEGORY && IDCategory == -1 )
            {
                GGButtonAddNewCategory.Text = "Add New Category";
                _CategoryInfo = new MCategory();
                _CategoryInfo.EnMode = MCategory._EnModeCategory._kAADD_NEW_CATEGORY;

                return; 
            }


            _CategoryInfo = CategoriesBL.FindTheCategoryBy(IDCategory);


            if(_CategoryInfo == null )
            {
                MessageBox.Show("Sorry The Category is Not Exsits ", "note Of Add/Update New Category");
                return; 
            }


            _CategoryInfo.EnMode = MCategory._EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
            GTextBoxCategoryName.Text = _CategoryInfo.CategoryName; 
            GTextBoxCategoryDescripation.Text = _CategoryInfo.DescripationCategory;
            _ModeCategory = _EnModeCategory._UPDATE_INFORMATION_CATEGORY;
            GGButtonAddNewCategory.Text = "Update Information Category";
            GGButtonAddNewCategory.Image = Resources.Update_Icon_EETMS;

        }
        
        private int _SplitTheCategoryIDString(string CategoryIDString )
        {
            return Convert.ToInt32(CategoryIDString.Split( '-' )[1]); 
        }

        private void _LoadAllInformationCategoriesInTheDataGridView ()
        {

            DataTable CategoriesGroupByName_DT = CategoriesBL.GetAllInformationCategoriesGroupByNameForEvent();
            DataTable Categories_DT = CategoriesBL.GetAllInformationCategories();


            int MinCount = Math.Max(CategoriesGroupByName_DT.Rows.Count, Categories_DT.Rows.Count); 

            for (int counter = 0; counter < MinCount; counter += 1)
            {
                string CategoryID = "";

                CategoryID = "#CAT-" + Categories_DT.Rows[counter]["CategoryID"].ToString();

                GDataGridViewCategoriesInformation.Rows.Add(


                    CategoryID,
                    CategoriesGroupByName_DT.Rows[counter]["CategoryName"].ToString(),
                    CategoriesGroupByName_DT.Rows[counter]["CountEventForCategory"].ToString(),
                    Categories_DT.Rows[counter]["Discripation"].ToString() 


                              );

            }
        }
      
        private void USCategory_Load(object sender, EventArgs e)
        {

            _IntialSettingsAfterLoadTheSection();
            _LoadAllInformationCategoryAfterLoadTheSection();
        }

        private void GGButtonAddNewCategory_Click(object sender, EventArgs e)
        {
            _AddNewCategoryOrUpdate();
        }
  
        private void _IntialSettingsAfterLoadTheSection()
        {
            GDataGridViewCategoriesInformation.Rows.Clear();
            _LoadAllInformationCategoriesInTheDataGridView();
            GDataGridViewCategoriesInformation.ClearSelection();

            
        }
    
    }
}
