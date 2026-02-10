using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using EETMS_Models;
using System;

namespace EETMS_DataAccessLayer
{
    public class CustomerDAL
    {
        #region  The Connection String [Connect The Data base EETMS] 

        private static readonly string _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #endregion


        #region All Method Data Access Connection With Data Base [ EETMS ] 
        private static DataTable _GetAllCustomersInformation()
        {
            DataTable DT_Customers = new DataTable("infoCustomers");


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {

                string Query = @"
                                            SELECT CusotmerID,	FirstName,	MidName,	LastName,	NationalID
                                            FROM Customers
                                
                                ";


                using (SqlCommand Command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                            DT_Customers.Load(Reader);

                    }

                }


            }

            return DT_Customers;
        }

        public static DataTable GetAllCustomersInformation()
        {
            return _GetAllCustomersInformation();
        }

        private static DataTable _GetAllCustomersInformationJoinesPhoneAndEmail()
        {
          
            DataTable DT_Customers = new DataTable();


            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {

                string Query = @"
                                            
                                        SELECT 
			                                    Customers.CusotmerID ,
			                                    Customers.FirstName ,
			                                    Customers.MidName ,
			                                    Customers.LastName , 
			                                    Customers.NationalID ,
			                                    Emails.EmailAddress , 
			                                    Phones.PhoneNumber 

                                                                FROM Customers 
                                                                INNER JOIN Emails 
                                                                ON Emails.CusotmerID = Customers.CusotmerID 
                                                                INNER JOIN Phones 
                                                                ON Phones.CusotmerID = Customers.CusotmerID 
                                
                                ";


                using (SqlCommand Command = new SqlCommand(Query, connection))
                {

                    connection.Open();

                    using (SqlDataReader Reader = Command.ExecuteReader())
                    {
                        if (Reader.HasRows)
                            DT_Customers.Load(Reader);

                    }

                }


            }

            return DT_Customers;
        }

        public static DataTable GetAllCustomersInformationJoinesPhoneAndEmail()
        {
            return _GetAllCustomersInformationJoinesPhoneAndEmail();
        }

        private static MCustomer _FindTheCustomerReturingAllInformation(int CustomerID)
        {

            MCustomer InfoCustomer = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {


                    string Query = @"

                                              SELECT CusotmerID,	FirstName,	MidName,	LastName,	NationalID
                                              FROM Customers
                                              WHERE CusotmerID = @CusotmerID ; 

                                    ";


                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {
                        connection.Open();

                        Command.Parameters.AddWithValue("@CusotmerID", CustomerID);

                        using (SqlDataReader reader = Command.ExecuteReader())
                        {


                            if (reader.Read())
                            {

                                InfoCustomer = new MCustomer();

                                InfoCustomer.CusotmerID = reader["CusotmerID"] != DBNull.Value ? (int)reader["CusotmerID"] : 0;
                                InfoCustomer.FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : null;
                                InfoCustomer.MidName = reader["MidName"] != DBNull.Value ? (string)reader["MidName"] : null;
                                InfoCustomer.LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : null;
                                InfoCustomer.NationalID = reader["NationalID"] != DBNull.Value ? (string)reader["NationalID"] : null;



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return InfoCustomer;
        }

        public static MCustomer FindTheCustomerReturingAllInformation(int CustomerID)
        {
            return _FindTheCustomerReturingAllInformation(CustomerID);
        }

        private static int _InsertNewCustomer(MCustomer NewCsutomer)
        {

            int ID_NewCustomer = -1;

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {

                    string Query = @" 


                                    INSERT INTO Customers (FirstName , MidName , LastName , NationalID )
                                    VALUES (@FirstName , @MidName , @LastName , @NationalID ) ;

                                    SELECT SCOPE_IDENTITY();



                                    ";

                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        Command.Parameters.AddWithValue("@FirstName", NewCsutomer.FirstName);
                        Command.Parameters.AddWithValue("@MidName", NewCsutomer.MidName);
                        Command.Parameters.AddWithValue("@LastName", NewCsutomer.LastName);
                        Command.Parameters.AddWithValue("@NationalID", NewCsutomer.NationalID);


                        object result = Command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int IDCustomer))
                            ID_NewCustomer = IDCustomer;


                        NewCsutomer.CusotmerID = ID_NewCustomer;


                    }
                }


            }
            catch (Exception Ex)
            {

            }

            return ID_NewCustomer;
        }

        public static int InsertNewCustomer(MCustomer NewCsutomer)
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
                //Exception Message 
            }

            return RowAffective > 0;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return _DeleteTheCustomer(IDCustomer);

        }

        private static int _UpdateInformationCustomer(MCustomer NewCsutomerInformation)
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

                                    ";

                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        Command.Parameters.AddWithValue("@CusotmerID", NewCsutomerInformation.CusotmerID);
                        Command.Parameters.AddWithValue("@FirstName", NewCsutomerInformation.FirstName);
                        Command.Parameters.AddWithValue("@MidName", NewCsutomerInformation.MidName);
                        Command.Parameters.AddWithValue("@LastName", NewCsutomerInformation.LastName);
                        Command.Parameters.AddWithValue("@NationalID", NewCsutomerInformation.NationalID);


                        RowAffective = Command.ExecuteNonQuery();



                    }
                }


            }
            catch (Exception Ex)
            {

            }

            return RowAffective;
        }

        public static int UpdateInformationCustomer(MCustomer NewCsutomerInformation)
        {
            return _UpdateInformationCustomer(NewCsutomerInformation);
        }


        #endregion


    }
}
