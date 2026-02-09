using System;

using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class US_AddAndEditInformationEvent : UserControl
    {
        public US_AddAndEditInformationEvent()
        {
            InitializeComponent();
        }


        public event EventHandler RequestClose; 


        private void GButtonBackTheEvents_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
