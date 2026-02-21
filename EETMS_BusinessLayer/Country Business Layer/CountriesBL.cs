using EETMS_DataAccessLayer;
using System.Data;


namespace EETMS_BusinessLayer
{
    public  class CountriesBL
    {

        public static DataTable AllInformationCountries () =>  CountriesDAL.GetAllInformationCountries();
        

    }
}
