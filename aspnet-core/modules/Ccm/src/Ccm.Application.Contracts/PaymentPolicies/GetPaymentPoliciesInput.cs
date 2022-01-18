using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.PaymentPolicies
{
    public class GetPaymentPoliciesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string DelayedDepositAt { get; set; }
        public decimal? DepositMin { get; set; }
        public decimal? DepositMax { get; set; }
        public bool? DepositAtReservation { get; set; }
        public string DepositType { get; set; }
        public int? FinalPaymentDueDaysMin { get; set; }
        public int? FinalPaymentDueDaysMax { get; set; }
        public int? FullPaymentRequiredDaysMin { get; set; }
        public int? FullPaymentRequiredDaysMax { get; set; }
        public string PolicyString { get; set; }
        public Guid? OperatorName { get; set; }
        public Guid? PolicyName { get; set; }

        public GetPaymentPoliciesInput()
        {

        }
    }
}