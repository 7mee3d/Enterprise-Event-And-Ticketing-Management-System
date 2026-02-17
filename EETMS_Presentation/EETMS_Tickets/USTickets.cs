using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EETMS_BusinessLayer;
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


        public USTickets()
        {
            InitializeComponent();
        }

        private void _CheckTheStackTickes(int CountOfTicketsAvailable = 0, bool IsSelected = false, Guna2GradientButton G2DB = null)
        {

            if (IsSelected)
            {

                G2DB.Text = "Selected";
                G2DB.DisabledState.ForeColor = Color.White;

                G2DB.DisabledState.FillColor = Color.FromArgb(43, 140, 238);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(43, 140, 238);

                return;
            }


            if (CountOfTicketsAvailable > 10)
            {
                G2DB.Text = "Available";
                G2DB.DisabledState.ForeColor = Color.FromArgb(21, 128, 61);

                G2DB.DisabledState.FillColor = Color.FromArgb(220, 252, 231);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(220, 252, 231);

            }
            else
            {

                G2DB.Text = "Low Stack";
                G2DB.DisabledState.ForeColor = Color.FromArgb(180, 83, 9);

                G2DB.DisabledState.FillColor = Color.FromArgb(254, 243, 199);
                G2DB.DisabledState.FillColor2 = Color.FromArgb(254, 243, 199);

                lblQLeftPermium.ForeColor = Color.FromArgb(180, 83, 9);
                lblQLeftRegular.ForeColor = Color.FromArgb(180, 83, 9);
                lblQLeftVIP.ForeColor = Color.FromArgb(180, 83, 9);

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

            lblTotalPriceOneTicketPermium.Text = "$0";
            lblTotalPriceOneTicketVIP.Text = "$0";
            lblTotalPriceOneTicketRegular.Text = "$0";

            PanelRegularTicket.Visible = false;
            PanelVIPTicket.Visible = false;
            PanelPremiumTicket.Visible = false;

        }

        private void _LoadAllInformationTicketTypeForEventAfterSelectComboBox()
        {


            int EventIDValue = (int)GComboBoxSelectEvents.SelectedValue;
            //  _ResetAllSettingCardsTickets();

            DataTable TicketType_DT = TicketBL.GetInformationTicketForEvent(EventIDValue);

            if (TicketType_DT != null)
                foreach (DataRow DR_Tickets in TicketType_DT.Rows)
                {
                    string ticketType = DR_Tickets["TicketTypeName"].ToString();

                    switch (ticketType)
                    {
                        case "Standard":
                            GGPanelRegularTicket.Enabled = true;
                            lblQLeftRegular.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketRegular.Text = "$" + DR_Tickets["Price"].ToString();
                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonRegularTicketStatus);
                            GNumericUpDownRegularTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheRegularTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            break;

                        case "VIP":
                            GGPanelVIPTicket.Enabled = true;
                            lblQLeftVIP.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketVIP.Text = "$" + DR_Tickets["Price"].ToString();
                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonVIPTicketStatus);
                            GNumericUpDownVIPTicket.Maximum = Convert.ToInt32(DR_Tickets["Available"]);

                            _PriceTheVIPTicket = Convert.ToInt32(DR_Tickets["Price"]);
                            break;

                        case "Premium":
                            GGPanelPermiumTicket.Enabled = true;
                            lblQLeftPermium.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketPermium.Text = "$" + DR_Tickets["Price"].ToString();
                            _CheckTheStackTickes(Convert.ToInt32(DR_Tickets["Available"]), false, GGButtonPremiumTicketStatus);
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

            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonRegularTicketStatus);
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelRegularTicket, GNumericUpDownRegularTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);

        }

        private void GComboBoxSelectEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void GGPanelVIPTicket_MouseClick(object sender, MouseEventArgs e)
        {
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonVIPTicketStatus);
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelVIPTicket, GNumericUpDownVIPTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);


        }

        private void GGPanelPermiumTicket_MouseClick(object sender, MouseEventArgs e)
        {
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
            _CheckTheStackTickes(0, true, GGButtonPremiumTicketStatus);
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

                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;

                PanelRegularTicket.Location = new Point(4, 91);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 158);
            }
            else if (_NumberOfTicketRegular == 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum == 0)
            {
                PanelRegularTicket.Visible = false;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = false;

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

                PanelPremiumTicket.Location = new Point(4, 91);
                GPanelSubTotalAndTaxTicketBookingSummary.Location = new Point(4, 158);
            }
            else if (_NumberOfTicketRegular > 0 && _NumberOfTicketVIP > 0 && _NumberOfTicketPreimum == 0)
            {
                PanelRegularTicket.Visible = true;
                PanelVIPTicket.Visible = true;
                PanelPremiumTicket.Visible = false;
                GPanelSubTotalAndTaxTicketBookingSummary.Visible = true;

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


    }
}
