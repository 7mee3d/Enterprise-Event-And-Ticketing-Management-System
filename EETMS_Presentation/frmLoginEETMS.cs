using System;
using System.Windows.Forms;

using EETMS_BusinessLayer;

namespace EETMS_Presentation
{
    public partial class frmLoginEETMS : Form
    {
        
        public frmLoginEETMS()
        {
            InitializeComponent();
        }

        private void _LoginEETMS()
        {
            string UserNameOrEmail = GTextBoxUserNameOrEmailUser.Text;
            string Password = GTextBoxPassword.Text;
            switch(UserBL.PassLoginTheUser(UserNameOrEmail , Password))
            {
                case EETMS_Models.MUser.EnStatusLoginUser._kSUCCESS_LOGIN:
                    MessageBox.Show("Login Successfully");
                    break;

                case EETMS_Models.MUser.EnStatusLoginUser._kFAILD_LOGIN:
                    MessageBox.Show("Login Faild");
                    break;

                case EETMS_Models.MUser.EnStatusLoginUser._kBLOCKED_USER:
                    MessageBox.Show("Login Blocked");
                    break;

                case EETMS_Models.MUser.EnStatusLoginUser._kUSER_NOT_FOUND:
                    MessageBox.Show("User Not Found");
                    break;
            }
        }

        private void GGButtonLoginToEETMS_Click(object sender, EventArgs e)
        {
            _LoginEETMS();
        }
    }
}
