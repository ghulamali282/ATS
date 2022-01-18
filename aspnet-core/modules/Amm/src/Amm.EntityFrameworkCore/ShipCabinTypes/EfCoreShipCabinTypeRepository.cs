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

namespace Amm.ShipCabinTypes
{
    public class EfCoreShipCabinTypeRepository : EfCoreRepository<AmmDbContext, ShipCabinType, Guid>, IShipCabinTypeRepository
    {
        public EfCoreShipCabinTypeRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<ShipCabinTypeWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.ShipCabinType.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<ShipCabinTypeWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            Guid? cabinCategory = null,
            Guid? deck = null,
            Guid? deckLocation = null,
            Guid? deckPosition = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ship, sortOrderMin, sortOrderMax, cabinCategory, deck, deckLocation, deckPosition);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipCabinTypeConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ShipCabinTypeWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from shipCabinType in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on shipCabinType.CabinCategory equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()
                   join shipDeck in (await GetDbContextAsync()).ShipDecks on shipCabinType.Deck equals shipDeck.Id into shipDecks
                   from shipDeck in shipDecks.DefaultIfEmpty()
                   join masterData1 in (await GetDbContextAsync()).MasterDatas on shipCabinType.DeckLocation equals masterData1.Id into masterDatas1
                   from masterData1 in masterDatas1.DefaultIfEmpty()
                   join masterData2 in (await GetDbContextAsync()).MasterDatas on shipCabinType.DeckPosition equals masterData2.Id into masterDatas2
                   from masterData2 in masterDatas2.DefaultIfEmpty()

                   select new ShipCabinTypeWithNavigationProperties
                   {
                       ShipCabinType = shipCabinType,
                       MasterData = masterData,
                       ShipDeck = shipDeck,
                       MasterData1 = masterData1,
                       MasterData2 = masterData2
                   };
        }

        protected virtual IQueryable<ShipCabinTypeWithNavigationProperties> ApplyFilter(
            IQueryable<ShipCabinTypeWithNavigationProperties> query,
            string filterText,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            Guid? cabinCategory = null,
            Guid? deck = null,
            Guid? deckLocation = null,
            Guid? deckPosition = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(ship.HasValue, e => e.ShipCabinType.Ship == ship)
                    .WhereIf(sortOrderMin.HasValue, e => e.ShipCabinType.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.ShipCabinType.SortOrder <= sortOrderMax.Value)
                    .WhereIf(cabinCategory != null && cabinCategory != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == cabinCategory)
                    .WhereIf(deck != null && deck != Guid.Empty, e => e.ShipDeck != null && e.ShipDeck.Id == deck)
                    .WhereIf(deckLocation != null && deckLocation != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == deckLocation)
                    .WhereIf(deckPosition != null && deckPosition != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == deckPosition);
        }

        public async Task<List<ShipCabinType>> GetListAsync(
            string filterText = null,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, ship, sortOrderMin, sortOrderMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipCabinTypeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            Guid? cabinCategory = null,
            Guid? deck = null,
            Guid? deckLocation = null,
            Guid? deckPosition = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, ship, sortOrderMin, sortOrderMax, cabinCategory, deck, deckLocation, deckPosition);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShipCabinType> ApplyFilter(
            IQueryable<ShipCabinType> query,
            string filterText,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => true)
                    .WhereIf(ship.HasValue, e => e.Ship == ship)
                    .WhereIf(sortOrderMin.HasValue, e => e.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.SortOrder <= sortOrderMax.Value);
        }
    }
}