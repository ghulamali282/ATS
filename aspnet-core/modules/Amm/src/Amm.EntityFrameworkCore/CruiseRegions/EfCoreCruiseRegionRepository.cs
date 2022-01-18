using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Amm.EntityFrameworkCore;

namespace Amm.CruiseRegions
{
    public class EfCoreCruiseRegionRepository : EfCoreRepository<AmmDbContext, CruiseRegion, Guid>, ICruiseRegionRepository
    {
        public EfCoreCruiseRegionRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CruiseRegionWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.CruiseRegion.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CruiseRegionWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string freeEntry = null,
            Guid? cruiseRegionName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, freeEntry, cruiseRegionName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CruiseRegionConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<CruiseRegionWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from cruiseRegion in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on cruiseRegion.CruiseRegionName equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new CruiseRegionWithNavigationProperties
                   {
                       CruiseRegion = cruiseRegion,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<CruiseRegionWithNavigationProperties> ApplyFilter(
            IQueryable<CruiseRegionWithNavigationProperties> query,
            string filterText,
            string freeEntry = null,
            Guid? cruiseRegionName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CruiseRegion.FreeEntry.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(freeEntry), e => e.CruiseRegion.FreeEntry.Contains(freeEntry))
                    .WhereIf(cruiseRegionName != null && cruiseRegionName != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == cruiseRegionName);
        }

        public async Task<List<CruiseRegion>> GetListAsync(
            string filterText = null,
            string freeEntry = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, freeEntry);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CruiseRegionConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string freeEntry = null,
            Guid? cruiseRegionName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, freeEntry, cruiseRegionName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CruiseRegion> ApplyFilter(
            IQueryable<CruiseRegion> query,
            string filterText,
            string freeEntry = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.FreeEntry.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(freeEntry), e => e.FreeEntry.Contains(freeEntry));
        }
    }
}