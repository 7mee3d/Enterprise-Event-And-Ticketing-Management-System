using EETMS_BusinessLayer;
using System;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.Main_User_Control_Users_And_Roles
{
    public partial class USUsersManagmentAndRoles : UserControl
    {
        public USUsersManagmentAndRoles()
        {
            InitializeComponent();
        }

        private void _InitalSettingTheUserManagmentCountsUsers()
        {
            lblTotalUsers.Text = UserBL.GetTotalUsers().ToString();
            lblTotalActiveAdmin.Text = UserBL.GetTheAvtiveAdmin().ToString();
            lblTotalBlockedAccountsUser.Text = UserBL.GetTheBlockedUser().ToString();

        }

        private void USUsersManagmentAndRoles_Load(object sender, EventArgs e)
        {
            _InitalSettingTheUserManagmentCountsUsers();

        }



    }
}
