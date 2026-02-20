using System;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Events
{
    public partial class US_AddAndUpdateTheTicketsToTheEvents : UserControl
    {
        int _ID = 0;

        public US_AddAndUpdateTheTicketsToTheEvents(int id)
        {
            InitializeComponent();
            _ID = id;
        }

        public event EventHandler<int> ERequestTheClose_AddAndUpdateTheTicketsEvents;

        private void GButtonDiscardChanges_Click(object sender, EventArgs e)
        {
            ERequestTheClose_AddAndUpdateTheTicketsEvents?.Invoke(this, _ID);
        }

        private void US_AddAndUpdateTheTicketsToTheEvents_Load(object sender, EventArgs e)
        {
            MessageBox.Show(_ID.ToString());
        }
    }
}
