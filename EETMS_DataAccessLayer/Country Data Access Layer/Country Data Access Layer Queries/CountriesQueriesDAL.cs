using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace EETMS_DataAccessLayer
{
    public class CountriesQueriesDAL
    {

        #region Setting Data Access Events
        private static readonly string _ConneactionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        #endregion



        private static DataTable _GetAllInformationCountries()
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
                throw;
            }


            return CountriesDT;
        }

        public static DataTable GetAllInformationCountries()
        {
            return _GetAllInformationCountries();
        }

        private static List<string> _GetAllCountryName()
        {

            List<string> LI_AllCountryName = new List<string>();



            using (SqlConnection connection = new SqlConnection(_ConneactionString))
            {


                string Query = @"


                                            SELECT COUN.CountryName
                                            FROM Countries COUN



                                ";


                using (SqlCommand command = new SqlCommand(Query, connection))
                {


                    connection.Open();


                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                            LI_AllCountryName.Add(reader["CountryName"].ToString());

                    }

                }

            }

            return LI_AllCountryName;

        }

        public static List<string> GetAllCountryName()
            => _GetAllCountryName();


    }
}
