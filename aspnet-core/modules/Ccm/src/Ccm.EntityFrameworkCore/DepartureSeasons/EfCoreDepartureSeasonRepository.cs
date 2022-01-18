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

namespace Ccm.DepartureSeasons
{
    public class EfCoreDepartureSeasonRepository : EfCoreRepository<CcmDbContext, DepartureSeason, Guid>, IDepartureSeasonRepository
    {
        public EfCoreDepartureSeasonRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<DepartureSeasonWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.DepartureSeason.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<DepartureSeasonWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            Guid? partner = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, seasonMin, seasonMax, seasonName, partner);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DepartureSeasonConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<DepartureSeasonWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from departureSeason in (await GetDbSetAsync())
                   join partner in (await GetDbContextAsync()).Partners on departureSeason.Partner equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()

                   select new DepartureSeasonWithNavigationProperties
                   {
                       DepartureSeason = departureSeason,
                       Partner = partner
                   };
        }

        protected virtual IQueryable<DepartureSeasonWithNavigationProperties> ApplyFilter(
            IQueryable<DepartureSeasonWithNavigationProperties> query,
            string filterText,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            Guid? partner = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DepartureSeason.SeasonName.Contains(filterText))
                    .WhereIf(seasonMin.HasValue, e => e.DepartureSeason.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.DepartureSeason.Season <= seasonMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(seasonName), e => e.DepartureSeason.SeasonName.Contains(seasonName))
                    .WhereIf(partner != null && partner != Guid.Empty, e => e.Partner != null && e.Partner.Id == partner);
        }

        public async Task<List<DepartureSeason>> GetListAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, seasonMin, seasonMax, seasonName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DepartureSeasonConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            Guid? partner = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, seasonMin, seasonMax, seasonName, partner);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<DepartureSeason> ApplyFilter(
            IQueryable<DepartureSeason> query,
            string filterText,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.SeasonName.Contains(filterText))
                    .WhereIf(seasonMin.HasValue, e => e.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.Season <= seasonMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(seasonName), e => e.SeasonName.Contains(seasonName));
        }
    }
}