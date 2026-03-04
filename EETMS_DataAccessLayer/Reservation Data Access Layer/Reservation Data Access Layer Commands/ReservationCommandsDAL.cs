
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using EETMS_DTOs;
using System;

namespace EETMS_DataAccessLayer
{
    public class ReservationCommandsDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion



        #region All Methods Reservation Commands 

        private static int _InsertTheNewReservation(ReservationsDTO mReservations)
        {

            int NewIDReservation = -1;

            try
            {
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
            }
            catch (Exception ex) { throw; }

            return NewIDReservation;
        }

        public static int InsertTheNewReservation(ReservationsDTO mReservations)
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
