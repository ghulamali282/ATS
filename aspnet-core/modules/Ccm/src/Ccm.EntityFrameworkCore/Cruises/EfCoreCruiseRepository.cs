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

namespace Ccm.Cruises
{
    public class EfCoreCruiseRepository : EfCoreRepository<CcmDbContext, Cruise, Guid>, ICruiseRepository
    {
        public EfCoreCruiseRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<CruiseWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Cruise.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<CruiseWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, seasonMin, seasonMax, cruiseEnabled, featured, freeInternetOnBoard, internetOnBoard, video, b2B, b2C, b2B_Agent, b2C_Agent, cruiseDescriptions, shipAmenities, shipArticles, shipPhotos, cabinAmenities, cabinArticles, cabinPhotos, ship, itinerary);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CruiseConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<CruiseWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from cruise in (await GetDbSetAsync())
                   join ship in (await GetDbContextAsync()).Ships on cruise.Ship equals ship.Id into ships
                   from ship in ships.DefaultIfEmpty()
                   join itinerary in (await GetDbContextAsync()).Itineraries on cruise.Itinerary equals itinerary.Id into itineraries
                   from itinerary in itineraries.DefaultIfEmpty()

                   select new CruiseWithNavigationProperties
                   {
                       Cruise = cruise,
                       Ship = ship,
                       Itinerary = itinerary
                   };
        }

        protected virtual IQueryable<CruiseWithNavigationProperties> ApplyFilter(
            IQueryable<CruiseWithNavigationProperties> query,
            string filterText,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            Guid? ship = null,
            Guid? itinerary = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Cruise.Video.Contains(filterText))
                    .WhereIf(seasonMin.HasValue, e => e.Cruise.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.Cruise.Season <= seasonMax.Value)
                    .WhereIf(cruiseEnabled.HasValue, e => e.Cruise.CruiseEnabled == cruiseEnabled)
                    .WhereIf(featured.HasValue, e => e.Cruise.Featured == featured)
                    .WhereIf(freeInternetOnBoard.HasValue, e => e.Cruise.FreeInternetOnBoard == freeInternetOnBoard)
                    .WhereIf(internetOnBoard.HasValue, e => e.Cruise.InternetOnBoard == internetOnBoard)
                    .WhereIf(!string.IsNullOrWhiteSpace(video), e => e.Cruise.Video.Contains(video))
                    .WhereIf(b2B.HasValue, e => e.Cruise.B2B == b2B)
                    .WhereIf(b2C.HasValue, e => e.Cruise.B2C == b2C)
                    .WhereIf(b2B_Agent.HasValue, e => e.Cruise.B2B_Agent == b2B_Agent)
                    .WhereIf(b2C_Agent.HasValue, e => e.Cruise.B2C_Agent == b2C_Agent)
                    .WhereIf(cruiseDescriptions.HasValue, e => e.Cruise.CruiseDescriptions == cruiseDescriptions)
                    .WhereIf(shipAmenities.HasValue, e => e.Cruise.ShipAmenities == shipAmenities)
                    .WhereIf(shipArticles.HasValue, e => e.Cruise.ShipArticles == shipArticles)
                    .WhereIf(shipPhotos.HasValue, e => e.Cruise.ShipPhotos == shipPhotos)
                    .WhereIf(cabinAmenities.HasValue, e => e.Cruise.CabinAmenities == cabinAmenities)
                    .WhereIf(cabinArticles.HasValue, e => e.Cruise.CabinArticles == cabinArticles)
                    .WhereIf(cabinPhotos.HasValue, e => e.Cruise.CabinPhotos == cabinPhotos)
                    .WhereIf(ship != null && ship != Guid.Empty, e => e.Ship != null && e.Ship.Id == ship)
                    .WhereIf(itinerary != null && itinerary != Guid.Empty, e => e.Itinerary != null && e.Itinerary.Id == itinerary);
        }

        public async Task<List<Cruise>> GetListAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, seasonMin, seasonMax, cruiseEnabled, featured, freeInternetOnBoard, internetOnBoard, video, b2B, b2C, b2B_Agent, b2C_Agent, cruiseDescriptions, shipAmenities, shipArticles, shipPhotos, cabinAmenities, cabinArticles, cabinPhotos);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CruiseConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            Guid? ship = null,
            Guid? itinerary = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, seasonMin, seasonMax, cruiseEnabled, featured, freeInternetOnBoard, internetOnBoard, video, b2B, b2C, b2B_Agent, b2C_Agent, cruiseDescriptions, shipAmenities, shipArticles, shipPhotos, cabinAmenities, cabinArticles, cabinPhotos, ship, itinerary);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Cruise> ApplyFilter(
            IQueryable<Cruise> query,
            string filterText,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Video.Contains(filterText))
                    .WhereIf(seasonMin.HasValue, e => e.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.Season <= seasonMax.Value)
                    .WhereIf(cruiseEnabled.HasValue, e => e.CruiseEnabled == cruiseEnabled)
                    .WhereIf(featured.HasValue, e => e.Featured == featured)
                    .WhereIf(freeInternetOnBoard.HasValue, e => e.FreeInternetOnBoard == freeInternetOnBoard)
                    .WhereIf(internetOnBoard.HasValue, e => e.InternetOnBoard == internetOnBoard)
                    .WhereIf(!string.IsNullOrWhiteSpace(video), e => e.Video.Contains(video))
                    .WhereIf(b2B.HasValue, e => e.B2B == b2B)
                    .WhereIf(b2C.HasValue, e => e.B2C == b2C)
                    .WhereIf(b2B_Agent.HasValue, e => e.B2B_Agent == b2B_Agent)
                    .WhereIf(b2C_Agent.HasValue, e => e.B2C_Agent == b2C_Agent)
                    .WhereIf(cruiseDescriptions.HasValue, e => e.CruiseDescriptions == cruiseDescriptions)
                    .WhereIf(shipAmenities.HasValue, e => e.ShipAmenities == shipAmenities)
                    .WhereIf(shipArticles.HasValue, e => e.ShipArticles == shipArticles)
                    .WhereIf(shipPhotos.HasValue, e => e.ShipPhotos == shipPhotos)
                    .WhereIf(cabinAmenities.HasValue, e => e.CabinAmenities == cabinAmenities)
                    .WhereIf(cabinArticles.HasValue, e => e.CabinArticles == cabinArticles)
                    .WhereIf(cabinPhotos.HasValue, e => e.CabinPhotos == cabinPhotos);
        }
    }
}