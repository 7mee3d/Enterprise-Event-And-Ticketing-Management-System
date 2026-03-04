using EETMS_DTOs;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EETMS_DataAccessLayer
{
    public class TicketCommandsDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion


        #region All Methods Ticket Commands

        private static int _InsertNewTicketToTheEventBy(TicketTypeDTO mTicketType)
        {

            int NewIDTicket = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {



                    string Query = @"


                                    INSERT INTO TicketTypes ( TicketTypeName , Quantity , Available , Price , EventID )
                                    VALUES (@TicketTypeName , @Quantity ,@Available ,  @Price , @EventID);


                                    SELECT SCOPE_IDENTITY(); 



                             ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@TicketTypeName", SqlDbType.NVarChar, 250).Value = mTicketType.TicketTypeName;
                        command.Parameters.Add("@Quantity", SqlDbType.Int).Value = mTicketType.Quantity;
                        command.Parameters.Add("@Available", SqlDbType.Int).Value = mTicketType.Quantity;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = mTicketType.Price;
                        command.Parameters.Add("@EventID", SqlDbType.Int).Value = mTicketType.EventID;

                        connection.Open();


                        object result = command.ExecuteScalar();


                        if (result != null && int.TryParse(result.ToString(), out int NewID))
                            NewIDTicket = NewID;


                        mTicketType.TicketTypeID = NewIDTicket;

                    }


                }
            }
            catch (Exception ex) { throw; }

            return NewIDTicket;

        }

        public static int InsertNewTicketToTheEventBy(TicketTypeDTO mTicketType)
            => _InsertNewTicketToTheEventBy(mTicketType);

        private static int _UpdateInformationTicketToTheEventBy(TicketTypeDTO mTicketType)
        {

            int RowAffective = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {



                    string Query = @"


                                    UPDATE TicketTypes

                                            SET Quantity = @Quantity , Available = @Available ,  Price = @Price 

                                            WHERE  EventID = @EventID AND TicketTypeID = @TicketTypeID



                             ";


                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        command.Parameters.Add("@Quantity", SqlDbType.Int).Value = mTicketType.Quantity;
                        command.Parameters.Add("@Available", SqlDbType.Int).Value = mTicketType.Available;
                        command.Parameters.Add("@Price", SqlDbType.Decimal).Value = mTicketType.Price;
                        command.Parameters.Add("@EventID", SqlDbType.Int).Value = mTicketType.EventID;
                        command.Parameters.Add("@TicketTypeID", SqlDbType.Int).Value = mTicketType.TicketTypeID;


                        connection.Open();


                        RowAffective = command.ExecuteNonQuery();



                    }


                }
            }
            catch (Exception ex) { throw; }

            return RowAffective;

        }

        public static int UpdateInformationTicketToTheEventBy(TicketTypeDTO mTicketType)
            => _UpdateInformationTicketToTheEventBy(mTicketType);


        #endregion


    }
}
