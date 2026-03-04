

using System;

namespace EETMS_DTOs
{
    public class PaymentFilterDTO
    {

        public string TypeMainFilter { get; set; }
        public string TypeSubMainFilter { get; set; }
        public DateTime? FromDatePayment { get; set; }
        public DateTime? ToDatePayment { get; set; }

        public PaymentFilterDTO()
        {
            this.TypeMainFilter = default;
            this.TypeSubMainFilter = default;
            this.FromDatePayment = default;
            this.ToDatePayment = default;
        }

    }
}
