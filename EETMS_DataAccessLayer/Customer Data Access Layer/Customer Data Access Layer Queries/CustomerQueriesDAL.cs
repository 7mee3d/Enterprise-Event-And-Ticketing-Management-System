using EETMS_Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class CustomerQueriesDAL
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

        private static CustomerDTO _FindTheCustomerReturingAllInformation(int CustomerID)
        {

            CustomerDTO InfoCustomer = null;

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

                                InfoCustomer = new CustomerDTO();

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
                throw;
            }

            return InfoCustomer;
        }

        public static CustomerDTO FindTheCustomerReturingAllInformation(int CustomerID)
        {
            return _FindTheCustomerReturingAllInformation(CustomerID);
        }


        private static DataTable _SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(string ToBySearch)
        {

            DataTable DT_Customer = new DataTable();

            try
            {

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

                                                                        LOWER ( CustomerTableSubQuery.FullName )  =   LOWER ( @Search )  
                                                                  

                                                                        ) 

                                                                  OR (
                                                                        LOWER ( CustomerTableSubQuery.FullNameWithOutMidName ) = LOWER ( @Search ) 
                                                                     ) 

                                                                  OR  CustomerTableSubQuery.NationalID  LIKE '%' +  @Search  + '%'


                                    
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
            }
            catch (Exception ex) { throw; }
      ;

            return DT_Customer;

        }

        public static DataTable SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(string ToBySearch)
        {
            return _SearchTheCustomerFirstNameOrMidOrLast_OR_NationalID(ToBySearch);
        }

        private static bool _FindTheCustomerBy(CustomerDTO mCustomerNames)
        {

            bool FlagFindTheCustomer = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {


                    string Query = @"


                                    SELECT 1 
                                    FROM Customers CUST 
                                    WHERE (
                                                    ( 

                                                CONCAT(CUST.FirstName , ' ' , CUST.MidName , ' ' , CUST.LastName) 
                                                                        =
                                                CONCAT(@FirstName , ' ' , @MidName, ' ' ,  @LastName)

                                                     ) 
                                           )

                                            ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {


                        command.Parameters.AddWithValue("@FirstName", mCustomerNames.FirstName);
                        command.Parameters.AddWithValue("@MidName", mCustomerNames.MidName);
                        command.Parameters.AddWithValue("@LastName", mCustomerNames.LastName);


                        connection.Open();


                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int ResultTheQueryCheckName))
                            FlagFindTheCustomer = (ResultTheQueryCheckName > 0);

                    }
                }
            }
            catch (Exception ex) { throw; }
            ;

            return FlagFindTheCustomer;

        }

        public static bool FindTheCustomerBy(CustomerDTO mCustomerNames)
            => _FindTheCustomerBy(mCustomerNames);





        private static bool _IsCustomerNationalIDExsits(string NationalID)
        {

            bool FlagExsist = false;

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


                                                 WHERE Customers.NationalID = @NationalID ; 

                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {

                    command.Parameters.AddWithValue("@NationalID", NationalID);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                        if (reader.Read())
                            FlagExsist = true;


                }
            }

            return FlagExsist;
        }

        public static bool IsCustomerNationalIDExsits(string NationalID)
            => _IsCustomerNationalIDExsits(NationalID);

        #endregion
    }
}