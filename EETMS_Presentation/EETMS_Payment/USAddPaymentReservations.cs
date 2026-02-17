using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Payment
{
    public partial class USAddPaymentReservations : UserControl
    {
        public USAddPaymentReservations()
        {
            InitializeComponent();
        }

        public event EventHandler ERequestTheClosePaymentBooking = null;

        private void Close_Click(object sender, EventArgs e)
        {
            ERequestTheClosePaymentBooking?.Invoke(this, EventArgs.Empty);
        }
    }
}
