using EETMS_DataAccessLayer;
using System.Collections.Generic;
using System.Data;


namespace EETMS_BusinessLayer
{
    public class CountriesBL
    {

        public static DataTable AllInformationCountries() => CountriesQueriesDAL.GetAllInformationCountries();

        public static List<string> AllInformationCountryName()
            => CountriesQueriesDAL.GetAllCountryName();

    }
}
