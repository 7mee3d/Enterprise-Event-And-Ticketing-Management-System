using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;


namespace EETMS_Presentation.EETMS_Customers
{
    public partial class USCustomers : UserControl
    {

        public event EventHandler<int> RequestOpenTheAddNewCustomer;
        private DataTable _CustomersDT;


        public USCustomers()
        {
            InitializeComponent();
            RequestOpenTheAddNewCustomer = null;
            _CustomersDT = null;
        }

        private int _GetTotalCustomer()
            => _CustomersDT.Rows.Count;

        private int _GetTheIDCustomerAfterSelectedInDataGridView()
        {
            return ((GDataGridViewCustomerInformation.SelectedRows.Count > clsEETMS_Constants.kZERO) ? Convert.ToInt32(GDataGridViewCustomerInformation.SelectedRows[clsEETMS_Constants.kZERO].Cells["CustomerID"].Value) : clsEETMS_Constants.kNEGATIVE_ONE);
        }

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

        private void GGButtonCreateNewEvent_Click(object sender, EventArgs e)
            => RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());

        private void DeleteCustomerlStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to be Delete This Customer?", "Note For Delete Customer operation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (CustomerBL.DeleteTheCustomer(_GetTheIDCustomerAfterSelectedInDataGridView()))
                    MessageBox.Show("Customer is Deleteed Sccuessfully", "Note For Delete Customer operation");
                else MessageBox.Show("Customer is Delete Failed", "Note For Delete Customer operation");

                _InitalSettingAfterLoadingTheCustomerUS();
            }



        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
            => RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());

        private void GTextBoxSearchTheEvent_TextChanged(object sender, EventArgs e)
        {

            string SearchStr = GTextBoxSearchTheCustomer.Text;

            _CustomersDT = CustomerBL.AllInformationCustomerAfterSearch(SearchStr);

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


    }
}
