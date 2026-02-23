using EETMS_Models;
using System;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using System.Collections.Generic;
using System.Reflection;
using EETMS_Presentation.Properties;

namespace EETMS_Presentation.EETMS_Customers
{
    public partial class US_AddAndUpdateInformationCustomer : UserControl
    {


        private enum _EnModeCustomer
        {
            _kADD_NEW_CUSTOMER = 1,
            _kUPDATE_INFORMATION_CUSTOMER = 2,
            _kNOTHING = 3
        }


        private _EnModeCustomer _EnMode = _EnModeCustomer._kNOTHING;
        private MCustomer _CustomerInformation = null;
        private int _IDCustomer = 0;
        private List<string> _AllInformationCustomerInList = null;
        public event EventHandler RequestClose = null;

        public US_AddAndUpdateInformationCustomer(int IDCustomer)
        {
            InitializeComponent();


            if (IDCustomer != -1)
                _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;

            else _EnMode = _EnModeCustomer._kADD_NEW_CUSTOMER;

            this._IDCustomer = IDCustomer;
        }

        private void _LoadAllInformationAndSettingAddNewCustomer()
        {

            if (_EnMode == _EnModeCustomer._kADD_NEW_CUSTOMER)
            {

                _EnMode = _EnModeCustomer._kADD_NEW_CUSTOMER;
                _CustomerInformation = new MCustomer();
                _CustomerInformation.Emode = MCustomer.EnMode._kADD_NEW_CUSTOMER;
                return;
            }

            _CustomerInformation = CustomerBL.FindCustomer(_IDCustomer);


            if (_CustomerInformation == null)
            {
                MessageBox.Show($"The Customer ID [{_IDCustomer}] Not Found ..", "Note Of Search The Customer By ID");
                return;
            }


            GTextBoxFirstName.Text = _CustomerInformation.FirstName;
            GTextBoxMidName.Text = _CustomerInformation.MidName;
            GTextBoxLastName.Text = _CustomerInformation.LastName;
            GTextBoxEmailAddress.Text = _CustomerInformation.EmailCustomer;
            GTextBoxPhoneNumber.Text = _CustomerInformation.PhoneCustomer;
            if (_EnMode == _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER) GTextBoxNationalID.Enabled = false;
            GTextBoxNationalID.Text = _CustomerInformation.NationalID;
            _CustomerInformation.Emode = MCustomer.EnMode._kUPDATE_INFORMATION_CUSTOMER;

            _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;
            GButtonAddNewCustomer.Text = "Update Customer";
            GButtonAddNewCustomer.Image = Resources.Update_Icon_EETMS;
        }

        private void _AddOrUpdateInformationCustomer()
        {

            _CustomerInformation.FirstName = GTextBoxFirstName.Text;
            _CustomerInformation.MidName = GTextBoxMidName.Text;
            _CustomerInformation.LastName = GTextBoxLastName.Text;
            _CustomerInformation.EmailCustomer = GTextBoxEmailAddress.Text;
            _CustomerInformation.PhoneCustomer = GTextBoxPhoneNumber.Text;

            if (_EnMode == _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER) GTextBoxNationalID.Enabled = false;
            else
                _CustomerInformation.NationalID = GTextBoxNationalID.Text;



            if (CustomerBL.Save(_CustomerInformation))
            {
                if (_EnMode == _EnModeCustomer._kADD_NEW_CUSTOMER)
                    MessageBox.Show($"The Customer ID [{_CustomerInformation.CusotmerID}] Added Sccuessfully", "Note Of Add New Customer");
                else MessageBox.Show($"The Customer ID [{_CustomerInformation.CusotmerID}] Updated Sccuessfully", "Note Of Add Update Customer");
            }

            GButtonAddNewCustomer.Text = "Update Customer";
            GButtonAddNewCustomer.Image = Resources.Update_Icon_EETMS;

            _CustomerInformation.Emode = MCustomer.EnMode._kUPDATE_INFORMATION_CUSTOMER;
            _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;

        }

        private void GButtonCansel_Click(object sender, EventArgs e)
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void _FillAllInformationCustomerAfterFillToList()
        {

            _AllInformationCustomerInList = new List<string>();

            _AllInformationCustomerInList.Add(GTextBoxFirstName.Text);
            _AllInformationCustomerInList.Add(GTextBoxMidName.Text);
            _AllInformationCustomerInList.Add(GTextBoxLastName.Text);
            _AllInformationCustomerInList.Add(GTextBoxEmailAddress.Text);
            _AllInformationCustomerInList.Add(GTextBoxPhoneNumber.Text);
            _AllInformationCustomerInList.Add(GTextBoxNationalID.Text);



        }

        private bool _CheckTheAllTextBoxiesAllFilledOrNot(List<string> AllInformationCustomerInList)
        {

            return (


                         AllInformationCustomerInList[0] != "" &&   // The First Name 
                                                                    //   AllInformationCustomerInList[1] != "" &&// The Mid Name 
                         AllInformationCustomerInList[2] != "" &&   // The last Name
                                                                    // AllInformationCustomerInList[3] != "" &&//The Email
                                                                    //  AllInformationCustomerInList[4] != "" &&//The Phone
                         AllInformationCustomerInList[5] != ""      //The National ID

                             );

        }

        private void GButtonAddNewCustomer_Click(object sender, EventArgs e)
        {
            _FillAllInformationCustomerAfterFillToList();

            if (_CheckTheAllTextBoxiesAllFilledOrNot(_AllInformationCustomerInList))

                _AddOrUpdateInformationCustomer();


            else MessageBox.Show("Please Fill All Text Boxies Customer To Be Added / Update .. ", "Note The Add / Update Information Customer ");

        }

        private void US_AddAndUpdateInformationCustomer_Load(object sender, EventArgs e)
        {

            _LoadAllInformationAndSettingAddNewCustomer();

        }

    }
}
