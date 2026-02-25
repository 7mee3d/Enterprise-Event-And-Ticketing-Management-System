using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.Main_User_Control_Users_And_Roles
{
    public partial class USUsersManagmentAndRoles : UserControl
    {


        public event EventHandler<int> ERequestToOpenTheAddNewUserUS;
        private int _IDUser;

        public USUsersManagmentAndRoles()
        {
            InitializeComponent();
            ERequestToOpenTheAddNewUserUS = null;
            _IDUser = clsEETMS_Constants.kZERO;
        }


        private int _GetTheIDUserAfterSelectionUserFromDGV()
           => (GDataGridViewUsersInformation.SelectedRows.Count > clsEETMS_Constants.kZERO ?
            Convert.ToInt32(GDataGridViewUsersInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells[clsEETMS_Constants.kZERO].Value) :
            clsEETMS_Constants.kNEGATIVE_ONE);

        private void _InitalSettingTheUserManagmentCountsUsers()
        {
            GDataGridViewUsersInformation.Rows.Clear();

            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTotalUsers(), lblTotalUsers, 5, false);
            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTheAvtiveAdmin(), lblTotalActiveAdmin, 5, false);
            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTheBlockedUser(), lblTotalBlockedAccountsUser, 5, false);

            _LoadAllDataToTheDataGridViewUsers();
            GDataGridViewUsersInformation.ClearSelection();

        }

        private void _LoadAllDataToTheDataGridViewUsers()
        {

            DataTable DT_AllInformationUser = UserBL.GetAllInformationUsers();

            foreach (DataRow DR_InformationOneUser in DT_AllInformationUser.Rows)
            {


                string StrActiveOrInActive = (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE) ? "Active" : "Inactive";

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

                if (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE)
                    DGVC.Style.ForeColor = Color.Green;
                else DGVC.Style.ForeColor = Color.Red;

            }
        }

        private void _USUsersManagmentAndRoles_Load(object sender, EventArgs e)
           => _InitalSettingTheUserManagmentCountsUsers();

        private void _GGButtonAddNewUser_Click(object sender, EventArgs e)
            => ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());

        private void _EditToolStripMenuItem_Click(object sender, EventArgs e)
            => ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());

        private void _DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to be delete This User ..?? ", "Note For the delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                if (UserBL.DeleteTheUserBy(_GetTheIDUserAfterSelectionUserFromDGV()))
                    MessageBox.Show("The User is Deleted Successfully", "Note For Delete The User");
                else MessageBox.Show("The User is Deleted Faild", "Note For Delete The User");


            _InitalSettingTheUserManagmentCountsUsers();
        }



    }
}
