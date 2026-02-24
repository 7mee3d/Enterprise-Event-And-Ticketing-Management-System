using EETMS_BusinessLayer;
using EETMS_Models;
using EETMS_Presentation.EETMS_Category;
using EETMS_Presentation.EETMS_Customers;
using EETMS_Presentation.EETMS_Dashboard;
using EETMS_Presentation.EETMS_Events;
using EETMS_Presentation.EETMS_Events.User_Controls_Operation_Event;
using EETMS_Presentation.EETMS_Payment;
using EETMS_Presentation.EETMS_Report;
using EETMS_Presentation.EETMS_Tickets;
using EETMS_Presentation.EETMS_UsersAndRoles.Main_User_Control_Users_And_Roles;
using EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles;
using EETMS_Presentation.Properties;
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

        MUser _InformationUser;

        public frmMainScreenEETMS(string UsernameOrEmail)
        {
            InitializeComponent();

            _InformationUser = null;


            _InformationUser = UserBL.FindUser(UsernameOrEmail);

            if (_InformationUser != null)
            {
                lblNameUser.Text = _InformationUser.UserFullName;
                lblRoleUser.Text = _InformationUser.RoleName;
                if (_InformationUser.ImagePath != null)
                    GCPictureBoxImageUser.Load(_InformationUser.ImagePath);
                else
                    GCPictureBoxImageUser.Image = Resources.Image_hide_White_Icon_EETMS;
            }

        }

        private void _ShowTheUserControlInThePanel(UserControl us)
        {

            GPanelMainScreens.Controls.Clear();
            us.Dock = DockStyle.Fill;
            GPanelMainScreens.Controls.Add(us);

            us.BringToFront();
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

        private void _OpenTheAddNewTicketTypeToTheEvent(int IDEvent, int IDTicketType)
        {
            var US_AddNewTicketTypeToTheEvent = new USAddTheTicketsTypeToTheEvent(IDEvent, IDTicketType);

            US_AddNewTicketTypeToTheEvent.ERequestToTheClose_USAddNewTicketTypeToTheEvent += (sender, e) =>
            _ShowTicketEvent(IDEvent, IDTicketType);

            _ShowTheUserControlInThePanel(US_AddNewTicketTypeToTheEvent);
        }

        private void _ShowTicketEvent(int id, int IDTicketType)
        {

            var us = new USShowAllInformationTicketTypeForEvent(id);

            us.ERequestTheClose_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTheCreateNewEventUS(eventId);
            };

            us.ERequestToOpenThe_USAddNewTicketTypeToTheEvent += (sender, DataAddNewTicketToRvent) =>
            _OpenTheAddNewTicketTypeToTheEvent(DataAddNewTicketToRvent.EventID, DataAddNewTicketToRvent.TicketTypeID);

            _ShowTheUserControlInThePanel(us);
        }

        private void _ShowTheCreateNewEventUS(int id)
        {
            int IDTicketType = -1;

            US_AddAndEditInformationEvent US_AddNewEvent = new US_AddAndEditInformationEvent(id);


            US_AddNewEvent.ERequestTheOpen_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTicketEvent(eventId, IDTicketType);
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

        private void frmMainScreenEETMS_Load(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USDashboard());
        }

        private void _OpenTheAddNewUser(int IDUser)
        {
            USAddNewUserAndUpdate USANUAU = new USAddNewUserAndUpdate(IDUser);
            USANUAU.ERequestToTheCloseAddNewUser += (sender, e) =>
            _ShowTheUserAndRoleUS();

            _ShowTheUserControlInThePanel(USANUAU);
        }

        private void _ShowTheUserAndRoleUS()
        {

            USUsersManagmentAndRoles USUMAR = new USUsersManagmentAndRoles();

            USUMAR.ERequestToOpenTheAddNewUserUS += (sender, UserID) =>
            _OpenTheAddNewUser(UserID);

            _ShowTheUserControlInThePanel(USUMAR);
        }

        private void GButtonUsersAndRoles_Click(object sender, EventArgs e)
        {
            _ShowTheUserAndRoleUS();
        }



    }
}
