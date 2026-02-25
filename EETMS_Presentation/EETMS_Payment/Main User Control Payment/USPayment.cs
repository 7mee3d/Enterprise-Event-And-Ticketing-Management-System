using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;


namespace EETMS_Presentation.EETMS_Payment
{
    public partial class USPayment : UserControl
    {


        public event EventHandler ERequestTheOpenAddPaymentBooking;

        public USPayment()
        {
            InitializeComponent();
            ERequestTheOpenAddPaymentBooking = null;
        }

        private void _LoadAllInformationPayments(DataTable DT)
        {


            string BookingIDSTR = clsEETMS_Constants.kEMPTY_STRING;

            int counter = clsEETMS_Constants.kZERO;

            foreach (DataRow DR_Payment in DT.Rows)
            {

                BookingIDSTR = "#BK-" + DR_Payment["ReservationID"];

                GDataGridViewCategoriesInformation.Rows.Add(

                                    DR_Payment["PaymentID"],
                                    BookingIDSTR,
                                    "$" + DR_Payment["TotalAmount"],
                                    "$" + DR_Payment["PaidAmount"],
                                    DR_Payment["NamePaymentMethod"],
                                    DR_Payment["BookingDateTimeDateTime"],
                                    DR_Payment["NamePaymentStatus"]

                        );

                DataGridViewRow DGVR = GDataGridViewCategoriesInformation.Rows[counter++];

                DataGridViewCell DGVC_BookingID = DGVR.Cells[clsEETMS_Constants.kONE];
                DataGridViewCell DGVC_Status = DGVR.Cells[6];

                switch (DGVC_Status.Value.ToString())
                {
                    case "Paid":
                        DGVC_Status.Style.ForeColor = Color.FromArgb(22, 129, 62);
                        break;

                    case "Partially Paid":
                        DGVC_Status.Style.ForeColor = Color.FromArgb(180, 83, 9);
                        break;

                    case "Unpaid":
                        DGVC_Status.Style.ForeColor = Color.Red;
                        break;
                }

                DGVC_BookingID.Style.ForeColor = Color.FromArgb(255, 45, 141, 238);


            }

        }

        private void USPayment_Load(object sender, EventArgs e)
        {
            DataTable Payments_DT = PaymentsBL.GetAllInformationPayments();

            lblTotalRevenue.Text = '$' + PaymentsBL.GetTheTotalRevenue().ToString();
            _LoadAllInformationPayments(Payments_DT);
            GDataGridViewCategoriesInformation.ClearSelection();
        }

        private void GTextBoxSearchTheCategory_TextChanged(object sender, EventArgs e)
        {
            string BookingID = clsEETMS_Constants.kEMPTY_STRING;

            if (!String.IsNullOrEmpty(GTextBoxSearchThePayment.Text))
                BookingID = GTextBoxSearchThePayment.Text;

            DataTable Payments_DT = null;
            GDataGridViewCategoriesInformation.Rows.Clear();

            if (BookingID != clsEETMS_Constants.kEMPTY_STRING)
            {
                Payments_DT = PaymentsBL.GetAllInformationPaymentBy(BookingID);
            }
            else
            {
                Payments_DT = PaymentsBL.GetAllInformationPayments();
            }

            _LoadAllInformationPayments(Payments_DT);
        }

        private void GGButtonPaymentBooking_Click(object sender, EventArgs e)
           => ERequestTheOpenAddPaymentBooking?.Invoke(this, EventArgs.Empty);


    }
}
