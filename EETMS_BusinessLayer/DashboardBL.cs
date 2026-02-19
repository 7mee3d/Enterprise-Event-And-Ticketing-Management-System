using EETMS_DataAccessLayer;
using System.Collections.Generic;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class DashboardBL
    {

        public static DataTable GetTheStatisticsTicketsByCategoryBL()
            => DashboardDAL.GetTheStatisticsTicketsByCategory();


        public static List<int> GetTheAllYearsPaymentTotalRevenue()
            => DashboardDAL.GetAllYearsPayments();


        public static DataTable GetTheTotalReveneForMonthBL_By(int Year)
            => DashboardDAL.GetTheTotalReveneForMonthBy(Year);

    }
}
