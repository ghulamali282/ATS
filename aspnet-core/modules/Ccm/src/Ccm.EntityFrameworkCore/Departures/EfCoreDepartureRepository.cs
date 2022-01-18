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

namespace Ccm.Departures
{
    public class EfCoreDepartureRepository : EfCoreRepository<CcmDbContext, Departure, Guid>, IDepartureRepository
    {
        public EfCoreDepartureRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<DepartureWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Departure.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<DepartureWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string departuresArray = null,
            string seasonGroup = null,
            Guid? partner = null,
            Guid? seasonName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, departuresArray, seasonGroup, partner, seasonName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DepartureConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<DepartureWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from departure in (await GetDbSetAsync())
                   join partner in (await GetDbContextAsync()).Partners on departure.Partner equals partner.Id into partners
                   from partner in partners.DefaultIfEmpty()
                   join departureSeason in (await GetDbContextAsync()).DepartureSeasons on departure.SeasonName equals departureSeason.Id into departureSeasons
                   from departureSeason in departureSeasons.DefaultIfEmpty()

                   select new DepartureWithNavigationProperties
                   {
                       Departure = departure,
                       Partner = partner,
                       DepartureSeason = departureSeason
                   };
        }

        protected virtual IQueryable<DepartureWithNavigationProperties> ApplyFilter(
            IQueryable<DepartureWithNavigationProperties> query,
            string filterText,
            string departuresArray = null,
            string seasonGroup = null,
            Guid? partner = null,
            Guid? seasonName = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Departure.DeparturesArray.Contains(filterText) || e.Departure.SeasonGroup.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(departuresArray), e => e.Departure.DeparturesArray.Contains(departuresArray))
                    .WhereIf(!string.IsNullOrWhiteSpace(seasonGroup), e => e.Departure.SeasonGroup.Contains(seasonGroup))
                    .WhereIf(partner != null && partner != Guid.Empty, e => e.Partner != null && e.Partner.Id == partner)
                    .WhereIf(seasonName != null && seasonName != Guid.Empty, e => e.DepartureSeason != null && e.DepartureSeason.Id == seasonName);
        }

        public async Task<List<Departure>> GetListAsync(
            string filterText = null,
            string departuresArray = null,
            string seasonGroup = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, departuresArray, seasonGroup);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DepartureConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string departuresArray = null,
            string seasonGroup = null,
            Guid? partner = null,
            Guid? seasonName = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, departuresArray, seasonGroup, partner, seasonName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Departure> ApplyFilter(
            IQueryable<Departure> query,
            string filterText,
            string departuresArray = null,
            string seasonGroup = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.DeparturesArray.Contains(filterText) || e.SeasonGroup.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(departuresArray), e => e.DeparturesArray.Contains(departuresArray))
                    .WhereIf(!string.IsNullOrWhiteSpace(seasonGroup), e => e.SeasonGroup.Contains(seasonGroup));
        }
    }
}