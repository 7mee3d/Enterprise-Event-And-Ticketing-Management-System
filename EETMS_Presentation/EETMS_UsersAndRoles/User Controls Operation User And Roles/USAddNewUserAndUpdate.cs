using EETMS_BusinessLayer;
using EETMS_Models;
using EETMS_Presentation.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles
{
    public partial class USAddNewUserAndUpdate : UserControl
    {
        public event EventHandler ERequestToTheCloseAddNewUser = null;
        int _IDUser = 0;
        private string _ImagePathUser = null;

        private enum _EnModeUser
        {
            _kADD_NEW_USER = 1,
            _kUPDATE_INFORMATION_USER = 2
        };

        private _EnModeUser _EnMode;
        private MUser _InformationUser = null;

        public USAddNewUserAndUpdate(int id)
        {
            InitializeComponent();

            if (id != -1)
                this._EnMode = _EnModeUser._kUPDATE_INFORMATION_USER;
            else
                this._EnMode = _EnModeUser._kADD_NEW_USER;

            this._IDUser = id;
        }



        private void _LoadAllInformationUserAfterLoadTheUS()
        {

            if (_EnMode == _EnModeUser._kADD_NEW_USER)
            {
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
            GComboBoxRoleUser.SelectedItem = _InformationUser.RoleID;
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


        }

        private void _AddNewUser()
        {

            _InformationUser.UserFullName = GTextBoxFullName.Text;
            _InformationUser.Username = GTextBoxUsername.Text;
            _InformationUser.EmailUser = GTextBoxProfessionalEmail.Text;
            _InformationUser.PasswordUser = GTextBoxPassword.Text;
            _InformationUser.RoleID =/* Convert.ToInt32(GComboBoxRoleUser.SelectedItem)*/ 2;
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
        {
            ERequestToTheCloseAddNewUser?.Invoke(this, EventArgs.Empty);

        }

        private void USAddNewUserAndUpdate_Load(object sender, EventArgs e)
        {
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

                MessageBox.Show("Remove Mode");

                GGCButtonAddImageUser.Image = Resources.Add_New_Photo_NoFill_Icon_EETMS;

            }
        }

        private void GButtonCreateTheNewUser_Click(object sender, EventArgs e)
        {
            _AddNewUser();
        }

        /*   private void GCPictureBoxImageUser_MouseLeave(object sender, EventArgs e)
           {
               string Path =
                   _ImagePathUser ?? _InformationUser.ImagePath;

               if (Path != null)
               {
                   GGCButtonAddImageUser.Visible = false;
                   GCPictureBoxImageUser.Visible = true;

                   using (var imgTemp = Image.FromFile(Path))
                   {
                       GCPictureBoxImageUser.Image = new Bitmap(imgTemp);
                   }
               }
           }
           */

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
        {
            GCPictureBoxImageUser.Visible = false;
        }

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

