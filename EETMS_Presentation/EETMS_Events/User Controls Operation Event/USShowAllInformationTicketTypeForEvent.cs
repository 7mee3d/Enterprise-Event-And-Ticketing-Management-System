using EETMS_BusinessLayer;
using EETMS_Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class USShowAllInformationTicketTypeForEvent : UserControl
    {

        private int _EventID = 0;
        //  private int _IDTicketType = 0;

        public event EventHandler<int> ERequestTheClose_AddAndUpdateTheTicketsEvents;

        public event EventHandler<TicketEventArgs> ERequestToOpenThe_USAddNewTicketTypeToTheEvent;

        DataTable _DT_AllTicketsEvent;

        public USShowAllInformationTicketTypeForEvent(int id)
        {
            InitializeComponent();

            ERequestTheClose_AddAndUpdateTheTicketsEvents = null;
            _DT_AllTicketsEvent = null;
            _EventID = id;
        }

        private void _LoadAllInformationTicketToDataGridView()
        {

            _DT_AllTicketsEvent = TicketBL.GetInformationTicketForEvent(_EventID);

            foreach (DataRow DR_TicketsForEvent in _DT_AllTicketsEvent.Rows)
            {


                GDataGridViewTicketsEvents.Rows.Add(

                                DR_TicketsForEvent["TicketTypeID"].ToString(),
                                 DR_TicketsForEvent["TicketTypeName"].ToString(),
                                "$" + DR_TicketsForEvent["Price"].ToString(),
                                DR_TicketsForEvent["Quantity"].ToString(),
                                 DR_TicketsForEvent["Available"].ToString(),
                                 DR_TicketsForEvent["CurrentSales"].ToString()



                    );

            }

        }

        private int _GetTheIDTicketTypeFromDGV()
        {

            return (Convert.ToInt32(GDataGridViewTicketsEvents.SelectedRows[0].Cells["TicketTypeID2"].Value));
        }
        private void GButtonDiscardChanges_Click(object sender, EventArgs e)
        {
            ERequestTheClose_AddAndUpdateTheTicketsEvents?.Invoke(this, _EventID);
        }

        private void _InitalSettingLabelsTitleEvents()
        {

            MEvent M_InformationEvent = EventBL.FindTheEventBy(_EventID);

            lblTitleEventAfterAddedOrUpdate.Text = M_InformationEvent.EventName;
            lblNameTheEventAfterAdded.Text = M_InformationEvent.EventName;

        }

        private void _InitalSettingAfterLoadingTheManagmentTicketForEvent()
        {
            _LoadAllInformationTicketToDataGridView();
            GDataGridViewTicketsEvents.ClearSelection();
            _CheckTheEventHaveTheFullTicketOrNotVisiableAddTicket();
            _InitalSettingLabelsTitleEvents();
        }

        private void US_AddAndUpdateTheTicketsToTheEvents_Load(object sender, EventArgs e)
        {
            _InitalSettingAfterLoadingTheManagmentTicketForEvent();
        }

        private void lblBackEvents_Click(object sender, EventArgs e)
        {
            ERequestTheClose_AddAndUpdateTheTicketsEvents?.Invoke(this, _EventID);
        }

        private void _CheckTheEventHaveTheFullTicketOrNotVisiableAddTicket()
        {
            if (_DT_AllTicketsEvent.Rows.Count >= 3)
            {
                GGButtonAddTicketType.Visible = false;
                GGButtonWarningFullTheTicketTypeEvent.Visible = true;

            }
            else
            {
                GGButtonAddTicketType.Visible = true;
                GGButtonWarningFullTheTicketTypeEvent.Visible = false;
            }

        }

        private void GGButtonAddTicketType_Click(object sender, EventArgs e)
        {
            ERequestToOpenThe_USAddNewTicketTypeToTheEvent?.Invoke(this, new TicketEventArgs(_EventID, -1));
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERequestToOpenThe_USAddNewTicketTypeToTheEvent?.Invoke(this, new TicketEventArgs(_EventID, _GetTheIDTicketTypeFromDGV()));
        }

        private void GButtonSaveChanges_Click(object sender, EventArgs e)
        {

        }
    }
}
