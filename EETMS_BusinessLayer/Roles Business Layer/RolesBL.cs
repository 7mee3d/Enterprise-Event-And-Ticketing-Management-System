using EETMS_DataAccessLayer;
using EETMS_DataAccessLayer.Roles_Data_Access_Layer;
using EETMS_DTOs;
using System.Collections.Generic;
using System.Data;
using static EETMS_DTOs.RoleDTO;

namespace EETMS_BusinessLayer.Roles_Business_Layer
{
    public class RolesBL
    {

        public static DataTable GetAllInformationRoles()
            => RoleQueriesDAL.GetTheAllInformationRoles();

        public static List<string> GetAllRoleName()
            => RoleQueriesDAL.GetAllNameRole();

        public static DataTable AllInformationRolesWithStatus()
            => RoleQueriesDAL.GetAllInformationRoleWithStatusWord();

        public static int TotalRoles()
            => RoleQueriesDAL.GetTotalRoles();

        public static int TotalActiveRoles()
            => RoleQueriesDAL.GetTotalRolesActive();

        public static RoleDTO FindTheRoleBy(int IDRole)
            => RoleQueriesDAL.FindTheRoleBy(IDRole);

        private static bool AddNewRole(RoleDTO InfromationNewRole)
            => RolesCommandsDAL.InsertNewRole(InfromationNewRole) > 0;

        private static bool UpdateIOnformationRole(int RoleID, RoleDTO InfromationNewRole)
            => RolesCommandsDAL.UpdateInformationRole(RoleID, InfromationNewRole) > 0;

        public static bool DeleteRoleBy(int RoleID)
            => RolesCommandsDAL.DeleteRoleBy(RoleID) > 0;

        public static bool SaveMode(RoleDTO InfromationNewRole)
        {

            switch (InfromationNewRole.ModeRole)
            {
                case RoleDTO.EnModeRole.kADD_NEW_ROLE:
                    return (AddNewRole(InfromationNewRole));
                case RoleDTO.EnModeRole.kUPDATE_INFORMATION_ROLE:
                    return UpdateIOnformationRole(InfromationNewRole.RoleID, InfromationNewRole);
                default: return false;
            }
        }

        public static bool IsPassUserPermssions(int Permssions, EnPermssionsType enPermssionsType)
            => ((Permssions & (int)enPermssionsType) == (int)enPermssionsType);

    }
}
