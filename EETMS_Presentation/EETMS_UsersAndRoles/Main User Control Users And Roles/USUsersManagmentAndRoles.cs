using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
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
        private Guna2MessageDialog _G2MD;

        public USUsersManagmentAndRoles()
        {
            InitializeComponent();
            ERequestToOpenTheAddNewUserUS = null;
            _IDUser = clsEETMS_Constants.kZERO;
            _G2MD = null;
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

            _LoadAllInformationUsersToTheDGV();
            GDataGridViewUsersInformation.ClearSelection();

        }

        private string _GetTheWordLastLogin(int NumberOfDayLastLogin)
        {

            if (NumberOfDayLastLogin == clsEETMS_Constants.kNEGATIVE_ONE)
                return "For a long time";
            else if (NumberOfDayLastLogin == clsEETMS_Constants.kZERO)
                return "Today";
            else if (NumberOfDayLastLogin == clsEETMS_Constants.kONE)
                return "Yestarday";

            return NumberOfDayLastLogin.ToString() + " Day ago";
        }

        private void _LoadAllDataToTheDataGridViewUsers(DataTable DT_InformationUsers)
        {

            foreach (DataRow DR_InformationOneUser in DT_InformationUsers.Rows)
            {


                string StrActiveOrInActive = (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE) ? "Active" : "Inactive";


                int rowIndex = GDataGridViewUsersInformation.Rows.Add(



                                                                  DR_InformationOneUser["UserID"].ToString(),
                                                                  DR_InformationOneUser["UserFullName"].ToString(),
                                                                  DR_InformationOneUser["UserName"].ToString(),
                                                                  DR_InformationOneUser["EmailUser"].ToString(),
                                                                  StrActiveOrInActive,
                                                                  DR_InformationOneUser["RoleName"].ToString(),
                                                                  _GetTheWordLastLogin(Convert.ToInt32(DR_InformationOneUser["LastLoginForDay"] != DBNull.Value ? DR_InformationOneUser["LastLoginForDay"] : -1))




                    );


                DataGridViewRow DGVR = GDataGridViewUsersInformation.Rows[rowIndex];
                DataGridViewCell DGVC = DGVR.Cells[4];

                DataGridViewRow DGVR_LastLogin = GDataGridViewUsersInformation.Rows[rowIndex];
                DataGridViewCell DGVC_LastLogin = DGVR.Cells[6];

                if (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE)
                    DGVC.Style.ForeColor = Color.Green;
                else DGVC.Style.ForeColor = Color.Red;

                DGVC_LastLogin.Style.ForeColor = Color.FromArgb(100, 116, 139);

            }
        }

        private void _LoadAllInformationUsersToTheDGV()
        {
            DataTable DT_AllInformationUser = UserBL.GetAllInformationUsers();
            _LoadAllDataToTheDataGridViewUsers(DT_AllInformationUser);
        }

        private void _USUsersManagmentAndRoles_Load(object sender, EventArgs e)
           => _InitalSettingTheUserManagmentCountsUsers();

        private void _GGButtonAddNewUser_Click(object sender, EventArgs e)
            => ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());

        private void _EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            if (UserID != clsEETMS_Constants.kNEGATIVE_ONE)
                ERequestToOpenTheAddNewUserUS?.Invoke(this, UserID);
            else
            {
                _G2MD = new Guna2MessageDialog();
                _G2MD.Icon = MessageDialogIcon.Warning;
                _G2MD.Caption = "Important Note ...";
                _G2MD.Text = "You Must Selected The User From List To Be Updated information.";

                _G2MD.Show();
            }
        }

        private void _DeleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            if (UserID != clsEETMS_Constants.kNEGATIVE_ONE)
            {
                if (MessageBox.Show("Are you sure to be delete This User ..?? ", "Note For the delete user", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    if (UserBL.DeleteTheUserBy(_GetTheIDUserAfterSelectionUserFromDGV()))
                    {
                        MessageBox.Show("The User is Deleted Successfully", "Note For Delete The User");
                        _InitalSettingTheUserManagmentCountsUsers();
                    }
                    else MessageBox.Show("The User is Deleted Faild", "Note For Delete The User");
            }
            else
            {
                _G2MD = new Guna2MessageDialog();
                _G2MD.Icon = MessageDialogIcon.Warning;
                _G2MD.Caption = "Important Note ...";
                _G2MD.Text = "You Must Selected The User From List To Be Delete.";

                _G2MD.Show();
            }


        }

        private void _ActiveAndInactiveTheUser()
        {

            Guna2MessageDialog G2MD = new Guna2MessageDialog();

            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            UserDTO mUser = UserBL.FindUserBy(UserID);

            if (mUser != null)
            {
                G2MD.Icon = MessageDialogIcon.Question;
                G2MD.Caption = "Note. For The Inactive/Active This User";

                if (mUser.IsActiveAccount)
                    G2MD.Text = "Are You Sure Inactive This User";
                else G2MD.Text = "Are You Sure Active This User";

                G2MD.Buttons = MessageDialogButtons.OKCancel;

                if (G2MD.Show() == DialogResult.Yes)
                {
                    if (mUser.IsActiveAccount)
                        mUser.IsActiveAccount = false;
                    else mUser.IsActiveAccount = true;

                    if (UserBL.SaveInformationUserMode(mUser, true))
                    {
                        if (mUser.IsActiveAccount)
                            G2MD.Text = "The User is Active Successfully";
                        else G2MD.Text = "The User is Inactive Successfully";

                        _InitalSettingTheUserManagmentCountsUsers();

                    }
                    else
                    {
                        G2MD.Icon = MessageDialogIcon.Error;
                        if (mUser.RoleID == clsEETMS_Constants.kONE)
                        {

                            G2MD.Text = "The User is Inactive/Active Faild , Because The User is Admin .";
                        }
                        else
                            G2MD.Text = "The User is Inactive Faild";
                    }



                    G2MD.Show();
                }
            }
            else
            {
                G2MD.Caption = "Invalid Select From List User!!";
                G2MD.Icon = MessageDialogIcon.Error;
                G2MD.Text = "Please Select The User In The List To Be Inactive/Active User . ";

                G2MD.Show();
            }
        }

        private void InactiveUsertoolStripMenuItem_Click(object sender, EventArgs e)
           => _ActiveAndInactiveTheUser();

        private void _LoadAllInformationUserAfterTheSearchByNameOrUsername()
        {
            GDataGridViewUsersInformation.Rows.Clear();

            string TextSearchTheUserByNameOrUsername = GTextBoxSearchTheUser.Text.Trim();

            DataTable DT_AllUsersAfterSearch = UserBL.GetAllUsersAfterSearchBy(TextSearchTheUserByNameOrUsername);
            _LoadAllDataToTheDataGridViewUsers(DT_AllUsersAfterSearch);

        }

        private void GTextBoxSearchTheUser_TextChanged(object sender, EventArgs e)
            => _LoadAllInformationUserAfterTheSearchByNameOrUsername();

    }
}

