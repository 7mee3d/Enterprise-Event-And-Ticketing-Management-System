
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class TicketsDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion


        private static DataTable _GetInformation_ID_Name_Events()
        {
            DataTable Events_DT = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"
                                        
                                     SELECT 
                                                 EventID ,
                                                 EventName 

                                     FROM [Events] 

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

        public static DataTable GetInformation_ID_Name_Events()
            => _GetInformation_ID_Name_Events();

        private static DataTable _GetInformationTicketForEventBy(int EventID)
        {

            DataTable Ticket_DT = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"

                                        SELECT
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



    }
}
