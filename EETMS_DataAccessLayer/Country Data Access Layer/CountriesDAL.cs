using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class CountriesDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        private static DataTable _GetAllInformationCountries ()
        {

            DataTable CountriesDT = new DataTable();

            try
            {

                using (SqlConnection connection = new SqlConnection(_ConneactionString))
                {


                    string Query = @"

                                SELECT 
		                                Countries.CountryID ,
		                                Countries.CountryName,
		                                Countries.ZipCode

			                                    FROM Countries 

                                ";

                    using (SqlCommand command = new SqlCommand(Query, connection))
                    {

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.HasRows)
                                CountriesDT.Load(reader);


                        }

                    }

                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }


            return CountriesDT;
        }

        public static DataTable GetAllInformationCountries()
        {
            return _GetAllInformationCountries();
        }


    }
}
