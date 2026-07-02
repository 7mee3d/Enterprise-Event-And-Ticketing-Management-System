using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_BusinessLayer.Validation;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles
{
    public partial class UC_AddNewUserAndUpdate : UserControl
    {


        public event EventHandler ERequestToTheCloseAddNewUser;
        private int _IDUser;
        private string _ImagePathUser;
        private _EnModeUser _EnMode;
        private UserDTO _InformationUser;
        private Guna2MessageDialog _G2MD;

        private enum _EnModeUser
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2,
            _kNOTHING = 3
        };



        public UC_AddNewUserAndUpdate(int id)
        {
            InitializeComponent();

            _EnMode = _EnModeUser._kNOTHING;
            _IDUser = clsEETMS_Constants.kZERO;
            ERequestToTheCloseAddNewUser = null;
            _ImagePathUser = null;
            _G2MD = null;

            if (id != clsEETMS_Constants.kNEGATIVE_ONE)
                this._EnMode = _EnModeUser._kUPDATE_INFORMATION_USER;
            else
                this._EnMode = _EnModeUser._kADD_NEW_USER;

            this._IDUser = id;
            _InformationUser = null;
        }

        private void _LoadAllInformationUserAfterLoadTheUS()
        {

            if (_EnMode == _EnModeUser._kADD_NEW_USER)
            {
                GGCButtonAddImageUser.Image = Resources.Add_Image_Icon_EETMS;
                lblTiteTheUS.Text = "Create Account";
                _InformationUser = new UserDTO();
                return;

            }

            _InformationUser = UserBL.FindUserBy(_IDUser);

            if (_InformationUser == null)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "This User Not Found in The EETMS ", "Note For Find The User", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;

            }


            GTextBoxFullName.Text = _InformationUser.UserFullName;
            GTextBoxUsername.Text = _InformationUser.Username;
            GTextBoxProfessionalEmail.Text = _InformationUser.EmailUser;
            GComboBoxRoleUser.SelectedValue = _InformationUser.RoleID;
            GTextBoxPassword.Text = _InformationUser.PasswordUser;

            if (!string.IsNullOrWhiteSpace(_InformationUser.ImagePath))
            {
                GCPictureBoxImageUser.Visible = true;
                _ImagePathUser = _InformationUser.ImagePath;
                GCPictureBoxImageUser.Image = Image.FromFile(_InformationUser.ImagePath);

            }
            else
                GGCButtonAddImageUser.Image = Resources.Add_Image_Icon_EETMS;

            _InformationUser.enMode = UserDTO.EnModeUser._kUPDATE_INFORMATION_USER;
            _EnMode = _EnModeUser._kUPDATE_INFORMATION_USER;
            GButtonCreateTheNewUser.Text = "Update Information User";
            lblTiteTheUS.Text = "Update Account";

        }


        private void _LoadAllInformationRolesToComboBox()
        {
            DataTable DT_AllInformationRoles = RolesBL.GetAllInformationRoles();

            GComboBoxRoleUser.DataSource = DT_AllInformationRoles;

            GComboBoxRoleUser.DisplayMember = "RoleName";
            GComboBoxRoleUser.ValueMember = "RoleID";
        }

        private void _AddNewUser()
        {
            Guna2MessageDialog guna2MessageDialog = new Guna2MessageDialog();

            bool FlagIsFillFullName = true;
            bool FlagIsFillUsername = true;
            bool FlagIsFillEmail = true;
            bool FlagIsFillPassword = true;
            bool FalgIsUsernameExists = true;
            string TextMessageDialog = clsEETMS_Constants.kEMPTY_STRING;


            if (!string.IsNullOrEmpty(GTextBoxFullName.Text.Trim()))
                _InformationUser.UserFullName = GTextBoxFullName.Text.Trim();
            else
            {
                TextMessageDialog += "\nPlease enter a Full Name User\n";
                FlagIsFillFullName = false;
            }



            bool IsExists = UserBL.IsUserExistsBy(GTextBoxUsername.Text.Trim());


            if (_EnMode == _EnModeUser._kUPDATE_INFORMATION_USER)
            {
                if (GTextBoxUsername.Text.Trim() != _InformationUser.Username && IsExists)
                {
                    TextMessageDialog += "\nThis Username Already Exists , Please enter another username\n";
                    FalgIsUsernameExists = false;
                }
                else
                    FalgIsUsernameExists = true;
            }
            else
            {
                if (IsExists)
                {
                    TextMessageDialog += "\nThis Username Already Exists , Please enter another username\n";
                    FalgIsUsernameExists = false;
                }
                else
                    FalgIsUsernameExists = true;
            }

            if (FalgIsUsernameExists)
                if (!string.IsNullOrEmpty(GTextBoxUsername.Text.Trim()) && !clsValidation.IsTheUsernameStartedDigits((GTextBoxUsername.Text)[0]))
                    _InformationUser.Username = GTextBoxUsername.Text.Trim();
                else
                {
                    TextMessageDialog += "\nPlease enter a Username Without the Space , Without Start Any Digits\n";
                    FlagIsFillUsername = false;
                }

            else FlagIsFillUsername = false;

            if (clsValidation.IsValidEmailAddress(GTextBoxProfessionalEmail.Text.Trim()))
            {
                if (_EnMode == _EnModeUser._kADD_NEW_USER)
                {
                    if (!UserBL.IsEmailExists(GTextBoxProfessionalEmail.Text.Trim()))
                        _InformationUser.EmailUser = GTextBoxProfessionalEmail.Text.Trim();
                    else
                    {
                        TextMessageDialog += "\nThis Email Already Exists\n";
                        FlagIsFillEmail = false;
                    }
                }
                else
                    _InformationUser.EmailUser = GTextBoxProfessionalEmail.Text.Trim();
            }
            else

            {

                TextMessageDialog += "\nPlease enter a valid email address\n";
                FlagIsFillEmail = false;
            }



            if (clsValidation.IsHasTheSymbolAndNumberAndLetters(GTextBoxPassword.Text.Trim()))
            {
                _InformationUser.PasswordUser = GTextBoxPassword.Text.Trim();
            }
            else
            {
                FlagIsFillPassword = false;
                TextMessageDialog += "\n\nPassword must contain:\n" +
                    "• Uppercase letter\n" +
                    "• Lowercase letter\n" +
                    "• Digit\n" +
                    "• Symbol\n";
            }


            if (!FlagIsFillFullName || !FlagIsFillUsername || !FlagIsFillEmail || !FlagIsFillPassword || !FalgIsUsernameExists)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, TextMessageDialog, "Invalid Data!", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }


            _InformationUser.RoleID = Convert.ToInt32(GComboBoxRoleUser.SelectedValue);
            _InformationUser.ImagePath = _ImagePathUser != null ? _ImagePathUser : null;
            _InformationUser.IsActiveAccount = true;
            _InformationUser.NumberAttempts = 3;



            if (UserBL.SaveInformationUserMode(_InformationUser))
            {
                if (_EnMode == _EnModeUser._kADD_NEW_USER) clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The User Added Sccessfully..", "Note For Add new user", MessageDialogButtons.OK, MessageDialogIcon.Information);
                else if (_EnMode == _EnModeUser._kUPDATE_INFORMATION_USER) clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The User Updated Information Sccessfully..", "Note For Update Information user", MessageDialogButtons.OK, MessageDialogIcon.Information);

            }

            GTextBoxFullName.Text = _InformationUser.UserFullName;
            GTextBoxUsername.Text = _InformationUser.Username;
            GTextBoxProfessionalEmail.Text = _InformationUser.EmailUser;
            GComboBoxRoleUser.SelectedItem = _InformationUser.RoleID;
            GTextBoxPassword.Text = _InformationUser.PasswordUser;

            if (_InformationUser.ImagePath != null)
            {
                GCPictureBoxImageUser.Image = Image.FromFile(_InformationUser.ImagePath);
            }

            _InformationUser.enMode = UserDTO.EnModeUser._kUPDATE_INFORMATION_USER;
            _EnMode = _EnModeUser._kUPDATE_INFORMATION_USER;
            GButtonCreateTheNewUser.Text = "Update Information User";
            lblTiteTheUS.Text = "Update Account";

        }

        private void _GetTheImageUser()
        {

            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Filter = "ALL TYPE IMAGE|*.png;*.jpeg|PNG IMAGE|*.png|JPEG IMAGE|*.jpeg";
            OFD.Title = "Select The Image User";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                _ImagePathUser = OFD.FileName;

            }

            try
            {
                if (_ImagePathUser != null)
                {

                    GCPictureBoxImageUser.Visible = true;
                    GGCButtonAddImageUser.Visible = false;
                    GCPictureBoxImageUser.Load(_ImagePathUser);
                    _InformationUser.ImagePath = _ImagePathUser;

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void GButtonClose_Click(object sender, EventArgs e)
           => ERequestToTheCloseAddNewUser?.Invoke(this, EventArgs.Empty);

        private void USAddNewUserAndUpdate_Load(object sender, EventArgs e)
        {
            _LoadAllInformationRolesToComboBox();
            _LoadAllInformationUserAfterLoadTheUS();
        }

        private void GGCButtonAddImageUser_Click(object sender, EventArgs e)
        {
            if (_ImagePathUser == null || _InformationUser.ImagePath == null)
            {
                _GetTheImageUser();
            }
            else
            {

                GGCButtonAddImageUser.Image = null;
                _InformationUser.ImagePath = null;
                _ImagePathUser = null;

                GGCButtonAddImageUser.Image = Resources.Add_Image_Icon_EETMS;

            }
        }

        private void GButtonCreateTheNewUser_Click(object sender, EventArgs e)
            => _AddNewUser();

        private void GCPictureBoxImageUser_MouseEnter(object sender, EventArgs e)
        {
            bool HasImage = _InformationUser.ImagePath != null && _ImagePathUser != null;

            if (HasImage)
            {

                GCPictureBoxImageUser.Visible = false;
                GGCButtonAddImageUser.Visible = true;

                GGCButtonAddImageUser.Image = (HasImage) ? Resources.Remove_image_Icon_EETMS : Resources.Add_Image_Icon_EETMS;
            }



            GGCButtonAddImageUser.BringToFront();


        }

        private void GGCButtonAddImageUser_MouseEnter(object sender, EventArgs e)
            => GCPictureBoxImageUser.Visible = false;

        private void GGCButtonAddImageUser_MouseLeave(object sender, EventArgs e)
        {

            bool NotHasImage = _InformationUser.ImagePath == null && _ImagePathUser == null;

            if (_InformationUser.ImagePath != null && _ImagePathUser != null)
            {
                GCPictureBoxImageUser.Visible = true;
                GCPictureBoxImageUser.Image = Image.FromFile(_InformationUser.ImagePath);
                GGCButtonAddImageUser.Visible = false;
            }
            else
            {
                GCPictureBoxImageUser.Visible = false;
                GGCButtonAddImageUser.Image = (NotHasImage) ? Resources.Add_Image_Icon_EETMS : Resources.Remove_image_Icon_EETMS;
            }
        }

        private void GTextBoxFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void GTextBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar));
        }

        private void GTextBoxProfessionalEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsPunctuation(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
    }
}

