
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using EETMS_DTOs;
using System;
using EETMS_DTOs.Reservation_Tickets_DTO;

namespace EETMS_DataAccessLayer
{
    public class ReservationTicketCommandsDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion



        #region All Methods Reservation Ticket Commands 

        private static int _InsertTheNewReservation(ReservationTicketsDTO mReservations)
        {

            int NewIDReservation = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {



                    string Query = @"

                                            INSERT INTO ReservationTickets (Price, Quantity, TicketTypeID, ReservationID)
                                            VALUES ( @Price , @Quantity , @TicketTypeID , @ReservationID) ;

                                            
                                            SELECT SCOPE_IDENTITY(); 


                        ";



                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
                        command.Parameters.Add("@Quantity", SqlDbType.Int).Value = mReservations.Quantity;
                        command.Parameters.Add("@Price", SqlDbType.Int).Value = mReservations.Price;
                        command.Parameters.Add("@TicketTypeID", SqlDbType.Int).Value = mReservations.TicketTypeID;
                        command.Parameters.Add("@ReservationID", SqlDbType.Int).Value = mReservations.ReservationID;

                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int NewIDR))
                            NewIDReservation = NewIDR;


                        mReservations.ReservationID = NewIDReservation;


                    }
                }
            }
            catch (Exception ex) { throw; }

            return NewIDReservation;
        }

        public static int InsertTheNewReservation(ReservationTicketsDTO mReservations)
            => _InsertTheNewReservation(mReservations);

        private static int _UpdateTheQuntityTicketsBy(int EventID, string TicketTypeName, int NumberReservationTicket)
        {

            int RowAffective = -1;

            try
            {

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
            }
            catch (Exception ex) { throw; }
            ;

            return RowAffective;
        }

        public static int UpdateTheQuntityTicketsBy(int EventID, string TicketTypeName, int NewAvailableTicket)
            => _UpdateTheQuntityTicketsBy(EventID, TicketTypeName, NewAvailableTicket);

        #endregion


    }
}
