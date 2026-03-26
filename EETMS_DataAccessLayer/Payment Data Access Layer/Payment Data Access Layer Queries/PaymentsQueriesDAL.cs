using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class PaymentsQueriesDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Methods Payment Queries 

        private static double _GetTotalRevenue()
        {

            double TotalRevenue = 0.0;

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

                    if (result != null && Double.TryParse(result.ToString(), out double TotalRev))
                        TotalRevenue = TotalRev;
                }


            }

            return TotalRevenue;

        }

        public static double GetTotalRevenue()
            => _GetTotalRevenue();

        private static DataTable _GetAllInformationPayment()
        {

            DataTable Payment_DT = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"
                                                                
													    SELECT DISTINCT
																	 	 P.PaymentID, 
																		 R.ReservationID , 
																		 ResultTotalAmount.TotalAmount,
																		 P.Amount  AS [PaidAmount],
																		 PM.NamePaymentMethod,
																		 R.BookingDateTimeDateTime,
																		 PS.NamePaymentStatus
																	

																    FROM Payments P

																	INNER JOIN ReservationTickets RT 
																	ON RT.ReservationID = P.ReservationID 

																    INNER JOIN TicketTypes TT
																    ON TT.TicketTypeID = RT.TicketTypeID 

																	INNER JOIN Reservations R
																	ON R.ReservationID = P.ReservationID
																	
														
																	INNER JOIN (
																				
																				SELECT RT.ReservationID ,
																			    SUM(RT.Price * CAST (  RT.Quantity  AS DECIMAL (10 , 2 ) )) + ISNULL (RT.Tax , 0 )AS [TotalAmount] 
																				FROM ReservationTickets  RT
																				GROUP BY RT.ReservationID , RT.Tax  

																	) AS ResultTotalAmount  
																	ON P.ReservationID = ResultTotalAmount.ReservationID


																	INNER JOIN PaymentMethods PM 
																	ON PM.PaymentMethodID = P.PaymentMethodID 

																	INNER JOIN PaymentStatus PS 
																	ON PS.PaymentStatusID = P.PaymentStatusID 
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

		                                              SELECT DISTINCT
																	 	 P.PaymentID, 
																		 R.ReservationID , 
																		 ResultTotalAmount.TotalAmount,
																		 P.Amount  AS [PaidAmount],
																		 PM.NamePaymentMethod,
																		 R.BookingDateTimeDateTime,
																		 PS.NamePaymentStatus
																	

																    FROM Payments P

																	INNER JOIN ReservationTickets RT 
																	ON RT.ReservationID = P.ReservationID 

																    INNER JOIN TicketTypes TT
																    ON TT.TicketTypeID = RT.TicketTypeID 

																	INNER JOIN Reservations R
																	ON R.ReservationID = P.ReservationID
																	
														
																	INNER JOIN (
																				
																				SELECT RT.ReservationID ,
																			    SUM(RT.Price * CAST (  RT.Quantity  AS DECIMAL (10 , 2 ) )) + ISNULL (RT.Tax , 0 )AS [TotalAmount] 
																				FROM ReservationTickets  RT
																				GROUP BY RT.ReservationID , RT.Tax  

																	) AS ResultTotalAmount  
																	ON P.ReservationID = ResultTotalAmount.ReservationID


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

        private static List<string> _GetAllPaymentStatus()
        {
            List<string> AllPaymentStatus = new List<string>();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                    SELECT NamePaymentStatus 
                                    FROM PaymentStatus;


                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                            AllPaymentStatus.Add(reader["NamePaymentStatus"].ToString());
                    }
                }
            }

            return AllPaymentStatus;

        }

        public static List<string> GetAllPaymentStatus()
            => _GetAllPaymentStatus();

        private static DataTable _GetAllInformationPaymentAccordingBy(string NameStatusPaymentType)
        {

            DataTable DT_AllInformationPaymentStatus = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                              SELECT DISTINCT
																 	 P.PaymentID, 
																	 R.ReservationID , 
																	 ResultTotalAmount.TotalAmount,
																	 P.Amount  AS [PaidAmount],
																	 PM.NamePaymentMethod,
																	 R.BookingDateTimeDateTime,
																	 PS.NamePaymentStatus
																

															    FROM Payments P

																INNER JOIN ReservationTickets RT 
																ON RT.ReservationID = P.ReservationID 

															    INNER JOIN TicketTypes TT
															    ON TT.TicketTypeID = RT.TicketTypeID 

																INNER JOIN Reservations R
																ON R.ReservationID = P.ReservationID
																
													
																INNER JOIN (
																			
																			SELECT RT.ReservationID ,
																		    SUM(RT.Price * CAST (  RT.Quantity  AS DECIMAL (10 , 2 ) )) + ISNULL (RT.Tax , 0 )AS [TotalAmount] 
																			FROM ReservationTickets  RT
																			GROUP BY RT.ReservationID , RT.Tax  

																) AS ResultTotalAmount  
																ON P.ReservationID = ResultTotalAmount.ReservationID


																INNER JOIN PaymentMethods PM 
																ON PM.PaymentMethodID = P.PaymentMethodID 

																INNER JOIN PaymentStatus PS 
																ON PS.PaymentStatusID = P.PaymentStatusID 

                                                                WHERE PS.NamePaymentStatus= @NamePaymentStatus



                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@NamePaymentStatus", NameStatusPaymentType);

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllInformationPaymentStatus.Load(reader);


                }
            }

            return DT_AllInformationPaymentStatus;


        }

        public static DataTable GetAllInformationPaymentAccordingBy(string NameStatusPaymentType)
            => _GetAllInformationPaymentAccordingBy(NameStatusPaymentType);

        private static List<string> _GetAllPaymentMethods()
        {
            List<string> AllPaymentMethods = new List<string>();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                   
                                        SELECT NamePaymentMethod 
                                        FROM PaymentMethods


                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                            AllPaymentMethods.Add(reader["NamePaymentMethod"].ToString());
                    }
                }
            }

            return AllPaymentMethods;

        }

        public static List<string> GetAllPaymentMethods()
            => _GetAllPaymentMethods();

        private static DataTable _GetAllInformationPaymentMethodsBy(string NamePaymentMethod)
        {

            DataTable DT_AllInformationPaymentMethods = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                               SELECT DISTINCT
																 	 P.PaymentID, 
																	 R.ReservationID , 
																	 ResultTotalAmount.TotalAmount,
																	 P.Amount  AS [PaidAmount],
																	 PM.NamePaymentMethod,
																	 R.BookingDateTimeDateTime,
																	 PS.NamePaymentStatus
																

															    FROM Payments P

																INNER JOIN ReservationTickets RT 
																ON RT.ReservationID = P.ReservationID 

															    INNER JOIN TicketTypes TT
															    ON TT.TicketTypeID = RT.TicketTypeID 

																INNER JOIN Reservations R
																ON R.ReservationID = P.ReservationID
																
													
																INNER JOIN (
																			
																			SELECT RT.ReservationID ,
																		    SUM(RT.Price * CAST (  RT.Quantity  AS DECIMAL (10 , 2 ) )) + ISNULL (RT.Tax , 0 )AS [TotalAmount] 
																			FROM ReservationTickets  RT
																			GROUP BY RT.ReservationID , RT.Tax  

																) AS ResultTotalAmount  
																ON P.ReservationID = ResultTotalAmount.ReservationID


																INNER JOIN PaymentMethods PM 
																ON PM.PaymentMethodID = P.PaymentMethodID 

																INNER JOIN PaymentStatus PS 
																ON PS.PaymentStatusID = P.PaymentStatusID 


                                                                WHERE PM.NamePaymentMethod = @NamePaymentMethod

                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@NamePaymentMethod", NamePaymentMethod);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_AllInformationPaymentMethods.Load(reader);

                    }

                }
            }

            return DT_AllInformationPaymentMethods;
        }

        public static DataTable GetAllInformationPaymentMethodsBy(string NamePaymentMethod)
            => _GetAllInformationPaymentMethodsBy(NamePaymentMethod);

        private static DataTable _GetAllInformationPaymentFilterTwoDate(DateTime DateFrom, DateTime DateTo)
        {

            DataTable DT_AllInformationBetweenTwoDate = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                   SELECT DISTINCT
																 	 P.PaymentID, 
																	 R.ReservationID , 
																	 ResultTotalAmount.TotalAmount,
																	 P.Amount  AS [PaidAmount],
																	 PM.NamePaymentMethod,
																	 R.BookingDateTimeDateTime,
																	 PS.NamePaymentStatus
																

															    FROM Payments P

																INNER JOIN ReservationTickets RT 
																ON RT.ReservationID = P.ReservationID 

															    INNER JOIN TicketTypes TT
															    ON TT.TicketTypeID = RT.TicketTypeID 

																INNER JOIN Reservations R
																ON R.ReservationID = P.ReservationID
																
													
																INNER JOIN (
																			
																			SELECT RT.ReservationID ,
																		    SUM(RT.Price * CAST (  RT.Quantity  AS DECIMAL (10 , 2 ) )) + ISNULL (RT.Tax , 0 )AS [TotalAmount] 
																			FROM ReservationTickets  RT
																			GROUP BY RT.ReservationID , RT.Tax  

																) AS ResultTotalAmount  
																ON P.ReservationID = ResultTotalAmount.ReservationID


																INNER JOIN PaymentMethods PM 
																ON PM.PaymentMethodID = P.PaymentMethodID 

																INNER JOIN PaymentStatus PS 
																ON PS.PaymentStatusID = P.PaymentStatusID 


                                                                WHERE  R.BookingDateTimeDateTime  >= @DateFrom AND
                                                                       R.BookingDateTimeDateTime < DATEADD(DAY , 1 , @DateTo ) ; 


                            ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@DateFrom", SqlDbType.Date).Value = DateFrom.Date;
                    command.Parameters.Add("@DateTo", SqlDbType.Date).Value = DateTo.Date;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_AllInformationBetweenTwoDate.Load(reader);

                    }

                }
            }

            return DT_AllInformationBetweenTwoDate;
        }

        public static DataTable GetAllInformationPaymentFilterTwoDate(DateTime DateFrom, DateTime DateTo)
            => _GetAllInformationPaymentFilterTwoDate(DateFrom, DateTo);

        #endregion


    }
}
