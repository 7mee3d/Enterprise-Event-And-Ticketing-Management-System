using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class EventCommandsDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Methods Events Commands 

        private static int _InsertNewEvent(EventDTO InfoNewEvent)
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
                                                                        EndDateTimeEvent,
                                                                        Duration,
                                                                        MaxCapacity,
                                                                        Street,
                                                                        CountryID,
                                                                        CategoryID,
                                                                        Discripation

                                                                    )

                                            VALUES (@EventName , @DateTimeEvent , @EndDateTimeEvent , @Duration , @MaxCapacity , @Street , @CountryID , @CategoryID , @Discripation) ;


                                            SELECT SCOPE_IDENTITY();



                                   ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("EventName", SqlDbType.NVarChar, 300).Value = InfoNewEvent.EventName;
                        command.Parameters.Add("DateTimeEvent", SqlDbType.DateTime2).Value = InfoNewEvent.DateTimeEvent;
                        command.Parameters.Add("EndDateTimeEvent", SqlDbType.DateTime2).Value = InfoNewEvent.EndDateTimeEvent;
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
                throw;
            }

            return NewID;

        }

        public static int InsertNewEvent(EventDTO InfoNewEvent)
             => _InsertNewEvent(InfoNewEvent);

        private static int _UpdateInformationEvent(int IDEvent, EventDTO NewInformationEvent)
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

        public static int UpdateInformationEvent(int IDEvent, EventDTO NewInformationEvent)
            => _UpdateInformationEvent(IDEvent, NewInformationEvent);

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

                return RowAffective;
            }

            return RowAffective;
        }

        public static int DeleteTheEventByID(int IDEvent)
            => _DeleteTheEventByID(IDEvent);


        #endregion


    }
}
