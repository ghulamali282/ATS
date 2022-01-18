using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.PaymentPolicies
{
    public class PaymentPolicyCreateDto
    {
        [StringLength(PaymentPolicyConsts.DelayedDepositAtMaxLength)]
        public string DelayedDepositAt { get; set; }
        [Required]
        public decimal Deposit { get; set; }
        [Required]
        public bool DepositAtReservation { get; set; }
        [Required]
        [StringLength(PaymentPolicyConsts.DepositTypeMaxLength)]
        public string DepositType { get; set; }
        [Required]
        public int FinalPaymentDueDays { get; set; }
        [Required]
        public int FullPaymentRequiredDays { get; set; }
        [Required]
        public string PolicyString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }
    }
}