
using EETMS_Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public static class EventsDAL
    {


        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Method CRUD Event Result-Set


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

        private static MEvent _FindTheEventByID(int EventID)
        {

            MEvent InfoEvent = null;

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
                                InfoEvent = new MEvent()
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

        public static MEvent FindTheEventByID(int EventID)
        {
            return _FindTheEventByID(EventID);
        }

        private static int _InsertNewEvent(MEvent InfoNewEvent)
        {
            int NewID = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {



                    string Query = @"
                                            INSERT INTO [Events] (

                                                                        EventName,
                                                                        DateTimeEvent,
                                                                        Duration,
                                                                        MaxCapacity,
                                                                        Street,
                                                                        CountryID,
                                                                        CategoryID,
                                                                        Discripation

                                                                    )

                                            VALUES (@EventName , @DateTimeEvent , @Duration , @MaxCapacity , @Street , @CountryID , @CategoryID , @Discripation) ;


                                            SELECT SCOPE_IDENTITY();



                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("EventName", SqlDbType.NVarChar, 300).Value = InfoNewEvent.EventName;
                        command.Parameters.Add("DateTimeEvent", SqlDbType.DateTime2).Value = InfoNewEvent.DateTimeEvent;
                        command.Parameters.Add("Duration", SqlDbType.Int).Value = InfoNewEvent.DurationEvent;
                        command.Parameters.Add("MaxCapacity", SqlDbType.SmallInt).Value = InfoNewEvent.MaxCapacity;
                        command.Parameters.Add("Street", SqlDbType.NVarChar, 350).Value = InfoNewEvent.Street;
                        command.Parameters.Add("CountryID", SqlDbType.Int).Value = InfoNewEvent.CountryID;
                        command.Parameters.Add("CategoryID", SqlDbType.Int).Value = InfoNewEvent.CategoryID;
                        command.Parameters.Add("Discripation", SqlDbType.NVarChar).Value = InfoNewEvent.Discripation;


                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int NewIDEvent))
                            NewID = NewIDEvent;

                        InfoNewEvent.EventID = NewID;




                    }
                }


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

            return NewID;

        }

        public static int InsertNewEvent(MEvent InfoNewEvent)
        {
            return _InsertNewEvent(InfoNewEvent);
        }

        private static int _UpdateInformationEvent(int IDEvent, MEvent NewInformationEvent)
        {
            int RowAffective = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

                                UPDATE [Events]
                                            SET
                                            EventName = @EventName ,
                                            DateTimeEvent = @DateTimeEvent ,
                                            Duration = @Duration ,
                                            MaxCapacity = @MaxCapacity,
                                            Street = @Street ,
                                            CountryID = @CountryID ,
                                            CategoryID = @CategoryID ,
                                            Discripation = @Discripation,
                                            IsActiveEvent = @IsActiveEvent
                                            

                                WHERE EventID = @EventID ;

                                    ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("EventID", SqlDbType.Int).Value = IDEvent;
                        command.Parameters.Add("EventName", SqlDbType.NVarChar, 300).Value = NewInformationEvent.EventName;
                        command.Parameters.Add("DateTimeEvent", SqlDbType.DateTime2).Value = NewInformationEvent.DateTimeEvent;
                        command.Parameters.Add("Duration", SqlDbType.Int).Value = NewInformationEvent.DurationEvent;
                        command.Parameters.Add("MaxCapacity", SqlDbType.SmallInt).Value = NewInformationEvent.MaxCapacity;
                        command.Parameters.Add("Street", SqlDbType.NVarChar, 350).Value = NewInformationEvent.Street;
                        command.Parameters.Add("CountryID", SqlDbType.Int).Value = NewInformationEvent.CountryID;
                        command.Parameters.Add("CategoryID", SqlDbType.Int).Value = NewInformationEvent.CategoryID;
                        command.Parameters.Add("Discripation", SqlDbType.NVarChar).Value = NewInformationEvent.Discripation;
                        command.Parameters.Add("IsActiveEvent", SqlDbType.Bit).Value = NewInformationEvent.IsActiveEvent;


                        connection.Open();


                        RowAffective = command.ExecuteNonQuery();


                    }
                }

            }
            catch (Exception Ex)
            {
                throw;
            }

            return RowAffective;
        }

        public static int UpdateInformationEvent(int IDEvent, MEvent NewInformationEvent)
        {
            return _UpdateInformationEvent(IDEvent, NewInformationEvent);
        }

        private static int _DeleteTheEventByID(int IDEvent)
        {
            int RowAffective = -1;

            try
            {


                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {

                    string Query = @"

                                    DELETE FROM [Events]
                                    WHERE EventID = @EventID ;



                                    ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("EventID", SqlDbType.Int).Value = IDEvent;

                        connection.Open();



                        RowAffective = command.ExecuteNonQuery();
                    }
                }



            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message);
            }

            return RowAffective;
        }

        public static int DeleteTheEventByID(int IDEvent)
        {
            return _DeleteTheEventByID(IDEvent);
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




        #endregion


    }
}
