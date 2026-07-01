using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;


namespace EETMS_Presentation.EETMS_Events.User_Controls_Operation_Event
{
    public partial class UC_AddTheTicketsTypeToTheEvent : UserControl
    {

        public event EventHandler<int> ERequestToTheClose_USAddNewTicketTypeToTheEvent;
        public event Action<bool> OnFinishedAddUpdateInfoTickets;

        private int _IDEvent;
        private int _IDTicketType;

        private _EnModeTicketType _MTicketType;
        private TicketTypeDTO _ObjTicketTypeInformation;
        Guna2MessageDialog _G2MD;


        private enum _EnModeTicketType
        {
            _kADD_NEW_TICKETTYPE = 1,
            _kUPDATE_INFOMRATION_TICKETTYPE = 2
        }

        public UC_AddTheTicketsTypeToTheEvent(int IDEvent, int IDTicketType)
        {
            InitializeComponent();

            ERequestToTheClose_USAddNewTicketTypeToTheEvent = null;
            _IDTicketType = clsEETMS_Constants.kNEGATIVE_ONE;
            _IDEvent = clsEETMS_Constants.kZERO;

            _IDEvent = IDEvent;
            _IDTicketType = IDTicketType;

            if (IDTicketType != clsEETMS_Constants.kNEGATIVE_ONE) _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            else _MTicketType = _EnModeTicketType._kADD_NEW_TICKETTYPE;
        }

        private List<string> _GetTheAllTicketsTypeNotIncludeTheEvent()
        {
            List<string> AllTicketsTypeNotIndludeEvents = new List<string>();

            DataTable DT_TicketsType = TicketBL.GetInformationTicketForEvent(_IDEvent);

            bool ActiveReguler = false;
            bool ActiveVIP = false;
            bool ActivePremium = false;

            foreach (DataRow DR_TicketType in DT_TicketsType.Rows)
            {
                if (DR_TicketType["TicketTypeName"].ToString() == "Regular")
                    ActiveReguler = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "VIP")
                    ActiveVIP = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "Premium")
                    ActivePremium = true;


            }

            if (!ActiveReguler) AllTicketsTypeNotIndludeEvents.Add("Regular");

            if (!ActiveVIP) AllTicketsTypeNotIndludeEvents.Add("VIP");

            if (!ActivePremium) AllTicketsTypeNotIndludeEvents.Add("Premium");

