using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_Models;

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
        private MEvent _InformationEvent = null;
        private int _IDEvent = 0; 


        public US_AddAndEditInformationEvent(int id )
        {
            InitializeComponent();

            if (id != -1)
                _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;
            else
                _Mode = _EnMode._kADD_NEW_EVENT;

            this._IDEvent = id;

        }

        private void _LoadAllInformationEvent ()
        {

            if (_Mode == _EnMode._kADD_NEW_EVENT )
            {
                _InformationEvent = new MEvent();
                _InformationEvent.EnMode = MEvent.EnModeEvent._kADD_NEW_EVENT;
                return; 
            }


            _InformationEvent = EventBL.FindTheEventBy(_IDEvent);


            if(_InformationEvent == null )
            {
                MessageBox.Show("Connot Found The Event , Try Agian Later...", "Note Of The Find Event");
                return;
            }


            _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;
            _InformationEvent.EnMode = MEvent.EnModeEvent._kUPDATE_INFORMATION_EVENT; 
            GTextBoxEventName.Text = _InformationEvent.EventName;
            GTextBoxDiscripation.Text = _InformationEvent.Discripation;
            GDateTimePickerEvent.Value = _InformationEvent.DateTimeEvent.Value; 
            GComboBoxCategories.SelectedValue = _InformationEvent.CategoryID;
            GComboBoxCountries.SelectedValue = _InformationEvent.CountryID;
            GTextBoxStreet.Text = _InformationEvent.Street;
            GTextBoxDuration.Text = _InformationEvent.DurationEvent.ToString();
            GNumericUpDownMaxCapacity.Value = _InformationEvent.MaxCapacity;

            GButtonCreateEvent.Text = "Update Event";

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

        private void _AddOrEditEventInformation ()
        {

            _InformationEvent.EventName =  GTextBoxEventName.Text  ;
            _InformationEvent.Discripation = GTextBoxDiscripation.Text ;
            _InformationEvent.DateTimeEvent =  GDateTimePickerEvent.Value ;
            _InformationEvent.CategoryID = Convert.ToInt32( GComboBoxCategories.SelectedValue);
            _InformationEvent.CountryID = Convert.ToInt32(GComboBoxCountries.SelectedValue);
            _InformationEvent.Street = GTextBoxStreet.Text;
            _InformationEvent.DurationEvent = Convert.ToInt32( GTextBoxDuration.Text);
            _InformationEvent.MaxCapacity = Convert.ToInt32(GNumericUpDownMaxCapacity.Value);
           

            if (EventBL.SaveTheMode(_InformationEvent))
            {
                if (_InformationEvent.EnMode == MEvent.EnModeEvent._kADD_NEW_EVENT) MessageBox.Show("Add The New Event Information Sccessfully", "Note The Add New Event ");
                else  MessageBox.Show("Update The Event Information Sccessfully", "Note The Update Event "); 
            }

            GButtonCreateEvent.Text = "Update Event";
            _InformationEvent.EnMode = MEvent.EnModeEvent._kUPDATE_INFORMATION_EVENT;
            _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT; 
        }
     
        private void US_AddAndEditInformationEvent_Load(object sender, EventArgs e)
        {
       

            _LoadAllInformationCountriesInComboBox();
            _LoadAllInformationCategoriesInComboBox();

            _LoadAllInformationEvent();

        }

        private void GButtonCreateEvent_Click(object sender, EventArgs e)
        {
            _AddOrEditEventInformation();
        }
  
    
    
    }
}
