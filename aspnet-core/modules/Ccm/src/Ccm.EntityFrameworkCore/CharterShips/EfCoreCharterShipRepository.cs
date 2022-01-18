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

namespace Ccm.CharterShips
{
    public class EfCoreCharterShipRepository : EfCoreRepository<CcmDbContext, CharterShip, Guid>, ICharterShipRepository
    {
        public EfCoreCharterShipRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CharterShip>> GetListAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            Guid? shipNamePrefix = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string tabs = null,
            string video = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internet = null,
            bool? transferIncluded = null,
            bool? enabledByUser = null,
            int? disabledBySystemMin = null,
            int? disabledBySystemMax = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, operatorName, seasonMin, seasonMax, shipNamePrefix, ship, itinerary, tabs, video, featured, freeInternetOnBoard, internet, transferIncluded, enabledByUser, disabledBySystemMin, disabledBySystemMax, b2B, b2C, b2B_Agent, b2C_Agent, shipAmenities, shipArticles, shipPhotos, cabinAmenities, cabinArticles, cabinPhotos);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CharterShipConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            Guid? shipNamePrefix = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string tabs = null,
            string video = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internet = null,
            bool? transferIncluded = null,
            bool? enabledByUser = null,
            int? disabledBySystemMin = null,
            int? disabledBySystemMax = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, operatorName, seasonMin, seasonMax, shipNamePrefix, ship, itinerary, tabs, video, featured, freeInternetOnBoard, internet, transferIncluded, enabledByUser, disabledBySystemMin, disabledBySystemMax, b2B, b2C, b2B_Agent, b2C_Agent, shipAmenities, shipArticles, shipPhotos, cabinAmenities, cabinArticles, cabinPhotos);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CharterShip> ApplyFilter(
            IQueryable<CharterShip> query,
            string filterText,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            Guid? shipNamePrefix = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string tabs = null,
            string video = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internet = null,
            bool? transferIncluded = null,
            bool? enabledByUser = null,
            int? disabledBySystemMin = null,
            int? disabledBySystemMax = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Tabs.Contains(filterText) || e.Video.Contains(filterText))
                    .WhereIf(operatorName.HasValue, e => e.OperatorName == operatorName)
                    .WhereIf(seasonMin.HasValue, e => e.Season >= seasonMin.Value)
                    .WhereIf(seasonMax.HasValue, e => e.Season <= seasonMax.Value)
                    .WhereIf(shipNamePrefix.HasValue, e => e.ShipNamePrefix == shipNamePrefix)
                    .WhereIf(ship.HasValue, e => e.Ship == ship)
                    .WhereIf(itinerary.HasValue, e => e.Itinerary == itinerary)
                    .WhereIf(!string.IsNullOrWhiteSpace(tabs), e => e.Tabs.Contains(tabs))
                    .WhereIf(!string.IsNullOrWhiteSpace(video), e => e.Video.Contains(video))
                    .WhereIf(featured.HasValue, e => e.Featured == featured)
                    .WhereIf(freeInternetOnBoard.HasValue, e => e.FreeInternetOnBoard == freeInternetOnBoard)
                    .WhereIf(internet.HasValue, e => e.Internet == internet)
                    .WhereIf(transferIncluded.HasValue, e => e.TransferIncluded == transferIncluded)
                    .WhereIf(enabledByUser.HasValue, e => e.EnabledByUser == enabledByUser)
                    .WhereIf(disabledBySystemMin.HasValue, e => e.DisabledBySystem >= disabledBySystemMin.Value)
                    .WhereIf(disabledBySystemMax.HasValue, e => e.DisabledBySystem <= disabledBySystemMax.Value)
                    .WhereIf(b2B.HasValue, e => e.B2B == b2B)
                    .WhereIf(b2C.HasValue, e => e.B2C == b2C)
                    .WhereIf(b2B_Agent.HasValue, e => e.B2B_Agent == b2B_Agent)
                    .WhereIf(b2C_Agent.HasValue, e => e.B2C_Agent == b2C_Agent)
                    .WhereIf(shipAmenities.HasValue, e => e.ShipAmenities == shipAmenities)
                    .WhereIf(shipArticles.HasValue, e => e.ShipArticles == shipArticles)
                    .WhereIf(shipPhotos.HasValue, e => e.ShipPhotos == shipPhotos)
                    .WhereIf(cabinAmenities.HasValue, e => e.CabinAmenities == cabinAmenities)
                    .WhereIf(cabinArticles.HasValue, e => e.CabinArticles == cabinArticles)
                    .WhereIf(cabinPhotos.HasValue, e => e.CabinPhotos == cabinPhotos);
        }
    }
}