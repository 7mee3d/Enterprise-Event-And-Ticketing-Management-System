

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


    }
}
