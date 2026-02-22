using EETMS_BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class USEvents : UserControl
    {


        public USEvents()
        {
            InitializeComponent();
        }


        private DataTable _EventDT = null;
        public event EventHandler<int> RequestOpenCreateNewEventUS = null;


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
            int CountDraftEvents = 0;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);
                if ((int)DR_Event["SoldTickets"] == 0 && (int)DR_Event["SoldTickets"] != MaxCapacity) ++CountDraftEvents;

            }

            return CountDraftEvents;
        }

        private int _GetCountTheLiveEvents()
        {
            int CountLiveEvents = 0;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);
                if ((int)DR_Event["SoldTickets"] > 0 && (int)DR_Event["SoldTickets"] != MaxCapacity) ++CountLiveEvents;

            }

            return CountLiveEvents;
        }

        private int _GetCountTheFullyBookedEvents()
        {
            int CountFullyBookedEvents = 0;

            foreach (DataRow DR_Event in _EventDT.Rows)
            {
                int.TryParse(DR_Event["MaxCapacity"].ToString(), out int MaxCapacity);

                if ((int)DR_Event["SoldTickets"] == MaxCapacity) ++CountFullyBookedEvents;
            }

            return CountFullyBookedEvents;
        }

        private int _GetTheCountOfEvents()
        {
            return _EventDT.Rows.Count;
        }

        private void _InitalSettingAfterLoadTheUSEvents()
        {
            GDataGridViewEventsInformation.Rows.Clear();
            _LoadAndFillDataGridViewONAllInformationEvent();
            GDataGridViewEventsInformation.ClearSelection();
            lblTotalEvents.Text = _GetTheCountOfEvents().ToString();
            lblTotalLiveEvents.Text = _GetCountTheLiveEvents().ToString();
            lblTotalFullyBookedEvents.Text = _GetCountTheFullyBookedEvents().ToString();
            lblNumberDraftsEvents.Text = _GetCountTheDraftEvents().ToString();
        }

        private void USEvents_Load(object sender, EventArgs e)
        {
            _InitalSettingAfterLoadTheUSEvents();
        }

        private void GGButtonCreateNewEvent_Click(object sender, EventArgs e)
        {
            RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RequestOpenCreateNewEventUS?.Invoke(this, _GetTheEventID());
        }

        private int _GetTheEventID()
        {

            return (GDataGridViewEventsInformation.SelectedRows.Count > 0) ? Convert.ToInt32(GDataGridViewEventsInformation.SelectedRows[0].Cells["EventID"].Value) : -1;

        }

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
