using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer; 

namespace EETMS_Presentation.EETMS_Events
{
    public partial class USEvents : UserControl
    {

        private DataTable _EventDT = null; 
        public USEvents()
        {
            InitializeComponent();
        }

        private void _LoadAndFillDataGridViewONAllInformationEvent ()
        {

            _EventDT  = EventBL.GetAllInformationEvents();

            foreach(DataRow DR_Event in _EventDT.Rows)
            {

                GDataGridViewEventsInformation.Rows.Add(

                    DR_Event["EventName"],
                    DR_Event["CategoryName"],
                    DR_Event["DateTimeEvent"],
                    DR_Event["AvailableInEvent"] + " / " + DR_Event["MaxCapacity"],
                    DR_Event["CountryName"] + " , " + DR_Event["Street"],
                    DR_Event["Duration"],
                    DR_Event["Discripation"]


                                                    );


            }
        }

        private int _GetTheCountOfEvents()
        {
            return _EventDT.Rows.Count;
        }


        private void _InitalSettingAfterLoadTheUSEvents()
        {
            _LoadAndFillDataGridViewONAllInformationEvent();
            GDataGridViewEventsInformation.ClearSelection();
            lblTotalEvents.Text = _GetTheCountOfEvents().ToString();
        }

        private void USEvents_Load(object sender, EventArgs e)
        {
            _InitalSettingAfterLoadTheUSEvents();
        }
    }
}
