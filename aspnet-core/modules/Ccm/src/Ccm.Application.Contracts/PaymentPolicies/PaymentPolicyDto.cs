using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.PaymentPolicies
{
    public class PaymentPolicyDto : EntityDto<Guid>
    {
        public string DelayedDepositAt { get; set; }
        public decimal Deposit { get; set; }
        public bool DepositAtReservation { get; set; }
        public string DepositType { get; set; }
        public int FinalPaymentDueDays { get; set; }
        public int FullPaymentRequiredDays { get; set; }
        public string PolicyString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }
    }
}