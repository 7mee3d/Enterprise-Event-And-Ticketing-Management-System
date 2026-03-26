using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;


namespace EETMS_Presentation.EETMS_Customers
{
    public partial class USCustomers : UserControl
    {

        public event EventHandler<int> RequestOpenTheAddNewCustomer;
        private DataTable _CustomersDT;
        private Guna2MessageDialog _G2MD;


        public USCustomers()
        {
            InitializeComponent();
            RequestOpenTheAddNewCustomer = null;
            _CustomersDT = null;
            _G2MD = null;
        }

        private int _GetTotalCustomer()
            => _CustomersDT.Rows.Count;

        private int _GetTheIDCustomerAfterSelectedInDataGridView()
            => ((GDataGridViewCustomerInformation.SelectedRows.Count > clsEETMS_Constants.kZERO) ?
            Convert.ToInt32(GDataGridViewCustomerInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells["CustomerID"].Value) :
            clsEETMS_Constants.kNEGATIVE_ONE);

        private void _LoadAllInformationCustomerToDataGridView()
        {

            _CustomersDT = CustomerBL.GetAllInformationCustomerWithPhoneAndEmail();

            foreach (DataRow CustomerInfoRow in _CustomersDT.Rows)
            {

                string FullNameCustomer = CustomerInfoRow["FirstName"] + " " + CustomerInfoRow["MidName"] + " " + CustomerInfoRow["LastName"];

                GDataGridViewCustomerInformation.Rows.Add(

                    CustomerInfoRow["CusotmerID"],
                    FullNameCustomer,
                    (CustomerInfoRow["EmailAddress"].ToString() == "") ? "-" : (CustomerInfoRow["EmailAddress"]),
                    (CustomerInfoRow["phoneNumber"].ToString() == "") ? "-" : (CustomerInfoRow["phoneNumber"]),
                    CustomerInfoRow["NationalID"]


                                                );


            }

        }

        private void _InitalSettingAfterLoadingTheCustomerUS()
        {

            GDataGridViewCustomerInformation.Rows.Clear();
            _LoadAllInformationCustomerToDataGridView();
            GDataGridViewCustomerInformation.ClearSelection();
            clsEETMS_SettingPresentation._AnimationLables(_GetTotalCustomer(), lblTotalCustomer, 4, false);


        }

        private void USCustomers_Load(object sender, EventArgs e)
            => _InitalSettingAfterLoadingTheCustomerUS();

        private void DeleteCustomerlStripMenuItem_Click(object sender, EventArgs e)
        {

            int CustomerID = _GetTheIDCustomerAfterSelectedInDataGridView();

            if (CustomerID != clsEETMS_Constants.kNEGATIVE_ONE)
            {
                if (clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Are You Sure to be Delete This Customer?", "Note For Delete Customer operation", MessageDialogButtons.YesNo, MessageDialogIcon.Information))
                {

                    if (CustomerBL.DeleteTheCustomer(CustomerID))
                        clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Customer is Deleteed Sccuessfully", "Note For Delete Customer operation", MessageDialogButtons.YesNo, MessageDialogIcon.Information);
                    else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Customer is Delete Failed", "Note For Delete Customer operation", MessageDialogButtons.YesNo, MessageDialogIcon.Warning);

                    _InitalSettingAfterLoadingTheCustomerUS();
                }
            }
            else
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                    _G2MD,
                    "You Must Selected The Customer From List To Be Delete." +
                      "\nOR .. cannot Delete This Custoemr Because The Customer Have The Reservations",
                    "Important Note ...",
                    MessageDialogButtons.YesNo,
                    MessageDialogIcon.Warning
                    );


            }
        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int CustomerID = _GetTheIDCustomerAfterSelectedInDataGridView();


            if (CustomerID != clsEETMS_Constants.kNEGATIVE_ONE)
                RequestOpenTheAddNewCustomer?.Invoke(this, CustomerID);
            else
            {

                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                      _G2MD,
                       "You Must Selected The Customer From List To Be Updated information.",
                       "Important Note ...",
                     MessageDialogButtons.YesNo,
                      MessageDialogIcon.Warning
                      );
            }
        }

        private void GTextBoxSearchTheEvent_TextChanged(object sender, EventArgs e)
        {

            string SearchStr = GTextBoxSearchTheCustomer.Text;

            _CustomersDT = CustomerBL.GetAllInformationCustomerAfterSearchBy(SearchStr);

            GDataGridViewCustomerInformation.Rows.Clear();

            foreach (DataRow CustomerInfoRow in _CustomersDT.Rows)
            {
                string FullNameCustomer =

                    CustomerInfoRow["FirstName"] + " " +
                    CustomerInfoRow["MidName"] + " " +
                    CustomerInfoRow["LastName"];

                GDataGridViewCustomerInformation.Rows.Add(

                                            CustomerInfoRow["CusotmerID"],
                                            FullNameCustomer,
                                            (CustomerInfoRow["EmailAddress"].ToString() == "") ? "-" : CustomerInfoRow["EmailAddress"],
                                            (CustomerInfoRow["PhoneNumber"].ToString() == "") ? "-" : CustomerInfoRow["PhoneNumber"],
                                            CustomerInfoRow["NationalID"]


                );
            }
        }

        private void GGButtonAddNewCustomer_Click(object sender, EventArgs e)
         => RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());

        private void GGButtonAddNewCustomer_Click_1(object sender, EventArgs e)
         => RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());

    }
}
