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

namespace Ccm.AgePolicies
{
    public class EfCoreAgePolicyRepository : EfCoreRepository<CcmDbContext, AgePolicy, Guid>, IAgePolicyRepository
    {
        public EfCoreAgePolicyRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<AgePolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.AgePolicy.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<AgePolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string demoField = null,
            Guid? name = null,
            Guid? operatorName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, demoField, name, operatorName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AgePolicyConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<AgePolicyWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from agePolicy in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on agePolicy.Name equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()
                   join partner in (await GetDbContextAsync()).Partners on agePolicy.OperatorName equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()

                   select new AgePolicyWithNavigationProperties
                   {
                       AgePolicy = agePolicy,
                       MasterData = masterData,
                       Partner = partner
                   };
        }

        protected virtual IQueryable<AgePolicyWithNavigationProperties> ApplyFilter(
            IQueryable<AgePolicyWithNavigationProperties> query,
            string filterText,
            string demoField = null,
            Guid? name = null,
            Guid? operatorName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.AgePolicy.DemoField.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(demoField), e => e.AgePolicy.DemoField.Contains(demoField))
                    .WhereIf(name != null && name != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == name)
                    .WhereIf(operatorName != null && operatorName != Guid.Empty, e => e.Partner != null && e.Partner.Id == operatorName);
        }

        public async Task<List<AgePolicy>> GetListAsync(
            string filterText = null,
            string demoField = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, demoField);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AgePolicyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string demoField = null,
            Guid? name = null,
            Guid? operatorName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, demoField, name, operatorName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AgePolicy> ApplyFilter(
            IQueryable<AgePolicy> query,
            string filterText,
            string demoField = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DemoField.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(demoField), e => e.DemoField.Contains(demoField));
        }
    }
}