

using EETMS_Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml.XPath;


namespace EETMS_DataAccessLayer
{
    public class ReservationDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion


        private static int _InsertTheNewReservation(MReservations mReservations)
        {

            int NewIDReservation = -1;


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {



                string Query = @"
                                            
                                            INSERT INTO Reservations (Quantity , 	TicketTypeID , 	CusotmerID ) 
                                            VALUES ( @Quantity , @TicketTypeID , @CusotmerID) ;

                                            
                                            SELECT SCOPE_IDENTITY(); 




                        ";



                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.Add("@Quantity", SqlDbType.Int).Value = mReservations.Quantity;
                    command.Parameters.Add("@TicketTypeID", SqlDbType.Int).Value = mReservations.TicketTypeID;
                    command.Parameters.Add("@CusotmerID", SqlDbType.Int).Value = mReservations.CustomerID;

                    connection.Open();


                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int NewIDR))
                        NewIDReservation = NewIDR;


                    mReservations.ReservationID = NewIDReservation;


                }
            }

            return NewIDReservation;
        }

        public static int InsertTheNewReservation(MReservations mReservations)
            => _InsertTheNewReservation(mReservations);

        private static int _UpdateTheQuntityTicketsBy(int EventID, string TicketTypeName, int NumberReservationTicket)
        {
            int RowAffective = -1;


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"
                                            UPDATE TicketTypes 
                                            SET Available = Available - @NumberReservationTicket 
                                            WHERE TicketTypeName = @TicketTypeName AND EventID = @EventID

                                        ";



                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.Add("@NumberReservationTicket", SqlDbType.Int).Value = NumberReservationTicket;
                    command.Parameters.AddWithValue("@TicketTypeName", TicketTypeName);
                    command.Parameters.Add("@EventID", SqlDbType.Int).Value = EventID;

                    connection.Open();


                    RowAffective = command.ExecuteNonQuery();


                }
            }

            return RowAffective;
        }

        public static int UpdateTheQuntityTicketsBy(int EventID, string TicketTypeName, int NewAvailableTicket)
            => _UpdateTheQuntityTicketsBy(EventID, TicketTypeName, NewAvailableTicket);


    }
}
