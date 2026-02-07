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

        private void frmLoginEETMS_Load(object sender, EventArgs e)
        {

        }

        private void IsExsitsUserByEmail ()
        {
            string Username = UsernameT.Text;
            string Password = password.Text;

            if (UserBL.IsUserExsitsByEmail(Username, Password) || UserBL.IsUserExsitsByUsername(Username , Password))
                MessageBox.Show("Login Successfully ");
            else MessageBox.Show("Login Faild ");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            IsExsitsUserByEmail();

        }
    }
}
