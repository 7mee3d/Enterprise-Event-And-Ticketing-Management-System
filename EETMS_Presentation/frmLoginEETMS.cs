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

            if (UserBL.IsUserExsitsByUsername(UserNameOrEmail, Password) || UserBL.IsUserExsitsByEmail(UserNameOrEmail, Password))
                MessageBox.Show("Login Successfully");
            else MessageBox.Show("Login Faild");
        }

        private void GGButtonLoginToEETMS_Click(object sender, EventArgs e)
        {
            _LoginEETMS();
        }
    }
}
