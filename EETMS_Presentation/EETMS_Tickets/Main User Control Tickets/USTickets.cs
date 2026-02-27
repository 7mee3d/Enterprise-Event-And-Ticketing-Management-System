using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Models;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;


namespace EETMS_Presentation.EETMS_Tickets
{

    public partial class USTickets : UserControl
    {


        private int _NumberOfTicketRegular;
        private int _NumberOfTicketVIP;
        private int _NumberOfTicketPreimum;

        private int _PriceTheRegularTicket;
        private int _PriceTheVIPTicket;
        private int _PriceThePreimumTicket;

        private int _NumberAvailableTicketRegular;
        private int _NumberAvailableTicketVIP;
        private int _NumberAvailableTicketPremium;

        private double _SubTotalAmount;
        private double _Tax;
        private double _TotalAmount;


        private int _CustomerID;
        private MReservations _MReservations;
        private int _EventID;

        public USTickets()
        {
            InitializeComponent();
            _NumberOfTicketRegular = clsEETMS_Constants.kZERO;
            _NumberOfTicketVIP = clsEETMS_Constants.kZERO;
            _NumberOfTicketPreimum = clsEETMS_Constants.kZERO;

            _PriceTheRegularTicket = clsEETMS_Constants.kZERO;
            _PriceTheVIPTicket = clsEETMS_Constants.kZERO;
            _PriceThePreimumTicket = clsEETMS_Constants.kZERO;

            _SubTotalAmount = clsEETMS_Constants.kZERO;
            _Tax = clsEETMS_Constants.kZERO;
            _TotalAmount = clsEETMS_Constants.kZERO;

            _NumberAvailableTicketRegular = clsEETMS_Constants.kZERO;
            _NumberAvailableTicketVIP = clsEETMS_Constants.kZERO;
            _NumberAvailableTicketPremium = clsEETMS_Constants.kZERO;


            _CustomerID = clsEETMS_Constants.kNEGATIVE_ONE;

            _MReservations = null;

            _EventID = clsEETMS_Constants.kZERO;
        }

        private void _CheckTheStackTickes(int CountOfTicketsAvailable = clsEETMS_Constants.kZERO, bool IsSelected = false, Guna2GradientButton G2DB = null, Label lblLeftTikets = null)
        {

            if (IsSelected)
            {

                G2DB.Text = "Selected";
                G2DB.DisabledState.ForeColor = Color.White;

                G2DB.DisabledState.FillColor = Color.FromArgb(43, 140, 238);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(43, 140, 238);

                return;
            }

            if (CountOfTicketsAvailable == clsEETMS_Constants.kZERO)
            {
                G2DB.Text = "";
                G2DB.DisabledState.FillColor = Color.FromArgb(43, 140, 238);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(43, 140, 238);
                lblLeftTikets.ForeColor = Color.Black;

                return;
            }

            if (CountOfTicketsAvailable > 10)
            {
                G2DB.Text = "Available";
                G2DB.DisabledState.ForeColor = Color.FromArgb(21, 128, 61);

                G2DB.DisabledState.FillColor = Color.FromArgb(220, 252, 231);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(220, 252, 231);
                lblLeftTikets.ForeColor = Color.Black;
            }
            else
            {

                G2DB.Text = "Low Stack";
                G2DB.DisabledState.ForeColor = Color.FromArgb(180, 83, 9);

                G2DB.DisabledState.FillColor = Color.FromArgb(254, 243, 199);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(254, 243, 199);

                lblLeftTikets.ForeColor = Color.FromArgb(180, 83, 9);

            }

        }

        private void _LoadInformationEventToComboBox()
        {
            DataTable Events_DT = TicketBL.GetInformationEvent_Name_And_ID();

            GComboBoxSelectEvents.ValueMember = "EventID";
            GComboBoxSelectEvents.DisplayMember = "EventName";
            GComboBoxSelectEvents.DataSource = Events_DT;

        }

