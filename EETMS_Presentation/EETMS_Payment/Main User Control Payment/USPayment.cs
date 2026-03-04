using EETMS_BusinessLayer;
using EETMS_BusinessLayer.EETMS_Constants;
using EETMS_DTOs;
using EETMS_Presentation.EETMS_Settings;
using EETMS_Presentation.Properties;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace EETMS_Presentation.EETMS_Payment
{
    public partial class USPayment : UserControl
    {


        public event EventHandler ERequestTheOpenAddPaymentBooking;
        private bool _IsCheckButtonFilter = false;

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

                GDataGridViewPaymentInformation.Rows.Add(

                                    DR_Payment["PaymentID"],
                                    BookingIDSTR,
                                    "$" + DR_Payment["TotalAmount"],
                                    "$" + DR_Payment["PaidAmount"],
                                    DR_Payment["NamePaymentMethod"],
                                    DR_Payment["BookingDateTimeDateTime"],
                                    DR_Payment["NamePaymentStatus"]

                        );

                DataGridViewRow DGVR = GDataGridViewPaymentInformation.Rows[counter++];

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

        private void _LoadAllInformationPaymentToDGV()
        {
            DataTable Payments_DT = PaymentsBL.GetAllInformationPayments();

            clsEETMS_SettingPresentation._AnimationLables(PaymentsBL.GetTheTotalRevenue(), lblTotalRevenue, 5, true);

            _LoadAllInformationPayments(Payments_DT);

            GDataGridViewPaymentInformation.ClearSelection();
        }

        private void USPayment_Load(object sender, EventArgs e)
        {
            _LoadAllInformationPaymentToDGV();

            GDateTimePickerFromDatePayment.MaxDate = DateTime.Today.Date;
        }

        private void GTextBoxSearchTheCategory_TextChanged(object sender, EventArgs e)
        {
            string BookingID = clsEETMS_Constants.kEMPTY_STRING;

            if (!String.IsNullOrEmpty(GTextBoxSearchThePayment.Text))
                BookingID = GTextBoxSearchThePayment.Text;

            DataTable Payments_DT = null;
            GDataGridViewPaymentInformation.Rows.Clear();

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

        private void _InitalSettingTheComboBoxies()
        {

            GDataGridViewPaymentInformation.Rows.Clear();


            GComboBoxMainTypeFilter.SelectedIndex = clsEETMS_Constants.kNEGATIVE_ONE;
            GSubComboBoxTheFilterPayment.SelectedIndex = clsEETMS_Constants.kNEGATIVE_ONE;

            if (GComboBoxMainTypeFilter.Items.Count <= clsEETMS_Constants.kZERO)
                GComboBoxMainTypeFilter.Items.Clear();


            if (GSubComboBoxTheFilterPayment.Items.Count <= clsEETMS_Constants.kZERO)
                GSubComboBoxTheFilterPayment.Items.Clear();

            GGSubPanelFilteringByPaymentDate.Visible = false;
            GGSubPanelGeneralFilter.Visible = false;

            _LoadAllInformationPaymentToDGV();
        }

        private void _ActiveTheFilter()
        {

            if (_IsCheckButtonFilter)
            {
                GGButtonFilter.HoverState.Image = Resources.Filter_Icon_EETMS;
                GGButtonFilter.Image = Resources.Filter_Icon_EETMS;
                GGMainPanelFilter.Visible = false;
                _IsCheckButtonFilter = false;
                GGButtonFilter.Text = "Filter";

                _InitalSettingTheComboBoxies();
            }
            else
            {
                GGButtonFilter.HoverState.Image = Resources.Cancel_Icon_EETMS;
                GGButtonFilter.Image = Resources.Cancel_Icon_EETMS;
                GGMainPanelFilter.Visible = true;
                _IsCheckButtonFilter = true;
                GGButtonFilter.Text = "Cancel";

            }


        }

        private void GGButtonFilter_Click(object sender, EventArgs e)
        {
            _ActiveTheFilter();

        }

        private void _LoadAllInformationPaymentStatusToComboBox()
        {

            GSubComboBoxTheFilterPayment.DataSource = PaymentsBL.GetAllPaymentStatus();
            GSubComboBoxTheFilterPayment.DisplayMember = "NamePaymentStatus";
        }

        private void _LoadAllInformationPaymentMethodsToComboBox()
        {
            GSubComboBoxTheFilterPayment.DataSource = PaymentsBL.GetAllPaymentMethods();
            GSubComboBoxTheFilterPayment.DisplayMember = "NamePaymentMethod";

        }

        private void _PushAllInformationAccordingTheTypeFilterToComboBox()
        {
            if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kZERO)

                GSubComboBoxTheFilterPayment.Visible = false;

            else GSubComboBoxTheFilterPayment.Visible = true;



            if (GComboBoxMainTypeFilter.SelectedIndex == 3)
                _LoadAllInformationPaymentStatusToComboBox();
            else if (GComboBoxMainTypeFilter.SelectedIndex == clsEETMS_Constants.kONE)
                _LoadAllInformationPaymentMethodsToComboBox();

        }

        private void _ShowTheSubFiltering()
        {
            if (GComboBoxMainTypeFilter.SelectedIndex == 2)
            {
                GGSubPanelFilteringByPaymentDate.Visible = true;
                GGSubPanelGeneralFilter.Visible = false;

            }
            else
            {
                GGSubPanelFilteringByPaymentDate.Visible = false;
                GGSubPanelGeneralFilter.Visible = true;

                _PushAllInformationAccordingTheTypeFilterToComboBox();
            }

        }

        private void _PushAllInformtionPaymentAccrodingTypeToDGV()
        {
            GDataGridViewPaymentInformation.Rows.Clear();
            DataTable DT_InformationPaymentAccrodingTheStatus = null;


            if (GComboBoxMainTypeFilter.SelectedIndex != 2)
            {

                PaymentFilterDTO paymentFilterDTO = new PaymentFilterDTO()
                {
                    TypeMainFilter = GComboBoxMainTypeFilter.SelectedItem.ToString(),
                    TypeSubMainFilter = GSubComboBoxTheFilterPayment.SelectedValue.ToString()
                };

                DT_InformationPaymentAccrodingTheStatus = PaymentsBL.GetAllInformationPaymentFilter(paymentFilterDTO);


            }
            else
            {
                PaymentFilterDTO paymentFilterDTO = new PaymentFilterDTO()
                {

                    TypeMainFilter = GComboBoxMainTypeFilter.SelectedItem.ToString(),
                    FromDatePayment = GDateTimePickerFromDatePayment.Value,
                    ToDatePayment = GDateTimePickerToDatePayment.Value

                };

                DT_InformationPaymentAccrodingTheStatus = PaymentsBL.GetAllInformationPaymentFilter(paymentFilterDTO);
            }

            _LoadAllInformationPayments(DT_InformationPaymentAccrodingTheStatus);
        }

        private void GComboBoxMainTypeFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _ShowTheSubFiltering();
        }

        private void GSubComboBoxTheFilterPayment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _PushAllInformtionPaymentAccrodingTypeToDGV();
        }

        private void GDateTimePickerFromDatePayment_ValueChanged(object sender, EventArgs e)
        {
            _PushAllInformtionPaymentAccrodingTypeToDGV();
        }

        private void GDateTimePickerToDatePayment_ValueChanged(object sender, EventArgs e)
        {
            _PushAllInformtionPaymentAccrodingTypeToDGV();
        }

   }
}
