using EETMS_BusinessLayer;
using EETMS_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Payment
{
    public partial class USAddPaymentReservations : UserControl
    {
        public USAddPaymentReservations()
        {
            InitializeComponent();
        }

        public event EventHandler ERequestTheClosePaymentBooking = null;

        private MReservationPayment _MReservationPayment = null;

        private MPayment mPayment = null;


        private void _LoadThReservationPaymentIDandNameCustomer()
        {
            List<MReservationPayment> AllInformationReservationPayment = ReservationPaymentBL.GetAllInformationReservationPayment();


            GComboBoxBookingIDAndCustomerName.DataSource = AllInformationReservationPayment;
            GComboBoxBookingIDAndCustomerName.DisplayMember = "DisplayComboBox";
            GComboBoxBookingIDAndCustomerName.ValueMember = "ReservationID";



        }

        private void _LoadAndInitalSettingAfterTheLoadingPayment()
        {


            if (GComboBoxBookingIDAndCustomerName.SelectedValue != null)
            {
                int ReservationID = Convert.ToInt32(GComboBoxBookingIDAndCustomerName.SelectedValue);

                _MReservationPayment = ReservationPaymentBL.GetAllInformationReservationPaymentByReservationID(ReservationID);

                if (_MReservationPayment != null)
                {
                    lblRemainingBalance.Text = "$" + _MReservationPayment.Remaining.ToString();
                    GNumericUpDownAmountToPay.Maximum = _MReservationPayment.Remaining;
                }

            }

        }

        private void Close_Click(object sender, EventArgs e)
        {
            ERequestTheClosePaymentBooking?.Invoke(this, EventArgs.Empty);
        }

        private void USAddPaymentReservations_Load(object sender, EventArgs e)
        {
            _LoadThReservationPaymentIDandNameCustomer();
        }

        private void GComboBoxBookingIDAndCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _LoadAndInitalSettingAfterTheLoadingPayment();
        }

        private void _ResetAllSettingAfterConfirmThePayment()
        {

            GButtonCard.Checked = false;
            GButtonCash.Checked = false;
            GButtonBankTransfer.Checked = false;

            GNumericUpDownAmountToPay.Value = 0;
            GNumericUpDownAmountToPay.Maximum = 0;

            GComboBoxBookingIDAndCustomerName.SelectedValue = 1;
            lblRemainingBalance.Text = "$0";

        }

        private void _AddNewPayment()
        {


            mPayment = new MPayment();


            int StatusPaymentNumber = 0;
            int PaymentMethodNumebr = 0;

            int ResevationID = _MReservationPayment.ReservationID;

            decimal AmountToPay = GNumericUpDownAmountToPay.Value;
            decimal RemainingBalance = _MReservationPayment.Remaining;

            if (!PaymentsBL.IsPaidAmountGratherThanOriginalAmount(AmountToPay, RemainingBalance))
                mPayment.PaidAmount = AmountToPay;


            if (PaymentsBL.GetTheStatusPayment(AmountToPay, RemainingBalance) == MPayment.EnPaymentStatus._kPAID)
                StatusPaymentNumber = 1;
            else if (PaymentsBL.GetTheStatusPayment(AmountToPay, RemainingBalance) == MPayment.EnPaymentStatus._kPARTIALLY_PAID)
                StatusPaymentNumber = 2;
            else
                StatusPaymentNumber = 3;


            if (GButtonCash.Checked)
                PaymentMethodNumebr = Convert.ToInt16(GButtonCash.Tag);

            else if (GButtonCard.Checked)
                PaymentMethodNumebr = Convert.ToInt16(GButtonCard.Tag);

            else if (GButtonBankTransfer.Checked)
                PaymentMethodNumebr = Convert.ToInt16(GButtonBankTransfer.Tag);


            if (mPayment != null)
            {
                mPayment = new MPayment
                {

                    PaidAmount = AmountToPay,
                    PaymentMethod = PaymentMethodNumebr.ToString(),
                    PaymentStatus = StatusPaymentNumber.ToString(),
                    BookingID = ResevationID

                };
            }

            if (PaymentsBL.SaveTheInformationPayment(mPayment))
                MessageBox.Show("The Payment is Addedd Sccessfully ", "Note For Add New Payment ");
            else MessageBox.Show("The Payment is Addedd Faild ", "Note For Add New Payment ");


            mPayment = null;
            _ResetAllSettingAfterConfirmThePayment();
        }

        private void GButtonConfirmPayment_Click(object sender, EventArgs e)
        {
            _AddNewPayment();
        }
    }
}