        private void _ResetAllSettingCardsTickets()
        {

            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket, GGButtonRegularTicketStatus);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket, GGButtonVIPTicketStatus);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket, GGButtonPremiumTicketStatus);

            GNumericUpDownPremium.Enabled = false;
            GNumericUpDownRegularTicket.Enabled = false;
            GNumericUpDownVIPTicket.Enabled = false;

            GNumericUpDownPremium.Value = clsEETMS_Constants.kZERO;
            GNumericUpDownRegularTicket.Value = clsEETMS_Constants.kZERO;
            GNumericUpDownVIPTicket.Value = clsEETMS_Constants.kZERO;

            GGPanelRegularTicket.Enabled = false;
            GGPanelVIPTicket.Enabled = false;
            GGPanelPermiumTicket.Enabled = false;

            lblQLeftRegular.Text = "0 LEFT";
            lblQLeftVIP.Text = "0 LEFT";
            lblQLeftPermium.Text = "0 LEFT";

            lblQLeftRegular.ForeColor = Color.Black;
            lblQLeftVIP.ForeColor = Color.Black;
            lblQLeftPermium.ForeColor = Color.Black;

            lblTotalPriceOneTicketPermium.Text = "$0";
            lblTotalPriceOneTicketVIP.Text = "$0";
            lblTotalPriceOneTicketRegular.Text = "$0";

            PanelRegularTicket.Visible = false;
            PanelVIPTicket.Visible = false;
            PanelPremiumTicket.Visible = false;

        }

        private void _LoadAllInformationTicketTypeForEventAfterSelectComboBox()
        {

            if (GComboBoxSelectEvents.Items.Count > clsEETMS_Constants.kZERO)
                _EventID = (int)GComboBoxSelectEvents.SelectedValue;


            DataTable TicketType_DT = TicketBL.GetInformationTicketForEvent(_EventID);

            if (TicketType_DT != null)
                foreach (DataRow DR_Tickets in TicketType_DT.Rows)
                {
                    string ticketType = DR_Tickets["TicketTypeName"].ToString();

                    switch (ticketType)
                    {
                        case "Regular":

                            lblQLeftRegular.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketRegular.Text = "$" + DR_Tickets["Price"].ToString();

                            if (Convert.ToInt32(DR_Tickets["Available"]) > clsEETMS_Constants.kZERO)
                                GGPanelRegularTicket.Enabled = true;


                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonRegularTicketStatus, lblQLeftRegular);
                            GNumericUpDownRegularTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheRegularTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            _NumberAvailableTicketRegular = Convert.ToInt32(DR_Tickets["Available"]);

                            break;


                        case "VIP":
                            lblQLeftVIP.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketVIP.Text = "$" + DR_Tickets["Price"].ToString();

                            if (Convert.ToInt32(DR_Tickets["Available"]) > clsEETMS_Constants.kZERO)
                                GGPanelVIPTicket.Enabled = true;

                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonVIPTicketStatus, lblQLeftVIP);
                            GNumericUpDownVIPTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheVIPTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            _NumberAvailableTicketVIP = Convert.ToInt32(DR_Tickets["Available"]);
                            break;


                        case "Premium":
                            lblQLeftPermium.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketPermium.Text = "$" + DR_Tickets["Price"].ToString();

                            if (Convert.ToInt32(DR_Tickets["Available"]) > clsEETMS_Constants.kZERO)
                                GGPanelPermiumTicket.Enabled = true;

                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonPremiumTicketStatus, lblQLeftPermium);
                            GNumericUpDownPremium.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceThePreimumTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            _NumberAvailableTicketPremium = Convert.ToInt32(DR_Tickets["Available"]);

                            break;

                    }
                }




        }

        private void USTickets_Load(object sender, EventArgs e)
        {
            _LoadInformationEventToComboBox();
            lblTaxLabelTitle.Text = "Tax(" + _Tax.ToString() + "%)";
        }

        private void _ChangeTheColorBackAndFrontMouseClickTheCardTicket(Guna2GradientPanel G2GP, Guna2NumericUpDown G2NUD = null)
        {
            G2GP.FillColor = Color.FromArgb(244, 249, 254);
            G2GP.FillColor2 = Color.FromArgb(244, 249, 254);
            G2GP.BorderColor = Color.FromArgb(43, 140, 238);
            if (G2NUD != null)
                G2NUD.Enabled = true;
        }

        private void _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(Guna2GradientPanel G2GP, Guna2GradientButton G2GB = null)
        {


            G2GP.FillColor = Color.White;
            G2GP.FillColor2 = Color.White;
            G2GP.BorderColor = Color.FromArgb(241, 245, 249);

            if (G2GB != null)
            {
                G2GB.DisabledState.FillColor = Color.FromArgb(43, 140, 238);
                G2GB.DisabledState.FillColor2 = Color.FromArgb(43, 140, 238);
                G2GB.DisabledState.ForeColor = Color.White;
                G2GB.Text = "";


            }

        }

        private void GGPanelRegularTicket_MouseClick(object sender, MouseEventArgs e)
            => TicketPanel("Regular");

        private void GGPanelVIPTicket_MouseClick(object sender, MouseEventArgs e)
            => TicketPanel("VIP");

        private void GGPanelPermiumTicket_MouseClick(object sender, MouseEventArgs e)
            => TicketPanel("Premium");

        private void _UpdateThePanelsAndThePricesAndCountTickets()
        {

            if (_NumberOfTicketRegular > clsEETMS_Constants.kZERO && _NumberOfTicketVIP == clsEETMS_Constants.kZERO && _NumberOfTicketPreimum == clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = true;
                PanelPremiumTicket.Visible = false;
                PanelVIPTicket.Visible = false;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;

                PanelRegularTicket.Location = new Point(4, 91);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 158);
            }
            else if (_NumberOfTicketRegular == clsEETMS_Constants.kZERO && _NumberOfTicketVIP > clsEETMS_Constants.kZERO && _NumberOfTicketPreimum == clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = false;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = false;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;

                PanelVIPTicket.Location = new Point(4, 91);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 158);
            }
            else if (_NumberOfTicketRegular == clsEETMS_Constants.kZERO && _NumberOfTicketVIP == clsEETMS_Constants.kZERO && _NumberOfTicketPreimum > clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = false;
                PanelVIPTicket.Visible = false;
                PanelPremiumTicket.Visible = true;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                PanelPremiumTicket.Location = new Point(4, 91);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 158);
            }
            else if (_NumberOfTicketRegular > clsEETMS_Constants.kZERO && _NumberOfTicketVIP > clsEETMS_Constants.kZERO && _NumberOfTicketPreimum == clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = true;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = false;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                PanelRegularTicket.Location = new Point(4, 91);
                PanelVIPTicket.Location = new Point(4, 158);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 225);
            }
            else if (_NumberOfTicketRegular > clsEETMS_Constants.kZERO && _NumberOfTicketVIP == clsEETMS_Constants.kZERO && _NumberOfTicketPreimum > clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = true;
                PanelVIPTicket.Visible = false;
                PanelPremiumTicket.Visible = true;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                PanelRegularTicket.Location = new Point(4, 91);
                PanelPremiumTicket.Location = new Point(4, 158);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 225);
            }
            else if (_NumberOfTicketRegular == clsEETMS_Constants.kZERO && _NumberOfTicketVIP > clsEETMS_Constants.kZERO && _NumberOfTicketPreimum > clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = false;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = true;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;

                PanelVIPTicket.Location = new Point(4, 91);
                PanelPremiumTicket.Location = new Point(4, 158);

                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 225);
            }
            else if (_NumberOfTicketRegular > clsEETMS_Constants.kZERO && _NumberOfTicketVIP > clsEETMS_Constants.kZERO && _NumberOfTicketPreimum > clsEETMS_Constants.kZERO)
            {
                PanelRegularTicket.Visible = true;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = true;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;
                GGButtonConfirmBooking.Visible = true;
                lblNoteBooking.Visible = true;


                PanelRegularTicket.Location = new Point(4, 91);
                PanelVIPTicket.Location = new Point(4, 158);
                PanelPremiumTicket.Location = new Point(4, 225);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(2, 293);
            }
            else
            {
                PanelRegularTicket.Visible = false;
                PanelVIPTicket.Visible = false;
                PanelPremiumTicket.Visible = false;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = false;
                GGButtonConfirmBooking.Visible = false;
                lblNoteBooking.Visible = false;
            }

        }

        private void _CalcTheTotalAmountAndSubAmount()
        {

            _SubTotalAmount = clsEETMS_Constants.kZERO;
            _TotalAmount = clsEETMS_Constants.kZERO;


            _SubTotalAmount += _Tax + _NumberOfTicketRegular * _PriceTheRegularTicket;
            _TotalAmount = _SubTotalAmount;

            _SubTotalAmount += _Tax + _NumberOfTicketVIP * _PriceTheVIPTicket;
            _TotalAmount = _SubTotalAmount;

            _SubTotalAmount += _Tax + _NumberOfTicketPreimum * _PriceThePreimumTicket;
            _TotalAmount = _SubTotalAmount;
        }

        private void _LoadTheAmountSubTotalToLabel_ConvertNumberToString()
        {
            lblTotalAmount.Text = "$" + _TotalAmount.ToString();
            lblSubTotal.Text = "$" + _SubTotalAmount.ToString();
            lblTax.Text = "$" + _Tax.ToString();
        }

        private void GNumericUpDownRegularTicket_ValueChanged(object sender, EventArgs e)
        {

            _NumberOfTicketRegular = Convert.ToInt32(GNumericUpDownRegularTicket.Value);


            _UpdateThePanelsAndThePricesAndCountTickets();

            lblTotalTicketRegularBookingSummary.Text = (_NumberOfTicketRegular.ToString() + " x " + _PriceTheRegularTicket.ToString());
            lblTotalPriceAfterBookingSummaryRegularTickets.Text = "$" + (_NumberOfTicketRegular * _PriceTheRegularTicket).ToString();

            _CalcTheTotalAmountAndSubAmount();
            _LoadTheAmountSubTotalToLabel_ConvertNumberToString();
        }

        private void GNumericUpDownVIPTicket_ValueChanged(object sender, EventArgs e)
        {

            _NumberOfTicketVIP = Convert.ToInt32(GNumericUpDownVIPTicket.Value);

            _UpdateThePanelsAndThePricesAndCountTickets();

            lblTotalTicketVIPBookingSummary.Text = (_NumberOfTicketVIP.ToString() + " x " + _PriceTheVIPTicket.ToString());
            lblTotalPriceAfterBookingSummaryVIPTickets.Text = "$" + (_NumberOfTicketVIP * _PriceTheVIPTicket).ToString();

            _CalcTheTotalAmountAndSubAmount();
            _LoadTheAmountSubTotalToLabel_ConvertNumberToString();
        }

        private void GNumericUpDownPremium_ValueChanged(object sender, EventArgs e)
        {

            _NumberOfTicketPreimum = Convert.ToInt32(GNumericUpDownPremium.Value);

            _UpdateThePanelsAndThePricesAndCountTickets();

            lblTotalTicketPremiumBookingSummary.Text = (_NumberOfTicketPreimum.ToString() + " x " + _PriceThePreimumTicket.ToString());
            lblTotalPriceAfterBookingSummaryPreimumTickets.Text = "$" + (_NumberOfTicketPreimum * _PriceThePreimumTicket).ToString();

            _CalcTheTotalAmountAndSubAmount();
            _LoadTheAmountSubTotalToLabel_ConvertNumberToString();


        }

        private void _SearchTheCustoemrByIDOrName()
        {

            string ToBeSearch = clsEETMS_Constants.kEMPTY_STRING;

            if (!string.IsNullOrEmpty(GTextBoxCustomerIDorName.Text))
                ToBeSearch = GTextBoxCustomerIDorName.Text;
            else
                return;

            DataTable DT = CustomerBL.AllInformationCustomerAfterSearch(ToBeSearch);

            if (DT.Rows.Count > clsEETMS_Constants.kZERO)
                _CustomerID = Convert.ToInt32(DT.Rows[clsEETMS_Constants.kZERO]["CusotmerID"]);

            if (_CustomerID > clsEETMS_Constants.kZERO) MessageBox.Show("The Customer Founded", "note For Search The Customer ");
            else MessageBox.Show("The Customer Not Founded", "note For Search The Customer ");
        }

        private void _BookingTheNewTickets()
        {
            _EventID = (int)GComboBoxSelectEvents.SelectedValue;

            Dictionary<int, string> Dic_AllTicketTypeEvents = TicketBL.GetTheAllTicketTypeBy(_EventID);


            if (_CustomerID > clsEETMS_Constants.kZERO)
            {
                int TicketTypeIDRegular = clsEETMS_Constants.kZERO;
                int TicketTypeIDVIP = clsEETMS_Constants.kZERO;
                int TicketTypeIDPremium = clsEETMS_Constants.kZERO;

                foreach (var ItemDic in Dic_AllTicketTypeEvents)
                {

                    if (ItemDic.Value == "Regular") TicketTypeIDRegular = ItemDic.Key;
                    else if (ItemDic.Value == "VIP") TicketTypeIDVIP = ItemDic.Key;
                    else if (ItemDic.Value == "Premium") TicketTypeIDPremium = ItemDic.Key;

                }

                if (_NumberOfTicketRegular > clsEETMS_Constants.kZERO)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketRegular,
                        TicketTypeID = TicketTypeIDRegular,
                        CustomerID = _CustomerID


                    };

                    ReservationBL.SaveTheReservatio(_MReservations);

                }

                if (_NumberOfTicketVIP > clsEETMS_Constants.kZERO)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketVIP,
                        TicketTypeID = TicketTypeIDVIP,
                        CustomerID = _CustomerID


                    };


                    ReservationBL.SaveTheReservatio(_MReservations);

                }
                if (_NumberOfTicketPreimum > clsEETMS_Constants.kZERO)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketPreimum,
                        TicketTypeID = TicketTypeIDPremium,
                        CustomerID = _CustomerID


                    };


                    ReservationBL.SaveTheReservatio(_MReservations);

                }


            }
            else
            {

                MessageBox.Show("Must Search The Customer To Be Booking", "Note OF Booking New Tickets ");
                return;
            }

            MessageBox.Show("The Booking Is Successfully", "Note For Add New Reservations");
            ;



            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "Regular", _NumberOfTicketRegular);
            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "VIP", _NumberOfTicketVIP);
            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "Premium", _NumberOfTicketPreimum);

            // Change The Active Event After The Fully Booking Event 
            DataTable DT_InfoEvent = EventBL.GetRemainingCapacityEventfoBy(_EventID);
            MEvent mEvent = EventBL.FindTheEventBy(_EventID);

            if (Convert.ToInt32(DT_InfoEvent.Rows[0]["RemainingCapacity"]) == clsEETMS_Constants.kZERO)
            {

                mEvent.IsActiveEvent = false;
                mEvent.EnMode = MEvent.EnModeEvent._kUPDATE_INFORMATION_EVENT;
                EventBL.SaveTheMode(mEvent);

            }

            _ResetAllSettingCardsTickets();
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void GGButtonSearchTheCustomerByIDorName_Click(object sender, EventArgs e)
            => _SearchTheCustoemrByIDOrName();

        private void GGButtonConfirmBooking_Click(object sender, EventArgs e)
            => _BookingTheNewTickets();

        private void GComboBoxSelectEvents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ResetAllSettingCardsTickets();
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void TicketPanel(string TicketType)
        {
            switch (TicketType)
            {

                case "Regular":
                    _CheckTheStackTickes(clsEETMS_Constants.kZERO, true, GGButtonRegularTicketStatus, lblQLeftRegular);
                    _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelRegularTicket, GNumericUpDownRegularTicket);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);

                    _CheckTheStackTickes(_NumberAvailableTicketPremium, false, GGButtonPremiumTicketStatus, lblQLeftPermium);
                    _CheckTheStackTickes(_NumberAvailableTicketVIP, false, GGButtonVIPTicketStatus, lblQLeftVIP);

                    break;

                case "VIP":
                    _CheckTheStackTickes(clsEETMS_Constants.kZERO, true, GGButtonVIPTicketStatus, lblQLeftVIP);
                    _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelVIPTicket, GNumericUpDownVIPTicket);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);


                    _CheckTheStackTickes(_NumberAvailableTicketPremium, false, GGButtonPremiumTicketStatus, lblQLeftPermium);
                    _CheckTheStackTickes(_NumberAvailableTicketRegular, false, GGButtonRegularTicketStatus, lblQLeftRegular);

                    break;

                case "Premium":
                    _CheckTheStackTickes(clsEETMS_Constants.kZERO, true, GGButtonPremiumTicketStatus, lblQLeftPermium);
                    _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelPermiumTicket, GNumericUpDownPremium);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);
                    _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);

                    _CheckTheStackTickes(_NumberAvailableTicketVIP, false, GGButtonVIPTicketStatus, lblQLeftVIP);
                    _CheckTheStackTickes(_NumberAvailableTicketRegular, false, GGButtonRegularTicketStatus, lblQLeftRegular);

                    break;


            }
        }


    }
}
