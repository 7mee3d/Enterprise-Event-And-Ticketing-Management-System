

using EETMS_Models;
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

                                              SELECT SUM(P.Amount)
                                                FROM Payments P

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

        private static int _InsertNewPayment(MPayment mPayment)
        {

            int NewIDReservationPayment = -1;


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                            INSERT INTO Payments ( Amount , PaymentMethodID , PaymentStatusID , ReservationID )
                                            VALUES (@Amount , @PaymentMethodID , @PaymentStatusID , @ReservationID ) ;


                                            SELECT SCOPE_IDENTITY();

                                 ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.AddWithValue("@Amount", mPayment.PaidAmount);
                    command.Parameters.AddWithValue("@PaymentMethodID", Convert.ToInt32(mPayment.PaymentMethod));
                    command.Parameters.AddWithValue("@PaymentStatusID", Convert.ToInt32(mPayment.PaymentStatus));
                    command.Parameters.AddWithValue("@ReservationID", mPayment.BookingID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int NewID))
                        NewIDReservationPayment = NewID;

                    mPayment.PaymentID = NewIDReservationPayment;

                }
            }

            return NewIDReservationPayment;
        }

        public static int InsertNewPayment(MPayment mPayment)
            => _InsertNewPayment(mPayment);


    }
}
