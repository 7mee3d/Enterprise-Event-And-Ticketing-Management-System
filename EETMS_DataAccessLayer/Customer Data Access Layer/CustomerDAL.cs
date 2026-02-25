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
                                                                LEFT OUTER JOIN Emails 
                                                                ON Emails.CusotmerID = Customers.CusotmerID 

                                                                LEFT OUTER JOIN Phones 
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
                                            SELECT 
			                                    Customers.CusotmerID ,
			                                    Customers.FirstName ,
			                                    Customers.MidName ,
			                                    Customers.LastName , 
			                                    Customers.NationalID ,
			                                    Emails.EmailAddress , 
			                                    Phones.PhoneNumber 

                                                                FROM Customers 
                                                                LEFT OUTER JOIN Emails 
                                                                ON Emails.CusotmerID = Customers.CusotmerID 

                                                                LEFT OUTER JOIN Phones 
                                                                ON Phones.CusotmerID = Customers.CusotmerID 


                                                 WHERE Customers.CusotmerID = @CusotmerID ; 

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
                                InfoCustomer.EmailCustomer = reader["EmailAddress"] != DBNull.Value ? (string)reader["EmailAddress"] : null;
                                InfoCustomer.PhoneCustomer = reader["PhoneNumber"] != DBNull.Value ? (string)reader["PhoneNumber"] : null;
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
                throw;
            }

            return RowAffective > 0;
        }

        public static bool DeleteTheCustomer(int IDCustomer)
        {
            return _DeleteTheCustomer(IDCustomer);

        }

        private static int _UpdateInformationCustomer(int IDCustomer, MCustomer NewCsutomerInformation)
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
                                    WHERE CusotmerID = @CusotmerID ; 




                                    ";


                    using (SqlCommand Command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        Command.Parameters.AddWithValue("@CusotmerID", IDCustomer);
                        Command.Parameters.AddWithValue("@FirstName", NewCsutomerInformation.FirstName);
                        Command.Parameters.AddWithValue("@MidName", NewCsutomerInformation.MidName);
                        Command.Parameters.AddWithValue("@LastName", NewCsutomerInformation.LastName);
                        Command.Parameters.AddWithValue("@NationalID", NewCsutomerInformation.NationalID);

                        Command.Parameters.AddWithValue("@EmailAddress", NewCsutomerInformation.EmailCustomer);
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

        public static int UpdateInformationCustomer(int IDCustomer, MCustomer NewCsutomerInformation)
        {
            return _UpdateInformationCustomer(IDCustomer, NewCsutomerInformation);
        }

        private static DataTable _SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(string ToBySearch)
        {

            DataTable DT_Customer = new DataTable();

            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {


                string Query = @"
                                           SELECT  

                                                   CustomerTableSubQuery.CusotmerID,
                                                   CustomerTableSubQuery.FirstName ,
                                                   CustomerTableSubQuery.MidName ,
                                                   CustomerTableSubQuery.LastName , 
                                                   CustomerTableSubQuery.NationalID ,
                                                   CustomerTableSubQuery.EmailAddress , 
                                                   CustomerTableSubQuery.PhoneNumber ,
                                                   CustomerTableSubQuery.FullName , 
                                                   CustomerTableSubQuery.FullNameWithOutMidName


                                                         FROM
                                                                        (
                                                                           SELECT 
                                                                                Customers.CusotmerID ,
                                                                                Customers.FirstName ,
                                                                                Customers.MidName ,
                                                                                Customers.LastName , 
                                                                                Customers.NationalID ,
                                                                                Emails.EmailAddress , 
                                                                                Phones.PhoneNumber ,
                                                                                CONCAT(Customers.FirstName, ' ', Customers.MidName, ' ', Customers.LastName) AS FullName,
                                                                                CONCAT(Customers.FirstName, ' ', Customers.LastName) AS FullNameWithOutMidName

                                                                                                 FROM Customers 
                                                                                                 LEFT JOIN Emails ON Emails.CusotmerID = Customers.CusotmerID 
                                                                                                 LEFT JOIN Phones ON Phones.CusotmerID = Customers.CusotmerID 

                                                             ) AS CustomerTableSubQuery



                                                            WHERE 
                                                                       ( 

                                                                        CustomerTableSubQuery.FullName LIKE '%' + @Search + '%'
                                                                        OR CustomerTableSubQuery.NationalID LIKE '%' + @Search + '%'

                                                                        ) 

                                                                        OR ( CustomerTableSubQuery.FullNameWithOutMidName LIKE '%' + @Search + '%' ) ;

                                    
                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Search", ToBySearch);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.HasRows)
                            DT_Customer.Load(reader);


                    }


                }


            }

            return DT_Customer;

        }

        public static DataTable SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(string ToBySearch)
        {
            return _SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(ToBySearch);
        }



        #endregion


    }
}
