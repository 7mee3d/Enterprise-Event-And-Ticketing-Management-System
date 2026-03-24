using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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

                                           INSERT INTO Reservations ( CusotmerID) 
                                           VALUES (@CusotmerID); 
                                            
                                           SELECT SCOPE_IDENTITY(); 


                        ";



                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {
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


        #endregion


    }
}
