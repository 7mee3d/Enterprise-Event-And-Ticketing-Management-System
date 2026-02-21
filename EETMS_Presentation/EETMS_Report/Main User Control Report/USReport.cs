using EETMS_BusinessLayer;
using System;
using System.Data;
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

        private void _ClaerSelectionGDV()
        {

            GDataGridViewCategoryDales.ClearSelection();
            GDataGridViewRevenuePerEvent.ClearSelection();
            GDataGridViewTopSpenders.ClearSelection();

        }

        private void _InitalTheSettingAfterLoadTheReportUSFillAllDataToGDV()
        {
            _FillTheDataGridViewRevenuePerEventToData();
            _FillTheDataGridViewCategorySalesToData();
            _FillTheDataGridViewTopSpendersToData();
            _ClaerSelectionGDV();

        }

        private void USReport_Load(object sender, EventArgs e)
        {
            _InitalTheSettingAfterLoadTheReportUSFillAllDataToGDV();
        }


    }
}
