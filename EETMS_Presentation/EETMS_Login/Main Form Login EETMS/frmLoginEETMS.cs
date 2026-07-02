using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Main;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using EETMS_DTOs;
using EETMS_Presentation.Properties;

namespace EETMS_Presentation
{
    public partial class frmLoginEETMS : Form
    {

        private bool _IsAnimating;

        public frmLoginEETMS()
        {
            InitializeComponent();
            _IsAnimating = false;
        }

        private void _MakeTheLoginScreenCenterPosition()
        {

            int X_Axis = ((Screen.PrimaryScreen.Bounds.Width - this.Width) / clsEETMS_Constants.kNUMBER_TWO_OF_HALF_PRIMARY_SCREEN);
            int Y_Axis = ((Screen.PrimaryScreen.Bounds.Height - this.Height) / clsEETMS_Constants.kNUMBER_TWO_OF_HALF_PRIMARY_SCREEN);

            this.Location = new Point(X_Axis, Y_Axis);
            this.Size = new Size(clsEETMS_Constants.kNUMBER_WIDTH_LOGIN_SCREEN, clsEETMS_Constants.kNUMBER_HEIGTH_LOGIN_SCREEN);

        }

        private async Task _AniMessageLoginScreen(Label ObjLabel, string Context, Color? ForeColor = null)
        {
            if (_IsAnimating) return;
            _IsAnimating = true;

            ObjLabel.Visible = true;
            ObjLabel.ForeColor = ForeColor ?? Color.Black;
            ObjLabel.Text = Context;

            for (int i = clsEETMS_Constants.kZERO; i <= clsEETMS_Constants.kNUMBER_TOP_SHOW_KMESSAGE; i++)
            {
                ObjLabel.Location = new Point(clsEETMS_Constants.kNUMBER_OF_WIDTH_LABEL_ANIMATION, clsEETMS_Constants.kNUMBER_OF_HEIGTH_LABEL_ANIMATION - i);
                await Task.Delay(5);
            }

            await Task.Delay(clsEETMS_Constants.kNUMBER_OF_DELAY_LABEL_ANIMATION_LOGIN_SCREEN);
            ObjLabel.Visible = false;
            ObjLabel.Location = new Point(clsEETMS_Constants.kNUMBER_OF_WIDTH_LABEL_ANIMATION, clsEETMS_Constants.kORIGNIAL_TOP_LABLEL_SHOW_MESSAGE);

            _IsAnimating = false;
        }

        private void OpenMainScreenEETMS(string Username)
        {

            frmMainScreenEETMS frm_MS_EETMS = new frmMainScreenEETMS(Username);
            frm_MS_EETMS.Show();
            this.Hide();
        }

        private async Task _LoginEETMS()
        {
            string UserNameOrEmail = GTextBoxUserNameOrEmailUser.Text;
            string Password = GTextBoxPassword.Text;

            switch (UserBL.PassLoginTheUser(UserNameOrEmail, Password))
            {
                case UserDTO.EnStatusLoginUser._kSUCCESS_LOGIN:
                    OpenMainScreenEETMS(UserNameOrEmail);
                    break;

                case UserDTO.EnStatusLoginUser._kFAILD_LOGIN:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "Username or Password is incorrect", Color.Red); break;

                case UserDTO.EnStatusLoginUser._kBLOCKED_USER:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "User is blocked", Color.Red); break;

                case UserDTO.EnStatusLoginUser._kUSER_NOT_FOUND:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "User not found", Color.Red); break;
            }
        }

        private async void GGButtonLoginToEETMS_Click(object sender, EventArgs e)
           => await _LoginEETMS();

        private void frmLoginEETMS_Move(object sender, EventArgs e)
           => _MakeTheLoginScreenCenterPosition();

        private void frmLoginEETMS_Resize(object sender, EventArgs e)
           => _MakeTheLoginScreenCenterPosition();

        private void GPictureBoxShowPassword_Click(object sender, EventArgs e)
        {
            if (GTextBoxPassword.PasswordChar == '•')
            {
                GPictureBoxShowHidePassword.Image = Resources.eye_show_gif_Image;
                GTextBoxPassword.PasswordChar = '\0';

            }
            else
            {
                GPictureBoxShowHidePassword.Image = Resources.eye_hide;
                GTextBoxPassword.PasswordChar = '•';
            }
        }

        private void GControlBoxExit_Click(object sender, EventArgs e)
           => Application.Exit();

        private void frmLoginEETMS_Load(object sender, EventArgs e)
        {

        }
    }
}
