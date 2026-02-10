using System;
using System.Data;
using System.Windows.Forms;
using EETMS_BusinessLayer; 


namespace EETMS_Presentation.EETMS_Customers
{
    public partial class USCustomers : UserControl
    {
        public USCustomers()
        {
            InitializeComponent();
        }

        private void _LoadAllInformationCustomerToDataGridView ()
        {

            DataTable CustomersDT = CustomerBL.GetAllInformationCustomerWithPhoneAndEmail();

            foreach (DataRow CustomerInfoRow in CustomersDT.Rows)
            {

                string FullNameCustomer = CustomerInfoRow["FirstName"] + " " + CustomerInfoRow["MidName"] + " " + CustomerInfoRow["LastName"];

                GDataGridViewCustomerInformation.Rows.Add(

                    CustomerInfoRow["CusotmerID"],
                    FullNameCustomer ,
                    CustomerInfoRow["EmailAddress"],
                    CustomerInfoRow["phoneNumber"],
                    CustomerInfoRow["NationalID"]


                                                );


            }

        }
        private void USCustomers_Load(object sender, EventArgs e)
        {
            _LoadAllInformationCustomerToDataGridView();
        }
    }
}
