using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using EETMS_Models;
using System;

namespace EETMS_DataAccessLayer
{
    public class CustomerCommandsDAL
    {

        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion


        private static int _InsertNewCustomer(CustomerDTO NewCsutomer)
        {

            int ID_NewCustomer = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    string Query = @" 


                                    INSERT INTO Customers ( FirstName , MidName , LastName , NationalID ) 
                                    VALUES (@FirstName , @MidName , @LastName , @NationalID ) ;


                                        DECLARE @NEW_CUSTOMER_ID INT 
                                        SET @NEW_CUSTOMER_ID  = SCOPE_IDENTITY(); 


                                        
                                    INSERT INTO Emails ( EmailAddress , CusotmerID ) 
                                    VALUES (@EmailAddress, @NEW_CUSTOMER_ID) ;

                                    INSERT INTO Phones( PhoneNumber , CusotmerID ) 
                                    VALUES (@PhoneNumber, @NEW_CUSTOMER_ID ) ;


                                    SELECT @NEW_CUSTOMER_ID;



                                    ";

                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        Command.Parameters.AddWithValue("@FirstName", NewCsutomer.FirstName);

                        if (string.IsNullOrEmpty(NewCsutomer.MidName))
                            Command.Parameters.AddWithValue("@MidName", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@MidName", NewCsutomer.MidName);

                        Command.Parameters.AddWithValue("@LastName", NewCsutomer.LastName);
                        Command.Parameters.AddWithValue("@NationalID", NewCsutomer.NationalID);

                        if (string.IsNullOrEmpty(NewCsutomer.EmailCustomer))
                            Command.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@EmailAddress", NewCsutomer.EmailCustomer);

                        if (string.IsNullOrEmpty(NewCsutomer.PhoneCustomer))
                            Command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@PhoneNumber", NewCsutomer.PhoneCustomer);


                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int IDCustomer))
                            ID_NewCustomer = IDCustomer;


                        NewCsutomer.CusotmerID = ID_NewCustomer;


                    }
                }


            }
            catch (Exception Ex)
            {

                throw;
            }

            return ID_NewCustomer;
        }

        public static int InsertNewCustomer(CustomerDTO NewCsutomer)
        {
            return _InsertNewCustomer(NewCsutomer);
        }

        private static bool _DeleteTheCustomer(int IDCustomer)
        {

            int RowAffective = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    string Query = @"

                                                DELETE FROM Customers 
                                                WHERE CusotmerID = @CusotmerID 

                                        ";

                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        Command.Parameters.AddWithValue("@CusotmerID", IDCustomer);

                        connection.Open();

                        RowAffective = Command.ExecuteNonQuery();


                    }
                }


            }
            catch (Exception ex)
            {
                return false;
            }

            return RowAffective > 0;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return _DeleteTheCustomer(IDCustomer);

        }

        private static int _UpdateInformationCustomer(int IDCustomer, CustomerDTO NewCsutomerInformation)
        {


            int RowAffective = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    string Query = @" 


                                    UPDATE Customers 
                                    SET FirstName = @FirstName  , MidName = @MidName , LastName = @LastName , NationalID  = @NationalID  
                                    WHERE CusotmerID = @CusotmerID ; 


                                    UPDATE Emails 
                                    SET EmailAddress = @EmailAddress  
                                    WHERE CusotmerID = @CusotmerID ; 



                                    UPDATE Phones 
                                    SET PhoneNumber = @PhoneNumber  
                                    WHERE CustomerID = @CusotmerID ; 




                                    ";


                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        Command.Parameters.AddWithValue("@CusotmerID", IDCustomer);
                        Command.Parameters.AddWithValue("@FirstName", NewCsutomerInformation.FirstName);
                        Command.Parameters.AddWithValue("@MidName", NewCsutomerInformation.MidName);
                        Command.Parameters.AddWithValue("@LastName", NewCsutomerInformation.LastName);
                        Command.Parameters.AddWithValue("@NationalID", NewCsutomerInformation.NationalID);

                        if (string.IsNullOrEmpty(NewCsutomerInformation.EmailCustomer))
                            Command.Parameters.AddWithValue("@EmailAddress", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@EmailAddress", NewCsutomerInformation.EmailCustomer);

                        if (string.IsNullOrEmpty(NewCsutomerInformation.PhoneCustomer))
                            Command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                        else
                            Command.Parameters.AddWithValue("@PhoneNumber", NewCsutomerInformation.PhoneCustomer);


                        RowAffective = Command.ExecuteNonQuery();

                    }
                }


            }
            catch (Exception Ex)
            {
                throw;
            }

            return RowAffective;
        }

        public static int UpdateInformationCustomer(int IDCustomer, CustomerDTO NewCsutomerInformation)
        {
            return _UpdateInformationCustomer(IDCustomer, NewCsutomerInformation);
        }




    }
}
