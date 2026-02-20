
using EETMS_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class ReservationPaymentDAL
    {



        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        private static List<MReservationPayment> _GetAllInformationMReservationPayment()
        {

            List<MReservationPayment> LMReservationPayments = new List<MReservationPayment>();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


	                           SELECT 
                                    R.ReservationID,
                                    CONCAT(C.FirstName, ' ', C.MidName, ' ', C.LastName) AS FullName,
                                    RT.TotalAmount,
                                    ISNULL(PA.PaidAmount, 0) AS PaidAmount,
                                    RT.TotalAmount - ISNULL(PA.PaidAmount, 0) AS Remaining


                                            FROM Reservations R

                                                INNER JOIN Customers C
                                                    ON R.CusotmerID = C.CusotmerID

                                            INNER JOIN (
                                                SELECT 
                                                    ReservationID,
                                                    SUM(T.Price * R.Quantity) AS TotalAmount
                                                FROM Reservations R
                                                INNER JOIN TicketTypes T
                                                    ON T.TicketTypeID = R.TicketTypeID
                                                GROUP BY ReservationID
                                            ) RT
                                                ON RT.ReservationID = R.ReservationID



                                            LEFT JOIN (
                                                SELECT 
                                                    ReservationID,
                                                    SUM(Amount) AS PaidAmount
                                                FROM Payments
                                                GROUP BY ReservationID
                                            ) PA
                                                ON PA.ReservationID = R.ReservationID




                              ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            MReservationPayment mReservationPaymentOne = new MReservationPayment();

                            mReservationPaymentOne.ReservationID = reader["ReservationID"] != DBNull.Value ? Convert.ToInt32(reader["ReservationID"]) : 0;
                            mReservationPaymentOne.FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : null;
                            mReservationPaymentOne.TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0.0M;
                            mReservationPaymentOne.PaidAmount = reader["PaidAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PaidAmount"]) : 0.0M;
                            mReservationPaymentOne.Remaining = reader["Remaining"] != DBNull.Value ? Convert.ToDecimal(reader["Remaining"]) : 0.0M;


                            LMReservationPayments.Add(mReservationPaymentOne);
                        }
                    }
                }
            }

            return LMReservationPayments;
        }

        public static List<MReservationPayment> GetAllInformationMReservationPayment()
            => _GetAllInformationMReservationPayment();

        private static MReservationPayment _GetAllInformationMReservationPaymentByReservationID(int ReservationID)
        {

            MReservationPayment MReservationPayments = new MReservationPayment();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


	                           SELECT 
                                    R.ReservationID,
                                    CONCAT(C.FirstName, ' ', C.MidName, ' ', C.LastName) AS FullName,
                                    RT.TotalAmount,
                                    ISNULL(PA.PaidAmount, 0) AS PaidAmount,
                                    RT.TotalAmount - ISNULL(PA.PaidAmount, 0) AS Remaining


                                            FROM Reservations R

                                                INNER JOIN Customers C
                                                    ON R.CusotmerID = C.CusotmerID

                                            INNER JOIN (
                                                SELECT 
                                                    ReservationID,
                                                    SUM(T.Price * R.Quantity) AS TotalAmount
                                                FROM Reservations R
                                                INNER JOIN TicketTypes T
                                                    ON T.TicketTypeID = R.TicketTypeID
                                                GROUP BY ReservationID
                                            ) RT
                                                ON RT.ReservationID = R.ReservationID



                                            LEFT JOIN (
                                                SELECT 
                                                    ReservationID,
                                                    SUM(Amount) AS PaidAmount
                                                FROM Payments
                                                GROUP BY ReservationID
                                            ) PA
                                                ON PA.ReservationID = R.ReservationID

                                        WHERE R.ReservationID = @ReservationID ;



                              ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@ReservationID", System.Data.SqlDbType.Int).Value = ReservationID;
                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.Read())
                        {


                            MReservationPayments.ReservationID = reader["ReservationID"] != DBNull.Value ? Convert.ToInt32(reader["ReservationID"]) : 0;
                            MReservationPayments.FullName = reader["FullName"] != DBNull.Value ? reader["FullName"].ToString() : null;
                            MReservationPayments.TotalAmount = reader["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(reader["TotalAmount"]) : 0.0M;
                            MReservationPayments.PaidAmount = reader["PaidAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PaidAmount"]) : 0.0M;
                            MReservationPayments.Remaining = reader["Remaining"] != DBNull.Value ? Convert.ToDecimal(reader["Remaining"]) : 0.0M;

                        }
                    }
                }
            }

            return MReservationPayments;
        }

        public static MReservationPayment GetAllInformationMReservationPaymentByReservationID(int ReservationID)
            => _GetAllInformationMReservationPaymentByReservationID(ReservationID);


    }
}

