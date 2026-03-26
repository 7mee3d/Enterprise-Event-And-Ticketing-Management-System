using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_BusinessLayer.Roles_Business_Layer;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Roles
{
    public partial class US_RolesManagment : UserControl
    {

        public event EventHandler<int> ERequestToOpenCreateNewRole;
        private Guna2MessageDialog _G2MD;
  
        public US_RolesManagment()
        {
            InitializeComponent();

            _G2MD = null; 
        }

        private void _InitalSettingAfterLoadTheUSRoles()
        {

            clsEETMS_SettingPresentation._AnimationLables(RolesBL.TotalRoles(), lblTotalRoles, clsEETMS_Constants.kNUMBER_OF_DELAY_ANIMATION_ROLE, false);
            clsEETMS_SettingPresentation._AnimationLables(RolesBL.TotalActiveRoles(), lblTotalActiveStzatusRoles, clsEETMS_Constants.kNUMBER_OF_DELAY_ANIMATION_ROLE, false);

        }

        private void _GetAllInfromationRole()
        {

            foreach (DataRow DR_RoleInfo in RolesBL.AllInformationRolesWithStatus().Rows)
            {

                int RpwIndex = GDataGridViewRolesInformation.Rows.Add(

                    DR_RoleInfo["RoleID"].ToString(),
                    DR_RoleInfo["RoleName"].ToString(),
                    DR_RoleInfo["DescripationRole"].ToString(),
                    DR_RoleInfo["Permssions"].ToString(),
                    DR_RoleInfo["StatusRole"].ToString()





                 );


                DataGridViewRow DGVR = GDataGridViewRolesInformation.Rows[RpwIndex];
                DataGridViewCell DGVC = DGVR.Cells[clsEETMS_Constants.kNUMBER_OF_COLUMN_STATUS_ROLE];
                if (DGVR.Cells[clsEETMS_Constants.kNUMBER_OF_COLUMN_STATUS_ROLE].Value.ToString() == "Active")
                    DGVC.Style.ForeColor = Color.Green;
                else DGVC.Style.ForeColor = Color.Red;
            }

        }

        private int _GetTheIDRoleFromDGV()
            => GDataGridViewRolesInformation.SelectedRows.Count > clsEETMS_Constants.kZERO ? Convert.ToInt32(GDataGridViewRolesInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells[clsEETMS_Constants.kZERO].Value) : clsEETMS_Constants.kNEGATIVE_ONE;

        private void _LoadDataRolesAndHeaders()
        {
            GDataGridViewRolesInformation.Rows.Clear();

            _GetAllInfromationRole();
            _InitalSettingAfterLoadTheUSRoles();

            GDataGridViewRolesInformation.ClearSelection();
        }

        private void US_RolesManagment_Load(object sender, EventArgs e)
           => _LoadDataRolesAndHeaders();

        private void GGButtonCreateNewRole_Click(object sender, EventArgs e)
            => ERequestToOpenCreateNewRole?.Invoke(this, clsEETMS_Constants.kNEGATIVE_ONE);

        private void EditRoleToolStripMenuItem_Click(object sender, EventArgs e)
        => ERequestToOpenCreateNewRole?.Invoke(this, _GetTheIDRoleFromDGV());

        private void deleteRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Are You Sure to be delete this role ?", "Note For Delete Role..", MessageDialogButtons.YesNo, MessageDialogIcon.Question))
                if (RolesBL.DeleteRoleBy(_GetTheIDRoleFromDGV()))
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Role Deleted Successfully .", "Note For Delete Role..", MessageDialogButtons.OK, MessageDialogIcon.Information);
                    _LoadDataRolesAndHeaders();
                }
                else
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Role Deleted Faild Because The Role Referances Users .", "Note For Delete Role..", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    return;
                }

        }
    }
}
