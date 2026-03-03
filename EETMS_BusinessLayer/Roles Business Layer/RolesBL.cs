
using EETMS_DataAccessLayer.Roles_Data_Access_Layer;
using System.Collections.Generic;
using System.Data;

namespace EETMS_BusinessLayer.Roles_Business_Layer
{
    public class RolesBL
    {

        public static DataTable GetAllInformationRoles()
            => RoleDAL.GetTheAllInformationRoles();

        public static List<string> GetAllRoleName()
            => RoleDAL.GetAllNameRole();
    }
}
