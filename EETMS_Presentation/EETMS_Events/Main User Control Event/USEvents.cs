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
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class USEvents : UserControl
    {
        private bool _IsCheckButtonFilter = false;
        private DataTable _EventDT;
        public event EventHandler<int> RequestOpenCreateNewEventUS;


        public USEvents()
        {
            InitializeComponent();
            _EventDT = null;
            RequestOpenCreateNewEventUS = null;
        }

        private void _LoadTheInformationEventsToGDVBy(DataTable DT_EventsInformation)
        {
            GDataGridViewEventsInformation.Rows.Clear();

            foreach (DataRow DR_Event in DT_EventsInformation.Rows)
            {

                GDataGridViewEventsInformation.Rows.Add(

                    DR_Event["EventID"],
                    DR_Event["EventName"],
                    DR_Event["CategoryName"],
                    DR_Event["DateTimeEvent"],
                    DR_Event["SoldTickets"] + " / " + DR_Event["MaxCapacity"],
                    DR_Event["CountryName"] + " , " + DR_Event["Street"],
                    DR_Event["Duration"],
                    DR_Event["Discripation"]


                                                    );

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

        private void _LoadAllInformationCategoryNameToComboBox()
        {

            GSubComboBoxTypeTheFilter.DataSource = CategoriesBL.AllCategoryNames();
            GSubComboBoxTypeTheFilter.DisplayMember = "CategoryName";

        }

        private int _GetTheCountOfEvents()
            => _EventDT.Rows.Count;

        private void _InitalSettingAfterLoadTheUSEvents()
        {
            GDataGridViewEventsInformation.Rows.Clear();
            _LoadAndFillDataGridViewONAllInformationEvent();
            GDataGridViewEventsInformation.ClearSelection();

            clsEETMS_SettingPresentation._AnimationLables(_GetTheCountOfEvents(), lblTotalEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            clsEETMS_SettingPresentation._AnimationLables(_GetCountTheLiveEvents(), lblTotalLiveEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            clsEETMS_SettingPresentation._AnimationLables(_GetCountTheFullyBookedEvents(), lblTotalFullyBookedEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);
            clsEETMS_SettingPresentation._AnimationLables(_GetCountTheDraftEvents(), lblNumberDraftsEvents, clsEETMS_Constants.kMAX_NUMBER_DELAY_EVENT_US, false);

        }

        private void USEvents_Load(object sender, EventArgs e)
           => _InitalSettingAfterLoadTheUSEvents();

        private void GGButtonCreateNewEvent_Click(object sender, EventArgs e)
           => RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
            => RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());

        private void _LoadAllInformationTypeStatus()
        {
            List<string> AllItemsStatusEvent = new List<string>();

            AllItemsStatusEvent.Add("None");
            AllItemsStatusEvent.Add("Fully Booked");
            AllItemsStatusEvent.Add("Live");
            AllItemsStatusEvent.Add("Draft");

            GSubComboBoxTypeTheFilter.DataSource = AllItemsStatusEvent;


        }

        private void _LoadAllInformationTypeCapacityUsage()
        {
            List<string> AllItemsCapacityUsageEvent = new List<string>();

            AllItemsCapacityUsageEvent.Add("None");
            AllItemsCapacityUsageEvent.Add("Less Than 50%");
            AllItemsCapacityUsageEvent.Add("50% - 90%");
            AllItemsCapacityUsageEvent.Add("Almost Full");
            AllItemsCapacityUsageEvent.Add("Sold Out");

            GSubComboBoxTypeTheFilter.DataSource = AllItemsCapacityUsageEvent;


        }

        private void _LoadAllInformationTypeCountry()
        {

            GSubComboBoxTypeTheFilter.DataSource = CountriesBL.AllInformationCountryName();
            GSubComboBoxTypeTheFilter.DisplayMember = "CountryName";

        }

        private int _GetTheEventID()
            => (GDataGridViewEventsInformation.SelectedRows.Count > clsEETMS_Constants.kZERO) ?
            Convert.ToInt32(GDataGridViewEventsInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells["EventID"].Value) :
            clsEETMS_Constants.kNEGATIVE_ONE;

        private void deleteEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Delete This Event ?", "Note For Delete Event", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                if (EventBL.DeleteTheEvent(_GetTheEventID()))
                {
                    MessageBox.Show("The Event Is Deleted Successfully", "Note For Delete Event");
                    _InitalSettingAfterLoadTheUSEvents();
                }

        }

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

        private void _PushAllInformationMainType()
        {
            if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kZERO)
            {
                GSubComboBoxTypeTheFilter.Visible = false;
                return;
            }
            else
                GSubComboBoxTypeTheFilter.Visible = true;

            if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kONE)
                _LoadAllInformationTypeStatus();
            else if (GComboBoxMainTypeFilter.SelectedIndex == 2)
                _LoadAllInformationCategoryNameToComboBox();
            else if (GComboBoxMainTypeFilter.SelectedIndex == 3)
                _LoadAllInformationTypeCapacityUsage();
            else if (GComboBoxMainTypeFilter.SelectedIndex == 4)
            {

                _LoadAllInformationTypeCountry();


            }

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
        {
            _ActiveTheFilter();
        }

        private void GSubComboBoxTypeTheFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (GComboBoxMainTypeFilter.SelectedIndex != 4)
                _FillTheInformationFilter();
            else
            {
                GTextBoxStreetSearch.Visible = true;
                _GetAllEventAccordingTheCountryAndStreet();
            }
        }

        private void GComboBoxMainTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PushAllInformationMainType();
        }

        private void GTextBoxStreetSearch_TextChanged(object sender, EventArgs e)
        {
            _GetAllEventAccordingTheCountryAndStreet();
        }


    }
}
