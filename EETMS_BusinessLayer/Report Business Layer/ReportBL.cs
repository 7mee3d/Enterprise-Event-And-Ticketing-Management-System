using EETMS_DataAccessLayer;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class ReportBL
    {

        public static DataTable GetTotalRevenuePerEvent()
            => ReportQueriesDAL.GetTotalRevenuePerEvent();

        public static DataTable GetTotalCategorySales()
            => ReportQueriesDAL.GetTotalCategorySales();

        public static DataTable GetTopSpenders()
            => ReportQueriesDAL.GetTopSpenders();

        public static DataTable GetAllInformationEvents()
            => ReportQueriesDAL.GetAllInfomrationEvent();
        public static DataTable GetAllInformationEventInProgressRemainingCapacity()
            => ReportQueriesDAL.GetAllEventInProgressRemainingCapacity();

    }
}
