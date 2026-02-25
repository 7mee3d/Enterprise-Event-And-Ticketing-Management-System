using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer;
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
            int SelectedYear = 0;

            if (GComboBoxYearsPayments.Items.Count > 0)
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
                    double TotalRevenue = Convert.ToDouble(DR_TotalRevenueForMonth["TotalRevenue"] != DBNull.Value ? DR_TotalRevenueForMonth["TotalRevenue"] : 0.0);

                    DataSet.DataPoints.Add(DR_TotalRevenueForMonth["Month"].ToString(), TotalRevenue);
                }


            }

            GChartsTotalRevenueForMonth.Datasets.Add(DataSet);
            GChartsTotalRevenueForMonth.Update();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void USDashboard_Load(object sender, EventArgs e)
        {
            _LoadTheStatisticsTicketsByCategoryInCharts();
            _LoadAllYearsToComboBoxAndInitalSettingTheComboBox();
            _LoadTheDataToChartsTotalRevenueForMonth();
            _InitalSettingAfterLoadTheDashboard();
        }

        private void GComboBoxYearsPayments_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _LoadTheDataToChartsTotalRevenueForMonth();
        }

        private void _InitalSettingAfterLoadTheDashboard()
        {

            lblTotalRevenue.Text = "$" + DashboardBL.GetTheTotalRevenueBL().ToString();
            lblTicketSold.Text = DashboardBL.GetTheSoldTickets().ToString();
            lblActiveEvents.Text = DashboardBL.GetTheTotalActiveEvents().ToString();
            lblTotalCustomers.Text = DashboardBL.GetTheTotalCustomers().ToString();

        }


    }
}
