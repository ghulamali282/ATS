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

namespace Amm.Destinations
{
    public class EfCoreDestinationRepository : EfCoreRepository<AmmDbContext, Destination, Guid>, IDestinationRepository
    {
        public EfCoreDestinationRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<DestinationWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Destination.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<DestinationWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string destCountry = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, city, cityLocalName, latitudeMin, latitudeMax, longitudeMin, longitudeMax, videoUrl, placeId, destCountry);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DestinationConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<DestinationWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from destination in (await GetDbSetAsync())
                   join country in (await GetDbContextAsync()).Countries on destination.DestCountry equals country.Id into countries
                   from country in countries.DefaultIfEmpty()

                   select new DestinationWithNavigationProperties
                   {
                       Destination = destination,
                       Country = country
                   };
        }

        protected virtual IQueryable<DestinationWithNavigationProperties> ApplyFilter(
            IQueryable<DestinationWithNavigationProperties> query,
            string filterText,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string destCountry = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Destination.City.Contains(filterText) || e.Destination.CityLocalName.Contains(filterText) || e.Destination.VideoUrl.Contains(filterText) || e.Destination.PlaceId.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.Destination.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(cityLocalName), e => e.Destination.CityLocalName.Contains(cityLocalName))
                    .WhereIf(latitudeMin.HasValue, e => e.Destination.latitude >= latitudeMin.Value)
                    .WhereIf(latitudeMax.HasValue, e => e.Destination.latitude <= latitudeMax.Value)
                    .WhereIf(longitudeMin.HasValue, e => e.Destination.longitude >= longitudeMin.Value)
                    .WhereIf(longitudeMax.HasValue, e => e.Destination.longitude <= longitudeMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(videoUrl), e => e.Destination.VideoUrl.Contains(videoUrl))
                    .WhereIf(!string.IsNullOrWhiteSpace(placeId), e => e.Destination.PlaceId.Contains(placeId))
                    .WhereIf(destCountry != null && destCountry != "", e => e.Country != null && e.Country.Id == destCountry);
        }

        public async Task<List<Destination>> GetListAsync(
            string filterText = null,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, city, cityLocalName, latitudeMin, latitudeMax, longitudeMin, longitudeMax, videoUrl, placeId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? DestinationConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string destCountry = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, city, cityLocalName, latitudeMin, latitudeMax, longitudeMin, longitudeMax, videoUrl, placeId, destCountry);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Destination> ApplyFilter(
            IQueryable<Destination> query,
            string filterText,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.City.Contains(filterText) || e.CityLocalName.Contains(filterText) || e.VideoUrl.Contains(filterText) || e.PlaceId.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(cityLocalName), e => e.CityLocalName.Contains(cityLocalName))
                    .WhereIf(latitudeMin.HasValue, e => e.latitude >= latitudeMin.Value)
                    .WhereIf(latitudeMax.HasValue, e => e.latitude <= latitudeMax.Value)
                    .WhereIf(longitudeMin.HasValue, e => e.longitude >= longitudeMin.Value)
                    .WhereIf(longitudeMax.HasValue, e => e.longitude <= longitudeMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(videoUrl), e => e.VideoUrl.Contains(videoUrl))
                    .WhereIf(!string.IsNullOrWhiteSpace(placeId), e => e.PlaceId.Contains(placeId));
        }
    }
}