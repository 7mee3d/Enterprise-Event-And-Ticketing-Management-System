using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using System;
using System.Data;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class UC_ShowAllInformationTicketTypeForEvent : UserControl
    {

        private int _EventID;
        public event EventHandler<int> ERequestTheClose_AddAndUpdateTheTicketsEvents;
        public event EventHandler<TicketEventArgs> ERequestToOpenThe_USAddNewTicketTypeToTheEvent;
        DataTable _DT_AllTicketsEvent;

        public UC_ShowAllInformationTicketTypeForEvent(int id)
        {
            InitializeComponent();

            _EventID = clsEETMS_Constants.kZERO;
            ERequestTheClose_AddAndUpdateTheTicketsEvents = null;
            ERequestToOpenThe_USAddNewTicketTypeToTheEvent = null;
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
            => (Convert.ToInt32(GDataGridViewTicketsEvents.SelectedRows[clsEETMS_Constants.kZERO].Cells["TicketTypeID2"].Value));

        private void GButtonDiscardChanges_Click(object sender, EventArgs e)
           => ERequestTheClose_AddAndUpdateTheTicketsEvents?.Invoke(this, _EventID);

        private void _InitalSettingLabelsTitleEvents()
        {

            EventDTO M_InformationEvent = EventBL.FindTheEventBy(_EventID);

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
            => _InitalSettingAfterLoadingTheManagmentTicketForEvent();

        private void lblBackEvents_Click(object sender, EventArgs e)
           => ERequestTheClose_AddAndUpdateTheTicketsEvents?.Invoke(this, _EventID);

        private void _CheckTheEventHaveTheFullTicketOrNotVisiableAddTicket()
        {
            if (_DT_AllTicketsEvent.Rows.Count >= clsEETMS_Constants.kMAX_NUMBER_TICKET_EVERY_EVENT)
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
            ERequestToOpenThe_USAddNewTicketTypeToTheEvent?.Invoke(this, new TicketEventArgs(_EventID, clsEETMS_Constants.kNEGATIVE_ONE));
        }

        private void updateTicketToolStripMenuItem_Click(object sender, EventArgs e)
           => ERequestToOpenThe_USAddNewTicketTypeToTheEvent?.Invoke(this, new TicketEventArgs(_EventID, _GetTheIDTicketTypeFromDGV()));

    }
}
