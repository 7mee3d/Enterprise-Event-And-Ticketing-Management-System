using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Validation;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;


namespace EETMS_Presentation.EETMS_Category
{
    public partial class UC_Category : UserControl
    {


        private CategoryDTO _CategoryInfo;
        private int IDCategory;
        private _EnModeCategory _ModeCategory;
        private Guna2MessageDialog _G2MD;



        private enum _EnModeCategory
        {
            _ADD_NEW_CATEGORY = 1,
            _UPDATE_INFORMATION_CATEGORY = 2
        };


        public UC_Category()
        {
            InitializeComponent();
            _CategoryInfo = null;
            _ModeCategory = _EnModeCategory._ADD_NEW_CATEGORY;
            IDCategory = clsEETMS_Constants.kZERO;

        }

        private void _ClearTheTextBoxies()
        {

            foreach (Control outterControl in this.Controls)
            {

                foreach (Control innerControl in outterControl.Controls)
                {
                    if (innerControl is Guna2TextBox G2TB)
                        G2TB.Text = clsEETMS_Constants.kEMPTY_STRING;

                }
            }
        }

        private bool _CheckTheTextBoxFiledOrNot()
            => (String.IsNullOrEmpty(GTextBoxCategoryName.Text));

        private int _GetTheIDCategoryAfterSelectedDGV()
            => (GDataGridViewCategoriesInformation.SelectedRows.Count > clsEETMS_Constants.kZERO) ?
            _SplitTheCategoryIDString(GDataGridViewCategoriesInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells[clsEETMS_Constants.kZERO].Value.ToString())
            : clsEETMS_Constants.kNEGATIVE_ONE;

        private void _AddNewCategoryOrUpdate()
        {
            Guna2MessageDialog G2MD = new Guna2MessageDialog();

            if (clsValidation.CheckTheNameHaveDigit_SymbolOrPunctuation(GTextBoxCategoryName.Text))
            {

                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    $"Please Enter The Category Name is Vaild" +
                    "\nWithout The Symbol , Digits And Punctuation",
                    "Invaild Input Data !!",
                    MessageDialogButtons.OK,
                    MessageDialogIcon.Error
                    );


                return;
            }
            else
                _CategoryInfo.CategoryName = GTextBoxCategoryName.Text;

            _CategoryInfo.DescripationCategory = GTextBoxCategoryDescripation.Text;


            if (!_CheckTheTextBoxFiledOrNot())
            {
                if (_ModeCategory == _EnModeCategory._ADD_NEW_CATEGORY)
                {
                    if (CategoriesBL.IsCategoryExistsBy(GTextBoxCategoryName.Text))
                    {
                        _ClearTheTextBoxies();
                        clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Connot Be Added This Category Becouse The Category Already Exsits.", "Note For Add New Category", MessageDialogButtons.OK, MessageDialogIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Must Fill The Category Name To Be Add", "Note Add New Category ", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;

            }

            if (CategoriesBL.SaveInformationCategory(_CategoryInfo))
                if (_CategoryInfo.EnMode == CategoryDTO._EnModeCategory._kAADD_NEW_CATEGORY)
                {
                    IDCategory = _CategoryInfo.CategoryID;
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Category Addedd Successfully", "Note of Add new Category", MessageDialogButtons.OK, MessageDialogIcon.Information);
                }
                else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Category Updated Successfully", "Note of Update Category", MessageDialogButtons.OK, MessageDialogIcon.Information);
            else
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Add/Update Faild", "Note For Add /Update Category", MessageDialogButtons.OK, MessageDialogIcon.Error);
                _ClearTheTextBoxies();
                return;
            }

            _InitalSettingUpdateMode();
            _IntialSettingsAfterLoadTheSection();

        }

        private void _InitalSettingUpdateMode()
        {
            _CategoryInfo.EnMode = CategoryDTO._EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
            GTextBoxCategoryName.Text = _CategoryInfo.CategoryName;
            GTextBoxCategoryDescripation.Text = _CategoryInfo.DescripationCategory;
            _ModeCategory = _EnModeCategory._UPDATE_INFORMATION_CATEGORY;
            GGButtonAddNewCategory.Text = "Update Information Category";
            GGButtonAddNewCategory.Image = Resources.Update_Icon_EETMS;
        }

        private void _LoadAllInformationCategoryAfterLoadTheSectionUpdateMode()
        {

            IDCategory = _GetTheIDCategoryAfterSelectedDGV();

            if (_ModeCategory == _EnModeCategory._ADD_NEW_CATEGORY && IDCategory == clsEETMS_Constants.kNEGATIVE_ONE)
            {
                GGButtonAddNewCategory.Text = "Add New Category";
                _CategoryInfo = new CategoryDTO();
                _CategoryInfo.EnMode = CategoryDTO._EnModeCategory._kAADD_NEW_CATEGORY;
                IDCategory = -1;
                return;
            }


            _CategoryInfo = CategoriesBL.FindTheCategoryBy(IDCategory);


            if (_CategoryInfo == null)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Sorry The Category is Not Exsits ", "note Of Add/Update New Category", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }


            _InitalSettingUpdateMode();

        }

        private int _SplitTheCategoryIDString(string CategoryIDString)
            => Convert.ToInt32(CategoryIDString.Split('-')[clsEETMS_Constants.kONE]);

