using EETMS_BusinessLayer;
using EETMS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Main
{
    public partial class frmMainScreenEETMS : Form
    {

        MUser _InformationUser = null; 

        public frmMainScreenEETMS(string UsernameOrEmail  )
        {
            InitializeComponent();

            _InformationUser = UserBL.FindUser(UsernameOrEmail);
            if (_InformationUser != null)
            {
                lblNameUser.Text = _InformationUser.UserFullName;
                lblRoleUser.Text = _InformationUser.RoleName;
            }

        }

        private void frmMainScreenEETMS_Load(object sender, EventArgs e)
        {
            //   MessageBox.Show($"Welcome Back {_InformationUser.RoleName}");
         

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PicLogoutEETMS_Click(object sender, EventArgs e)
        {
            frmLoginEETMS frm_L_EETMS = new frmLoginEETMS();
            frm_L_EETMS.Show();
            this.Close();
        }
    }
}
