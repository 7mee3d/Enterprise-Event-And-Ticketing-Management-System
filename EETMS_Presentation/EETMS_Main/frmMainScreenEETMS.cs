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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Main
{
    public partial class frmMainScreenEETMS : Form
    {

        MUser _InformationUser = null; 


        private void _ShowTheUserControlInThePanel(UserControl us)
        {

            GPanelMainScreens.Controls.Clear();
            us.Dock = DockStyle.Fill;
            GPanelMainScreens.Controls.Add(us);

            us.BringToFront();
        }



        public frmMainScreenEETMS(string UsernameOrEmail  )
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

        private void GButtonCustomers_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USCustomers());

        }

        private void GButtonTickets_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USTickets());

        }

        private void GButtonPayment_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USPayment());
        }

        private void GButtonReport_Click(object sender, EventArgs e)
        {
            _ShowTheUserControlInThePanel(new USReport());
        }
   
        private void _ShowTheCreateNewEventUS(int id)
        {
            US_AddAndEditInformationEvent US_AddNewEvent = new US_AddAndEditInformationEvent(id);

            US_AddNewEvent.RequestClose += (sender, e) => _ShowTheEventUS();

            _ShowTheUserControlInThePanel(US_AddNewEvent);
        }

        private void _ShowTheEventUS()

        {
            USEvents US_Event = new USEvents();

            US_Event.RequestOpenCreateNewEventUS += (sender, id) => _ShowTheCreateNewEventUS(id);

            _ShowTheUserControlInThePanel(US_Event);
        } 
   
    
    
    }
}
