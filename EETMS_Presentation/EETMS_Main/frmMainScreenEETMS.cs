using EETMS_BusinessLayer;
using EETMS_Models;
using EETMS_Presentation.EETMS_Category;
using EETMS_Presentation.EETMS_Customers;
using EETMS_Presentation.EETMS_Dashboard;
using EETMS_Presentation.EETMS_Events;
using EETMS_Presentation.EETMS_Payment;
using EETMS_Presentation.EETMS_Report;
using EETMS_Presentation.EETMS_Tickets;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace EETMS_Presentation.EETMS_Main
{
    public partial class frmMainScreenEETMS : Form
    {
        private struct _stInfoMovePanel
        {
            public Point _NewLocation;
            public bool IsMouseDown;

        }

        private _stInfoMovePanel _StInfoMovePanel;

        MUser _InformationUser = null;


        private void _ShowTheUserControlInThePanel(UserControl us)
        {

            GPanelMainScreens.Controls.Clear();
            us.Dock = DockStyle.Fill;
            GPanelMainScreens.Controls.Add(us);

            us.BringToFront();
        }



        public frmMainScreenEETMS(string UsernameOrEmail)
        {
            InitializeComponent();

            _InformationUser = UserBL.FindUser(UsernameOrEmail);
            if (_InformationUser != null)
            {
                lblNameUser.Text = _InformationUser.UserFullName;
                lblRoleUser.Text = _InformationUser.RoleName;
            }

        }

        private void PicLogoutEETMS_Click(object sender, EventArgs e)
        {
            frmLoginEETMS frm_L_EETMS = new frmLoginEETMS();
            frm_L_EETMS.Show();
            this.Close();
        }

        private void GButtonDashboard_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USDashboard());
        }

        private void GButtonCategory_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USCategory());
        }

        private void GButtonEvents_Click(object sender, EventArgs e)
        {
            _ShowTheEventUS();
        }


        private void _OpenTheAddNewCustomer(int IDCustomer)
        {
            US_AddAndUpdateInformationCustomer US_AddNewCustomer = new US_AddAndUpdateInformationCustomer(IDCustomer);

            US_AddNewCustomer.RequestClose += (sender, e) => _OpenThe_US_Customer();

            _ShowTheUserControlInThePanel(US_AddNewCustomer);
        }

        private void _OpenThe_US_Customer()
        {
            USCustomers US_Customer = new USCustomers();

            US_Customer.RequestOpenTheAddNewCustomer += (sender, IDCustomer) => _OpenTheAddNewCustomer(IDCustomer);

            _ShowTheUserControlInThePanel(US_Customer);
        }

        private void _OpenThePaymentUS()
        {
            USPayment US_Payment = new USPayment();

            US_Payment.ERequestTheOpenAddPaymentBooking += (sender, e) => _OpenTheAddNewPaymentBooking();

            _ShowTheUserControlInThePanel(US_Payment);

        }

        private void _OpenTheAddNewPaymentBooking()
        {
            USAddPaymentReservations US_APR = new USAddPaymentReservations();

            US_APR.ERequestTheClosePaymentBooking += (sender, e) => _OpenThePaymentUS();
            _ShowTheUserControlInThePanel(US_APR);

        }

        private void GButtonCustomers_Click(object sender, EventArgs e)
        {

            _OpenThe_US_Customer();

        }

        private void GButtonTickets_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USTickets());

        }

        private void GButtonPayment_Click(object sender, EventArgs e)
        {
            _OpenThePaymentUS();
        }

        private void GButtonReport_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USReport());
        }

        private void _ShowTicketEvent(int id)
        {

            var us = new US_AddAndUpdateTheTicketsToTheEvents(id);

            us.ERequestTheClose_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTheCreateNewEventUS(eventId);
            };

            _ShowTheUserControlInThePanel(us);
        }

        private void _ShowTheCreateNewEventUS(int id)
        {

            US_AddAndEditInformationEvent US_AddNewEvent = new US_AddAndEditInformationEvent(id);


            US_AddNewEvent.ERequestTheOpen_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTicketEvent(eventId);
            };

            US_AddNewEvent.RequestClose += (sender, e) => _ShowTheEventUS();

            _ShowTheUserControlInThePanel(US_AddNewEvent);
        }


        private void _ShowTheEventUS()

        {
            USEvents US_Event = new USEvents();

            US_Event.RequestOpenCreateNewEventUS += (sender, id) => _ShowTheCreateNewEventUS(id);

            _ShowTheUserControlInThePanel(US_Event);
        }

        private void GPanelMainScreens_MouseDown(object sender, MouseEventArgs e)
        {
            _StInfoMovePanel.IsMouseDown = true;
            _StInfoMovePanel._NewLocation = e.Location;
        }

        private void GPanelMainScreens_MouseUp(object sender, MouseEventArgs e)
        {
            _StInfoMovePanel.IsMouseDown = false;
        }

        private void GPanelMainScreens_MouseMove(object sender, MouseEventArgs e)
        {
            if (_StInfoMovePanel.IsMouseDown)
            {
                int NewX = (this.Location.X - _StInfoMovePanel._NewLocation.X) + e.X;
                int NewY = (this.Location.Y - _StInfoMovePanel._NewLocation.Y) + e.Y;

                this.Location = new Point(NewX, NewY);
            }
        }
    }
}
