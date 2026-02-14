using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using EETMS_BusinessLayer; 

namespace EETMS_Presentation.EETMS_Category
{
    public partial class USCategory : UserControl
    {

        private void _LoadAllInformationCategoriesInTheDataGridView ()
        {
            DataTable CategoriesGroupByName_DT = CategoriesBL.GetAllInformationCategoriesGroupByNameForEvent();
            DataTable Categories_DT = CategoriesBL.GetAllInformationCategories();

            string CategoryID = "#CAT-";

            for (int counter = 0; counter < Categories_DT.Rows.Count; counter += 1)
            {

                CategoryID += Categories_DT.Rows[counter]["CategoryID"].ToString();

                GDataGridViewCategoriesInformation.Rows.Add(


                    CategoryID,
                    CategoriesGroupByName_DT.Rows[counter]["CategoryName"].ToString(),
                    CategoriesGroupByName_DT.Rows[counter]["CountEventForCategory"].ToString(),
                    Categories_DT.Rows[counter]["Discripation"].ToString()





                              );

            }




        }
        public USCategory()
        {
            InitializeComponent();
        }

        private void USCategory_Load(object sender, EventArgs e)
        {
            _LoadAllInformationCategoriesInTheDataGridView();
        }
    }
}
