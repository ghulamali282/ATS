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

namespace Amm.Ships
{
    public class EfCoreShipRepository : EfCoreRepository<AmmDbContext, Ship, Guid>, IShipRepository
    {
        public EfCoreShipRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<ShipWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.Ship.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<ShipWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            Guid? homePort = null,
            string flag = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, shipName, yearBuildMin, yearBuildMax, yearRefurbishedMin, yearRefurbishedMax, ensuitedCabins, sharedToiletsMin, sharedToiletsMax, sharedShowersMin, sharedShowersMax, crewNoMin, crewNoMax, lenghtMin, lenghtMax, beamMin, beamMax, draftMin, draftMax, cruiseSpeedMin, cruiseSpeedMax, maxSpeedMin, maxSpeedMax, videoUrl, useCabinDeckPosition, useDeckLocation, shipEnabled, homePort, flag, shipCategory, shipOperator);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ShipWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from ship in (await GetDbSetAsync())
                   join destination in (await GetDbContextAsync()).Destinations on ship.HomePort equals destination.Id into destinations
                   from destination in destinations.DefaultIfEmpty()
                   join country in (await GetDbContextAsync()).Countries on ship.Flag equals country.Id into countries
                   from country in countries.DefaultIfEmpty()
                   join masterData in (await GetDbContextAsync()).MasterDatas on ship.ShipCategory equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()
                   join shipOperator in (await GetDbContextAsync()).ShipOperators on ship.ShipOperator equals shipOperator.Id into shipOperators
                   from shipOperator in shipOperators.DefaultIfEmpty()

