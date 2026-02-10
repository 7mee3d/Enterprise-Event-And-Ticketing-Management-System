using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer; 

namespace EETMS_Presentation.EETMS_Events
{
    public partial class US_AddAndEditInformationEvent : UserControl
    {

       private enum _EnMode
        {
            _kADD_NEW_EVENT = 1 ,
            _kEDIT_THE_INFORMATION_EVENT = 2 
        };


        private _EnMode _Mode;
        public event EventHandler RequestClose;


        public US_AddAndEditInformationEvent(int id )
        {
            InitializeComponent();

            if (id != -1)
                _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;
            else
                _Mode = _EnMode._kADD_NEW_EVENT;

            MessageBox.Show(_Mode.ToString());
        }

        private void GButtonBackTheEvents_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void GButtonCansel_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
  
        private void _LoadAllInformationCountriesInComboBox()
        {
            DataTable CountriesDT = CountriesBL.AllInformationCountries();

            GComboBoxCountries.DisplayMember = "CountryName";
            GComboBoxCountries.ValueMember = "CountryID";

            GComboBoxCountries.DataSource = CountriesDT; 
        }
        
        private void _LoadAllInformationCategoriesInComboBox()
        {
            DataTable CategoriesDT = CategoriesBL.GetAllInformationCategories();

            GComboBoxCategories.DisplayMember = "CategoryName";
            GComboBoxCategories.ValueMember = "CategoryID";

            GComboBoxCategories.DataSource = CategoriesDT;
        }

        private void US_AddAndEditInformationEvent_Load(object sender, EventArgs e)
        {
            _LoadAllInformationCountriesInComboBox();
            _LoadAllInformationCategoriesInComboBox();
        }

   
    }
}
