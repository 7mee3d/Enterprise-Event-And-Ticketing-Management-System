

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class DashboardDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        private static DataTable _GetTheStatisticsTicketsByCategory()
        {

            DataTable dataTableTicketsByCategory = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                SELECT  C.CategoryName ,
                                        SUM(TT.Quantity - TT.Available) AS [CountTicketForCategory]

                                    FROM Categories C
                                    INNER JOIN Events E
                                    ON E.CategoryID = C.CategoryID 


                                    INNER JOIN TicketTypes TT
                                    ON TT.EventID = E.EventID


                                    GROUP BY  C.CategoryName



                    ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows)
                            dataTableTicketsByCategory.Load(reader);

                    }


                }
            }

            return dataTableTicketsByCategory;
        }

        public static DataTable GetTheStatisticsTicketsByCategory()
            => _GetTheStatisticsTicketsByCategory();

        private static List<int> _GetAllYearsPayments()
        {
            List<int> LAllYearsPayments = new List<int>();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"



                                        SELECT 
                                                YEAR(P.DateTimePayment) AS [Year]
                                        FROM Payments P

                                        GROUP BY 
                                                YEAR(P.DateTimePayment)




                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {

                            LAllYearsPayments.Add(reader["Year"] != DBNull.Value ? Convert.ToInt32(reader["Year"]) : 0);

                        }



                    }


                }
            }

            return LAllYearsPayments;
        }

        public static List<int> GetAllYearsPayments()
            => _GetAllYearsPayments();

        private static DataTable _GetTheTotalReveneForMonthBy(int Year)
        {

            DataTable TotalRevenueForMonth_DT = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

	
                                                      SELECT 
                                                      	YEAR(P.DateTimePayment) AS [Year],
                                                      	MONTH(P.DateTimePayment) AS [Month],
                                                          SUM(P.Amount) AS [TotalRevenue]
                                                      FROM Payments P
                                                      WHERE 	YEAR(P.DateTimePayment) = @Year 
                                                      GROUP BY 
                                                          YEAR(P.DateTimePayment),
                                                      	MONTH(P.DateTimePayment)


                                   ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@Year", SqlDbType.Int).Value = Year;

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows) TotalRevenueForMonth_DT.Load(reader);


                    }
                }
            }

            return TotalRevenueForMonth_DT;

        }

        public static DataTable GetTheTotalReveneForMonthBy(int Year)
            => _GetTheTotalReveneForMonthBy(Year);

        private static double _GetTheTotalRevenue()
        {


            double TotalRevenue = 0.0;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                    SELECT
                                              ISNULL ( SUM ( P.Amount ) , 0 ) AS [Total Revenue]
                                    FROM Payments P




                       ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null & Double.TryParse(result.ToString(), out double ResultTotalRevenue))
                        TotalRevenue = ResultTotalRevenue;


                }
            }

            return TotalRevenue;

        }

        public static double GetTheTotalRevenue()
            => _GetTheTotalRevenue();

        private static int _GetTheSoldTickets()
        {

            int TicketSold = 0;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                    SELECT ISNULL ( SUM (TT.Quantity - Available) , 0 )  AS [Total Sold Ticket]
                                    FROM TicketTypes TT  



                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int TotalSoldTicket))
                        TicketSold = TotalSoldTicket;


                }
            }

            return TicketSold;
        }

        public static int GetTheSoldTickets()
            => _GetTheSoldTickets();

        private static int _GetTheActiveEvents()
        {

            int CountActiveEvents = 0;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                    SELECT COUNT(E.EventID) AS [CountActiveEvents]
                                        FROM [Events] E
                                    WHERE E.IsActiveEvent = 1 ;



                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int TotalActiveEvents))
                        CountActiveEvents = TotalActiveEvents;


                }
            }

            return CountActiveEvents;
        }

        public static int GetTheActiveEvents()
            => _GetTheActiveEvents();

    }
}
