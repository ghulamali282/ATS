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

namespace Ccm.CancellationPolicies
{
    public class EfCoreCancellationPolicyRepository : EfCoreRepository<CcmDbContext, CancellationPolicy, Guid>, ICancellationPolicyRepository
    {
        public EfCoreCancellationPolicyRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CancellationPolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.CancellationPolicy.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CancellationPolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string nameString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, nameString, operatorName, policyName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CancellationPolicyConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<CancellationPolicyWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from cancellationPolicy in (await GetDbSetAsync())
                   join partner in (await GetDbContextAsync()).Partners on cancellationPolicy.OperatorName equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()
                   join masterData in (await GetDbContextAsync()).MasterDatas on cancellationPolicy.PolicyName equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new CancellationPolicyWithNavigationProperties
                   {
                       CancellationPolicy = cancellationPolicy,
                       Partner = partner,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<CancellationPolicyWithNavigationProperties> ApplyFilter(
            IQueryable<CancellationPolicyWithNavigationProperties> query,
            string filterText,
            string nameString = null,
            Guid? operatorName = null,
            Guid? policyName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CancellationPolicy.NameString.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(nameString), e => e.CancellationPolicy.NameString.Contains(nameString))
                    .WhereIf(operatorName != null && operatorName != Guid.Empty, e => e.Partner != null && e.Partner.Id == operatorName)
                    .WhereIf(policyName != null && policyName != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == policyName);
        }

        public async Task<List<CancellationPolicy>> GetListAsync(
            string filterText = null,
            string nameString = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, nameString);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CancellationPolicyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string nameString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, nameString, operatorName, policyName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CancellationPolicy> ApplyFilter(
            IQueryable<CancellationPolicy> query,
            string filterText,
            string nameString = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.NameString.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(nameString), e => e.NameString.Contains(nameString));
        }
    }
}