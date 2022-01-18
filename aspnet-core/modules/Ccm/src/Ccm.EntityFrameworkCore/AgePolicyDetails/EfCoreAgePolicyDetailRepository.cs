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

namespace Ccm.AgePolicyDetails
{
    public class EfCoreAgePolicyDetailRepository : EfCoreRepository<CcmDbContext, AgePolicyDetail, Guid>, IAgePolicyDetailRepository
    {
        public EfCoreAgePolicyDetailRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<AgePolicyDetailWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.AgePolicyDetail.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<AgePolicyDetailWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            Guid? service = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ageFromMin, ageFromMax, agePolicy, ageToMin, ageToMax, service);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AgePolicyDetailConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<AgePolicyDetailWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from agePolicyDetail in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on agePolicyDetail.Service equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new AgePolicyDetailWithNavigationProperties
                   {
                       AgePolicyDetail = agePolicyDetail,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<AgePolicyDetailWithNavigationProperties> ApplyFilter(
            IQueryable<AgePolicyDetailWithNavigationProperties> query,
            string filterText,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            Guid? service = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(ageFromMin.HasValue, e => e.AgePolicyDetail.AgeFrom >= ageFromMin.Value)
                    .WhereIf(ageFromMax.HasValue, e => e.AgePolicyDetail.AgeFrom <= ageFromMax.Value)
                    .WhereIf(agePolicy.HasValue, e => e.AgePolicyDetail.AgePolicy == agePolicy)
                    .WhereIf(ageToMin.HasValue, e => e.AgePolicyDetail.AgeTo >= ageToMin.Value)
                    .WhereIf(ageToMax.HasValue, e => e.AgePolicyDetail.AgeTo <= ageToMax.Value)
                    .WhereIf(service != null && service != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == service);
        }

        public async Task<List<AgePolicyDetail>> GetListAsync(
            string filterText = null,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, ageFromMin, ageFromMax, agePolicy, ageToMin, ageToMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? AgePolicyDetailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            Guid? service = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ageFromMin, ageFromMax, agePolicy, ageToMin, ageToMax, service);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<AgePolicyDetail> ApplyFilter(
            IQueryable<AgePolicyDetail> query,
            string filterText,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(ageFromMin.HasValue, e => e.AgeFrom >= ageFromMin.Value)
                    .WhereIf(ageFromMax.HasValue, e => e.AgeFrom <= ageFromMax.Value)
                    .WhereIf(agePolicy.HasValue, e => e.AgePolicy == agePolicy)
                    .WhereIf(ageToMin.HasValue, e => e.AgeTo >= ageToMin.Value)
                    .WhereIf(ageToMax.HasValue, e => e.AgeTo <= ageToMax.Value);
        }
    }
}