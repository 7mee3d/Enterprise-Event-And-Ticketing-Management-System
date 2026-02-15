

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class PaymentsDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        private static decimal _GetTotalRevenue()
        {

            decimal TotalRevenue = 0.0M;

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                            SELECT SUM ( R.Quantity * T.Price ) AS [TotalRevenue] 
                                            FROM Reservations R 
                                            INNER JOIN TicketTypes T 
                                            ON R.TicketTypeID = T.TicketTypeID 


                              ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && Decimal.TryParse(result.ToString(), out decimal TotalRev))
                        TotalRevenue = TotalRev;
                }


            }

            return TotalRevenue;

        }

        public static decimal GetTotalRevenue()
            => _GetTotalRevenue();

        private static DataTable _GetAllInformationPayment()
        {

            DataTable Payment_DT = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                    SELECT      P.PaymentID ,
                                                R.ReservationID ,
                                                R.BookingDateTimeDateTime ,
                                                R.CusotmerID , ( R.Quantity * T.Price ) AS [TotalAmount] , 
                                                P.Amount  AS [PaidAmount],
                                                PM.NamePaymentMethod ,
                                                PS.NamePaymentStatus  

                                                        FROM Reservations R 

                                                        INNER JOIN Payments P 
                                                        ON P.ReservationID = R.ReservationID 

                                                        INNER JOIN TicketTypes T
                                                        ON T.TicketTypeID = R.TicketTypeID

                                                        INNER JOIN PaymentMethods PM 
                                                        ON PM.PaymentMethodID = P.PaymentMethodID 

                                                        INNER JOIN PaymentStatus PS 
                                                        ON PS.PaymentStatusID = P.PaymentStatusID ;

                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            Payment_DT.Load(reader);

                    }

                }
            }

            return Payment_DT;
        }

        public static DataTable GetAllInformationPayment()
            => _GetAllInformationPayment();

        private static DataTable _GetAllInformationPaymentBy(string BookingID)
        {

            DataTable Payment_DT = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                    SELECT      P.PaymentID ,
                                                R.ReservationID ,
                                                R.BookingDateTimeDateTime ,
                                                R.CusotmerID , ( R.Quantity * T.Price ) AS [TotalAmount] , 
                                                P.Amount  AS [PaidAmount],
                                                PM.NamePaymentMethod ,
                                                PS.NamePaymentStatus  

                                                        FROM Reservations R 

                                                        INNER JOIN Payments P 
                                                        ON P.ReservationID = R.ReservationID 

                                                        INNER JOIN TicketTypes T
                                                        ON T.TicketTypeID = R.TicketTypeID

                                                        INNER JOIN PaymentMethods PM 
                                                        ON PM.PaymentMethodID = P.PaymentMethodID 

                                                        INNER JOIN PaymentStatus PS 
                                                        ON PS.PaymentStatusID = P.PaymentStatusID 
    

                                                WHERE R.ReservationID = @ReservationID;
                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@ReservationID", BookingID);

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            Payment_DT.Load(reader);

                    }

                }
            }

            return Payment_DT;
        }

        public static DataTable GetAllInformationPaymentBy(string BookingID)
            => _GetAllInformationPaymentBy(BookingID);
    }
}
