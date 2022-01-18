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

namespace Amm.ShipDecks
{
    public class EfCoreShipDeckRepository : EfCoreRepository<AmmDbContext, ShipDeck, Guid>, IShipDeckRepository
    {
        public EfCoreShipDeckRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<ShipDeckWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.ShipDeck.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<ShipDeckWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            Guid? deck = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, shipDeckNameTEMP, sortOrderMin, sortOrderMax, ship, deck);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipDeckConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<ShipDeckWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from shipDeck in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on shipDeck.Deck equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new ShipDeckWithNavigationProperties
                   {
                       ShipDeck = shipDeck,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<ShipDeckWithNavigationProperties> ApplyFilter(
            IQueryable<ShipDeckWithNavigationProperties> query,
            string filterText,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            Guid? deck = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ShipDeck.ShipDeckNameTEMP.Contains(filterText) || e.ShipDeck.Ship.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(shipDeckNameTEMP), e => e.ShipDeck.ShipDeckNameTEMP.Contains(shipDeckNameTEMP))
                    .WhereIf(sortOrderMin.HasValue, e => e.ShipDeck.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.ShipDeck.SortOrder <= sortOrderMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(ship), e => e.ShipDeck.Ship.Contains(ship))
                    .WhereIf(deck != null && deck != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == deck);
        }

        public async Task<List<ShipDeck>> GetListAsync(
            string filterText = null,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, shipDeckNameTEMP, sortOrderMin, sortOrderMax, ship);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShipDeckConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            Guid? deck = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, shipDeckNameTEMP, sortOrderMin, sortOrderMax, ship, deck);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShipDeck> ApplyFilter(
            IQueryable<ShipDeck> query,
            string filterText,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ShipDeckNameTEMP.Contains(filterText) || e.Ship.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(shipDeckNameTEMP), e => e.ShipDeckNameTEMP.Contains(shipDeckNameTEMP))
                    .WhereIf(sortOrderMin.HasValue, e => e.SortOrder >= sortOrderMin.Value)
                    .WhereIf(sortOrderMax.HasValue, e => e.SortOrder <= sortOrderMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(ship), e => e.Ship.Contains(ship));
        }
    }
}