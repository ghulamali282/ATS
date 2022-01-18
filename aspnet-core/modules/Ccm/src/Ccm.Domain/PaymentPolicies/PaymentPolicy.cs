using Ccm.Partners;
using Ccm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.PaymentPolicies
{
    public class PaymentPolicy : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string DelayedDepositAt { get; set; }

        public virtual decimal Deposit { get; set; }

        public virtual bool DepositAtReservation { get; set; }

        [NotNull]
        public virtual string DepositType { get; set; }

        public virtual int FinalPaymentDueDays { get; set; }

        public virtual int FullPaymentRequiredDays { get; set; }

        [NotNull]
        public virtual string PolicyString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }

        public PaymentPolicy()
        {

        }

        public PaymentPolicy(Guid id, Guid operatorName, Guid policyName, decimal deposit, bool depositAtReservation, string depositType, int finalPaymentDueDays, int fullPaymentRequiredDays, string policyString, string delayedDepositAt = null)
        {
            Id = id;
            Check.NotNull(depositType, nameof(depositType));
            Check.Length(depositType, nameof(depositType), PaymentPolicyConsts.DepositTypeMaxLength, 0);
            Check.NotNull(policyString, nameof(policyString));
            Check.Length(delayedDepositAt, nameof(delayedDepositAt), PaymentPolicyConsts.DelayedDepositAtMaxLength, 0);
            Deposit = deposit;
            DepositAtReservation = depositAtReservation;
            DepositType = depositType;
            FinalPaymentDueDays = finalPaymentDueDays;
            FullPaymentRequiredDays = fullPaymentRequiredDays;
            PolicyString = policyString;
            DelayedDepositAt = delayedDepositAt;
            OperatorName = operatorName;
            PolicyName = policyName;
        }
    }
}