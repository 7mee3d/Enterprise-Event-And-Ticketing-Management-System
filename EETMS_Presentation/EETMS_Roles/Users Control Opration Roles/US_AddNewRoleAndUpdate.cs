using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;
using static EETMS_DTOs.RoleDTO;

namespace EETMS_Presentation.EETMS_Roles.Users_Control_Opration_Roles
{
    public partial class US_AddNewRoleAndUpdate : UserControl
    {



        private enum _EnModeRole
        {
            kADD_NEW_ROLE = 1,
            kUPDATE_INFORMATION_ROLE = 2,
            kNOTHING = 3
        };

        public event EventHandler ERequestToCloseTheUSAddNewRole;
        private _EnModeRole _ModeRole;
        private int _IDRole;
        private RoleDTO _InformationNewRole;
        private Guna2MessageDialog _G2MD;

        public US_AddNewRoleAndUpdate(int IDRole)
        {
            InitializeComponent();

            _ModeRole = _EnModeRole.kNOTHING;
            _IDRole = clsEETMS_Constants.kZERO;
            _InformationNewRole = null;
            _G2MD = null;

            if (IDRole != clsEETMS_Constants.kNEGATIVE_ONE)
                _ModeRole = _EnModeRole.kUPDATE_INFORMATION_ROLE;
            else
                _ModeRole = _EnModeRole.kADD_NEW_ROLE;

            this._IDRole = IDRole;

        }

        private void GButtonCloseUSAddUpdateNewRole_Click(object sender, EventArgs e)
            => ERequestToCloseTheUSAddNewRole?.Invoke(this, EventArgs.Empty);

        private int _GetThePermssionsRole()
        {
            int PermssionsRole = clsEETMS_Constants.kZERO;

            if (GCheckBoxPDasahboard.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kDASHBOARD;

            if (GCheckBoxPEvent.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kEVENTS_MANAGMENT;

            if (GCheckBoxPCategory.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kCATEGORY_MANAGMENT;

            if (GCheckBoxPCustomer.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kCUSTOMER;

            if (GCheckBoxPResravation.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kRESERVATION;

            if (GCheckBoxPPayment.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kPAYMENT;

            if (GCheckBoxPReport.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kREPORT;

            if (GCheckBoxPUsers.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kUSERS_MANAGMENT;

            if (GCheckBoxPRoles.Checked)
                PermssionsRole += (int)RoleDTO.EnPermssionsType.kROLES_MANAGMENT;

            return PermssionsRole;

        }

        private void _CheckTheCheckBoxAccordingThePermissions(int Permssions)
        {

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kDASHBOARD))
                GCheckBoxPDasahboard.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kCATEGORY_MANAGMENT))
                GCheckBoxPCategory.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kEVENTS_MANAGMENT))
                GCheckBoxPEvent.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kCUSTOMER))
                GCheckBoxPCustomer.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kRESERVATION))
                GCheckBoxPResravation.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kPAYMENT))
                GCheckBoxPPayment.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kREPORT))
               GCheckBoxPReport.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kUSERS_MANAGMENT))
                GCheckBoxPUsers.Checked = true;

            if (RolesBL.IsPassUserPermssions(Permssions, EnPermssionsType.kROLES_MANAGMENT))
                GCheckBoxPRoles.Checked = true;

        }

        private void _loadAllInformationRole()
        {

            if (_ModeRole == _EnModeRole.kADD_NEW_ROLE)
            {
                _InformationNewRole = new RoleDTO();
                _InformationNewRole.ModeRole = EnModeRole.kADD_NEW_ROLE;
                return;

            }

            _InformationNewRole = RolesBL.FindTheRoleBy(_IDRole);

            if (_InformationNewRole == null)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Role Is Not Exsits..", "Note For Search The Role", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }

            GTextBoxRoleName.Text = _InformationNewRole.RoleName;
            GTextBoxDescripation.Text = _InformationNewRole.DescripationRole;

            _SettingTheUpdateRoleMode();
        }

        private void _SettingTheUpdateRoleMode()
        {
            _CheckTheCheckBoxAccordingThePermissions(_InformationNewRole.PermssionsRole);
            _ModeRole = _EnModeRole.kUPDATE_INFORMATION_ROLE;
            _InformationNewRole.ModeRole = EnModeRole.kUPDATE_INFORMATION_ROLE;
            GButtonCreateNewRole.Text = "Update Information Role";
            GButtonCreateNewRole.Image = Resources.Save_Icon_EETMS;
        }

        private bool _CheckAllFieldFilled()
        => (!string.IsNullOrWhiteSpace(GTextBoxRoleName.Text) && !string.IsNullOrWhiteSpace(GTextBoxDescripation.Text));

        private void _AddNewRole()
        {

            _InformationNewRole.RoleName = GTextBoxRoleName.Text;
            _InformationNewRole.DescripationRole = GTextBoxDescripation.Text;
            _InformationNewRole.PermssionsRole = _GetThePermssionsRole();



            if (_CheckAllFieldFilled())
            {

                if (RolesBL.SaveMode(_InformationNewRole))
                {
                    if (_InformationNewRole.ModeRole == EnModeRole.kADD_NEW_ROLE)
                        clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Role Is Added Sccessfully..", "Note For Add New Role.", MessageDialogButtons.OK, MessageDialogIcon.Information);
                    else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Role Is Updated Sccessfully..", "Note For Update Role.", MessageDialogButtons.OK, MessageDialogIcon.Information);

                }
            }
            else
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Please,Enter All Field To Be Add/Update!!", "Note For Add/Update Role.", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }

            GTextBoxRoleName.Text = _InformationNewRole.RoleName;
            GTextBoxDescripation.Text = _InformationNewRole.DescripationRole;
            _SettingTheUpdateRoleMode();

        }

        private void US_AddNewRoleAndUpdate_Load(object sender, EventArgs e)
            => _loadAllInformationRole();

        private void GButtonCreateNewRole_Click(object sender, EventArgs e)
            => _AddNewRole();



    }
}
