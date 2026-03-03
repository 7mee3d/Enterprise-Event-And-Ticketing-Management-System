

namespace EETMS_DTOs
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
