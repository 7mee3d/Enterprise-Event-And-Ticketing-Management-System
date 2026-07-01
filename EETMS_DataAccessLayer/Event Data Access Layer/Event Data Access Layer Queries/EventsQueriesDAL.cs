using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static EETMS_DTOs.EventFilterDTO;


namespace EETMS_DataAccessLayer
{
    public static class EventsQueriesDAL
    {


        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Method Event Queries


        private static DataTable _GetAllBasicInformationEvents()
        {

            DataTable EventsDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

                                 SELECT EventID ,
                                        EventName,
                                        DateTimeEvent,
                                        EndDateTimeEvent,
                                        Duration,
                                        MaxCapacity,
                                        Street,
                                        CountryID,
                                        CategoryID,
                                        Discripation,
                                        AvailableInEvent,
                                        StartTimeMeridiem ,
                                        EndTimeMeridiem


                                FROM [Events] ;

                                ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                                EventsDT.Load(reader);


                        }

                    }

                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return EventsDT;
        }

        public static DataTable GetAllBasicInformationEvents()
        {
            return _GetAllBasicInformationEvents();
        }

        private static DataTable _GetAllInformationEvents()
        {

            DataTable EventsDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"



                                   SELECT
						                        E.EventID,
						                        E.EventName,

						                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

						                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

						                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

						                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

						                        E.Duration,
						                        E.MaxCapacity,
						                        E.DateTimeEvent,
						                        E.EndDateTimeEvent,
						                        CAT.CategoryName,
						                        COUN.CountryName,
						                        E.Street,	
                                                E.Discripation ,
						                        E.IsActiveEvent ,
                                                E.EndDateTimeEvent , 
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem


                                                                        FROM Events E
                                                                        LEFT JOIN TicketTypes TT
                                                                            ON E.EventID = TT.EventID
                                                                        INNER JOIN Categories CAT
                                                                            ON CAT.CategoryID = E.CategoryID
                                                                        INNER JOIN Countries COUN
                                                                            ON COUN.CountryID = E.CountryID

                                     GROUP BY
                                     				E.EventID,
                                     				E.EventName,
                                     				E.Duration,
                                     				E.MaxCapacity,
                                     				E.DateTimeEvent,
                                     				E.EndDateTimeEvent,
                                     				CAT.CategoryName,
                                     				COUN.CountryName,
                                     				E.Street,
                                                    E.Discripation,
                                     				E.IsActiveEvent ,
                                                    E.EndDateTimeEvent ,
                                                    E.StartTimeMeridiem ,
                                                    E.EndTimeMeridiem ;





                                ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                                EventsDT.Load(reader);


                        }

                    }

                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return EventsDT;
        }

        public static DataTable GetAllInformationEvents()
        {
            return _GetAllInformationEvents();
        }

        private static EventDTO _FindTheEventByID(int EventID)
        {

            EventDTO InfoEvent = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"
                                            SELECT EventID ,
                                            EventName,
                                            DateTimeEvent,
                                            EndDateTimeEvent,
                                            Duration,
                                            MaxCapacity,
                                            Street,
                                            CountryID,
                                            CategoryID,
                                            Discripation ,
                                            StartTimeMeridiem  ,
                                            EndTimeMeridiem

                                                    FROM [Events]
                                                    WHERE EventID = @EventID ;


                                        ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                InfoEvent = new EventDTO()
                                {
                                    EventID = reader["EventID"] != DBNull.Value ? (int)reader["EventID"] : 0,
                                    EventName = reader["EventName"] != DBNull.Value ? (string)reader["EventName"] : null,
                                    DateTimeEvent = reader["DateTimeEvent"] != DBNull.Value ? (DateTime)reader["DateTimeEvent"] : (DateTime?)null,
                                    EndDateTimeEvent = reader["EndDateTimeEvent"] != DBNull.Value ? (DateTime)reader["EndDateTimeEvent"] : (DateTime?)null,
                                    DurationEvent = reader["Duration"] != DBNull.Value ? (int)reader["Duration"] : 0,
                                    MaxCapacity = reader["MaxCapacity"] != DBNull.Value ? (short)reader["MaxCapacity"] : 0,
                                    Street = reader["Street"] != DBNull.Value ? (string)reader["Street"] : null,
                                    CountryID = reader["CountryID"] != DBNull.Value ? (int)reader["CountryID"] : 0,
                                    CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0,
                                    Discripation = reader["Discripation"] != DBNull.Value ? (string)reader["Discripation"] : null,
                                    StartTimeMeridiem = reader["StartTimeMeridiem"] != DBNull.Value ? (string)reader["StartTimeMeridiem"] : null,
                                    EndTimeMeridiem = reader["EndTimeMeridiem"] != DBNull.Value ? (string)reader["EndTimeMeridiem"] : null,
                                };

                            }


                        }

                    }

                }
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);

            }


            return InfoEvent;
        }

        public static EventDTO FindTheEventByID(int EventID)
        {
            return _FindTheEventByID(EventID);
        }

        private static DataTable _GetEventTicketCapacityInfoBy(int EventID)
        {

            DataTable DT_EventTicketCapacityInfo = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {



                string Query = @"


                                    SELECT

                                                  E.EventID,
                                                  E.EventName,
                                                  E.MaxCapacity,
                                                  ISNULL(SUM(T.Quantity), 0) AS TotalQuantityTickets,
                                                  (E.MaxCapacity - ISNULL(SUM(T.Quantity), 0)) AS RemainingCapacity

                                        FROM Events E
                                        LEFT JOIN TicketTypes T
                                            ON T.EventID = E.EventID

                                        WHERE E.EventID = @EventID

                                        GROUP BY 
                                                    E.EventID, 
                                                    E.EventName, 
                                                    E.MaxCapacity;



                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventTicketCapacityInfo.Load(reader);


                    }



                }
            }

            return DT_EventTicketCapacityInfo;

        }

        public static DataTable GetEventTicketCapacityInfoBy(int EventID)
            => _GetEventTicketCapacityInfoBy(EventID);

        private static DataTable _GetRemainingCapacityEventfoBy(int EventID)
        {

            DataTable DT_EventRemainingCapacity = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {



                string Query = @"


                                    SELECT

                                                  E.EventID,
                                                  ISNULL(E.MaxCapacity - SUM(T.Quantity - T.Available), E.MaxCapacity) AS RemainingCapacity


                                        FROM Events E
                                        LEFT JOIN TicketTypes T
                                            ON T.EventID = E.EventID

                                        WHERE E.EventID = @EventID

                                        GROUP BY 
                                                    E.EventID, 
                                                     E.MaxCapacity;



                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventRemainingCapacity.Load(reader);


                    }



                }
            }

            return DT_EventRemainingCapacity;

        }

        public static DataTable GetRemainingCapacityEventfoBy(int EventID)
            => _GetRemainingCapacityEventfoBy(EventID);

        private static DataTable _GetTheAllEventsAccordingTheSearchBy(string NameEvent)
        {
            DataTable DT_FinialResultEventAfterSearch = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @" 

                                   SELECT
						                        E.EventID,
						                        E.EventName,

						                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

						                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

						                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

						                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

						                        E.Duration,
						                        E.MaxCapacity,
						                        E.DateTimeEvent,
						                        E.EndDateTimeEvent,
						                        CAT.CategoryName,
						                        COUN.CountryName,
						                        E.Street,	
                                                E.Discripation ,
						                        E.IsActiveEvent


                                                                        FROM Events E
                                                                        LEFT JOIN TicketTypes TT
                                                                            ON E.EventID = TT.EventID
                                                                        INNER JOIN Categories CAT
                                                                            ON CAT.CategoryID = E.CategoryID
                                                                        INNER JOIN Countries COUN
                                                                            ON COUN.CountryID = E.CountryID
                                     WHERE 


                                                 LOWER ( E.EventName ) 
                                                 LIKE 
                                                 LOWER ( '%' + @EventName + '%' ) 


                                     GROUP BY
                                     				E.EventID,
                                     				E.EventName,
                                     				E.Duration,
                                     				E.MaxCapacity,
                                     				E.DateTimeEvent,
                                     				E.EndDateTimeEvent,
                                     				CAT.CategoryName,
                                     				COUN.CountryName,
                                     				E.Street,
                                                    E.Discripation,
                                     				E.IsActiveEvent;
                                           



                                    ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {



                    command.Parameters.AddWithValue("@EventName", NameEvent);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows) DT_FinialResultEventAfterSearch.Load(reader);

                    }
                }
            }

            return DT_FinialResultEventAfterSearch;

        }

        public static DataTable GetTheAllEventsAccordingTheSearchBy(string NameEvent)
            => _GetTheAllEventsAccordingTheSearchBy(NameEvent);

        private static DataTable _GetAllInfromationEventFilterBy(int StatusEventToBeFilter)
        {

            DataTable DT_AllInformationEventAfterFilter = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"


   
   
   
                                     SELECT
                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                        E.Duration,
                                                        E.MaxCapacity,
                                                        E.DateTimeEvent,
                                                        E.EndDateTimeEvent,
                                                        CAT.CategoryName,
                                                        COUN.CountryName,
                                                        E.Street,	
                                                        E.Discripation ,
                                                        E.IsActiveEvent ,
                                                        E.StartTimeMeridiem ,
                                                        E.EndTimeMeridiem


                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID


                                   GROUP BY
                 				                    E.EventID,
                 				                    E.EventName,
                 				                    E.Duration,
                 				                    E.MaxCapacity,
                 				                    E.DateTimeEvent,
                 				                    E.EndDateTimeEvent,
                 				                    CAT.CategoryName,
                 				                    COUN.CountryName,
                 				                    E.Street,
								                    E.Discripation,
                 				                    E.IsActiveEvent,
                                                    E.StartTimeMeridiem ,
                                                    E.EndTimeMeridiem



		                        HAVING  ( 
					                            CASE 
								                            WHEN ISNULL(SUM(TT.Quantity - TT.Available), 0)   = ISNULL(SUM(TT.Quantity), 0) THEN 1 -- Fully Booked
								                            WHEN ISNULL(SUM(TT.Quantity - TT.Available), 0) > 0 THEN 2 -- Live 
								                            ELSE 3 -- Draft 

					                            END

				                        ) = @StatusEvent ;

                        ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@StatusEvent", SqlDbType.Int).Value = StatusEventToBeFilter;

                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.HasRows)
                                DT_AllInformationEventAfterFilter.Load(reader);


                        }



                    }

                }
            }
            catch (Exception ex) { throw; }

            return DT_AllInformationEventAfterFilter;

        }

        public static DataTable GetAllInfromationEventFilterBy(int StatusEventToBeFilter)
            => _GetAllInfromationEventFilterBy(StatusEventToBeFilter);

        private static DataTable _GetAllEventAccordingCategoryBy(string CategoryName)
        {

            DataTable DT_AllEventsAfterFilter = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {

                string Query = @"


                                  SELECT
                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                        E.Duration,
                                                        E.MaxCapacity,
                                                        E.DateTimeEvent,
                                                        E.EndDateTimeEvent,
                                                        CAT.CategoryName,
                                                        COUN.CountryName,
                                                        E.Street,	
                                                        E.Discripation ,
                                                        E.IsActiveEvent , 
                                                        E.StartTimeMeridiem ,
                                                        E.EndTimeMeridiem


                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID

								   WHERE   CAT.CategoryName = @CategoryName 

                                   GROUP BY
                 				                    E.EventID,
                 				                    E.EventName,
                 				                    E.Duration,
                 				                    E.MaxCapacity,
                 				                    E.DateTimeEvent,
                 				                    E.EndDateTimeEvent,
                 				                    CAT.CategoryName,
                 				                    COUN.CountryName,
                 				                    E.Street,
								                    E.Discripation,
                 				                    E.IsActiveEvent,
                                                    E.StartTimeMeridiem ,
                                                    E.EndTimeMeridiem


                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@CategoryName", CategoryName);

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_AllEventsAfterFilter.Load(reader);

                    }


                }

            }
            return DT_AllEventsAfterFilter;

        }

        public static DataTable GetAllEventAccordingCategoryBy(string CategoryName)
            => _GetAllEventAccordingCategoryBy(CategoryName);

        public static DataTable GetAllEventAccordingByCapacityUsageLessThan50Percent()
        {

            DataTable DT_EventsCapacityUsageLessThan50 = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                  SELECT

                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                        E.Duration,
                                                        E.MaxCapacity,
                                                        E.DateTimeEvent,
                                                        E.EndDateTimeEvent,
                                                        CAT.CategoryName,
                                                        COUN.CountryName,
                                                        E.Street,	
                                                        E.Discripation ,
                                                        E.IsActiveEvent,
                                                        E.StartTimeMeridiem ,
                                                        E.EndTimeMeridiem


                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID

                                GROUP BY
                 				                    E.EventID,
                 				                    E.EventName,
                 				                    E.Duration,
                 				                    E.MaxCapacity,
                 				                    E.DateTimeEvent,
                 				                    E.EndDateTimeEvent,
                 				                    CAT.CategoryName,
                 				                    COUN.CountryName,
                 				                    E.Street,
								                    E.Discripation,
                 				                    E.IsActiveEvent,
                                                    E.StartTimeMeridiem ,
                                                    E.EndTimeMeridiem

								HAVING 
											( ISNULL(SUM(TT.Quantity - TT.Available),0) * 100.0 ) / E.MaxCapacity < 50



                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventsCapacityUsageLessThan50.Load(reader);

                    }


                }

            }

            return DT_EventsCapacityUsageLessThan50;

        }

        public static DataTable GetAllEventAccordingByCapacityUsageBetween50And90Percent()
        {

            DataTable DT_EventsCapacityUsageBetween50And90 = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                  SELECT

                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                        E.Duration,
                                                        E.MaxCapacity,
                                                        E.DateTimeEvent,
                                                        CAT.CategoryName,
                                                        COUN.CountryName,
                                                        E.Street,	
                                                        E.Discripation ,
                                                        E.IsActiveEvent,
                                                        E.StartTimeMeridiem ,
                                                        E.EndTimeMeridiem


                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID

                                GROUP BY
                 				                    E.EventID,
                 				                    E.EventName,
                 				                    E.Duration,
                 				                    E.MaxCapacity,
                 				                    E.DateTimeEvent,
                 				                    CAT.CategoryName,
                 				                    COUN.CountryName,
                 				                    E.Street,
								                    E.Discripation,
                 				                    E.IsActiveEvent,
                                                    E.StartTimeMeridiem ,
                                                    E.EndTimeMeridiem

								HAVING 
											( ISNULL(SUM(TT.Quantity - TT.Available),0) * 100.0 ) / E.MaxCapacity BETWEEN 50 AND 90 



                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventsCapacityUsageBetween50And90.Load(reader);

                    }


                }

            }

            return DT_EventsCapacityUsageBetween50And90;

        }

        public static DataTable GetAllEventAccordingByCapacityUsageBetween90And99Percent()
        {

            DataTable DT_EventsCapacityUsageBetween90And99 = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                  SELECT

                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                       
						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem



                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID

                                GROUP BY
                 				                    
						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem


								HAVING 
										(SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity BETWEEN 90 AND 99 ;
                       



                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventsCapacityUsageBetween90And99.Load(reader);

                    }


                }

            }

            return DT_EventsCapacityUsageBetween90And99;

        }

        public static DataTable GetAllEventAccordingByCapacityUsageSoldOut()
        {

            DataTable DT_EventsCapacityUsageSoldOut = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                  SELECT

                                                        E.EventID,
                                                        E.EventName,

                                                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

                                                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

                                                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

                                                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

                                                        E.Duration,
                                                        E.MaxCapacity,
                                                        E.DateTimeEvent,
                                                        E.EndDateTimeEvent,
                                                        CAT.CategoryName,
                                                        COUN.CountryName,
                                                        E.Street,	
                                                        E.Discripation ,
                                                        E.IsActiveEvent,
                                                        E.StartTimeMeridiem ,
                                                        E.EndTimeMeridiem


                                                                                     FROM Events E
                                                                                     LEFT JOIN TicketTypes TT
                                                                                         ON E.EventID = TT.EventID
                                                                                     INNER JOIN Categories CAT
                                                                                         ON CAT.CategoryID = E.CategoryID
                                                                                     INNER JOIN Countries COUN
                                                                                         ON COUN.CountryID = E.CountryID

                                GROUP BY
                 				                    
						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem

								HAVING 
										((SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity ) >= 100 
                               



                        ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_EventsCapacityUsageSoldOut.Load(reader);

                    }


                }

            }

            return DT_EventsCapacityUsageSoldOut;

        }

        public static DataTable GetAllInformationEventAccrodingCountryAndStreetBy(string CountryName, string StreetName)
        {

            DataTable DT_AllEventsAccordingCountryNameAndStreet = new DataTable();



            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"

                                   SELECT
						                        E.EventID,
						                        E.EventName,

						                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

						                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

						                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

						                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem


                                                                        FROM Events E
                                                                        LEFT JOIN TicketTypes TT
                                                                            ON E.EventID = TT.EventID
                                                                        INNER JOIN Categories CAT
                                                                            ON CAT.CategoryID = E.CategoryID
                                                                        INNER JOIN Countries COUN
                                                                            ON COUN.CountryID = E.CountryID


								     WHERE COUN.CountryName = @CountryName AND E.Street LIKE '%' + @StreetName + '%'

                                     GROUP BY
						                        E.EventID,
                                                E.EventName,
						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem

                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@CountryName", CountryName);
                    command.Parameters.AddWithValue("@StreetName", StreetName);

                    connection.Open();



                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllEventsAccordingCountryNameAndStreet.Load(reader);

                }



            }

            return DT_AllEventsAccordingCountryNameAndStreet;

        }

        public static DataTable GetAllInformationEventAccrodingStatusAndCategoryAndCountryAndCapacityAndLocationBy(EventFilterDTO eventFilterDTO)
        {

            DataTable DT_AllEventsAccordingAllOptions = new DataTable();



            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"



                                  
                                   SELECT
						                        E.EventID,
						                        E.EventName,

						                        ISNULL(SUM(TT.Available), 0) AS AvailableTickets,

						                        ISNULL(SUM(TT.Quantity), 0) AS TotalCreatedTickets,

						                        ISNULL(SUM(TT.Quantity - TT.Available), 0) AS SoldTickets,

						                        ISNULL(E.MaxCapacity - SUM(TT.Quantity - TT.Available), E.MaxCapacity) AS RemainingCapacity,

						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem



                                                                        FROM Events E
                                                                        LEFT JOIN TicketTypes TT
                                                                            ON E.EventID = TT.EventID
                                                                        INNER JOIN Categories CAT
                                                                            ON CAT.CategoryID = E.CategoryID
                                                                        INNER JOIN Countries COUN
                                                                            ON COUN.CountryID = E.CountryID
																		

                                     WHERE 
                                 
                                               (@CountryName IS NULL OR @CountryName = '' OR COUN.CountryName = @CountryName)

                                               AND (@StreetName IS NULL OR @StreetName = '' 
                                                    OR LOWER(E.Street) LIKE LOWER('%' + @StreetName + '%'))
								    
									

                                     GROUP BY 
                                                E.EventID,
                                                E.EventName,
						                        E.Duration,
                                                E.MaxCapacity,
                                                E.DateTimeEvent,
                                                E.EndDateTimeEvent,
                                                CAT.CategoryName,
                                                COUN.CountryName,
                                                E.Street,	
                                                E.Discripation ,
                                                E.IsActiveEvent,
                                                E.StartTimeMeridiem ,
                                                E.EndTimeMeridiem


                                      HAVING  
                                      
                                      (
                                                  @StatusEvent IS NULL 
                                                  OR @StatusEvent = '' 
                                                  OR
                                                  CASE 
                                                      WHEN ISNULL(SUM(TT.Quantity - TT.Available),0) = ISNULL(SUM(TT.Quantity),0) THEN 'Fully Booked'
                                                      WHEN ISNULL(SUM(TT.Quantity - TT.Available),0) > 0 THEN 'Live'
                                                      ELSE 'Draft'
                                                  END = @StatusEvent
                                      )
                                      
                                      AND
                                      (
                                                  @CategoryEventName IS NULL
                                                  OR @CategoryEventName = ''
                                                  OR CAT.CategoryName = @CategoryEventName
                                      )
                                      
                                      AND
                                      (
                                                   @UnsageCapacityEvent IS NULL
                                                   OR @UnsageCapacityEvent = ''
                                                   OR
                                                   CASE 
                                                       WHEN (SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity < 50 THEN 'Less Than 50%'
                                                       WHEN (SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity BETWEEN 50 AND 90 THEN '50% - 90%'
                                                       WHEN (SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity BETWEEN 90 AND 99 THEN 'Almost Full'
                                                       WHEN (SUM(TT.Quantity - TT.Available) * 100.0) / E.MaxCapacity >= 100 THEN 'Sold Out'
                                                   END = @UnsageCapacityEvent
                                      )



                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@StatusEvent", eventFilterDTO.StatusEvent);
                    command.Parameters.AddWithValue("@CategoryEventName", eventFilterDTO.CategoryEvent);
                    command.Parameters.AddWithValue("@UnsageCapacityEvent", eventFilterDTO.UnsageCapacityEvent);
                    command.Parameters.AddWithValue("@CountryName", eventFilterDTO.CountryName);
                    command.Parameters.AddWithValue("@StreetName", eventFilterDTO.Street);

                    connection.Open();



                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.HasRows)
                            DT_AllEventsAccordingAllOptions.Load(reader);




                }



            }

            return DT_AllEventsAccordingAllOptions;

        }

        private static bool _IsTheEventExsitsOrNotBy(string NameEvent)
        {

            bool FlagIsExsistsEvent = false;


            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"


                                 SELECT DISTINCT 1 
                                 FROM Events EVE
                                 WHERE EVE.EventName = @EventName

                            ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {


                        command.Parameters.AddWithValue("@EventName", NameEvent);

                        connection.Open();


                        using (SqlDataReader reader = command.ExecuteReader())
                            if (reader.Read())
                                FlagIsExsistsEvent = true;



                    }
                }
            }
            catch (Exception ex)
            {
                return FlagIsExsistsEvent;
            }


            return FlagIsExsistsEvent;
        }

        public static bool IsTheEventExsitsOrNotBy(string NameEvent)
            => _IsTheEventExsitsOrNotBy(NameEvent);

        #endregion


    }
}
