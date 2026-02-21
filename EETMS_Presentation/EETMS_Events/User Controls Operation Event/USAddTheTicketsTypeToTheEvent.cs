using EETMS_BusinessLayer;
using EETMS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events.User_Controls_Operation_Event
{
    public partial class USAddTheTicketsTypeToTheEvent : UserControl
    {

        public event EventHandler<int> ERequestToTheClose_USAddNewTicketTypeToTheEvent;

        int _IDEvent = 0;
        int _IDTicketType = -1;

        private enum _EnModeTicketType
        {
            _kADD_NEW_TICKETTYPE = 1,
            _kUPDATE_INFOMRATION_TICKETTYPE = 2
        }

        private _EnModeTicketType _MTicketType;
        private MTicketType _ObjTicketTypeInformation;

        public USAddTheTicketsTypeToTheEvent(int IDEvent, int IDTicketType)
        {
            InitializeComponent();

            _IDEvent = IDEvent;
            _IDTicketType = IDTicketType;

            if (IDTicketType != -1) _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            else _MTicketType = _EnModeTicketType._kADD_NEW_TICKETTYPE;
        }

        private List<string> _GetTheAllTicketsTypeNotIncludeTheEvent()
        {
            List<string> AllTicketsTypeNotIndludeEvents = new List<string>();

            DataTable DT_TicketsType = TicketBL.GetInformationTicketForEvent(_IDEvent);

            bool activeReguler = false;
            bool activeVIP = false;
            bool activePremium = false;
            foreach (DataRow DR_TicketType in DT_TicketsType.Rows)
            {
                if (DR_TicketType["TicketTypeName"].ToString() == "Regular")
                    activeReguler = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "VIP")
                    activeVIP = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "Premium")
                    activePremium = true;


            }

            if (!activeReguler) AllTicketsTypeNotIndludeEvents.Add("Regular");

            if (!activeVIP) AllTicketsTypeNotIndludeEvents.Add("VIP");

            if (!activePremium) AllTicketsTypeNotIndludeEvents.Add("Premium");

            return AllTicketsTypeNotIndludeEvents;
        }

        private List<string> _GetTheAllTicketsTypeNotIncludeTheEventUpdateMode()
        {
            List<string> AllTicketsTypeNotIndludeEvents = new List<string>();

            DataTable DT_TicketsType = TicketBL.GetInformationTicketForEvent(_IDEvent);

            bool activeReguler = false;
            bool activeVIP = false;
            bool activePremium = false;

            foreach (DataRow DR_TicketType in DT_TicketsType.Rows)
            {
                if (DR_TicketType["TicketTypeName"].ToString() == "Regular")
                    activeReguler = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "VIP")
                    activeVIP = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "Premium")
                    activePremium = true;


            }

            if (activeReguler) AllTicketsTypeNotIndludeEvents.Add("Regular");

            if (activeVIP) AllTicketsTypeNotIndludeEvents.Add("VIP");

            if (activePremium) AllTicketsTypeNotIndludeEvents.Add("Premium");


            return AllTicketsTypeNotIndludeEvents;
        }

        private void _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxAddMode()
        {

            GComboBoxAllTicketTypeNotIncludeEvent.DataSource = _GetTheAllTicketsTypeNotIncludeTheEvent();
            GComboBoxAllTicketTypeNotIncludeEvent.DisplayMember = "value";

        }

        private void _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxUpdateMode()
        {

            GComboBoxAllTicketTypeNotIncludeEvent.DataSource = _GetTheAllTicketsTypeNotIncludeTheEventUpdateMode();
            GComboBoxAllTicketTypeNotIncludeEvent.DisplayMember = "value";

        }

        private void GButtonBack_Click(object sender, EventArgs e)
        {
            ERequestToTheClose_USAddNewTicketTypeToTheEvent?.Invoke(this, _IDEvent);
        }

        private void USAddTheTicketsTypeToTheEvent_Load(object sender, EventArgs e)
        {
            MessageBox.Show(_MTicketType.ToString());

            _LoadAllInformationTicketTypeAfterLoadTheUS();

        }

        private void _LoadAllInformationTicketTypeAfterLoadTheUS()
        {

            if (_MTicketType == _EnModeTicketType._kADD_NEW_TICKETTYPE)
            {
                _ObjTicketTypeInformation = new MTicketType();
                GButtonAddTicketAndSave.Text = "Add New Ticket Type";
                _MTicketType = _EnModeTicketType._kADD_NEW_TICKETTYPE;
                _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxAddMode();
                return;

            }

            _ObjTicketTypeInformation = TicketBL.FindTheTicketTypeBy(_IDEvent, _IDTicketType);


            if (_ObjTicketTypeInformation == null)
            {
                MessageBox.Show("The Ticket Type Not Found , Try Agian", "Note Of Find The Ticket Type ");
                return;

            }

            _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxUpdateMode();
            GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem = _ObjTicketTypeInformation.TicketTypeName;
            GTextBoxPriceTheTicketType.Text = _ObjTicketTypeInformation.Price.ToString();

            GTextBoxAvailableQuantity.Text = _ObjTicketTypeInformation.Quantity.ToString();
            _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _ObjTicketTypeInformation.EnMode = MTicketType.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _ObjTicketTypeInformation.EnMode = MTicketType.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            GButtonAddTicketAndSave.Text = "Save Changes";

        }

        private void _AddUpdateInformatioNTicketType()
        {

            _ObjTicketTypeInformation.TicketTypeName = GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem.ToString();
            _ObjTicketTypeInformation.Quantity = Convert.ToInt32(GTextBoxAvailableQuantity.Text);
            _ObjTicketTypeInformation.Available = _ObjTicketTypeInformation.Quantity;
            _ObjTicketTypeInformation.Price = Convert.ToDecimal(GTextBoxAvailableQuantity.Text);
            _ObjTicketTypeInformation.EventID = _IDEvent;

            if (TicketBL.SaveModeTicketType(_ObjTicketTypeInformation))
            {
                if (_MTicketType == _EnModeTicketType._kADD_NEW_TICKETTYPE) MessageBox.Show("Add The Ticket Type Successfully ", "Note For Add New Ticket Type");
                else if (_MTicketType == _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE) MessageBox.Show("Update The Ticket Type Successfully ", "Note For Update Ticket Type");
            }


            GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem = _ObjTicketTypeInformation.TicketTypeName;
            GTextBoxAvailableQuantity.Text = _ObjTicketTypeInformation.Quantity.ToString();
            GTextBoxAvailableQuantity.Text = _ObjTicketTypeInformation.Price.ToString();
            _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _ObjTicketTypeInformation.EnMode = MTicketType.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            GButtonAddTicketAndSave.Text = "Save Changes";


            //  _ObjTicketTypeInformation.EventID = _IDEvent;
        }
        private void GButtonSaveChanges_Click(object sender, EventArgs e)
        {
            _AddUpdateInformatioNTicketType();
        }
    }
}
