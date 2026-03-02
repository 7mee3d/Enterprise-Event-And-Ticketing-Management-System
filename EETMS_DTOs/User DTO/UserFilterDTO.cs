

namespace EETMS_DTOs.User_DTO
{
    public class UserFilterDTO
    {

        public string MainNameFilter { get; set; }
        public string SubFilter { get; set; }


        public UserFilterDTO()
        {
            this.MainNameFilter = null;
            this.SubFilter = null;
        }

    }
}
