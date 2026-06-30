using EETMS_BusinessLayer;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Category;
using EETMS_Presentation.EETMS_Customers;
using EETMS_Presentation.EETMS_Dashboard;
using EETMS_Presentation.EETMS_Events;
using EETMS_Presentation.EETMS_Events.User_Controls_Operation_Event;
using EETMS_Presentation.EETMS_Payment;
using EETMS_Presentation.EETMS_Report;
using EETMS_Presentation.EETMS_Roles;
using EETMS_Presentation.EETMS_Roles.Users_Control_Opration_Roles;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.EETMS_Tickets;
using EETMS_Presentation.EETMS_UsersAndRoles.Main_User_Control_Users_And_Roles;
using EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;
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
        UserDTO _InformationUser;
        private int _Permissionsuser;
        private Guna2MessageDialog _G2MD;


        public frmMainScreenEETMS(string UsernameOrEmail)
        {
            InitializeComponent();

            _InformationUser = null;


            _InformationUser = UserBL.FindUser(UsernameOrEmail);

            if (_InformationUser != null)
            {
                lblNameUser.Text = _InformationUser.UserFullName;
                lblRoleUser.Text = _InformationUser.RoleName;
                if (!string.IsNullOrWhiteSpace(_InformationUser.ImagePath))
                    GCPictureBoxImageUser.Load(_InformationUser.ImagePath);
                else
                    GCPictureBoxImageUser.Image = Resources.Remove_image_Icon_EETMS;

                _Permissionsuser = RolesBL.FindTheRoleBy(_InformationUser.RoleID).PermssionsRole;
            }

        }

        private void _ShowTheUserControlInThePanel(UserControl us)
        {

            GPanelMainScreens.Controls.Clear();
            us.Dock = DockStyle.Fill;
            GPanelMainScreens.Controls.Add(us);

            us.BringToFront();
        }

        private void _ShowTheMessageAccessDenied()
        {
            GPanelMainScreens.Controls.Clear();
            GPanelMainScreens.Controls.Add(GPanelMessage);
            GPanelMessage.Visible = true;

            GPanelMessage.BringToFront();
        }

        private bool _IsHasAPermissionsThisSeaction(int Permissions, RoleDTO.EnPermssionsType enPermssionsType)
            => RolesBL.IsPassUserPermssions(Permissions, enPermssionsType);

        private void PicLogoutEETMS_Click(object sender, EventArgs e)
        {
            frmLoginEETMS frm_L_EETMS = new frmLoginEETMS();
            frm_L_EETMS.Show();
            this.Close();
        }

        private void GButtonDashboard_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kDASHBOARD))
                _ShowTheUserControlInThePanel(new UC_Dashboard());
            else _ShowTheMessageAccessDenied();

        }

        private void GButtonCategory_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kCATEGORY_MANAGMENT))
                _ShowTheUserControlInThePanel(new UC_Category());
            else
                _ShowTheMessageAccessDenied();


        }

        private void GButtonEvents_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kEVENTS_MANAGMENT))
                _ShowTheEventUS();
            else _ShowTheMessageAccessDenied();

        }

        private void _OpenTheAddNewCustomer(int IDCustomer)
        {
            UC_AddAndUpdateInformationCustomer US_AddNewCustomer = new UC_AddAndUpdateInformationCustomer(IDCustomer);

            US_AddNewCustomer.RequestClose += (sender, e) => _OpenThe_US_Customer();

            _ShowTheUserControlInThePanel(US_AddNewCustomer);
        }

        private void _OpenThe_US_Customer()
        {
            UC_Customers US_Customer = new UC_Customers();

            US_Customer.RequestOpenTheAddNewCustomer += (sender, IDCustomer) => _OpenTheAddNewCustomer(IDCustomer);

            _ShowTheUserControlInThePanel(US_Customer);
        }

        private void _OpenThePaymentUS()
        {
            UC_Payment US_Payment = new UC_Payment();

            US_Payment.ERequestTheOpenAddPaymentBooking += (sender, e) => _OpenTheAddNewPaymentBooking();

            _ShowTheUserControlInThePanel(US_Payment);

        }

        private void _OpenTheAddNewPaymentBooking()
        {
            UC_AddPaymentReservations US_APR = new UC_AddPaymentReservations();

            US_APR.ERequestTheClosePaymentBooking += (sender, e) => _OpenThePaymentUS();
            _ShowTheUserControlInThePanel(US_APR);

        }

        private void GButtonCustomers_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kCUSTOMER))
                _OpenThe_US_Customer();
            else _ShowTheMessageAccessDenied();
        }

        private void GButtonPayment_Click(object sender, EventArgs e)
        {

            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kPAYMENT))
                _OpenThePaymentUS();
            else _ShowTheMessageAccessDenied();
        }

        private void GButtonReport_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kREPORT))
                _ShowTheUserControlInThePanel(new UC_Report());
            else _ShowTheMessageAccessDenied();
        }

        private void _OpenTheAddNewTicketTypeToTheEvent(int IDEvent, int IDTicketType)
        {
            var US_AddNewTicketTypeToTheEvent = new UC_AddTheTicketsTypeToTheEvent(IDEvent, IDTicketType);

            US_AddNewTicketTypeToTheEvent.ERequestToTheClose_USAddNewTicketTypeToTheEvent += (sender, e) =>
            _ShowTicketEvent(IDEvent, IDTicketType);

            _ShowTheUserControlInThePanel(US_AddNewTicketTypeToTheEvent);
        }

        private void _ShowTicketEvent(int id, int IDTicketType)
        {

            var us = new UC_ShowAllInformationTicketTypeForEvent(id);

            us.ERequestTheClose_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTheCreateNewEventUS(eventId);
            };

            us.ERequestToOpenThe_USAddNewTicketTypeToTheEvent += (sender, DataAddNewTicketToEvent) =>
            _OpenTheAddNewTicketTypeToTheEvent(DataAddNewTicketToEvent.EventID, DataAddNewTicketToEvent.TicketTypeID);

            _ShowTheUserControlInThePanel(us);
        }

        private void _ShowTheCreateNewEventUS(int id)
        {
            int IDTicketType = -1;

            UC_AddAndEditInformationEvent US_AddNewEvent = new UC_AddAndEditInformationEvent(id);


            US_AddNewEvent.ERequestTheOpen_AddAndUpdateTheTicketsEvents += (sender, eventId) =>
            {
                _ShowTicketEvent(eventId, IDTicketType);
            };

            US_AddNewEvent.RequestClose += (sender, e) => _ShowTheEventUS();


            _ShowTheUserControlInThePanel(US_AddNewEvent);
        }

        private void _ShowTheEventUS()

        {
            UC_Events US_Event = new UC_Events();

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
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kDASHBOARD))
                _ShowTheUserControlInThePanel(new UC_Dashboard());
            else
            {
                GButtonDashboard.Checked = false;
                _ShowTheMessageAccessDenied();
            }
        }

        private void _OpenTheAddNewUser(int IDUser)
        {
            UC_AddNewUserAndUpdate USANUAU = new UC_AddNewUserAndUpdate(IDUser);
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

            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kUSERS_MANAGMENT))
                _ShowTheUserAndRoleUS();
            else

                _ShowTheMessageAccessDenied();

        }

        private void _OpenTheAddNewRole(int IDNewRole)
        {
            UC_AddNewRoleAndUpdate USAddNewRole = new UC_AddNewRoleAndUpdate(IDNewRole);
            USAddNewRole.ERequestToCloseTheUSAddNewRole += (sender, e) =>
            {
                _ShowTheRoleManagment();
            };

            _ShowTheUserControlInThePanel(USAddNewRole);
        }

        private void _ShowTheRoleManagment()
        {
            UC_RolesManagment USRolesManagment = new UC_RolesManagment();

            USRolesManagment.ERequestToOpenCreateNewRole += (sender, RoleID) =>
            {
                _OpenTheAddNewRole(RoleID);
            };

            _ShowTheUserControlInThePanel(USRolesManagment);

        }

        private void GButtonRole_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kROLES_MANAGMENT))
                _ShowTheRoleManagment();
            else _ShowTheMessageAccessDenied();
        }

        private void GButtonReservation_Click(object sender, EventArgs e)
        {
            if (_IsHasAPermissionsThisSeaction(_Permissionsuser, RoleDTO.EnPermssionsType.kRESERVATION))
                _ShowTheUserControlInThePanel(new UC_Reservation());
            else _ShowTheMessageAccessDenied();
        }
    }
}
