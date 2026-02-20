using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer; 


namespace EETMS_Presentation.EETMS_Customers
{
    public partial class USCustomers : UserControl
    {

        public event EventHandler<int> RequestOpenTheAddNewCustomer = null;
        private DataTable _CustomersDT = null;

        public USCustomers()
        {
            InitializeComponent();
        }

        private int _GetTotalCustomer ()
        {
            return _CustomersDT.Rows.Count; 
        } 

        private int _GetTheIDCustomerAfterSelectedInDataGridView()
        {
            return ( (GDataGridViewCustomerInformation.SelectedRows.Count > 0) ? Convert.ToInt32(GDataGridViewCustomerInformation.SelectedRows[0].Cells["CustomerID"].Value) : -1); 
        }

        private void _LoadAllInformationCustomerToDataGridView ()
        {

            _CustomersDT = CustomerBL.GetAllInformationCustomerWithPhoneAndEmail();

            foreach (DataRow CustomerInfoRow in _CustomersDT.Rows)
            {

                string FullNameCustomer = CustomerInfoRow["FirstName"] + " " + CustomerInfoRow["MidName"] + " " + CustomerInfoRow["LastName"];

                GDataGridViewCustomerInformation.Rows.Add(

                    CustomerInfoRow["CusotmerID"],
                    FullNameCustomer ,
                    (CustomerInfoRow["EmailAddress"].ToString() == "" ) ? "-" : (CustomerInfoRow["EmailAddress"] ),
                    (CustomerInfoRow["phoneNumber"].ToString() == "" )  ? "-" : (CustomerInfoRow["phoneNumber"]),
                    CustomerInfoRow["NationalID"]


                                                );


            }

        }

        private void _InitalSettingAfterLoadingTheCustomerUS()
        {
            GDataGridViewCustomerInformation.Rows.Clear();
            _LoadAllInformationCustomerToDataGridView();
            GDataGridViewCustomerInformation.ClearSelection();
            lblTotalCustomer.Text = _GetTotalCustomer().ToString();


        }

        private void USCustomers_Load(object sender, EventArgs e)
        {

            _InitalSettingAfterLoadingTheCustomerUS();

        }

        private void GGButtonCreateNewEvent_Click(object sender, EventArgs e)
        {
            RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());
        }

        private void DeleteCustomerlStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are You Sure to be Delete This Customer?" , "Note For Delete Customer operation" , MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (CustomerBL.DeleteTheCustomer(_GetTheIDCustomerAfterSelectedInDataGridView()))
                    MessageBox.Show("Customer is Deleteed Sccuessfully", "Note For Delete Customer operation");
                else MessageBox.Show("Customer is Delete Failed", "Note For Delete Customer operation");

                _InitalSettingAfterLoadingTheCustomerUS();
            }



        }

        private void updateCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RequestOpenTheAddNewCustomer?.Invoke(this, _GetTheIDCustomerAfterSelectedInDataGridView());
        }

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
