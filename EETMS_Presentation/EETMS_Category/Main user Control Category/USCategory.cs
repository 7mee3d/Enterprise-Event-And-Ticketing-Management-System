using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Validation;
using EETMS_Models;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;


namespace EETMS_Presentation.EETMS_Category
{
    public partial class USCategory : UserControl
    {


        private MCategory _CategoryInfo;
        private int IDCategory;
        private _EnModeCategory _ModeCategory;

        private enum _EnModeCategory
        {
            _ADD_NEW_CATEGORY = 1,
            _UPDATE_INFORMATION_CATEGORY = 2
        };


        public USCategory()
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
                        G2TB.Text = "";

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

                G2MD.Icon = MessageDialogIcon.Error;
                G2MD.Buttons = MessageDialogButtons.OK;
                G2MD.Caption = "Invaild Input Data !!";
                G2MD.Text = "Please Enter The Category Name is Vaild" +
                    "\nWithout The Symbol , Digits And Punctuation";

                G2MD.Show();
                return;
            }
            else
                _CategoryInfo.CategoryName = GTextBoxCategoryName.Text;


            _CategoryInfo.DescripationCategory = GTextBoxCategoryDescripation.Text;


            if (!_CheckTheTextBoxFiledOrNot())

                if (CategoriesBL.SaveInformationCategory(_CategoryInfo))
                    if (_CategoryInfo.EnMode == MCategory._EnModeCategory._kAADD_NEW_CATEGORY)
                    {

                        IDCategory = _CategoryInfo.CategoryID;
                        MessageBox.Show("The Category Addedd Successfully", "Note of Add new Category");

                    }
                    else MessageBox.Show("The Category Updated Successfully", "Note of Update Category");
                else
                {
                    MessageBox.Show("Connot Be Added This Category Becouse The Category Already Exsits", "Note of Add/Update Category");
                    _ClearTheTextBoxies();
                    return;
                }
            else
            {

                MessageBox.Show("Must Fill The Category Name To Be Add", "Note Add New Category ");
                return;

            }


            _InitalSettingUpdateMode();
            _IntialSettingsAfterLoadTheSection();

        }

        private void _InitalSettingUpdateMode()
        {
            _CategoryInfo.EnMode = MCategory._EnModeCategory._kUPDATE_INFORMATION_CATEGORY;
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
                _CategoryInfo = new MCategory();
                _CategoryInfo.EnMode = MCategory._EnModeCategory._kAADD_NEW_CATEGORY;

                return;
            }


            _CategoryInfo = CategoriesBL.FindTheCategoryBy(IDCategory);


            if (_CategoryInfo == null)
            {
                MessageBox.Show("Sorry The Category is Not Exsits ", "note Of Add/Update New Category");
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
                string CategoryID = "";

                CategoryID = "#CAT-" + Categories_DT.Rows[counter]["CategoryID"].ToString();

                int rowIndexCategory = GDataGridViewCategoriesInformation.Rows.Add(


                    CategoryID,
                    CategoriesGroupByName_DT.Rows[counter]["CategoryName"].ToString(),
                    CategoriesGroupByName_DT.Rows[counter]["CountEventForCategory"].ToString() ,
                    Categories_DT.Rows[counter]["Discripation"].ToString()


                              );


                DataGridViewRow DataGridViewRowCategory = GDataGridViewCategoriesInformation.Rows[rowIndexCategory];
                DataGridViewCell DataGridViewCellCategory = DataGridViewRowCategory.Cells[clsEETMS_Constants.kZERO];

                DataGridViewCellCategory.Style.ForeColor = Color.FromArgb(39, 83, 227);

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
            GGButtonAddNewCategory.Image = Resources.Add_Icon_EETMS;

            _ClearTheTextBoxies();
        }

        private void USCategory_Click(object sender, EventArgs e)
           => _ResetAllSettingAfterClickTheUSCategory();

        private void EditCategoryToolStripMenuItem_Click(object sender, EventArgs e)
            => _LoadAllInformationCategoryAfterLoadTheSectionUpdateMode();

        private void _DeleteTheCategoryByID()
        {
            if (MessageBox.Show("Are You Sure To Be Delete This Category ?? ", "Note For Delete The Category", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (CategoriesBL.DeleteTheCategoryBy(_GetTheIDCategoryAfterSelectedDGV()))
                    MessageBox.Show("The Category deleted Successfully ", "note For Delete Category");
                else MessageBox.Show("The Category deleted Faild ", "note For Delete Category");
            }
            else
            {
                MessageBox.Show("The Category Connot deleted Becouse The Category Referance Events", "note For Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _IntialSettingsAfterLoadTheSection();
            _ResetAllSettingAfterClickTheUSCategory();
        }

        private void deleteCategoryToolStripMenuItem_Click(object sender, EventArgs e)
            => _DeleteTheCategoryByID();

        private void _LoadAllInformationCategoriesInTheDataGridViewAfterSearchTextBox()
        {

            DataTable CategoriesGroupByName_DT = CategoriesBL.GetAllInformationCategoryFullInformation(GTextBoxSearchTheCategory.Text.Trim().ToLower());


            foreach (DataRow DR_Category in CategoriesGroupByName_DT.Rows)
            {
                string CategoryID = "";

                CategoryID = "#CAT-" + DR_Category["CategoryID"].ToString();

                GDataGridViewCategoriesInformation.Rows.Add(

                     CategoryID,
                     DR_Category["CategoryName"] != null ? DR_Category["CategoryName"].ToString() : "",
                     DR_Category["CountEventForCategory"] != null ? DR_Category["CountEventForCategory"].ToString() : "",
                     DR_Category["Discripation"].ToString()


                              );

            }
        }

        private void GTextBoxSearchTheCategory_TextChanged(object sender, EventArgs e)
        {
            GDataGridViewCategoriesInformation.Rows.Clear();
            _LoadAllInformationCategoriesInTheDataGridViewAfterSearchTextBox();
        }


    }
}
