using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class PaymentCommandsDAL
    {


        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion


        #region All Methods Payment Commands 


        private static int _InsertNewPayment(PaymentDTO mPayment)
        {

            int NewIDReservationPayment = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

                                            INSERT INTO Payments ( Amount , PaymentMethodID , PaymentStatusID , ReservationID )
                                            VALUES (@Amount , @PaymentMethodID , @PaymentStatusID , @ReservationID ) ;


                                            SELECT SCOPE_IDENTITY();

                                 ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {


                        command.Parameters.AddWithValue("@Amount", mPayment.PaidAmount);
                        command.Parameters.AddWithValue("@PaymentMethodID", Convert.ToInt32(mPayment.PaymentMethod));
                        command.Parameters.AddWithValue("@PaymentStatusID", Convert.ToInt32(mPayment.PaymentStatus));
                        command.Parameters.AddWithValue("@ReservationID", mPayment.BookingID);

                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                            NewIDReservationPayment = NewID;

                        mPayment.PaymentID = NewIDReservationPayment;

                    }
                }
            }
            catch (Exception ex) { throw; }

            return NewIDReservationPayment;
        }

        public static int InsertNewPayment(PaymentDTO mPayment)
            => _InsertNewPayment(mPayment);


        #endregion

    }
}
