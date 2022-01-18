using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.PaymentPolicies
{
    public interface IPaymentPolicyRepository : IRepository<PaymentPolicy, Guid>
    {
        Task<PaymentPolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<PaymentPolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string delayedDepositAt = null,
            decimal? depositMin = null,
            decimal? depositMax = null,
            bool? depositAtReservation = null,
            string depositType = null,
            int? finalPaymentDueDaysMin = null,
            int? finalPaymentDueDaysMax = null,
            int? fullPaymentRequiredDaysMin = null,
            int? fullPaymentRequiredDaysMax = null,
            string policyString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<PaymentPolicy>> GetListAsync(
                    string filterText = null,
                    string delayedDepositAt = null,
                    decimal? depositMin = null,
                    decimal? depositMax = null,
                    bool? depositAtReservation = null,
                    string depositType = null,
                    int? finalPaymentDueDaysMin = null,
                    int? finalPaymentDueDaysMax = null,
                    int? fullPaymentRequiredDaysMin = null,
                    int? fullPaymentRequiredDaysMax = null,
                    string policyString = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string delayedDepositAt = null,
            decimal? depositMin = null,
            decimal? depositMax = null,
            bool? depositAtReservation = null,
            string depositType = null,
            int? finalPaymentDueDaysMin = null,
            int? finalPaymentDueDaysMax = null,
            int? fullPaymentRequiredDaysMin = null,
            int? fullPaymentRequiredDaysMax = null,
            string policyString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            CancellationToken cancellationToken = default);
    }
}