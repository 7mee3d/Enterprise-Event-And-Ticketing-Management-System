using EETMS_DataAccessLayer;
using System.Data;

namespace EETMS_BusinessLayer
{
    public class ReportBL
    {

        public static DataTable GetTotalRevenuePerEvent()
            => ReportDAL.GetTotalRevenuePerEvent();

        public static DataTable GetTotalCategorySales()
            => ReportDAL.GetTotalCategorySales();

        public static DataTable GetTopSpenders()
            => ReportDAL.GetTopSpenders();


    }
}
