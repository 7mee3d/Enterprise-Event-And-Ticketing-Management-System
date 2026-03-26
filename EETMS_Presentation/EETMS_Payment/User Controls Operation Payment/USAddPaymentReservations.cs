using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EETMS_Presentation.EETMS_Payment
{
    public partial class USAddPaymentReservations : UserControl
    {

        public event EventHandler ERequestTheClosePaymentBooking;
        private ReservationPaymentDTO _MReservationPayment;
        private PaymentDTO mPayment;
        private Guna2MessageDialog _G2MD;


        public USAddPaymentReservations()
        {
            InitializeComponent();
            ERequestTheClosePaymentBooking = null;
            _MReservationPayment = null;
            mPayment = null;
            _G2MD = null;


        }

        private void _LoadThReservationPaymentIDandNameCustomer()
        {
            List<ReservationPaymentDTO> AllInformationReservationPayment = ReservationPaymentBL.GetAllInformationReservationPayment();


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
            => ERequestTheClosePaymentBooking?.Invoke(this, EventArgs.Empty);

        private void USAddPaymentReservations_Load(object sender, EventArgs e)
            => _LoadThReservationPaymentIDandNameCustomer();

        private void GComboBoxBookingIDAndCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
            => _LoadAndInitalSettingAfterTheLoadingPayment();

        private void _ResetAllSettingAfterConfirmThePayment()
        {

            GButtonCard.Checked = false;
            GButtonCash.Checked = false;
            GButtonBankTransfer.Checked = false;

            GNumericUpDownAmountToPay.Value = clsEETMS_Constants.kZERO;
            GNumericUpDownAmountToPay.Maximum = clsEETMS_Constants.kZERO;

            GComboBoxBookingIDAndCustomerName.SelectedValue = clsEETMS_Constants.kONE;
            lblRemainingBalance.Text = "$0";

        }

        private void _AddNewPayment()
        {

            mPayment = new PaymentDTO();


            int StatusPaymentNumber = clsEETMS_Constants.kZERO;
            int PaymentMethodNumebr = clsEETMS_Constants.kZERO;

            if (_MReservationPayment != null)
            {
                int ResevationID = _MReservationPayment.ReservationID;

                decimal AmountToPay = GNumericUpDownAmountToPay.Value;
                decimal RemainingBalance = _MReservationPayment.Remaining;

                if (!PaymentsBL.IsPaidAmountGratherThanOriginalAmount(AmountToPay, RemainingBalance))
                    mPayment.PaidAmount = AmountToPay;


                if (PaymentsBL.GetTheStatusPayment(AmountToPay, RemainingBalance) == PaymentDTO.EnPaymentStatus._kPAID)
                    StatusPaymentNumber = clsEETMS_Constants.kNUMBER_PAYMENT_STATUS_PAID;
                else if (PaymentsBL.GetTheStatusPayment(AmountToPay, RemainingBalance) == PaymentDTO.EnPaymentStatus._kPARTIALLY_PAID)
                    StatusPaymentNumber = clsEETMS_Constants.kNUMBER_PAYMENT_STATUS_PARTIALLY_PAID;
                else
                    StatusPaymentNumber = clsEETMS_Constants.kNUMBER_PAYMENT_STATUS_UNPAID;


                if (GButtonCash.Checked)
                    PaymentMethodNumebr = Convert.ToInt16(GButtonCash.Tag);

                else if (GButtonCard.Checked)
                    PaymentMethodNumebr = Convert.ToInt16(GButtonCard.Tag);

                else if (GButtonBankTransfer.Checked)
                    PaymentMethodNumebr = Convert.ToInt16(GButtonBankTransfer.Tag);


                if (mPayment != null)
                {
                    mPayment = new PaymentDTO
                    {

                        PaidAmount = AmountToPay,
                        PaymentMethod = PaymentMethodNumebr.ToString(),
                        PaymentStatus = StatusPaymentNumber.ToString(),
                        BookingID = ResevationID

                    };
                }

                if ((!GButtonCash.Checked && !GButtonCard.Checked && !GButtonBankTransfer.Checked) || GNumericUpDownAmountToPay.Value < clsEETMS_Constants.kZERO)
                {
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "Invalid Data! Please Enter All Data To Be Confirm Reservation", "Note Of Confirm Reservation", MessageDialogButtons.OK, MessageDialogIcon.Error);
                    return;
                }

                if (PaymentsBL.SaveTheInformationPayment(mPayment))
                    clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Payment is Addedd Sccessfully ", "Note For Add New Payment ", MessageDialogButtons.OK, MessageDialogIcon.Information);
                else clsEETMS_SettingPresentation.ShowTheMessageBoxUseTheMessageDialog(_G2MD, "The Payment is Addedd Faild ", "Note For Add New Payment ", MessageDialogButtons.OK, MessageDialogIcon.Warning);

                mPayment = null;
                _ResetAllSettingAfterConfirmThePayment();
            }
        }

        private void GButtonConfirmPayment_Click(object sender, EventArgs e)
            => _AddNewPayment();


    }
}
