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
            USDashboard US_Dashboard_EETMS = new USDashboard();
            _ShowTheUserControlInThePanel(US_Dashboard_EETMS);
        }

        private void GButtonCategory_Click(object sender, EventArgs e)
        {
            USCategory US_Category_EETMS = new USCategory();
            _ShowTheUserControlInThePanel(US_Category_EETMS);
        }

        private void GButtonEvents_Click(object sender, EventArgs e)
        {
            USEvents US_Events_EETMS = new USEvents();
            _ShowTheUserControlInThePanel(US_Events_EETMS);
        }

        private void GButtonCustomers_Click(object sender, EventArgs e)
        {
            USCustomers US_Customers_EETMS = new USCustomers();
            _ShowTheUserControlInThePanel(US_Customers_EETMS);

        }

        private void GButtonTickets_Click(object sender, EventArgs e)
        {
            USTickets US_Tickets_EETMS = new USTickets();
            _ShowTheUserControlInThePanel(US_Tickets_EETMS);

        }

        private void GButtonPayment_Click(object sender, EventArgs e)
        {
            USPayment US_Payment_EETMS = new USPayment();
            _ShowTheUserControlInThePanel(US_Payment_EETMS);
        }

        private void GButtonReport_Click(object sender, EventArgs e)
        {
            USReport US_Report_EETMS = new USReport();
            _ShowTheUserControlInThePanel(US_Report_EETMS);
        }
   
    }
}
