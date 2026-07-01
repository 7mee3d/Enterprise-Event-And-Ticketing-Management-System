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

        private DateTime GetFullDateTime(Guna2DateTimePicker datePicker, Guna2ComboBox[] comboBoxes)
        {
            int hour = int.Parse(comboBoxes[0].Text);
            int minute = int.Parse(comboBoxes[1].Text);

            return new DateTime(
                datePicker.Value.Year,
                datePicker.Value.Month,
                datePicker.Value.Day,
                hour,
                minute,
               0);
        }

        private bool _HandleCompletedEventContraints()
        {
            if (DateTime.Now > _InformationEvent.EndDateTimeEvent)
            {
                GGButtonWarningMessageWhenTheEventComplete.Visible = true;
                GButtonCreateEvent.Enabled = false;

                GTextBoxDiscripation.Enabled = false;
                GTextBoxDuration.Enabled = false;
                GTextBoxEventName.Enabled = false;
                GTextBoxStreet.Enabled = false;
                GDateTimePickerEndDateTimeEvent.Enabled = false;
                GDateTimePickerStartDateTimeEvent.Enabled = false;
                GNumericUpDownMaxCapacity.Enabled = false;
                GComboBoxCategories.Enabled = false;
                GComboBoxCountries.Enabled = false;
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
                lblMainTitleEvent.Text = "Create New Event";

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

            if (_InformationEvent.DateTimeEvent != null)
            {
                GDateTimePickerStartDateTimeEvent.Value = new DateTime(_InformationEvent.DateTimeEvent.Value.Year, _InformationEvent.DateTimeEvent.Value.Month, _InformationEvent.DateTimeEvent.Value.Day);

                if (_InformationEvent.DateTimeEvent.Value.Hour > 12)
                    GComboBoxStartHours.SelectedIndex = GComboBoxStartHours.FindString((_InformationEvent.DateTimeEvent.Value.Hour - 12).ToString());
                else GComboBoxStartHours.SelectedIndex = GComboBoxStartHours.FindString((_InformationEvent.DateTimeEvent.Value.Hour).ToString());

                GComboBoxStartMinutes.SelectedIndex = GComboBoxStartMinutes.FindString(_InformationEvent.DateTimeEvent.Value.Minute.ToString());
                GComboBoxStartZone.SelectedIndex = GComboBoxStartZone.FindString(_InformationEvent.StartTimeMeridiem);
            }

            if (_InformationEvent.EndDateTimeEvent != null)
            {
                GDateTimePickerEndDateTimeEvent.Value = new DateTime(_InformationEvent.EndDateTimeEvent.Value.Year, _InformationEvent.EndDateTimeEvent.Value.Month, _InformationEvent.EndDateTimeEvent.Value.Day);

                if (_InformationEvent.EndDateTimeEvent.Value.Hour > 12)
                    GComboBoxEndHour.SelectedIndex = GComboBoxEndHour.FindString((_InformationEvent.EndDateTimeEvent.Value.Hour - 12).ToString());
                else GComboBoxEndHour.SelectedIndex = GComboBoxEndHour.FindString((_InformationEvent.EndDateTimeEvent.Value.Hour).ToString());

                GComboBoxEndMinutes.SelectedIndex = GComboBoxEndMinutes.FindString(_InformationEvent.EndDateTimeEvent.Value.Minute.ToString());
                GComboBoxEndZone.SelectedIndex = GComboBoxEndZone.FindString(_InformationEvent.EndTimeMeridiem);
            }


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

            lblMainTitleEvent.Text = "Update Information Event";

            if (!_HandleCompletedEventContraints()) return;
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

        private bool _HandleTheDateTimeStartAndEndEvent()
        {
            DateTime DT1 = new DateTime(
                _InformationEvent.DateTimeEvent.Value.Year,
                _InformationEvent.DateTimeEvent.Value.Month,
                _InformationEvent.DateTimeEvent.Value.Day);

            DateTime DT2 = new DateTime(
                _InformationEvent.EndDateTimeEvent.Value.Year,
                _InformationEvent.EndDateTimeEvent.Value.Month,
                _InformationEvent.EndDateTimeEvent.Value.Day);

            if (DT1 > DT2)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    "The End Date Time Is Less Than Start Date.",
                    "Invalid Data",
                    MessageDialogButtons.OK,
                    MessageDialogIcon.Error);

                return false;

            }
            else if (DT1 == DT2)
            {
                int StartHour = _InformationEvent.DateTimeEvent.Value.Hour;
                int EndHour = _InformationEvent.EndDateTimeEvent.Value.Hour;

                if (_InformationEvent.StartTimeMeridiem == "PM" && StartHour != 12)
                    StartHour += 12;
                if (_InformationEvent.StartTimeMeridiem == "AM" && StartHour == 12)
                    StartHour = 0;

                if (_InformationEvent.EndTimeMeridiem == "PM" && EndHour != 12)
                    EndHour += 12;
                if (_InformationEvent.EndTimeMeridiem == "AM" && EndHour == 12)
                    EndHour = 0;


                TimeSpan Time1 = new TimeSpan(
                   StartHour,
                   _InformationEvent.DateTimeEvent.Value.Minute,
                   0);

                TimeSpan Time2 = new TimeSpan(
                   EndHour,
                    _InformationEvent.EndDateTimeEvent.Value.Minute,
                    0);

                if (_InformationEvent.StartTimeMeridiem == _InformationEvent.EndTimeMeridiem)
                {
                    if (Time1 >= Time2)
                    {
                        clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                            _G2MD,
                            "The End Date Time Is Less Than Start Date.",
                            "Invalid Data",
                            MessageDialogButtons.OK,
                            MessageDialogIcon.Error);

                        return false;
                    }
                }
                else if (_InformationEvent.StartTimeMeridiem == "PM" &&
                         _InformationEvent.EndTimeMeridiem == "AM")
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                        _G2MD,
                        "The End Date Time Is Less Than Start Date.",
                        "Invalid Data",
                        MessageDialogButtons.OK,
                        MessageDialogIcon.Error);

                    return false;
                }
            }

            return true;
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

            Guna2ComboBox[] ArrAllStartTime = { GComboBoxStartHours, GComboBoxStartMinutes };
            _InformationEvent.DateTimeEvent = GetFullDateTime(GDateTimePickerStartDateTimeEvent, ArrAllStartTime);

            Guna2ComboBox[] ArrAllEndTime = { GComboBoxEndHour, GComboBoxEndMinutes };
            _InformationEvent.EndDateTimeEvent = GetFullDateTime(GDateTimePickerEndDateTimeEvent, ArrAllEndTime);

            _InformationEvent.StartTimeMeridiem = GComboBoxStartZone.Text;
            _InformationEvent.EndTimeMeridiem = GComboBoxEndZone.Text;

            if (!_HandleTheDateTimeStartAndEndEvent()) return;
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
            lblMainTitleEvent.Text = "Update Information Event";
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
