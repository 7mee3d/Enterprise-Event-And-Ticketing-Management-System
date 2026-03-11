using EETMS_Models;
using System;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using System.Collections.Generic;
using EETMS_Presentation.Properties;
using EETMS_BusinessLayer.Validation;
using Guna.UI2.WinForms;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_Presentation.EETMS_Settings;

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


        private _EnModeCustomer _EnMode;
        private CustomerDTO _CustomerInformation;
        private int _IDCustomer;
        private List<string> _AllInformationCustomerInList;
        public event EventHandler RequestClose;
        private Guna2MessageDialog _G2MD;


        public US_AddAndUpdateInformationCustomer(int IDCustomer)
        {
            InitializeComponent();
            _EnMode = _EnModeCustomer._kNOTHING;
            _CustomerInformation = null;
            _IDCustomer = clsEETMS_Constants.kZERO;
            _AllInformationCustomerInList = null;
            RequestClose = null;
            _G2MD = null;


            if (IDCustomer != clsEETMS_Constants.kNEGATIVE_ONE)
                _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;

            else _EnMode = _EnModeCustomer._kADD_NEW_CUSTOMER;


            this._IDCustomer = IDCustomer;
        }

        private void _LoadAllInformationAndSettingAddNewCustomer()
        {

            if (_EnMode == _EnModeCustomer._kADD_NEW_CUSTOMER)
            {

                _EnMode = _EnModeCustomer._kADD_NEW_CUSTOMER;
                _CustomerInformation = new CustomerDTO();
                _CustomerInformation.Emode = CustomerDTO.EnMode._kADD_NEW_CUSTOMER;
                return;
            }

            _CustomerInformation = CustomerBL.FindCustomer(_IDCustomer);


            if (_CustomerInformation == null)
            {
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, $"The Customer ID [{_IDCustomer}] Not Found ..", "Note Of Search The Customer By ID", MessageDialogButtons.OK, MessageDialogIcon.Error);
                return;
            }


            GTextBoxFirstName.Text = _CustomerInformation.FirstName;
            GTextBoxMidName.Text = _CustomerInformation.MidName;
            GTextBoxLastName.Text = _CustomerInformation.LastName;
            GTextBoxEmailAddress.Text = _CustomerInformation.EmailCustomer;
            GTextBoxPhoneNumber.Text = _CustomerInformation.PhoneCustomer;
            if (_EnMode == _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER) GTextBoxNationalID.Enabled = false;
            GTextBoxNationalID.Text = _CustomerInformation.NationalID;
            _CustomerInformation.Emode = CustomerDTO.EnMode._kUPDATE_INFORMATION_CUSTOMER;

            _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;
            GButtonAddNewCustomer.Text = "Update Customer";
            GButtonAddNewCustomer.Image = Resources.Update_Icon_EETMS;
        }

        private void _AddOrUpdateInformationCustomer()
        {

            Guna2MessageDialog G2MD = new Guna2MessageDialog();


            _CustomerInformation.FirstName = GTextBoxFirstName.Text;
            _CustomerInformation.MidName = GTextBoxMidName.Text;
            _CustomerInformation.LastName = GTextBoxLastName.Text;

            if (!string.IsNullOrEmpty(GTextBoxEmailAddress.Text))
            {
                if (clsValidation.IsValidEmailAddress(GTextBoxEmailAddress.Text))
                    _CustomerInformation.EmailCustomer = GTextBoxEmailAddress.Text;
                else
                {

                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                                          _G2MD,
                                         "\nPlease enter a valid email address\n",
                                          "Invalid Email Address !!",
                                          MessageDialogButtons.OK,
                                          MessageDialogIcon.Error


                   );

                    return;



                }
            }
            else
                _CustomerInformation.EmailCustomer = null;

            _CustomerInformation.PhoneCustomer = GTextBoxPhoneNumber.Text;

            if (_EnMode == _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER) GTextBoxNationalID.Enabled = false;
            else
                _CustomerInformation.NationalID = GTextBoxNationalID.Text;



            CustomerDTO mCustomer = new CustomerDTO()
            {
                FirstName = GTextBoxFirstName.Text,
                MidName = GTextBoxMidName.Text,
                LastName = GTextBoxLastName.Text
            };


            if (_EnMode == _EnModeCustomer._kADD_NEW_CUSTOMER)
                if (CustomerBL._IsTheNameCustomerExsistsBy(mCustomer))
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(
                                           _G2MD,
                                           $"This Customer" +
                                           $" {mCustomer.FirstName + ' ' + mCustomer.MidName + ' ' + mCustomer.LastName}" +
                                           $"Already Exsists in the system EETMS , Try to Enter Another Customer",
                                           "Invalid Input This Data ... ",
                                           MessageDialogButtons.OK,
                                           MessageDialogIcon.Warning


                    );

                    return;
                }


            if (CustomerBL.Save(_CustomerInformation))
            {
                if (_EnMode == _EnModeCustomer._kADD_NEW_CUSTOMER)
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, $"The Customer ID [{_CustomerInformation.CusotmerID}] Added Sccuessfully", "Note Of Add New Customer", MessageDialogButtons.OK, MessageDialogIcon.Information);

                else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, $"The Customer ID [{_CustomerInformation.CusotmerID}] Updated Sccuessfully", "Note Of Add Update Customer", MessageDialogButtons.OK, MessageDialogIcon.Information);
            }

            GButtonAddNewCustomer.Text = "Update Customer";
            GButtonAddNewCustomer.Image = Resources.Update_Icon_EETMS;

            _CustomerInformation.Emode = CustomerDTO.EnMode._kUPDATE_INFORMATION_CUSTOMER;
            _EnMode = _EnModeCustomer._kUPDATE_INFORMATION_CUSTOMER;

        }

        private void GButtonCansel_Click(object sender, EventArgs e)
            => RequestClose?.Invoke(this, EventArgs.Empty);

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


                         AllInformationCustomerInList[clsEETMS_Constants.kZERO] != "" &&   // The First Name 
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
            else
                clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Please Fill All Text Boxies Customer To Be Added / Update .. ", "Note The Add / Update Information Customer ", MessageDialogButtons.OK, MessageDialogIcon.Error);



        }

        private void US_AddAndUpdateInformationCustomer_Load(object sender, EventArgs e)
            => _LoadAllInformationAndSettingAddNewCustomer();



    }
}
