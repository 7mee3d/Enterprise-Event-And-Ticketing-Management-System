using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Report
{
    public partial class USReport : UserControl
    {

        public USReport()
        {
            InitializeComponent();
        }


        private void _FillTheDataGridViewRevenuePerEventToData()
        {

            DataTable DT_TotalRevenuePerEvent = ReportBL.GetTotalRevenuePerEvent();

            foreach (DataRow DR_TotalRevenuePerEvent in DT_TotalRevenuePerEvent.Rows)
            {

                GDataGridViewRevenuePerEvent.Rows.Add(


                            DR_TotalRevenuePerEvent["EventName"].ToString(),
                            "$" + DR_TotalRevenuePerEvent["TotalRevenue"].ToString()


                                                     );

            }

        }

        private void _FillTheDataGridViewCategorySalesToData()
        {

            DataTable DT_CategorySales = ReportBL.GetTotalCategorySales();

            foreach (DataRow DR_CategorySales in DT_CategorySales.Rows)
            {

                GDataGridViewCategoryDales.Rows.Add(


                            DR_CategorySales["CategoryName"].ToString(),
                            DR_CategorySales["Count"].ToString()


                                                     );

            }

        }

        private void _FillTheDataGridViewTopSpendersToData()
        {

            DataTable DT_TopSpenders = ReportBL.GetTopSpenders();

            foreach (DataRow DR_TopSpenders in DT_TopSpenders.Rows)
            {

                GDataGridViewTopSpenders.Rows.Add(


                            DR_TopSpenders["FullName"].ToString(),
                           "$" + DR_TopSpenders["Total"].ToString()


                                                     );

            }

        }

        private void _FillTheDataGridViewFullyBookedEvents()
        {

            DataTable DT_InformatioNEvents = ReportBL.GetAllInformationEvent();

            for (int counter = clsEETMS_Constants.kZERO; counter < DT_InformatioNEvents.Rows.Count; counter += clsEETMS_Constants.kONE)
            {

                DataRow DR_InfoEvent = DT_InformatioNEvents.Rows[counter];


                int.TryParse(DR_InfoEvent["MaxCapacity"].ToString(), out int MaxCapacity);

                if ((int)DR_InfoEvent["SoldTickets"] == MaxCapacity)
                {
                    int rowIndex = GDataGridViewFullyBookedEvents.Rows.Add(

                                                               DR_InfoEvent["EventName"].ToString(),
                                                               "Sold Out"


                                                 );

                    DataGridViewRow GDVR = GDataGridViewFullyBookedEvents.Rows[rowIndex];
                    DataGridViewCell DGVC = GDVR.Cells[1];

                    DGVC.Style.ForeColor = Color.Red;
                }

            }
        }

        private void _FillTheDataGridViewRemainingCapacity()
        {

            DataTable DT_InformatioNEvents = ReportBL.GetAllInformationEvent();

            foreach (DataRow DR_InfoEvent in DT_InformatioNEvents.Rows)
            {


                int.TryParse(DR_InfoEvent["MaxCapacity"].ToString(), out int MaxCapacity);

                if ((int)DR_InfoEvent["SoldTickets"] < MaxCapacity)
                {
                    int rowIndex = GDataGridViewRemainingCapacity.Rows.Add(

                                                               DR_InfoEvent["EventName"].ToString(),
                                                               DR_InfoEvent["RemainingCapacity"].ToString()



                                                 );

                    DataGridViewRow GDVR = GDataGridViewRemainingCapacity.Rows[rowIndex];
                    DataGridViewCell DGVC = GDVR.Cells[1];

                    DGVC.Style.ForeColor = Color.Green;
                }

            }
        }

        private void _ClaerSelectionGDV()
        {

            GDataGridViewCategoryDales.ClearSelection();
            GDataGridViewRevenuePerEvent.ClearSelection();
            GDataGridViewTopSpenders.ClearSelection();
            GDataGridViewFullyBookedEvents.ClearSelection();
            GDataGridViewRemainingCapacity.ClearSelection();

        }

        private void _InitalTheSettingAfterLoadTheReportUSFillAllDataToGDV()
        {
            _FillTheDataGridViewRevenuePerEventToData();
            _FillTheDataGridViewCategorySalesToData();
            _FillTheDataGridViewTopSpendersToData();
            _FillTheDataGridViewFullyBookedEvents();
            _FillTheDataGridViewRemainingCapacity();
            _ClaerSelectionGDV();

        }

        private void USReport_Load(object sender, EventArgs e)
            => _InitalTheSettingAfterLoadTheReportUSFillAllDataToGDV();



    }
}
