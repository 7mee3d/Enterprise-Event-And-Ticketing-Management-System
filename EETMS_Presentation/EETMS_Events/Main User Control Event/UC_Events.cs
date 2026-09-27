using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class UC_Events : UserControl
    {
        private bool _IsCheckButtonFilter = false;
        private DataTable _EventDT;
        public event EventHandler<int> RequestOpenCreateNewEventUS;
        private Guna2MessageDialog _G2MD;


        private enum _EnChoiseMainFilter
        {

            kNONE = 0,
            kEVENT_PROGRESS = 1,
            kCATEGORY_TYPE_EVENT = 2,
            kCAPACITY_UNSAGE_EVENT = 3,
            kLOCATION_EVENT = 4,
            kCUSTOM_FILTER_EVENT = 5
        }

        public UC_Events()
        {
            InitializeComponent();
            _EventDT = null;
            RequestOpenCreateNewEventUS = null;
            _G2MD = null;

        }

        private string _GetTheEventStatusBy(DateTime StartDateTimeEvent, DateTime EndDateTimeEvent)
        {
            if (StartDateTimeEvent == DateTime.MinValue ||
                EndDateTimeEvent == DateTime.MinValue)
                return "Unknown";

            DateTime CurrentDateTime = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                0
            );

            if (CurrentDateTime >= EndDateTimeEvent)
                return "Completed";

            if (CurrentDateTime < StartDateTimeEvent)
                return "Pending";

            return "In Progress";
        }

        private void _LoadTheInformationEventsToGDVBy(DataTable DT_EventsInformation)
        {
            GDataGridViewEventsInformation.Rows.Clear();

            foreach (DataRow DR_Event in DT_EventsInformation.Rows)
            {
                DateTime start = Convert.ToDateTime(DR_Event["DateTimeEvent"]);

                string startDate =
                    $"{start:dd/MM/yyyy HH:mm} {DR_Event["StartTimeMeridiem"]}";

                DateTime StartDateTimeEvent = start;

                if (DR_Event["StartTimeMeridiem"].ToString() == "PM" &&
                    StartDateTimeEvent.Hour < 12)
                {
                    StartDateTimeEvent = StartDateTimeEvent.AddHours(12);
                }
                else if (DR_Event["StartTimeMeridiem"].ToString() == "AM" &&
                         StartDateTimeEvent.Hour == 12)
                {
                    StartDateTimeEvent = StartDateTimeEvent.AddHours(-12);
                }

                string endDate = "Unknown";
                DateTime EndDateTimeEvent = DateTime.MinValue;

                if (!string.IsNullOrWhiteSpace(DR_Event["EndDateTimeEvent"].ToString()))
                {
                    DateTime end =
                        Convert.ToDateTime(DR_Event["EndDateTimeEvent"]);

                    EndDateTimeEvent = end;

                    if (DR_Event["EndTimeMeridiem"].ToString() == "PM" &&
                        EndDateTimeEvent.Hour < 12)
                    {
                        EndDateTimeEvent = EndDateTimeEvent.AddHours(12);
                    }
                    else if (DR_Event["EndTimeMeridiem"].ToString() == "AM" &&
                             EndDateTimeEvent.Hour == 12)
                    {
                        EndDateTimeEvent = EndDateTimeEvent.AddHours(-12);
                    }

                    endDate =
                        $"{end:dd/MM/yyyy HH:mm} {DR_Event["EndTimeMeridiem"]}";
                }

                int CurrentRow = GDataGridViewEventsInformation.Rows.Add(
                    DR_Event["EventID"],
                    DR_Event["EventName"],
                    DR_Event["CategoryName"],
                    startDate,
                    endDate,
                    DR_Event["SoldTickets"] + " / " + DR_Event["MaxCapacity"],
                    DR_Event["CountryName"] + " , " + DR_Event["Street"],
                    DR_Event["Duration"],
                    DR_Event["Discripation"],
                    _GetTheEventStatusBy(
                        StartDateTimeEvent,
                        EndDateTimeEvent
                    )
                );

                DataGridViewRow DGVR =
                    GDataGridViewEventsInformation.Rows[CurrentRow];

                DataGridViewCell DGVC = DGVR.Cells[9];

                if (DGVC.Value.ToString() == "In Progress")
                    DGVC.Style.ForeColor = Color.FromArgb(59, 130, 246);
                else if (DGVC.Value.ToString() == "Pending")
                    DGVC.Style.ForeColor = Color.FromArgb(245, 158, 11);
                else if (DGVC.Value.ToString() == "Completed")
                    DGVC.Style.ForeColor = Color.FromArgb(34, 197, 94);
                else
                    DGVC.Style.ForeColor = Color.Red;
            }
        }

        private void _LoadAndFillDataGridViewONAllInformationEvent()
        {

            _EventDT = EventBL.GetAllInformationEvents();

            _LoadTheInformationEventsToGDVBy(_EventDT);

        }

        private int _GetCountTheDraftEvents()
        {
            int CountDraftEvents = clsEETMS_Constants.kZERO;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);
                if ((int)DR_Event["SoldTickets"] == clsEETMS_Constants.kZERO && (int)DR_Event["SoldTickets"] != MaxCapacity) ++CountDraftEvents;

            }

            return CountDraftEvents;
        }

        private int _GetCountTheLiveEvents()
        {
            int CountLiveEvents = clsEETMS_Constants.kZERO;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);
                if ((int)DR_Event["SoldTickets"] > clsEETMS_Constants.kZERO && (int)DR_Event["SoldTickets"] != MaxCapacity) ++CountLiveEvents;

            }

            return CountLiveEvents;
        }

        private int _GetCountTheFullyBookedEvents()
        {
            int CountFullyBookedEvents = clsEETMS_Constants.kZERO;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);

                if ((int)DR_Event["SoldTickets"] == MaxCapacity || !((bool)DR_Event["IsActiveEvent"])) ++CountFullyBookedEvents;
            }

            return CountFullyBookedEvents;
        }

        private void _LoadAllInformationCategoryNameToComboBox(Guna2ComboBox G2CB)
        {

            G2CB.DataSource = CategoriesBL.AllCategoryNames();
            G2CB.DisplayMember = "CategoryName";

        }

        private int _GetTheCountOfEvents()
            => _EventDT.Rows.Count;

        private async Task _InitalSettingAfterLoadTheUSEvents()
        {
            GDataGridViewEventsInformation.Rows.Clear();
            _LoadAndFillDataGridViewONAllInformationEvent();
            GDataGridViewEventsInformation.ClearSelection();

            Task animationTotalEvents =
                clsEETMS_SettingPresentation._AnimationLables(_GetTheCountOfEvents(), lblTotalEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            Task animationTotalLiveEvents =
                clsEETMS_SettingPresentation._AnimationLables(_GetCountTheLiveEvents(), lblTotalLiveEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            Task animationTotalFullyEvents =
                clsEETMS_SettingPresentation._AnimationLables(_GetCountTheFullyBookedEvents(), lblTotalFullyBookedEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            Task animationTotalDraftEvents =
                clsEETMS_SettingPresentation._AnimationLables(_GetCountTheDraftEvents(), lblNumberDraftsEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);

            await Task.WhenAll(animationTotalEvents, animationTotalLiveEvents, animationTotalFullyEvents, animationTotalDraftEvents);

        }

        private async void USEvents_Load(object sender, EventArgs e)
           => await _InitalSettingAfterLoadTheUSEvents();

        private void GGButtonCreateNewEvent_Click(object sender, EventArgs e)
           => RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
            => RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());

        private void _LoadAllInformationTypeStatus(Guna2ComboBox G2CB)
        {
            List<string> AllItemsStatusEvent = new List<string>();

            AllItemsStatusEvent.Add("None");
            AllItemsStatusEvent.Add("Fully Booked");
            AllItemsStatusEvent.Add("Live");
            AllItemsStatusEvent.Add("Draft");

            G2CB.DataSource = AllItemsStatusEvent;


        }

        private void _LoadAllInformationTypeCapacityUsage(Guna2ComboBox G2CB)
        {
            List<string> AllItemsCapacityUsageEvent = new List<string>();

            AllItemsCapacityUsageEvent.Add("None");
            AllItemsCapacityUsageEvent.Add("Less Than 50%");
            AllItemsCapacityUsageEvent.Add("50% - 90%");
            AllItemsCapacityUsageEvent.Add("Almost Full");
            AllItemsCapacityUsageEvent.Add("Sold Out");

            G2CB.DataSource = AllItemsCapacityUsageEvent;


        }

        private void _LoadAllInformationTypeCountry(Guna2ComboBox G2CB)
        {

            G2CB.DataSource = CountriesBL.AllInformationCountryName();
            G2CB.DisplayMember = "CountryName";

        }

        private int _GetTheEventID()
            => (GDataGridViewEventsInformation.SelectedRows.Count > clsEETMS_Constants.kZERO) ?
            Convert.ToInt32(GDataGridViewEventsInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells["EventID"].Value) :
            clsEETMS_Constants.kNEGATIVE_ONE;

        private void _LoadAllInformationEventsToDGVAfterTheSearchEvent()
        {
            string EventNameToBeSearch = GTextBoxSearchTheEvent.Text;
            _EventDT = EventBL.AllEventsAfterSearchBy(EventNameToBeSearch);
            _LoadTheInformationEventsToGDVBy(_EventDT);
        }

        private void GTextBoxSearchTheEvent_TextChanged(object sender, EventArgs e)
           => _LoadAllInformationEventsToDGVAfterTheSearchEvent();

        private void _InitalSettingTheComboBoxies()
        {

            GDataGridViewEventsInformation.Rows.Clear();
            GSubComboBoxTypeTheFilter.Visible = false;
            GTextBoxStreetSearch.Visible = false;
            GGPanelCustomFilter.Visible = false;

            GTextBoxStreetSearch.Text = "";

            GComboBoxMainTypeFilter.SelectedIndex = clsEETMS_Constants.kZERO;
            GSubComboBoxTypeTheFilter.SelectedIndex = clsEETMS_Constants.kZERO;

            if (GComboBoxMainTypeFilter.Items.Count <= clsEETMS_Constants.kZERO)
                GComboBoxMainTypeFilter.Items.Clear();


            if (GSubComboBoxTypeTheFilter.Items.Count <= clsEETMS_Constants.kZERO)
                GSubComboBoxTypeTheFilter.Items.Clear();

            _LoadAndFillDataGridViewONAllInformationEvent();
        }

        private void _ActiveTheFilter()
        {

            if (_IsCheckButtonFilter)
            {
                GGButtonFilter.HoverState.Image = Resources.Filter_Icon_EETMS;
                GGButtonFilter.Image = Resources.Filter_Icon_EETMS;
                GGMainPanelFilter.Visible = false;
                _IsCheckButtonFilter = false;
                GGButtonFilter.Text = "Filter";

                _InitalSettingTheComboBoxies();
            }
            else
            {
                GGButtonFilter.HoverState.Image = Resources.Cancel_Icon_EETMS;
                GGButtonFilter.Image = Resources.Cancel_Icon_EETMS;
                GGMainPanelFilter.Visible = true;
                _IsCheckButtonFilter = true;
                GGButtonFilter.Text = "Cancel";

            }


        }

        private void _LoadAllInformationFiltersToComboBoxiesCustomOption()
        {

            _LoadAllInformationTypeStatus(GCombvoBoxStatusCustomFilter);
            _LoadAllInformationCategoryNameToComboBox(GCombvoBoxCategoryCustomFilter);
            _LoadAllInformationTypeCapacityUsage(GComboBoxUnsageCapacityCustomerFilter);
            _LoadAllInformationTypeCountry(GComboBoxCountryCustomerFilter);
        }

        private void _PushAllInformationMainType()
        {
            if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kZERO)
            {
                GSubComboBoxTypeTheFilter.Visible = false;
                GGPanelCustomFilter.Visible = false;
                GTextBoxStreetSearch.Visible = false;
                return;
            }

            GSubComboBoxTypeTheFilter.Visible = true;

            if (GComboBoxMainTypeFilter.SelectedIndex == Convert.ToInt16(_EnChoiseMainFilter.kEVENT_PROGRESS))
                _LoadAllInformationTypeStatus(GSubComboBoxTypeTheFilter);
            else if (GComboBoxMainTypeFilter.SelectedIndex == Convert.ToInt16(_EnChoiseMainFilter.kCATEGORY_TYPE_EVENT))
                _LoadAllInformationCategoryNameToComboBox(GSubComboBoxTypeTheFilter);
            else if (GComboBoxMainTypeFilter.SelectedIndex == Convert.ToInt16(_EnChoiseMainFilter.kCAPACITY_UNSAGE_EVENT))
                _LoadAllInformationTypeCapacityUsage(GSubComboBoxTypeTheFilter);
            else if (GComboBoxMainTypeFilter.SelectedIndex == Convert.ToInt16(_EnChoiseMainFilter.kLOCATION_EVENT))
                _LoadAllInformationTypeCountry(GSubComboBoxTypeTheFilter);
            else if (GComboBoxMainTypeFilter.SelectedIndex == Convert.ToInt16(_EnChoiseMainFilter.kCUSTOM_FILTER_EVENT))
            {
                GSubComboBoxTypeTheFilter.Visible = false;
                GGPanelCustomFilter.Visible = true;
                GGPanelCustomFilter.BringToFront();
                _LoadAllInformationFiltersToComboBoxiesCustomOption();
                return;
            }

            GGPanelCustomFilter.Visible = false;
            GTextBoxStreetSearch.Visible = false;
        }

        private void _FillTheInformationFilter()
        {
            DataTable DT_ResultFilter = null;
            string SubSelectComboBoxTypeFilter = clsEETMS_Constants.kEMPTY_STRING;

            try
            {

                string MainSelectComboBoxTypeFilter = GComboBoxMainTypeFilter.SelectedItem.ToString();
                SubSelectComboBoxTypeFilter = GSubComboBoxTypeTheFilter.SelectedItem.ToString();



                EventFilterDTO eventFilterDTO = new EventFilterDTO()
                {
                    TypeMainFilterEvent = MainSelectComboBoxTypeFilter,
                    TypeSubFilterEvent = SubSelectComboBoxTypeFilter
                };


                DT_ResultFilter = EventBL.GetAllInformationEventAccordingBy(eventFilterDTO);

            }
            catch (Exception ex) { }
            ;


            if (DT_ResultFilter != null)
                _LoadTheInformationEventsToGDVBy(DT_ResultFilter);
        }

        private void _FillTheInformationEventToDGVAfterTheFilterCustom()
        {
            DataTable DT_ResultFilter = null;

            try
            {

                string MainSelectComboBoxTypeFilter = GComboBoxMainTypeFilter.SelectedItem.ToString();
                int SelectedStatus = GCombvoBoxStatusCustomFilter.SelectedIndex;
                string SelectedCategory = GCombvoBoxCategoryCustomFilter.SelectedItem.ToString();
                string SelectedUnsageCapactity = GComboBoxUnsageCapacityCustomerFilter.SelectedItem.ToString();
                string SelectedCountry = GComboBoxCountryCustomerFilter.SelectedItem.ToString();
                string NameStreet = GTextBoxStreetCustomFilter.Text;



                EventFilterDTO eventFilterDTO = new EventFilterDTO()
                {
                    TypeMainFilterEvent = MainSelectComboBoxTypeFilter,
                    StatusEvent = SelectedStatus,
                    CategoryEvent = SelectedCategory,
                    UnsageCapacityEvent = SelectedUnsageCapactity,
                    CountryName = SelectedCountry,
                    Street = NameStreet
                };


                DT_ResultFilter = EventBL.GetAllInformationEventAccordingBy(eventFilterDTO);

            }
            catch (Exception ex) { }
         ;


            if (DT_ResultFilter != null)
                _LoadTheInformationEventsToGDVBy(DT_ResultFilter);
        }

        private void _GetAllEventAccordingTheCountryAndStreet()
        {

            DataTable DT_ResultFilter = null;
            string CountryName = clsEETMS_Constants.kEMPTY_STRING;

            try
            {

                string MainSelectComboBoxTypeFilter = GComboBoxMainTypeFilter.SelectedItem.ToString();
                CountryName = GSubComboBoxTypeTheFilter.SelectedItem.ToString();
                string StreetName = GTextBoxStreetSearch.Text;

                EventFilterDTO eventFilterDTO = new EventFilterDTO()
                {
                    TypeMainFilterEvent = MainSelectComboBoxTypeFilter,
                    CountryName = CountryName,
                    Street = StreetName
                };


                DT_ResultFilter = EventBL.GetAllInformationEventAccordingBy(eventFilterDTO);

            }
            catch (Exception ex) { }
            ;


            if (DT_ResultFilter != null)
                _LoadTheInformationEventsToGDVBy(DT_ResultFilter);
        }

        private void GGButtonFilter_Click(object sender, EventArgs e)
            => _ActiveTheFilter();

        private void GSubComboBoxTypeTheFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (GComboBoxMainTypeFilter.SelectedIndex != Convert.ToInt16(_EnChoiseMainFilter.kLOCATION_EVENT))
                _FillTheInformationFilter();
            else
            {
                GTextBoxStreetSearch.Visible = true;
                _GetAllEventAccordingTheCountryAndStreet();
            }
        }

        private void GComboBoxMainTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
            => _PushAllInformationMainType();

        private void GTextBoxStreetSearch_TextChanged(object sender, EventArgs e)
            => _GetAllEventAccordingTheCountryAndStreet();

        private void GCombvoBoxCategoryCustomFilter_SelectionChangeCommitted(object sender, EventArgs e)
            => _FillTheInformationEventToDGVAfterTheFilterCustom();

        private void GComboBoxCountryCustomerFilter_SelectionChangeCommitted(object sender, EventArgs e)
            => _FillTheInformationEventToDGVAfterTheFilterCustom();

        private void GTextBoxStreetCustomFilter_TextChanged(object sender, EventArgs e)
            => _FillTheInformationEventToDGVAfterTheFilterCustom();

        private void editEventToolStripMenuItem_Click(object sender, EventArgs e)
          => RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());

        private async void deleteEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                _G2MD,
                "Are You Sure To Delete This Event ?",
                "Note For Delete Event",
                MessageDialogButtons.YesNo,
                MessageDialogIcon.Information))

                if (EventBL.DeleteTheEvent(_GetTheEventID()))
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                        _G2MD,
                        "The Event Is Deleted Successfully",
                        "Note For Delete Event",
                        MessageDialogButtons.OK,
                        MessageDialogIcon.Information);

                    await _InitalSettingAfterLoadTheUSEvents();
                }
                else
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                        _G2MD,
                        "Connot Delete This Event Because The Event Selled Tickets"
                        , "Note For Delete Event",
                        MessageDialogButtons.OK,
                        MessageDialogIcon.Error);
                    return;
                }
        }

        private void GContextMenuStripEvents_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_GetTheEventID() == clsEETMS_Constants.kNEGATIVE_ONE)
            {
                deleteEventToolStripMenuItem1.Enabled = false;
                editEventToolStripMenuItem.Enabled = false;

            }
            else
            {
                deleteEventToolStripMenuItem1.Enabled = true;
                editEventToolStripMenuItem.Enabled = true;
            }
        }
    }
}
