using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_BusinessLayer.Validation;
using EETMS_Models;
using EETMS_Presentation.Properties;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles
{
    public partial class USAddNewUserAndUpdate : UserControl
    {


        public event EventHandler ERequestToTheCloseAddNewUser;
        private int _IDUser;
        private string _ImagePathUser;
        private _EnModeUser _EnMode;
        private MUser _InformationUser;

        private enum _EnModeUser
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2,
            _kNOTHING = 3
        };

        public USAddNewUserAndUpdate(int id)
        {
            InitializeComponent();

            _EnMode = _EnModeUser._kNOTHING;
            _IDUser = clsEETMS_Constants.kZERO;
            ERequestToTheCloseAddNewUser = null;
            _ImagePathUser = null;


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
                lblTiteTheUS.Text = "Create Account";
                _InformationUser = new MUser();
                return;

            }


            _InformationUser = UserBL.FindUserBy(_IDUser);

            if (_InformationUser == null)
            {
                MessageBox.Show("This User Not Found in The EETMS ", "Note For Find The User");
                return;

            }


            GTextBoxFullName.Text = _InformationUser.UserFullName;
            GTextBoxUsername.Text = _InformationUser.Username;
            GTextBoxProfessionalEmail.Text = _InformationUser.EmailUser;
            GComboBoxRoleUser.SelectedValue = _InformationUser.RoleID;
            GTextBoxPassword.Text = _InformationUser.PasswordUser;

            if (_InformationUser.ImagePath != null)
            {
                GCPictureBoxImageUser.Visible = true;
                _ImagePathUser = _InformationUser.ImagePath;
                GCPictureBoxImageUser.Image = Image.FromFile(_InformationUser.ImagePath);

            }
            else
            {
                GGCButtonAddImageUser.Image = Resources.Add_New_Photo_NoFill_Icon_EETMS;

            }

            _InformationUser.enMode = MUser.EnModeUser._kUPDATE_INFORMATION_USER;
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
            string TextMessageDialog = clsEETMS_Constants.kEMPTY_STRING;


            if (!string.IsNullOrEmpty(GTextBoxFullName.Text))

                _InformationUser.UserFullName = GTextBoxFullName.Text;
            else
            {
                TextMessageDialog += "\nPlease enter a Full Name User\n";
                FlagIsFillFullName = false;
            }


            if (!string.IsNullOrEmpty(GTextBoxUsername.Text) && !clsValidation.IsTheUsernameStartedDigits((GTextBoxUsername.Text)[0]))
                _InformationUser.Username = GTextBoxUsername.Text;
            else
            {
                TextMessageDialog += "\nPlease enter a Username Without the Space , Without Start Any Digits\n";
                FlagIsFillUsername = false;
            }



            if (clsValidation.IsValidEmailAddress(GTextBoxProfessionalEmail.Text))

                _InformationUser.EmailUser = GTextBoxProfessionalEmail.Text;
            else
            {

                TextMessageDialog += "\nPlease enter a valid email address\n";
                FlagIsFillEmail = false;
            }



            if (clsValidation.IsHasTheSymbolAndNumberAndLetters(GTextBoxPassword.Text))
            {
                _InformationUser.PasswordUser = GTextBoxPassword.Text;
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


            if (!FlagIsFillFullName || !FlagIsFillUsername || !FlagIsFillEmail || !FlagIsFillPassword)
            {

                guna2MessageDialog.Icon = MessageDialogIcon.Error;
                guna2MessageDialog.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog.Caption = "Invalid Data!";
                guna2MessageDialog.Text = TextMessageDialog;
                guna2MessageDialog.Show();

                return;
            }


            _InformationUser.RoleID = Convert.ToInt32(GComboBoxRoleUser.SelectedValue);
            _InformationUser.ImagePath = _ImagePathUser != null ? _ImagePathUser : null;


            if (UserBL.SaveInformationUserMode(_InformationUser))
            {
                if (_EnMode == _EnModeUser._kADD_NEW_USER) MessageBox.Show("Add Sccessfuly");
                else if (_EnMode == _EnModeUser._kUPDATE_INFORMATION_USER) MessageBox.Show("Update Sccessfuly ");

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

            _InformationUser.enMode = MUser.EnModeUser._kUPDATE_INFORMATION_USER;
            _EnMode = _EnModeUser._kUPDATE_INFORMATION_USER;
            GButtonCreateTheNewUser.Text = "Update Information User";
            lblTiteTheUS.Text = "Update Account";

        }

        private void _GetTheImageUser()
        {

            OpenFileDialog OFD = new OpenFileDialog();

            OFD.Filter = "PNG IMAGE|*.png|JPGE IMAGE|jpge.*";
            OFD.Title = "Select The Image User";

            if (OFD.ShowDialog() == DialogResult.OK)
            {
                _ImagePathUser = OFD.FileName;

            }

            if (_ImagePathUser != null)
            {

                GCPictureBoxImageUser.Visible = true;
                GGCButtonAddImageUser.Visible = false;
                GCPictureBoxImageUser.Image = Image.FromFile(_ImagePathUser);
                _InformationUser.ImagePath = _ImagePathUser;

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

                GGCButtonAddImageUser.Image = Resources.Add_New_Photo_NoFill_Icon_EETMS;

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

                GGCButtonAddImageUser.Image = (HasImage) ? Resources.Remove_Image_Icon_EETMS : Resources.Add_New_Photo_NoFill_Icon_EETMS;
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
                GGCButtonAddImageUser.Image = (NotHasImage) ? Resources.Add_New_Photo_NoFill_Icon_EETMS : Resources.Remove_Image_Icon_EETMS;
            }
        }

    }
}

