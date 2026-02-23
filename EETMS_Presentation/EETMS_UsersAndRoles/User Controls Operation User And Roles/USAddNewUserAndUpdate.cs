using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_UsersAndRoles.User_Controls_Operation_User_And_Roles
{
    public partial class USAddNewUserAndUpdate : UserControl
    {
        public event EventHandler ERequestToTheCloseAddNewUser = null;

        public USAddNewUserAndUpdate(int id)
        {
            InitializeComponent();
        }

        private void GButtonClose_Click(object sender, EventArgs e)
        {
            ERequestToTheCloseAddNewUser?.Invoke(this, EventArgs.Empty);
        }
    }
}
