using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
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
        private bool _IsCheckButtonFilter;

        public USUsersManagmentAndRoles()
        {
            InitializeComponent();
            ERequestToOpenTheAddNewUserUS = null;
            _IDUser = clsEETMS_Constants.kZERO;
            _G2MD = null;
            _IsCheckButtonFilter = false;
        }


        private int _GetTheIDUserAfterSelectionUserFromDGV()
           => (GDataGridViewUsersInformation.SelectedRows.Count > clsEETMS_Constants.kZERO ?
            Convert.ToInt32(GDataGridViewUsersInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells[clsEETMS_Constants.kZERO].Value) :
            clsEETMS_Constants.kNEGATIVE_ONE);

        private void _InitalSettingTheUserManagmentCountsUsers()
        {
            GDataGridViewUsersInformation.Rows.Clear();

            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTotalUsers(), lblTotalUsers, clsEETMS_Constants.kMAX_NUMBER_DELAY_USER_US, false);
            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTheAvtiveAdmin(), lblTotalActiveAdmin, clsEETMS_Constants.kMAX_NUMBER_DELAY_USER_US, false);
            clsEETMS_SettingPresentation._AnimationLables(UserBL.GetTheBlockedUser(), lblTotalBlockedAccountsUser, clsEETMS_Constants.kMAX_NUMBER_DELAY_USER_US, false);

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


                string StrActiveOrInActive = (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE && Convert.ToInt32(DR_InformationOneUser["NumberAttempts"]) != 0) ? "Active" : "Inactive";


                int rowIndex = GDataGridViewUsersInformation.Rows.Add(



                                                                  DR_InformationOneUser["UserID"].ToString(),
                                                                  DR_InformationOneUser["UserFullName"].ToString(),
                                                                  DR_InformationOneUser["UserName"].ToString(),
                                                                  DR_InformationOneUser["EmailUser"].ToString(),
                                                                  DR_InformationOneUser["RoleName"].ToString(),
                                                                  StrActiveOrInActive,
                                                                  _GetTheWordLastLogin(Convert.ToInt32(DR_InformationOneUser["LastLoginForDay"] != DBNull.Value ? DR_InformationOneUser["LastLoginForDay"] : -1))




                    );


                DataGridViewRow DGVR = GDataGridViewUsersInformation.Rows[rowIndex];
                DataGridViewCell DGVC = DGVR.Cells[5];

                DataGridViewRow DGVR_LastLogin = GDataGridViewUsersInformation.Rows[rowIndex];
                DataGridViewCell DGVC_LastLogin = DGVR.Cells[6];

                if (Convert.ToInt32(DR_InformationOneUser["ActiveAccount"]) == clsEETMS_Constants.kONE && Convert.ToInt32(DR_InformationOneUser["NumberAttempts"]) != 0)
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
        {
            _InitalSettingTheUserManagmentCountsUsers();
            GComboBoxMainTypeFilter.Items.Clear();

            GComboBoxMainTypeFilter.Items.Add("Status");
            GComboBoxMainTypeFilter.Items.Add("Roles");
            GComboBoxMainTypeFilter.Items.Add("Last Login For Day");
        }

        private void _GGButtonAddNewUser_Click(object sender, EventArgs e)
            => ERequestToOpenTheAddNewUserUS?.Invoke(this, _GetTheIDUserAfterSelectionUserFromDGV());

        private void _ActiveAndInactiveTheUser()
        {

            string TextMessage = clsEETMS_Constants.kEMPTY_STRING;
            string CaptionMessage = clsEETMS_Constants.kEMPTY_STRING;

            MessageDialogIcon MDI = new MessageDialogIcon();
            MessageDialogButtons MDB = new MessageDialogButtons();

            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            bool IsActiveOrAttempts = false;

            UserDTO mUser = UserBL.FindUserBy(UserID);

            if (mUser != null)
            {
                MDI = MessageDialogIcon.Question;
                CaptionMessage = "Note. For The Inactive/Active This User";

                if (mUser.NumberAttempts == 0 && mUser.IsActiveAccount)
                {
                    TextMessage = "Are You Sure Active This User";
                }
                else
                {
                    if (mUser.IsActiveAccount)
                        TextMessage = "Are You Sure Inactive This User";
                    else TextMessage = "Are You Sure Active This User";
                }

                MDB = MessageDialogButtons.OKCancel;

                if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, TextMessage, CaptionMessage, MDB, MDI))
                {
                    mUser.enMode = UserDTO.EnModeUser._kUPDATE_INFORMATION_USER;

                    if (mUser.NumberAttempts == 0 && mUser.IsActiveAccount )
                    {
                        mUser.NumberAttempts = 3;
                        IsActiveOrAttempts = true;
                    }
                    else if (mUser.NumberAttempts == 0 && !mUser.IsActiveAccount)
                    {
                        mUser.NumberAttempts = 3;
                        mUser.IsActiveAccount = true;
                    }
                    else
                    {

                        if (mUser.IsActiveAccount)
                            mUser.IsActiveAccount = false;
                        else mUser.IsActiveAccount = true;
                    }

                    if (UserBL.SaveInformationUserMode(mUser, true))
                    {
                        if (IsActiveOrAttempts)
                        {
                            TextMessage = "The User is Active Successfully";
                        }
                        else
                        {
                            if (mUser.IsActiveAccount) TextMessage = "The User is Active Successfully";
                            else TextMessage = "The User is Inactive Successfully";
                        }

                        _InitalSettingTheUserManagmentCountsUsers();

                    }
                    else
                    {

                        MDI = MessageDialogIcon.Error;
                        if (mUser.RoleID == clsEETMS_Constants.kONE)
                        {

                            TextMessage = "The User is Inactive/Active Faild , Because The User is Admin .";
                        }
                        else
                            TextMessage = "The User is Inactive Failed";
                    }

                    MDB = MessageDialogButtons.OK;
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, TextMessage, CaptionMessage, MDB, MDI);



                }
            }
            else
            {
                CaptionMessage = "Invalid Select From List User!!";
                MDI = MessageDialogIcon.Error;
                TextMessage = "Please Select The User In The List To Be Inactive/Active User . ";

                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, TextMessage, CaptionMessage, MDB, MDI);

            }
        }

        private void _LoadAllInformationUserAfterTheSearchByNameOrUsername()
        {
            GDataGridViewUsersInformation.Rows.Clear();

            string TextSearchTheUserByNameOrUsername = GTextBoxSearchTheUser.Text.Trim();

            DataTable DT_AllUsersAfterSearch = UserBL.GetAllUsersAfterSearchBy(TextSearchTheUserByNameOrUsername);
            _LoadAllDataToTheDataGridViewUsers(DT_AllUsersAfterSearch);

        }

        private void GTextBoxSearchTheUser_TextChanged(object sender, EventArgs e)
            => _LoadAllInformationUserAfterTheSearchByNameOrUsername();

        private void _LoadAllInformationTypeStatusUserToComboBox()
        {
            GSubComboBoxTypeTheFilter.DataSource = null;
            GSubComboBoxTypeTheFilter.DataSource = UserBL.GetAllStatusType();
            GSubComboBoxTypeTheFilter.DisplayMember = "TypeStatusUser";
            GSubComboBoxTypeTheFilter.ValueMember = "TypeStatusUser";
        }

        private void _LoadAllInformationRoleNameToComboBox()
        {
            GSubComboBoxTypeTheFilter.DataSource = null;
            GSubComboBoxTypeTheFilter.DataSource = RolesBL.GetAllRoleName();
            GSubComboBoxTypeTheFilter.DisplayMember = "RoleName";
        }

        private void _LoadAllInformationLgoinForDaysToComboBox()
        {
            GSubComboBoxTypeTheFilter.DataSource = null;

            GSubComboBoxTypeTheFilter.Items.Add("Today");
            GSubComboBoxTypeTheFilter.Items.Add("Last 7 Days");
            GSubComboBoxTypeTheFilter.Items.Add("Last 30 Days");

        }

        private void _LoadAllInformationToComboBoxies()
        {

            if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kZERO)
            {
                _LoadAllInformationTypeStatusUserToComboBox();
            }
            else if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kONE)
                _LoadAllInformationRoleNameToComboBox();
            else _LoadAllInformationLgoinForDaysToComboBox();

        }

        private void _InitalSettingTheComboBoxies()
        {

            GDataGridViewUsersInformation.Rows.Clear();

            GComboBoxMainTypeFilter.SelectedIndex = clsEETMS_Constants.kNEGATIVE_ONE;
            GSubComboBoxTypeTheFilter.SelectedIndex = clsEETMS_Constants.kNEGATIVE_ONE;

            if (GComboBoxMainTypeFilter.Items.Count <= clsEETMS_Constants.kZERO)
                GComboBoxMainTypeFilter.Items.Clear();


            if (GSubComboBoxTypeTheFilter.Items.Count <= clsEETMS_Constants.kZERO)
                GSubComboBoxTypeTheFilter.Items.Clear();

            _LoadAllInformationUsersToTheDGV();
        }

        private void _ActiveTheFilter()
        {

            if (_IsCheckButtonFilter)
            {
                GGButtonFilter.HoverState.Image = Resources.Filter_Icon_EETMS;
                GGButtonFilter.Image = Resources.Filter_Icon_EETMS;
                GGMainPanelFilter.Visible = false;
                _IsCheckButtonFilter = false;
                GGButtonFilter.Text = "Filter";

                _InitalSettingTheComboBoxies();
            }
            else
            {
                GGButtonFilter.HoverState.Image = Resources.Cancel_Icon_EETMS;
                GGButtonFilter.Image = Resources.Cancel_Icon_EETMS;
                GGMainPanelFilter.Visible = true;
                _IsCheckButtonFilter = true;
                GGButtonFilter.Text = "Cancel";

            }


        }

        private void _FillTheInformationFilter()
        {
            DataTable DT_ResultFilter = null;
            int NumberDay = clsEETMS_Constants.kZERO;
            string SubSelectComboBoxTypeFilter = clsEETMS_Constants.kEMPTY_STRING;


            try
            {

                string MainSelectComboBoxTypeFilter = GComboBoxMainTypeFilter.SelectedItem.ToString();
                if (MainSelectComboBoxTypeFilter == "Last Login For Day")
                    SubSelectComboBoxTypeFilter = GSubComboBoxTypeTheFilter.SelectedItem.ToString();
                else SubSelectComboBoxTypeFilter = GSubComboBoxTypeTheFilter.SelectedValue.ToString();

                if (MainSelectComboBoxTypeFilter == "Last Login For Day")
                {
                    if (SubSelectComboBoxTypeFilter == "Today") NumberDay = clsEETMS_Constants.kZERO;
                    else if (SubSelectComboBoxTypeFilter == "Last 7 Days") NumberDay = clsEETMS_Constants.kNUMBER_DAY_LAST_LOGIN_SEVEN_DAY;
                    else NumberDay = clsEETMS_Constants.kNUMBER_DAY_LAST_LOGIN_THIRDTY_DAY;

                    SubSelectComboBoxTypeFilter = NumberDay.ToString();

                }


                UserFilterDTO userFilterDTO = new UserFilterDTO()
                {
                    MainNameFilter = MainSelectComboBoxTypeFilter,
                    SubFilter = SubSelectComboBoxTypeFilter
                };


                DT_ResultFilter = UserBL.GetTheUsersAccordingSelectFilter(userFilterDTO);

            }
            catch (Exception ex) { }
            ;

            GDataGridViewUsersInformation.Rows.Clear();

            if (DT_ResultFilter != null)
                _LoadAllDataToTheDataGridViewUsers(DT_ResultFilter);
        }

        private void GGButtonFilter_Click(object sender, EventArgs e)
            => _ActiveTheFilter();

        private void GComboBoxMainTypeFilter_SelectionChangeCommitted(object sender, EventArgs e)
            => _LoadAllInformationToComboBoxies();

        private void GSubComboBoxTypeTheFilter_SelectionChangeCommitted(object sender, EventArgs e)
            => _FillTheInformationFilter();

        private void changeActiveToolStripMenuItem_Click(object sender, EventArgs e)
            => _ActiveAndInactiveTheUser();

        private void deleteEventToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            if (UserID != clsEETMS_Constants.kNEGATIVE_ONE)
            {


                if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Are you sure to be delete This User ..?? ", "Note For the delete user", MessageDialogButtons.YesNo, MessageDialogIcon.Question))
                    if (UserBL.DeleteTheUserBy(_GetTheIDUserAfterSelectionUserFromDGV()))
                    {
                        clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The User is Deleted Successfully", "Note For Delete The User", MessageDialogButtons.YesNo, MessageDialogIcon.Information);
                        _InitalSettingTheUserManagmentCountsUsers();
                    }
                    else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The User is Deleted Faild", "Note For Delete The User", MessageDialogButtons.OK, MessageDialogIcon.Error);

            }
            else
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "You Must Selected The User From List To Be Delete.", "Important Note ...", MessageDialogButtons.OK, MessageDialogIcon.Warning);

        }

        private void editEventToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = _GetTheIDUserAfterSelectionUserFromDGV();

            if (UserID != clsEETMS_Constants.kNEGATIVE_ONE)
                ERequestToOpenTheAddNewUserUS?.Invoke(this, UserID);
            else
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "You Must Selected The User From List To Be Updated information.", "Important Note ...", MessageDialogButtons.OK, MessageDialogIcon.Warning);
        }
    }
}

