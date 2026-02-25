using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class USEvents : UserControl
    {

        private DataTable _EventDT;
        public event EventHandler<int> RequestOpenCreateNewEventUS;


        public USEvents()
        {
            InitializeComponent();
            _EventDT = null;
            RequestOpenCreateNewEventUS = null;
        }


        private void _LoadAndFillDataGridViewONAllInformationEvent()
        {

            _EventDT = EventBL.GetAllInformationEvents();

            foreach (DataRow DR_Event in _EventDT.Rows)
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

                if ((int)DR_Event["SoldTickets"] == MaxCapacity) ++CountFullyBookedEvents;
            }

            return CountFullyBookedEvents;
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



    }
}
