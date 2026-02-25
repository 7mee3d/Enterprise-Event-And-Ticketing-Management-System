using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;
using Guna.Charts.WinForms;

namespace EETMS_Presentation.EETMS_Dashboard
{
    public partial class USDashboard : UserControl
    {


        public USDashboard()
        {
            InitializeComponent();
        }


        private void _LoadTheStatisticsTicketsByCategoryInCharts()
        {
            DataTable TicketsByCategory_DT = DashboardBL.GetTheStatisticsTicketsByCategoryBL();


            GChartTicketByCategory.Datasets.Clear();

            var DataSet = new GunaPolarAreaDataset();
            DataSet.Label = "Category Name";

            foreach (DataRow DR_TicketsByCategory in TicketsByCategory_DT.Rows)
            {
                DataSet.DataPoints.Add(
                    DR_TicketsByCategory["CategoryName"].ToString(),
                    Convert.ToInt32(DR_TicketsByCategory["CountTicketForCategory"])
                );
            }


            GChartTicketByCategory.Datasets.Add(DataSet);

            GChartTicketByCategory.Update();
        }

        private void _LoadAllYearsToComboBoxAndInitalSettingTheComboBox()
        {
            List<int> LAllYearsPayments = DashboardBL.GetTheAllYearsPaymentTotalRevenue();

            GComboBoxYearsPayments.DataSource = LAllYearsPayments;
            GComboBoxYearsPayments.DisplayMember = "Year";

        }

        private void _LoadTheDataToChartsTotalRevenueForMonth()
        {
            int SelectedYear = clsEETMS_Constants.kZERO;

            if (GComboBoxYearsPayments.Items.Count > clsEETMS_Constants.kZERO)
                SelectedYear = (int)GComboBoxYearsPayments.SelectedItem;

            DataTable DT_TotalRevenueForMpnth = DashboardBL.GetTheTotalReveneForMonthBL_By(SelectedYear);


            GChartsTotalRevenueForMonth.Datasets.Clear();
            GSplineDatasetTotalRevenueByMonth.DataPoints.Clear();

            var DataSet = new GunaSplineDataset();

            DataSet.Label = "Revenue " + SelectedYear.ToString();


            foreach (DataRow DR_TotalRevenueForMonth in DT_TotalRevenueForMpnth.Rows)
            {

                if ((int)DR_TotalRevenueForMonth["Year"] == SelectedYear)
                {
                    GSplineDatasetTotalRevenueByMonth.Label = "Month";
                    double TotalRevenue = Convert.ToDouble(DR_TotalRevenueForMonth["TotalRevenue"] != DBNull.Value ? DR_TotalRevenueForMonth["TotalRevenue"] : clsEETMS_Constants.kZERO);

                    DataSet.DataPoints.Add(DR_TotalRevenueForMonth["Month"].ToString(), TotalRevenue);
                }


            }

            GChartsTotalRevenueForMonth.Datasets.Add(DataSet);
            GChartsTotalRevenueForMonth.Update();
        }

        private void USDashboard_Load(object sender, EventArgs e)
        {
            _LoadTheStatisticsTicketsByCategoryInCharts();
            _LoadAllYearsToComboBoxAndInitalSettingTheComboBox();
            _LoadTheDataToChartsTotalRevenueForMonth();
            _InitalSettingAfterLoadTheDashboardAsync();
        }

        private void GComboBoxYearsPayments_SelectionChangeCommitted(object sender, EventArgs e)
            => _LoadTheDataToChartsTotalRevenueForMonth();

        private async Task _InitalSettingAfterLoadTheDashboardAsync()
        {

            clsEETMS_SettingPresentation._AnimationLables(DashboardBL.GetTheTotalRevenueBL(), lblTotalRevenue, 1, true);
            clsEETMS_SettingPresentation._AnimationLables(DashboardBL.GetTheSoldTickets(), lblTicketSold, 2);
            clsEETMS_SettingPresentation._AnimationLables(DashboardBL.GetTheTotalActiveEvents(), lblActiveEvents, 5);
            clsEETMS_SettingPresentation._AnimationLables(DashboardBL.GetTheTotalCustomers(), lblTotalCustomers, 2);


        }


    }
}