            return AllTicketsTypeNotIndludeEvents;
        }

        private List<string> _GetTheAllTicketsTypeNotIncludeTheEventUpdateMode()
        {
            List<string> AllTicketsTypeNotIndludeEvents = new List<string>();

            DataTable DT_TicketsType = TicketBL.GetInformationTicketForEvent(_IDEvent);

            bool ActiveReguler = false;
            bool ActiveVIP = false;
            bool ActivePremium = false;

            foreach (DataRow DR_TicketType in DT_TicketsType.Rows)
            {
                if (DR_TicketType["TicketTypeName"].ToString() == "Regular")
                    ActiveReguler = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "VIP")
                    ActiveVIP = true;

                if (DR_TicketType["TicketTypeName"].ToString() == "Premium")
                    ActivePremium = true;


            }

            if (ActiveReguler) AllTicketsTypeNotIndludeEvents.Add("Regular");

            if (ActiveVIP) AllTicketsTypeNotIndludeEvents.Add("VIP");

            if (ActivePremium) AllTicketsTypeNotIndludeEvents.Add("Premium");


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
           => ERequestToTheClose_USAddNewTicketTypeToTheEvent?.Invoke(this, _IDEvent);

        private void USAddTheTicketsTypeToTheEvent_Load(object sender, EventArgs e)
            => _LoadAllInformationTicketTypeAfterLoadTheUS();

        private void _LoadAllInformationTicketTypeAfterLoadTheUS()
        {

            if (_MTicketType == _EnModeTicketType._kADD_NEW_TICKETTYPE)
            {
                _ObjTicketTypeInformation = new TicketTypeDTO();
                GButtonAddTicketAndSave.Text = "Add New Ticket Type";
                _MTicketType = _EnModeTicketType._kADD_NEW_TICKETTYPE;
                _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxAddMode();
                return;

            }

            _ObjTicketTypeInformation = TicketBL.FindTheTicketTypeBy(_IDEvent, _IDTicketType);


            if (_ObjTicketTypeInformation == null)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nThe Ticket Type Not Found, Try Agian", "Note Of Find The Ticket Type ", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }

            _LoadAllTicketTypeNotIncludeTheEventToTheComboBoxUpdateMode();
            GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem = _ObjTicketTypeInformation.TicketTypeName;
            GTextBoxPriceTheTicketType.Text = _ObjTicketTypeInformation.Price.ToString();

            GTextBoxAvailableQuantity.Text = _ObjTicketTypeInformation.Quantity.ToString();

            _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _ObjTicketTypeInformation.EnMode = TicketTypeDTO.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;

            GButtonAddTicketAndSave.Text = "Save Changes";

        }

        private void _AddUpdateInformatioNTicketType()
        {

            DataTable DT_EventTicketCapacityInfo = EventBL.GetEventTicketCapacityInfoBy(_IDEvent);


            int NewQuantity = Convert.ToInt32(GTextBoxAvailableQuantity.Text);
            int OriginalQuantityTicket = clsEETMS_Constants.kZERO;


            if (_MTicketType == _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE)
                OriginalQuantityTicket = TicketBL.FindTheTicketTypeBy(_IDEvent, _IDTicketType).Quantity;


            int MaxCapacity = Convert.ToInt32(DT_EventTicketCapacityInfo.Rows[clsEETMS_Constants.kZERO]["MaxCapacity"]);

            int AvailableBeforeUpdate = _ObjTicketTypeInformation.Available;
            int QuantityBeforeUpdated = _ObjTicketTypeInformation.Quantity;

            int FinialResultTicketQuantity = clsEETMS_Constants.kZERO;

            int TotalQuantityTicket = clsEETMS_Constants.kZERO;
            if (OriginalQuantityTicket >= NewQuantity)
            {
                FinialResultTicketQuantity = OriginalQuantityTicket - NewQuantity;
                TotalQuantityTicket = Convert.ToInt32(DT_EventTicketCapacityInfo.Rows[clsEETMS_Constants.kZERO]["TotalQuantityTickets"]) - FinialResultTicketQuantity;
            }
            else
            {
                FinialResultTicketQuantity = NewQuantity - OriginalQuantityTicket;
                TotalQuantityTicket = Convert.ToInt32(DT_EventTicketCapacityInfo.Rows[clsEETMS_Constants.kZERO]["TotalQuantityTickets"]) + FinialResultTicketQuantity;

            }


            _ObjTicketTypeInformation.TicketTypeName = GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem.ToString();

            if (NewQuantity > clsEETMS_Constants.kZERO)
            {
                if (MaxCapacity >= TotalQuantityTicket)
                    _ObjTicketTypeInformation.Quantity = NewQuantity;
                else
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nConnot Added This Ticket Type Because The Qunatity Ticket Type Grther Than Max Capacity", "Note The Add new Ticket Type", MessageDialogButtons.OK, MessageDialogIcon.Warning);
                    return;
                }
            }
            else
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nConnot Added This Ticket Type Because The Qunatity Ticket Type is Zero", "Note The Add new Ticket Type", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }

            int SoldTickets = QuantityBeforeUpdated - AvailableBeforeUpdate;

            if (NewQuantity < SoldTickets)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nCannot reduce quantity below sold tickets", "Warning...", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }

            _ObjTicketTypeInformation.Available = NewQuantity - SoldTickets;

            _ObjTicketTypeInformation.Price = Convert.ToDecimal(GTextBoxPriceTheTicketType.Text);
            _ObjTicketTypeInformation.EventID = _IDEvent;

            if (TicketBL.SaveModeTicketType(_ObjTicketTypeInformation))
            {
                OnFinishedAddUpdateInfoTickets?.Invoke(true);
                if (_MTicketType == _EnModeTicketType._kADD_NEW_TICKETTYPE)
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nAdd The Ticket Type Successfully", "Note For Add New Ticket Type", MessageDialogButtons.OK, MessageDialogIcon.Information);
                else if (_MTicketType == _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE)
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "\nUpdate The Ticket Type Successfully", "Note For Update Ticket Type", MessageDialogButtons.OK, MessageDialogIcon.Information);

            }


            GComboBoxAllTicketTypeNotIncludeEvent.SelectedItem = _ObjTicketTypeInformation.TicketTypeName;
            GTextBoxAvailableQuantity.Text = _ObjTicketTypeInformation.Quantity.ToString();
            GTextBoxPriceTheTicketType.Text = _ObjTicketTypeInformation.Price.ToString();

            _MTicketType = _EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _ObjTicketTypeInformation.EnMode = TicketTypeDTO.EnModeTicketType._kUPDATE_INFOMRATION_TICKETTYPE;
            _IDTicketType = _ObjTicketTypeInformation.TicketTypeID;

            GButtonAddTicketAndSave.Text = "Save Changes";

        }

        private void GButtonSaveChanges_Click(object sender, EventArgs e)
          => _AddUpdateInformatioNTicketType();

        private void GTextBoxAvailableQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void GTextBoxPriceTheTicketType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsNumber(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar));

        }
    }
}