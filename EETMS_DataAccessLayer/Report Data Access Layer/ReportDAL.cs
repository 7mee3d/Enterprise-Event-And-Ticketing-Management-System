

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.ConstrainedExecution;

namespace EETMS_DataAccessLayer
{
    public class ReportDAL
    {


        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion



        private static DataTable _GetTotalRevenuePerEvent()
        {

            DataTable DT_InformationTotalRevenuePerEvent = new DataTable();



            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {



                string Query = @"


                                        SELECT 
                                                E.EventName,
                                                ISNULL( SUM ( P.Amount ) , 0 )  AS [TotalRevenue]

                                                FROM Events E
                                                LEFT JOIN TicketTypes TT
                                                    ON TT.EventID = E.EventID

                                                LEFT JOIN Reservations R
                                                    ON R.TicketTypeID = TT.TicketTypeID

                                                LEFT JOIN Payments P
                                                    ON P.ReservationID = R.ReservationID

                                                GROUP BY E.EventName
                                                ORDER BY TotalRevenue DESC ; 
        

                       ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows) DT_InformationTotalRevenuePerEvent.Load(reader);


                    }



                }
            }

            return DT_InformationTotalRevenuePerEvent;
        }

        public static DataTable GetTotalRevenuePerEvent()
            => _GetTotalRevenuePerEvent();

        private static DataTable _GetTotalCategorySales()
        {
            DataTable DT_InformationTotalCategorySales = new DataTable();



            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {



                string Query = @"


                                        
                                        SELECT  

                                                CAT.CategoryName ,
                                                SUM (TT.Available) AS [Count]

                                        FROM Categories CAT 
                                        INNER JOIN [Events] EVE
                                        ON CAT.CategoryID = EVE.CategoryID 

                                        INNER JOIN TicketTypes TT
                                        ON TT.EventID = EVE.EventID 


                                        GROUP BY CAT.CategoryName  
                                        ORDER BY  [Count] DESC  

        

                       ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows) DT_InformationTotalCategorySales.Load(reader);


                    }



                }
            }

            return DT_InformationTotalCategorySales;

        }

        public static DataTable GetTotalCategorySales()
            => _GetTotalCategorySales();

        private static DataTable _GetTopSpenders()
        {
            DataTable DT_InformationTopSpenders = new DataTable();



            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {



                string Query = @"


                                        
                                        SELECT 

                                                CONCAT (C.FirstName , ' ' , C.MidName , ' ' , C.LastName) AS [FullName] , 
                                                SUM(P.Amount) AS [Total]

                                                FROM Payments P
                                                INNER JOIN Reservations  R
                                                ON R.ReservationID = P.ReservationID 

                                                INNER JOIN Customers C
                                                ON C.CusotmerID = R.CusotmerID 


                                        GROUP BY  CONCAT (C.FirstName , ' ' , C.MidName , ' ' , C.LastName)
                                        ORDER BY [Total] DESC 

        

                       ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows) DT_InformationTopSpenders.Load(reader);


                    }



                }
            }

            return DT_InformationTopSpenders;

        }

        public static DataTable GetTopSpenders()
            => _GetTopSpenders();

    }
}