                   select new ShipWithNavigationProperties
                   {
                       Ship = ship,
                       Destination = destination,
                       Country = country,
                       MasterData = masterData,
                       ShipOperator = shipOperator
                   };
        }

        protected virtual IQueryable<ShipWithNavigationProperties> ApplyFilter(
            IQueryable<ShipWithNavigationProperties> query,
            string filterText,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            Guid? homePort = null,
            string flag = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Ship.ShipName.Contains(filterText) || e.Ship.VideoUrl.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(shipName), e => e.Ship.ShipName.Contains(shipName))
                    .WhereIf(yearBuildMin.HasValue, e => e.Ship.YearBuild >= yearBuildMin.Value)
                    .WhereIf(yearBuildMax.HasValue, e => e.Ship.YearBuild <= yearBuildMax.Value)
                    .WhereIf(yearRefurbishedMin.HasValue, e => e.Ship.YearRefurbished >= yearRefurbishedMin.Value)
                    .WhereIf(yearRefurbishedMax.HasValue, e => e.Ship.YearRefurbished <= yearRefurbishedMax.Value)
                    .WhereIf(ensuitedCabins.HasValue, e => e.Ship.EnsuitedCabins == ensuitedCabins)
                    .WhereIf(sharedToiletsMin.HasValue, e => e.Ship.SharedToilets >= sharedToiletsMin.Value)
                    .WhereIf(sharedToiletsMax.HasValue, e => e.Ship.SharedToilets <= sharedToiletsMax.Value)
                    .WhereIf(sharedShowersMin.HasValue, e => e.Ship.SharedShowers >= sharedShowersMin.Value)
                    .WhereIf(sharedShowersMax.HasValue, e => e.Ship.SharedShowers <= sharedShowersMax.Value)
                    .WhereIf(crewNoMin.HasValue, e => e.Ship.CrewNo >= crewNoMin.Value)
                    .WhereIf(crewNoMax.HasValue, e => e.Ship.CrewNo <= crewNoMax.Value)
                    .WhereIf(lenghtMin.HasValue, e => e.Ship.Lenght >= lenghtMin.Value)
                    .WhereIf(lenghtMax.HasValue, e => e.Ship.Lenght <= lenghtMax.Value)
                    .WhereIf(beamMin.HasValue, e => e.Ship.Beam >= beamMin.Value)
                    .WhereIf(beamMax.HasValue, e => e.Ship.Beam <= beamMax.Value)
                    .WhereIf(draftMin.HasValue, e => e.Ship.Draft >= draftMin.Value)
                    .WhereIf(draftMax.HasValue, e => e.Ship.Draft <= draftMax.Value)
                    .WhereIf(cruiseSpeedMin.HasValue, e => e.Ship.CruiseSpeed >= cruiseSpeedMin.Value)
                    .WhereIf(cruiseSpeedMax.HasValue, e => e.Ship.CruiseSpeed <= cruiseSpeedMax.Value)
                    .WhereIf(maxSpeedMin.HasValue, e => e.Ship.MaxSpeed >= maxSpeedMin.Value)
                    .WhereIf(maxSpeedMax.HasValue, e => e.Ship.MaxSpeed <= maxSpeedMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(videoUrl), e => e.Ship.VideoUrl.Contains(videoUrl))
                    .WhereIf(useCabinDeckPosition.HasValue, e => e.Ship.UseCabinDeckPosition == useCabinDeckPosition)
                    .WhereIf(useDeckLocation.HasValue, e => e.Ship.UseDeckLocation == useDeckLocation)
                    .WhereIf(shipEnabled.HasValue, e => e.Ship.ShipEnabled == shipEnabled)
                    .WhereIf(homePort != null && homePort != Guid.Empty, e => e.Destination != null && e.Destination.Id == homePort)
                    .WhereIf(flag != null && flag != "", e => e.Country != null && e.Country.Id == flag)
                    .WhereIf(shipCategory != null && shipCategory != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == shipCategory)
                    .WhereIf(shipOperator != null && shipOperator != Guid.Empty, e => e.ShipOperator != null && e.ShipOperator.Id == shipOperator);
        }

        public async Task<List<Ship>> GetListAsync(
            string filterText = null,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, shipName, yearBuildMin, yearBuildMax, yearRefurbishedMin, yearRefurbishedMax, ensuitedCabins, sharedToiletsMin, sharedToiletsMax, sharedShowersMin, sharedShowersMax, crewNoMin, crewNoMax, lenghtMin, lenghtMax, beamMin, beamMax, draftMin, draftMax, cruiseSpeedMin, cruiseSpeedMax, maxSpeedMin, maxSpeedMax, videoUrl, useCabinDeckPosition, useDeckLocation, shipEnabled);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            Guid? homePort = null,
            string flag = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, shipName, yearBuildMin, yearBuildMax, yearRefurbishedMin, yearRefurbishedMax, ensuitedCabins, sharedToiletsMin, sharedToiletsMax, sharedShowersMin, sharedShowersMax, crewNoMin, crewNoMax, lenghtMin, lenghtMax, beamMin, beamMax, draftMin, draftMax, cruiseSpeedMin, cruiseSpeedMax, maxSpeedMin, maxSpeedMax, videoUrl, useCabinDeckPosition, useDeckLocation, shipEnabled, homePort, flag, shipCategory, shipOperator);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Ship> ApplyFilter(
            IQueryable<Ship> query,
            string filterText,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ShipName.Contains(filterText) || e.VideoUrl.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(shipName), e => e.ShipName.Contains(shipName))
                    .WhereIf(yearBuildMin.HasValue, e => e.YearBuild >= yearBuildMin.Value)
                    .WhereIf(yearBuildMax.HasValue, e => e.YearBuild <= yearBuildMax.Value)
                    .WhereIf(yearRefurbishedMin.HasValue, e => e.YearRefurbished >= yearRefurbishedMin.Value)
                    .WhereIf(yearRefurbishedMax.HasValue, e => e.YearRefurbished <= yearRefurbishedMax.Value)
                    .WhereIf(ensuitedCabins.HasValue, e => e.EnsuitedCabins == ensuitedCabins)
                    .WhereIf(sharedToiletsMin.HasValue, e => e.SharedToilets >= sharedToiletsMin.Value)
                    .WhereIf(sharedToiletsMax.HasValue, e => e.SharedToilets <= sharedToiletsMax.Value)
                    .WhereIf(sharedShowersMin.HasValue, e => e.SharedShowers >= sharedShowersMin.Value)
                    .WhereIf(sharedShowersMax.HasValue, e => e.SharedShowers <= sharedShowersMax.Value)
                    .WhereIf(crewNoMin.HasValue, e => e.CrewNo >= crewNoMin.Value)
                    .WhereIf(crewNoMax.HasValue, e => e.CrewNo <= crewNoMax.Value)
                    .WhereIf(lenghtMin.HasValue, e => e.Lenght >= lenghtMin.Value)
                    .WhereIf(lenghtMax.HasValue, e => e.Lenght <= lenghtMax.Value)
                    .WhereIf(beamMin.HasValue, e => e.Beam >= beamMin.Value)
                    .WhereIf(beamMax.HasValue, e => e.Beam <= beamMax.Value)
                    .WhereIf(draftMin.HasValue, e => e.Draft >= draftMin.Value)
                    .WhereIf(draftMax.HasValue, e => e.Draft <= draftMax.Value)
                    .WhereIf(cruiseSpeedMin.HasValue, e => e.CruiseSpeed >= cruiseSpeedMin.Value)
                    .WhereIf(cruiseSpeedMax.HasValue, e => e.CruiseSpeed <= cruiseSpeedMax.Value)
                    .WhereIf(maxSpeedMin.HasValue, e => e.MaxSpeed >= maxSpeedMin.Value)
                    .WhereIf(maxSpeedMax.HasValue, e => e.MaxSpeed <= maxSpeedMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(videoUrl), e => e.VideoUrl.Contains(videoUrl))
                    .WhereIf(useCabinDeckPosition.HasValue, e => e.UseCabinDeckPosition == useCabinDeckPosition)
                    .WhereIf(useDeckLocation.HasValue, e => e.UseDeckLocation == useDeckLocation)
                    .WhereIf(shipEnabled.HasValue, e => e.ShipEnabled == shipEnabled);
        }
    }
}