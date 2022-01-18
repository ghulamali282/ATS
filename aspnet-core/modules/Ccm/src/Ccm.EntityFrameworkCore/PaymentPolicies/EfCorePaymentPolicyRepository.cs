using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.PaymentPolicies
{
    public class EfCorePaymentPolicyRepository : EfCoreRepository<CcmDbContext, PaymentPolicy, Guid>, IPaymentPolicyRepository
    {
        public EfCorePaymentPolicyRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<PaymentPolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.PaymentPolicy.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<PaymentPolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, delayedDepositAt, depositMin, depositMax, depositAtReservation, depositType, finalPaymentDueDaysMin, finalPaymentDueDaysMax, fullPaymentRequiredDaysMin, fullPaymentRequiredDaysMax, policyString, operatorName, policyName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PaymentPolicyConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<PaymentPolicyWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from paymentPolicy in (await GetDbSetAsync())
                   join partner in (await GetDbContextAsync()).Partners on paymentPolicy.OperatorName equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()
                   join masterData in (await GetDbContextAsync()).MasterDatas on paymentPolicy.PolicyName equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new PaymentPolicyWithNavigationProperties
                   {
                       PaymentPolicy = paymentPolicy,
                       Partner = partner,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<PaymentPolicyWithNavigationProperties> ApplyFilter(
            IQueryable<PaymentPolicyWithNavigationProperties> query,
            string filterText,
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
            Guid? policyName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PaymentPolicy.DelayedDepositAt.Contains(filterText) || e.PaymentPolicy.DepositType.Contains(filterText) || e.PaymentPolicy.PolicyString.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(delayedDepositAt), e => e.PaymentPolicy.DelayedDepositAt.Contains(delayedDepositAt))
                    .WhereIf(depositMin.HasValue, e => e.PaymentPolicy.Deposit >= depositMin.Value)
                    .WhereIf(depositMax.HasValue, e => e.PaymentPolicy.Deposit <= depositMax.Value)
                    .WhereIf(depositAtReservation.HasValue, e => e.PaymentPolicy.DepositAtReservation == depositAtReservation)
                    .WhereIf(!string.IsNullOrWhiteSpace(depositType), e => e.PaymentPolicy.DepositType.Contains(depositType))
                    .WhereIf(finalPaymentDueDaysMin.HasValue, e => e.PaymentPolicy.FinalPaymentDueDays >= finalPaymentDueDaysMin.Value)
                    .WhereIf(finalPaymentDueDaysMax.HasValue, e => e.PaymentPolicy.FinalPaymentDueDays <= finalPaymentDueDaysMax.Value)
                    .WhereIf(fullPaymentRequiredDaysMin.HasValue, e => e.PaymentPolicy.FullPaymentRequiredDays >= fullPaymentRequiredDaysMin.Value)
                    .WhereIf(fullPaymentRequiredDaysMax.HasValue, e => e.PaymentPolicy.FullPaymentRequiredDays <= fullPaymentRequiredDaysMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(policyString), e => e.PaymentPolicy.PolicyString.Contains(policyString))
                    .WhereIf(operatorName != null && operatorName != Guid.Empty, e => e.Partner != null && e.Partner.Id == operatorName)
                    .WhereIf(policyName != null && policyName != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == policyName);
        }

        public async Task<List<PaymentPolicy>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, delayedDepositAt, depositMin, depositMax, depositAtReservation, depositType, finalPaymentDueDaysMin, finalPaymentDueDaysMax, fullPaymentRequiredDaysMin, fullPaymentRequiredDaysMax, policyString);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? PaymentPolicyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, delayedDepositAt, depositMin, depositMax, depositAtReservation, depositType, finalPaymentDueDaysMin, finalPaymentDueDaysMax, fullPaymentRequiredDaysMin, fullPaymentRequiredDaysMax, policyString, operatorName, policyName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<PaymentPolicy> ApplyFilter(
            IQueryable<PaymentPolicy> query,
            string filterText,
            string delayedDepositAt = null,
            decimal? depositMin = null,
            decimal? depositMax = null,
            bool? depositAtReservation = null,
            string depositType = null,
            int? finalPaymentDueDaysMin = null,
            int? finalPaymentDueDaysMax = null,
            int? fullPaymentRequiredDaysMin = null,
            int? fullPaymentRequiredDaysMax = null,
            string policyString = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DelayedDepositAt.Contains(filterText) || e.DepositType.Contains(filterText) || e.PolicyString.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(delayedDepositAt), e => e.DelayedDepositAt.Contains(delayedDepositAt))
                    .WhereIf(depositMin.HasValue, e => e.Deposit >= depositMin.Value)
                    .WhereIf(depositMax.HasValue, e => e.Deposit <= depositMax.Value)
                    .WhereIf(depositAtReservation.HasValue, e => e.DepositAtReservation == depositAtReservation)
                    .WhereIf(!string.IsNullOrWhiteSpace(depositType), e => e.DepositType.Contains(depositType))
                    .WhereIf(finalPaymentDueDaysMin.HasValue, e => e.FinalPaymentDueDays >= finalPaymentDueDaysMin.Value)
                    .WhereIf(finalPaymentDueDaysMax.HasValue, e => e.FinalPaymentDueDays <= finalPaymentDueDaysMax.Value)
                    .WhereIf(fullPaymentRequiredDaysMin.HasValue, e => e.FullPaymentRequiredDays >= fullPaymentRequiredDaysMin.Value)
                    .WhereIf(fullPaymentRequiredDaysMax.HasValue, e => e.FullPaymentRequiredDays <= fullPaymentRequiredDaysMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(policyString), e => e.PolicyString.Contains(policyString));
        }
    }
}