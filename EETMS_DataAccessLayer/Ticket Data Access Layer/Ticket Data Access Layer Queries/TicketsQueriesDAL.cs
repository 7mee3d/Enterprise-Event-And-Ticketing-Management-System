using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using EETMS_DTOs;

namespace EETMS_DataAccessLayer
{
    public class TicketsQueriesDAL
    {


        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion



        #region All Methods Ticket Queries 

        private static DataTable _GetInformation_ID_Name_EventsInProgress()
        {
            DataTable Events_DT = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"
                                        
                                       SELECT 
                                                 E.EventID ,
                                                 E.EventName 

                                     FROM [Events] E
                                     WHERE GETDATE() < E.EndDateTimeEvent
                                ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows) Events_DT.Load(reader);


                    }


                }
            }

            return Events_DT;
        }

        public static DataTable GetInformation_ID_Name_EventsInProgress()
            => _GetInformation_ID_Name_EventsInProgress();

        private static DataTable _GetInformationTicketForEventBy(int EventID)
        {

            DataTable Ticket_DT = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"

                                        SELECT

                                                    T.TicketTypeID ,
                                                    E.EventName ,
                                                    T.TicketTypeName ,
                                                    T.Quantity ,
                                                    T.Available ,
                                                    T.Price ,

                                                    ( T.Quantity -  T.Available ) AS [CurrentSales]
                                                    
                                        FROM Events E
                                        INNER JOIN TicketTypes T
                                        ON T.EventID = E.EventID

                                        WHERE E.EventID = @EventID;



                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;

                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.HasRows) Ticket_DT.Load(reader);



                    }
                }
            }

            return Ticket_DT;

        }

        public static DataTable GetInformationTicketForEventBy(int EventID)
            => _GetInformationTicketForEventBy(EventID);

        private static TicketTypeDTO _FindTheTicketTypeBy(int EventID, int TicketID)
        {

            TicketTypeDTO TicketTypedto = null;


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"

                                            SELECT
                                                         TT.TicketTypeID ,
                                                         TT.TicketTypeName ,
                                                         TT.Quantity , 
                                                         TT.Available , 
                                                         TT.Price ,
                                                         TT.EventID 


                                            FROM TicketTypes TT
                                            WHERE TT.EventID = @EventID AND TT.TicketTypeID = @TicketID





                        ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;
                    command.Parameters.Add("@TicketID", SqlDbType.Int).Value = TicketID;


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        if (reader.Read())
                        {

                            TicketTypedto = new TicketTypeDTO()
                            {

                                TicketTypeID = TicketID,
                                TicketTypeName = reader["TicketTypeName"] != DBNull.Value ? reader["TicketTypeName"].ToString() : null,
                                Quantity = reader["Quantity"] != DBNull.Value ? Convert.ToInt32(reader["Quantity"]) : 0,
                                Available = reader["Available"] != DBNull.Value ? Convert.ToInt32(reader["Available"]) : 0,
                                Price = reader["Price"] != DBNull.Value ? Convert.ToDecimal(reader["Price"]) : 0.0M,
                                EventID = EventID,



                            };
                        }

                    }
                }


            }

            return TicketTypedto;
        }

        public static TicketTypeDTO FindTheTicketTypeBy(int EventID, int TicketID)
            => _FindTheTicketTypeBy(EventID, TicketID);

        private static Dictionary<int, string> _GetTheAllTicketTypeBy(int IDEvent)
        {
            Dictionary<int, string> Dic_AllTicketTypes = new Dictionary<int, string>();


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {

                string Query = @"



                                            SELECT TT.TicketTypeID , TT.TicketTypeName
                                            FROM TicketTypes TT

                                            INNER JOIN [Events] E
                                            ON E.EventID = TT.EventID

                                            WHERE E.EventID = @IDEvent



                            ";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@IDEvent", SqlDbType.Int).Value = IDEvent;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            int TicketTypeID = reader["TicketTypeID"] != DBNull.Value ? Convert.ToInt32(reader["TicketTypeID"]) : 0;
                            string TicketTypeName = reader["TicketTypeName"] != DBNull.Value ? reader["TicketTypeName"].ToString() : null;

                            Dic_AllTicketTypes.Add(TicketTypeID, TicketTypeName);
                        }

                    }

                }

            }

            return Dic_AllTicketTypes;

        }

        public static Dictionary<int, string> GetTheAllTicketTypeBy(int IDEvent)
            => _GetTheAllTicketTypeBy(IDEvent);


        #endregion

    }
}
