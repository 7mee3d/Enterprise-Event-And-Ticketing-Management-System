using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


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
                                        Duration,
                                        MaxCapacity,
                                        Street,
                                        CountryID,
                                        CategoryID,
                                        Discripation,
                                        AvailableInEvent


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
                                     				E.IsActiveEvent;





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
                                            Duration,
                                            MaxCapacity,
                                            Street,
                                            CountryID,
                                            CategoryID,
                                            Discripation

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
                                    DurationEvent = reader["Duration"] != DBNull.Value ? (int)reader["Duration"] : 0,
                                    MaxCapacity = reader["MaxCapacity"] != DBNull.Value ? (short)reader["MaxCapacity"] : 0,
                                    Street = reader["Street"] != DBNull.Value ? (string)reader["Street"] : null,
                                    CountryID = reader["CountryID"] != DBNull.Value ? (int)reader["CountryID"] : 0,
                                    CategoryID = reader["CategoryID"] != DBNull.Value ? (int)reader["CategoryID"] : 0,
                                    Discripation = reader["Discripation"] != DBNull.Value ? (string)reader["Discripation"] : null,
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


        #endregion


    }
}
