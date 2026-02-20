using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_Models;
using Guna.UI2.WinForms;


namespace EETMS_Presentation.EETMS_Tickets
{


    public partial class USTickets : UserControl
    {

        private int _NumberOfTicketRegular = 0;
        private int _NumberOfTicketVIP = 0;
        private int _NumberOfTicketPreimum = 0;

        private int _PriceTheRegularTicket = 0;
        private int _PriceTheVIPTicket = 0;
        private int _PriceThePreimumTicket = 0;


        private double _SubTotalAmount = 0;
        private double _Tax = 0;
        private double _TotalAmount = 0;


        private int _CustomerID = -1;

        private MReservations _MReservations = null;



        private int _EventID;

        public USTickets()
        {
            InitializeComponent();
        }

        private void _CheckTheStackTickes(int CountOfTicketsAvailable = 0, bool IsSelected = false, Guna2GradientButton G2DB = null, Label lblLeftTikets = null)
        {

            if (IsSelected)
            {

                G2DB.Text = "Selected";
                G2DB.DisabledState.ForeColor = Color.White;

                G2DB.DisabledState.FillColor = Color.FromArgb(43, 140, 238);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(43, 140, 238);

                return;
            }

            if (CountOfTicketsAvailable == 0)
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

            GNumericUpDownPremium.Value = 0;
            GNumericUpDownRegularTicket.Value = 0;
            GNumericUpDownVIPTicket.Value = 0;

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

            //_EventID = 0;
        }

        private void _LoadAllInformationTicketTypeForEventAfterSelectComboBox()
        {

            // _ResetAllSettingCardsTickets();
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

                            if (Convert.ToInt32(DR_Tickets["Available"]) > 0)
                                GGPanelRegularTicket.Enabled = true;


                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonRegularTicketStatus, lblQLeftRegular);
                            GNumericUpDownRegularTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheRegularTicket = Convert.ToInt32(DR_Tickets["Price"]);

                            break;


                        case "VIP":
                            lblQLeftVIP.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketVIP.Text = "$" + DR_Tickets["Price"].ToString();

                            if (Convert.ToInt32(DR_Tickets["Available"]) > 0)
                                GGPanelVIPTicket.Enabled = true;

                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonVIPTicketStatus, lblQLeftVIP);
                            GNumericUpDownVIPTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheVIPTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            break;


                        case "Premium":
                            lblQLeftPermium.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketPermium.Text = "$" + DR_Tickets["Price"].ToString();

                            if (Convert.ToInt32(DR_Tickets["Available"]) > 0)
                                GGPanelPermiumTicket.Enabled = true;

                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonPremiumTicketStatus, lblQLeftPermium);
                            GNumericUpDownPremium.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceThePreimumTicket = Convert.ToInt32(DR_Tickets["Price"]);
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
        {

            //_LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonRegularTicketStatus, lblQLeftRegular);
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelRegularTicket, GNumericUpDownRegularTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);

        }

        private void GComboBoxSelectEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void GGPanelVIPTicket_MouseClick(object sender, MouseEventArgs e)
        {
            //   _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonVIPTicketStatus, lblQLeftVIP);
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelVIPTicket, GNumericUpDownVIPTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);


        }

        private void GGPanelPermiumTicket_MouseClick(object sender, MouseEventArgs e)
        {
            //  _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonPremiumTicketStatus, lblQLeftPermium);
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelPermiumTicket, GNumericUpDownPremium);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);

        }

        private void _UpdateThePanelsAndThePricesAndCountTickets()
        {

            if (_NumberOfTicketRegular > 0 && _NumberOfTicketVIP == 0 && _NumberOfTicketPreimum == 0)
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
            else if (_NumberOfTicketRegular == 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum == 0)
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
            else if (_NumberOfTicketRegular == 0 && _NumberOfTicketVIP == 0 && _NumberOfTicketPreimum > 0)
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
            else if (_NumberOfTicketRegular > 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum == 0)
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
            else if (_NumberOfTicketRegular > 0 && _NumberOfTicketVIP == 0 && _NumberOfTicketPreimum > 0)
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
            else if (_NumberOfTicketRegular == 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum > 0)
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
            else if (_NumberOfTicketRegular > 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum > 0)
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

            _SubTotalAmount = 0;
            _TotalAmount = 0;


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

            string ToBeSearch = GTextBoxCustomerIDorName.Text;

            DataTable DT = CustomerBL.AllInformationCustomerAfterSearch(ToBeSearch);

            if (DT.Rows.Count > 0)
                _CustomerID = Convert.ToInt32(DT.Rows[0]["CusotmerID"]);

            if (_CustomerID > 0) MessageBox.Show("The Customer Founded", "note For Search The Customer ");
            else MessageBox.Show("The Customer Not Founded", "note For Search The Customer ");
        }

        private void _BookingTheNewTickets()
        {
            if (_CustomerID > 0)
            {
                if (_NumberOfTicketRegular > 0)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketRegular,
                        TicketTypeID = 1,
                        CustomerID = _CustomerID


                    };

                    ReservationBL.SaveTheReservatio(_MReservations);

                }

                if (_NumberOfTicketVIP > 0)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketVIP,
                        TicketTypeID = 2,
                        CustomerID = _CustomerID


                    };


                    ReservationBL.SaveTheReservatio(_MReservations);

                }
                if (_NumberOfTicketPreimum > 0)
                {

                    _MReservations = new MReservations()
                    {

                        Quantity = _NumberOfTicketPreimum,
                        TicketTypeID = 3,
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

            _EventID = (int)GComboBoxSelectEvents.SelectedValue;

            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "Regular", _NumberOfTicketRegular);
            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "VIP", _NumberOfTicketVIP);
            ReservationBL.UpdateTheInformationTicketTypesBy(_EventID, "Premium", _NumberOfTicketPreimum);

            _ResetAllSettingCardsTickets();
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void GGButtonSearchTheCustomerByIDorName_Click(object sender, EventArgs e)
        {
            _SearchTheCustoemrByIDOrName();
        }

        private void GGButtonConfirmBooking_Click(object sender, EventArgs e)
        {
            _BookingTheNewTickets();
        }

        private void GComboBoxSelectEvents_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ResetAllSettingCardsTickets();
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }
    }
}
