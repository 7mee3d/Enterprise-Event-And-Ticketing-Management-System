using EETMS_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.Main_User_Control_Users_And_Roles
{
    public partial class USUsersManagmentAndRoles : UserControl
    {
        public USUsersManagmentAndRoles()
        {
            InitializeComponent();
        }

        public event EventHandler<int> ERequestToOpenTheAddNewUserUS = null;
        int IDUser = 0;

        private int _GetTheIDUserAfterSelectionUserFromDGV()
           => (GDataGridViewUsersInformation.SelectedRows.Count > 0 ? Convert.ToInt32(GDataGridViewUsersInformation.SelectedRows[0].Cells[0].Value) : -1);

        private void _InitalSettingTheUserManagmentCountsUsers()
        {
            lblTotalUsers.Text = UserBL.GetTotalUsers().ToString();
            lblTotalActiveAdmin.Text = UserBL.GetTheAvtiveAdmin().ToString();
            lblTotalBlockedAccountsUser.Text = UserBL.GetTheBlockedUser().ToString();
            _LoadAllDataToTheDataGridViewUsers();
            GDataGridViewUsersInformation.ClearSelection();

        }

        private void _LoadAllDataToTheDataGridViewUsers()
        {
            DataTable DT_AllInformationUser = UserBL.GetAllInformationUsers();

            foreach (DataRow DR_InformationOneUser in DT_AllInformationUser.Rows)
            {


                string StrActiveOrInActive = (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == 1) ? "Active" : "Inactive";

                int rowIndex = GDataGridViewUsersInformation.Rows.Add(



                                                                  DR_InformationOneUser["UserID"].ToString(),
                                                                  DR_InformationOneUser["UserFullName"].ToString(),
                                                                  DR_InformationOneUser["UserName"].ToString(),
                                                                  DR_InformationOneUser["EmailUser"].ToString(),
                                                                  StrActiveOrInActive,
                                                                  DR_InformationOneUser["RoleName"].ToString(),
                                                                  DR_InformationOneUser["LastLoginAccountDate"].ToString()




                    );


                DataGridViewRow DGVR = GDataGridViewUsersInformation.Rows[rowIndex];
                DataGridViewCell DGVC = DGVR.Cells[4];

                if (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == 1)
                    DGVC.Style.ForeColor = Color.Green;
                else DGVC.Style.ForeColor = Color.Red;

            }
        }

        private void USUsersManagmentAndRoles_Load(object sender, EventArgs e)
           => _InitalSettingTheUserManagmentCountsUsers();

        private void GGButtonAddNewUser_Click(object sender, EventArgs e)
        {
            ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());
        }
    }
}