        private void _LoadAllInformationCategoriesInTheDataGridView()
        {

            DataTable CategoriesGroupByName_DT = CategoriesBL.GetAllInformationCategoriesGroupByNameForEvent();
            DataTable Categories_DT = CategoriesBL.GetAllInformationCategories();


            int MaxCount = Math.Max(CategoriesGroupByName_DT.Rows.Count, Categories_DT.Rows.Count);

            for (int counter = clsEETMS_Constants.kZERO; counter < MaxCount; counter += clsEETMS_Constants.kONE)
            {
                string CategoryID = clsEETMS_Constants.kEMPTY_STRING;

                CategoryID = "#CAT-" + Categories_DT.Rows[counter]["CategoryID"].ToString();

                int rowIndexCategory = GDataGridViewCategoriesInformation.Rows.Add(


                    CategoryID,
                    CategoriesGroupByName_DT.Rows[counter]["CategoryName"].ToString(),
                    CategoriesGroupByName_DT.Rows[counter]["CountEventForCategory"].ToString(),
                    Categories_DT.Rows[counter]["Discripation"].ToString()


                              );


                DataGridViewRow DataGridViewRowCategory = GDataGridViewCategoriesInformation.Rows[rowIndexCategory];
                DataGridViewCell DataGridViewCellCategory = DataGridViewRowCategory.Cells[clsEETMS_Constants.kZERO];

                DataGridViewCellCategory.Style.ForeColor = Color.FromArgb(
                    clsEETMS_Constants.kNUMBER_RED_COLOR_ROYAL_BLUE,
                    clsEETMS_Constants.kNUMBER_GREEN_COLOR_ROYAL_BLUE,
                    clsEETMS_Constants.kNUMBER_BLUE_COLOR_ROYAL_BLUE
                    );

            }
        }

        private void USCategory_Load(object sender, EventArgs e)
        {
            _IntialSettingsAfterLoadTheSection();
            _LoadAllInformationCategoryAfterLoadTheSectionUpdateMode();
        }

        private void GGButtonAddNewCategory_Click(object sender, EventArgs e)
            => _AddNewCategoryOrUpdate();

        private void _IntialSettingsAfterLoadTheSection()
        {
            GDataGridViewCategoriesInformation.Rows.Clear();
            _LoadAllInformationCategoriesInTheDataGridView();
            GDataGridViewCategoriesInformation.ClearSelection();


        }

        private void _ResetAllSettingAfterClickTheUSCategory()
        {
            _ModeCategory = _EnModeCategory._ADD_NEW_CATEGORY;
            IDCategory = clsEETMS_Constants.kNEGATIVE_ONE;
            GGButtonAddNewCategory.Text = "Add New Category";
            GGButtonAddNewCategory.Image = Resources.Add_Image_Icon_EETMS;

            _ClearTheTextBoxies();
        }

        private void USCategory_Click(object sender, EventArgs e)
           => _ResetAllSettingAfterClickTheUSCategory();

        private void _DeleteTheCategoryByID()
        {

            if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Are You Sure To Be Delete This Category ??", "Note For Delete The Category", MessageDialogButtons.OKCancel, MessageDialogIcon.Question))
            {
                if (CategoriesBL.DeleteTheCategoryBy(_GetTheIDCategoryAfterSelectedDGV()))
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Category deleted Successfully ", "note For Delete Category", MessageDialogButtons.OK, MessageDialogIcon.Information);
                else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Category Connot deleted Becouse The Category Referance Events", "note For Delete Category", MessageDialogButtons.OK, MessageDialogIcon.Error);

            }
            else
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Category deleted Faild ", "note For Delete Category", MessageDialogButtons.OK, MessageDialogIcon.Error);

            _IntialSettingsAfterLoadTheSection();
            _ResetAllSettingAfterClickTheUSCategory();
        }

        private void _LoadAllInformationCategoriesInTheDataGridViewAfterSearchTextBox()
        {

            DataTable CategoriesGroupByName_DT = CategoriesBL.GetAllInformationCategoryFullInformation(GTextBoxSearchTheCategory.Text.Trim().ToLower());


            foreach (DataRow DR_Category in CategoriesGroupByName_DT.Rows)
            {
                string CategoryID = clsEETMS_Constants.kEMPTY_STRING;

                CategoryID = "#CAT-" + DR_Category["CategoryID"].ToString();

                GDataGridViewCategoriesInformation.Rows.Add(

                     CategoryID,
                     DR_Category["CategoryName"] != null ? DR_Category["CategoryName"].ToString() : clsEETMS_Constants.kEMPTY_STRING,
                     DR_Category["CountEventForCategory"] != null ? DR_Category["CountEventForCategory"].ToString() : clsEETMS_Constants.kEMPTY_STRING,
                     DR_Category["Discripation"].ToString()


                              );

            }
        }

        private void GTextBoxSearchTheCategory_TextChanged(object sender, EventArgs e)
        {
            GDataGridViewCategoriesInformation.Rows.Clear();
            _LoadAllInformationCategoriesInTheDataGridViewAfterSearchTextBox();
        }

        private void editEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _LoadAllInformationCategoryAfterLoadTheSectionUpdateMode();
        }

        private void deleteEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _DeleteTheCategoryByID();
        }

        private void GTextBoxCategoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar));
        }
    }
}
