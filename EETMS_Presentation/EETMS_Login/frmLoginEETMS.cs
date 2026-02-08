using EETMS_BusinessLayer;
using EETMS_Presentation.EETMS_Main;
using System;
using System.Drawing; 
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation
{
    public partial class frmLoginEETMS : Form
    {

        private const short _kNUMBER_TOP_SHOW_KMESSAGE = 5; 
        private const short _kORIGNIAL_TOP_LABLEL_SHOW_MESSAGE = 387;
        bool _IsAnimating = false;

        public frmLoginEETMS()
        {
            InitializeComponent();

        }

        private void _MakeTheLoginScreenCenterPosition ()
        {

            int X_Axis = ((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2); 
            int Y_Axis = ((Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            this.Location = new Point(X_Axis, Y_Axis);
            this.Size = new Size(1663, 935);

        }

        private async Task _AniMessageLoginScreen(Label ObjLabel, string Context, Color? ForeColor = null)
        {
            if (_IsAnimating) return;
            _IsAnimating = true;

            ObjLabel.Visible = true;
            ObjLabel.ForeColor = ForeColor ?? Color.Black;
            ObjLabel.Text = Context;

            for (int i = 0; i <= _kNUMBER_TOP_SHOW_KMESSAGE; i++)
            {
                ObjLabel.Location = new Point(81, 374 - i);
                await Task.Delay(5);
            }

            await Task.Delay(2000);
            ObjLabel.Visible = false;
            ObjLabel.Location = new Point(81, _kORIGNIAL_TOP_LABLEL_SHOW_MESSAGE);

            _IsAnimating = false;
        }

        private void OpenMainScreenEETMS (string Username )
        {

            frmMainScreenEETMS frm_MS_EETMS = new frmMainScreenEETMS(Username);
            frm_MS_EETMS.Show();
            this.Hide();
        }

        private async Task  _LoginEETMS()
        {
            string UserNameOrEmail = GTextBoxUserNameOrEmailUser.Text;
            string Password = GTextBoxPassword.Text;

            switch(UserBL.PassLoginTheUser(UserNameOrEmail , Password))
            {
                case EETMS_Models.MUser.EnStatusLoginUser._kSUCCESS_LOGIN:
                    //await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "Login Sccessfully", Color.Green);
                    OpenMainScreenEETMS(UserNameOrEmail);
                    break;

                case EETMS_Models.MUser.EnStatusLoginUser._kFAILD_LOGIN:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "Username or Password is incorrect", Color.Red); break;

                case EETMS_Models.MUser.EnStatusLoginUser._kBLOCKED_USER:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "User is blocked", Color.Red); break;

                case EETMS_Models.MUser.EnStatusLoginUser._kUSER_NOT_FOUND:
                    await _AniMessageLoginScreen(lblShowMessageInLoginScreen, "User not found", Color.Red); break;
            }
        }

        private async void GGButtonLoginToEETMS_Click(object sender, EventArgs e)
        {
            await _LoginEETMS();
        }

        private void frmLoginEETMS_Move(object sender, EventArgs e)
        {
            _MakeTheLoginScreenCenterPosition();
        }

        private void frmLoginEETMS_Resize(object sender, EventArgs e)
        {
            _MakeTheLoginScreenCenterPosition();
        }
    }
}
