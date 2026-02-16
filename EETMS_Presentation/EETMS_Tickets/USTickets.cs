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
        public USTickets()
        {
            InitializeComponent();
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
            GGPanelRegularTicket.Enabled = false;
            GGPanelVIPTicket.Enabled = false;
            GGPanelPermiumTicket.Enabled = false;

            lblQLeftRegular.Text = "0 LEFT";
            lblQLeftVIP.Text = "0 LEFT";
            lblQLeftPermium.Text = "0 LEFT";

            lblTotalPriceOneTicketPermium.Text = "$0";
            lblTotalPriceOneTicketVIP.Text = "$0";
            lblTotalPriceOneTicketRegular.Text = "$0";


        }

        private void _LoadAllInformationTicketTypeForEventAfterSelectComboBox()
        {

            _ResetAllSettingCardsTickets();

            int EventIDValue = (int)GComboBoxSelectEvents.SelectedValue;

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
                            break;

                        case "VIP":
                            GGPanelVIPTicket.Enabled = true;
                            lblQLeftVIP.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketVIP.Text = "$" + DR_Tickets["Price"].ToString();
                            break;

                        case "Premium":
                            GGPanelPermiumTicket.Enabled = true;
                            lblQLeftPermium.Text = DR_Tickets["Available"].ToString() + " LEFT";
                            lblTotalPriceOneTicketPermium.Text = "$" + DR_Tickets["Price"].ToString();
                            break;
                    }
                }




        }

        private void USTickets_Load(object sender, EventArgs e)
        {
            _LoadInformationEventToComboBox();
        }

        private void guna2GradientPanel2_Click(object sender, EventArgs e)
        {
            //    GGPanelRegularTicket.FillColor = Color.FromArgb(244, 249, 254);
            //    GGPanelRegularTicket.FillColor2 = Color.FromArgb(244, 249, 254);
            //    GGPanelRegularTicket.BorderColor = Color.FromArgb(43, 140, 238);
        }

        private void _ChangeTheColorBackAndFrontMouseClickTheCardTicket(Guna2GradientPanel G2GP)
        {
            G2GP.FillColor = Color.FromArgb(244, 249, 254);
            G2GP.FillColor2 = Color.FromArgb(244, 249, 254);
            G2GP.BorderColor = Color.FromArgb(43, 140, 238);
        }

        private void _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(Guna2GradientPanel G2GP)
        {
            G2GP.FillColor = Color.White;
            G2GP.FillColor2 = Color.White;
            G2GP.BorderColor = Color.FromArgb(241, 245, 249);
        }

        private void GGPanelRegularTicket_MouseClick(object sender, MouseEventArgs e)
        {

            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelRegularTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);
        }


        private void GComboBoxSelectEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadAllInformationTicketTypeForEventAfterSelectComboBox();
        }

        private void GGPanelVIPTicket_MouseClick(object sender, MouseEventArgs e)
        {
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelVIPTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);

        }

        private void GGPanelPermiumTicket_MouseClick(object sender, MouseEventArgs e)
        {
            _ChangeTheColorBackAndFrontMouseClickTheCardTicket(GGPanelPermiumTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelVIPTicket);
            _ChangeTheColorBackAndFrontMouseLeaveTheCardTicket(GGPanelRegularTicket);
        }


    }
}
