using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Customers
{
    public partial class US_AddAndUpdateInformationCustomer : UserControl
    {
        public US_AddAndUpdateInformationCustomer()
        {
            InitializeComponent();
        }

        public event EventHandler RequestClose = null; 


        private void GButtonCansel_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, EventArgs.Empty); 
        }
    }
}
