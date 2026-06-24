using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class UC_AddAndEditInformationEvent : UserControl
    {

        private enum _EnMode
        {
            _kADD_NEW_EVENT = 1,
            _kEDIT_THE_INFORMATION_EVENT = 2,
            _kNOTHING_MODE = 3
        };


        private _EnMode _Mode;
        public event EventHandler RequestClose;
        public event EventHandler<int> ERequestTheOpen_AddAndUpdateTheTicketsEvents;
        private EventDTO _InformationEvent;
        private int _IDEvent;
        private Guna2MessageDialog _G2MD;


        public UC_AddAndEditInformationEvent(int id)
        {
            InitializeComponent();


            _InformationEvent = null;
            _IDEvent = clsEETMS_Constants.kZERO;
            ERequestTheOpen_AddAndUpdateTheTicketsEvents = null;
            RequestClose = null;
            _Mode = _EnMode._kNOTHING_MODE;


            if (id != clsEETMS_Constants.kNEGATIVE_ONE)
                _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;
            else
                _Mode = _EnMode._kADD_NEW_EVENT;

            this._IDEvent = id;

        }

        private string _GetTheFullDateAndTime(Guna2DateTimePicker DatePicker, Guna2DateTimePicker TimePicker)
        {
            return DatePicker.Value.ToString() + TimePicker.Value.ToString();
        }

        private bool _HnadleDateTime()
        {
            if (_Mode == _EnMode._kADD_NEW_EVENT)
                if (GDateTimePickerEndDateTimeEvent.Value < GDateTimePickerStartDateTimeEvent.Value)

                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    "Connot Add Event Becouse Start Date Grather Than End",
                    "Invalid Data",
                    MessageDialogButtons.OK,
                    MessageDialogIcon.Error);
                    return false;
                }

            return true;
        }

        private void _LoadAllInformationEvent()
        {


            if (_Mode == _EnMode._kADD_NEW_EVENT)
            {
                GDateTimePickerStartDateTimeEvent.MinDate = DateTime.Today;
                _InformationEvent = new EventDTO();
                _InformationEvent.EnMode = EventDTO.EnModeEvent._kADD_NEW_EVENT;
                return;
            }


            _InformationEvent = EventBL.FindTheEventBy(_IDEvent);


            if (_InformationEvent == null)
            {

                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Connot Found The Event , Try Agian Later...", "Note Of The Find Event", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }


            _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;
            _InformationEvent.EnMode = EventDTO.EnModeEvent._kUPDATE_INFORMATION_EVENT;
            GTextBoxEventName.Text = _InformationEvent.EventName;
            GTextBoxDiscripation.Text = _InformationEvent.Discripation;

            GDateTimePickerStartDateTimeEvent.Value = _InformationEvent.DateTimeEvent.Value;
            GDateTimePickerEndDateTimeEvent.Value = _InformationEvent.EndDateTimeEvent.Value;

            GComboBoxCategories.SelectedValue = _InformationEvent.CategoryID;
            GComboBoxCountries.SelectedValue = _InformationEvent.CountryID;
            GTextBoxStreet.Text = _InformationEvent.Street;
            GTextBoxDuration.Text = _InformationEvent.DurationEvent.ToString();
            GNumericUpDownMaxCapacity.Value = _InformationEvent.MaxCapacity;

            GButtonCreateEvent.Text = "Update Event";

            if (_InformationEvent.EventID > clsEETMS_Constants.kZERO)
                GGButtonManageTheTicketsEvents.Enabled = true;
            else
                GGButtonManageTheTicketsEvents.Enabled = false;

        }

        private void GButtonBackTheEvents_Click(object sender, EventArgs e)
            => RequestClose?.Invoke(this, EventArgs.Empty);

        private void GButtonCansel_Click(object sender, EventArgs e)
            => RequestClose?.Invoke(this, EventArgs.Empty);

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

        private string _TextTheMessageDialogToCheckTheDataEventEntered()
        {

            string Text = clsEETMS_Constants.kEMPTY_STRING;

            if (string.IsNullOrWhiteSpace(GTextBoxEventName.Text))
                Text += "\nPlease,Enter a Event Name";

            if (string.IsNullOrWhiteSpace(GTextBoxDiscripation.Text))
                Text += "\nPlease,Enter a Descripation Event";

            if (string.IsNullOrWhiteSpace(GTextBoxStreet.Text))
                Text += "\nPlease,Enter a Street Location Event";

            if (string.IsNullOrWhiteSpace(GTextBoxDuration.Text))
                Text += "\nPlease,Enter a Duration Event";

            if (GNumericUpDownMaxCapacity.Value <= clsEETMS_Constants.kZERO)
                Text += "\nPlease,Enter a Max Capacity Event Grather ZERO";


            return Text;
        }

        private bool _CheckTheAllTextBoxiesFilledOrNot()
        {
            return (
                            (!string.IsNullOrWhiteSpace(GTextBoxEventName.Text)) &&
                            (!string.IsNullOrWhiteSpace(GTextBoxDiscripation.Text)) &&
                            (!string.IsNullOrWhiteSpace(GTextBoxStreet.Text)) &&
                            (!string.IsNullOrWhiteSpace(GTextBoxDuration.Text)) &&
                            (GNumericUpDownMaxCapacity.Value > clsEETMS_Constants.kZERO)

                    );
        }

        private void _AddOrEditEventInformation()
        {
            if (!_HnadleDateTime()) return;

            if (!_CheckTheAllTextBoxiesFilledOrNot())
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    _TextTheMessageDialogToCheckTheDataEventEntered(),
                    "Invalid Data",
                    MessageDialogButtons.OK,
                    MessageDialogIcon.Error);
                return;
            }

            _InformationEvent.EventName = GTextBoxEventName.Text;
            _InformationEvent.Discripation = GTextBoxDiscripation.Text;
            _InformationEvent.DateTimeEvent = GDateTimePickerStartDateTimeEvent.Value;
            _InformationEvent.EndDateTimeEvent = GDateTimePickerEndDateTimeEvent.Value;
            _InformationEvent.CategoryID = Convert.ToInt32(GComboBoxCategories.SelectedValue);
            _InformationEvent.CountryID = Convert.ToInt32(GComboBoxCountries.SelectedValue);
            _InformationEvent.Street = GTextBoxStreet.Text;

            if (GTextBoxDuration.Text != null)
                _InformationEvent.DurationEvent = Convert.ToInt32(GTextBoxDuration.Text);
            else
                _InformationEvent.DurationEvent = clsEETMS_Constants.kZERO;

            _InformationEvent.MaxCapacity = Convert.ToInt32(GNumericUpDownMaxCapacity.Value);

            if (_Mode == _EnMode._kADD_NEW_EVENT)
                if (EventBL.FindTheEventBy(GTextBoxEventName.Text))
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                        _G2MD,
                        $"The Event [ {GTextBoxEventName.Text} ] Already Exsits Enter Another Name",
                        "Note The Add New Event",
                        MessageDialogButtons.OK,
                        MessageDialogIcon.Error);
                    return;
                }

            if (EventBL.SaveTheMode(_InformationEvent))
            {

                if (_InformationEvent.EnMode == EventDTO.EnModeEvent._kADD_NEW_EVENT)
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                        _G2MD,
                        "Add The New Event Information Sccessfully",
                        "Note The Add New Event",
                        MessageDialogButtons.OK,
                        MessageDialogIcon.Information);
                else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    "Update The Event Information Sccessfully",
                    "Note The Update Event ",
                    MessageDialogButtons.OK,
                    MessageDialogIcon.Information);

                _IDEvent = _InformationEvent.EventID;
            }


            GButtonCreateEvent.Text = "Update Event";
            _InformationEvent.EnMode = EventDTO.EnModeEvent._kUPDATE_INFORMATION_EVENT;
            _Mode = _EnMode._kEDIT_THE_INFORMATION_EVENT;

            if (_IDEvent > clsEETMS_Constants.kZERO)
                GGButtonManageTheTicketsEvents.Enabled = true;
            else
                GGButtonManageTheTicketsEvents.Enabled = false;

        }

        private void _SetDefaultDateTimeEvent()
        {
            if (_Mode == _EnMode._kADD_NEW_EVENT)
            {
                GDateTimePickerStartDateTimeEvent.MinDate = DateTime.Now;
                GDateTimePickerStartDateTimeEvent.Value = GDateTimePickerStartDateTimeEvent.MinDate;


                GDateTimePickerEndDateTimeEvent.MinDate = DateTime.Now;
                GDateTimePickerEndDateTimeEvent.Value = GDateTimePickerEndDateTimeEvent.MinDate;
            }
        }

        private void US_AddAndEditInformationEvent_Load(object sender, EventArgs e)
        {
            _SetDefaultDateTimeEvent();
            _LoadAllInformationCountriesInComboBox();
            _LoadAllInformationCategoriesInComboBox();

            _LoadAllInformationEvent();

        }

        private void GButtonCreateEvent_Click(object sender, EventArgs e)
           => _AddOrEditEventInformation();

        private void GGButtonManageTheTicketsEvents_Click(object sender, EventArgs e)
            => ERequestTheOpen_AddAndUpdateTheTicketsEvents?.Invoke(this, _IDEvent);


    }
}
