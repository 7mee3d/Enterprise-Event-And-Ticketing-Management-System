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
        }

        private void _InitalSettingAfterLoadTheUSRoles()
        {

            clsEETMS_SettingPresentation._AnimationLables(RolesBL.TotalRoles(), lblTotalRoles, 5, false);
            clsEETMS_SettingPresentation._AnimationLables(RolesBL.TotalActiveRoles(), lblTotalActiveStzatusRoles, 5, false);

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
                DataGridViewCell DGVC = DGVR.Cells[4];
                if (DGVR.Cells[4].Value.ToString() == "Active")
                    DGVC.Style.ForeColor = Color.Green;
                else DGVC.Style.ForeColor = Color.Red;
            }

        }

        private int _GetTheIDRoleFromDGV()
            => GDataGridViewRolesInformation.SelectedRows.Count > 0 ? Convert.ToInt32(GDataGridViewRolesInformation.SelectedRows[0].Cells[0].Value) : -1;

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
            => ERequestToOpenCreateNewRole?.Invoke(this, -1);

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
