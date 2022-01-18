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

namespace Amm.ShpCabins
{
    public class EfCoreShpCabinRepository : EfCoreRepository<AmmDbContext, ShpCabin, Guid>, IShpCabinRepository
    {
        public EfCoreShpCabinRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShpCabin>> GetListAsync(
            string filterText = null,
            Guid? ship = null,
            Guid? cabinCategory = null,
            string cabinNo = null,
            int? cabinNoNumericMin = null,
            int? cabinNoNumericMax = null,
            Guid? bedLayout = null,
            int? standardCapacityMin = null,
            int? standardCapacityMax = null,
            int? maxCapacityMin = null,
            int? maxCapacityMax = null,
            bool? portohole = null,
            bool? window = null,
            decimal? cabinAreaMin = null,
            decimal? cabinAreaMax = null,
            bool? balcon = null,
            decimal? balconAreaMin = null,
            decimal? balconAreaMax = null,
            bool? isDisabled = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, ship, cabinCategory, cabinNo, cabinNoNumericMin, cabinNoNumericMax, bedLayout, standardCapacityMin, standardCapacityMax, maxCapacityMin, maxCapacityMax, portohole, window, cabinAreaMin, cabinAreaMax, balcon, balconAreaMin, balconAreaMax, isDisabled);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShpCabinConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? ship = null,
            Guid? cabinCategory = null,
            string cabinNo = null,
            int? cabinNoNumericMin = null,
            int? cabinNoNumericMax = null,
            Guid? bedLayout = null,
            int? standardCapacityMin = null,
            int? standardCapacityMax = null,
            int? maxCapacityMin = null,
            int? maxCapacityMax = null,
            bool? portohole = null,
            bool? window = null,
            decimal? cabinAreaMin = null,
            decimal? cabinAreaMax = null,
            bool? balcon = null,
            decimal? balconAreaMin = null,
            decimal? balconAreaMax = null,
            bool? isDisabled = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, ship, cabinCategory, cabinNo, cabinNoNumericMin, cabinNoNumericMax, bedLayout, standardCapacityMin, standardCapacityMax, maxCapacityMin, maxCapacityMax, portohole, window, cabinAreaMin, cabinAreaMax, balcon, balconAreaMin, balconAreaMax, isDisabled);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShpCabin> ApplyFilter(
            IQueryable<ShpCabin> query,
            string filterText,
            Guid? ship = null,
            Guid? cabinCategory = null,
            string cabinNo = null,
            int? cabinNoNumericMin = null,
            int? cabinNoNumericMax = null,
            Guid? bedLayout = null,
            int? standardCapacityMin = null,
            int? standardCapacityMax = null,
            int? maxCapacityMin = null,
            int? maxCapacityMax = null,
            bool? portohole = null,
            bool? window = null,
            decimal? cabinAreaMin = null,
            decimal? cabinAreaMax = null,
            bool? balcon = null,
            decimal? balconAreaMin = null,
            decimal? balconAreaMax = null,
            bool? isDisabled = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CabinNo.Contains(filterText))
                    .WhereIf(ship.HasValue, e => e.Ship == ship)
                    .WhereIf(cabinCategory.HasValue, e => e.CabinCategory == cabinCategory)
                    .WhereIf(!string.IsNullOrWhiteSpace(cabinNo), e => e.CabinNo.Contains(cabinNo))
                    .WhereIf(cabinNoNumericMin.HasValue, e => e.CabinNoNumeric >= cabinNoNumericMin.Value)
                    .WhereIf(cabinNoNumericMax.HasValue, e => e.CabinNoNumeric <= cabinNoNumericMax.Value)
                    .WhereIf(bedLayout.HasValue, e => e.BedLayout == bedLayout)
                    .WhereIf(standardCapacityMin.HasValue, e => e.StandardCapacity >= standardCapacityMin.Value)
                    .WhereIf(standardCapacityMax.HasValue, e => e.StandardCapacity <= standardCapacityMax.Value)
                    .WhereIf(maxCapacityMin.HasValue, e => e.MaxCapacity >= maxCapacityMin.Value)
                    .WhereIf(maxCapacityMax.HasValue, e => e.MaxCapacity <= maxCapacityMax.Value)
                    .WhereIf(portohole.HasValue, e => e.Portohole == portohole)
                    .WhereIf(window.HasValue, e => e.Window == window)
                    .WhereIf(cabinAreaMin.HasValue, e => e.CabinArea >= cabinAreaMin.Value)
                    .WhereIf(cabinAreaMax.HasValue, e => e.CabinArea <= cabinAreaMax.Value)
                    .WhereIf(balcon.HasValue, e => e.Balcon == balcon)
                    .WhereIf(balconAreaMin.HasValue, e => e.BalconArea >= balconAreaMin.Value)
                    .WhereIf(balconAreaMax.HasValue, e => e.BalconArea <= balconAreaMax.Value)
                    .WhereIf(isDisabled.HasValue, e => e.IsDisabled == isDisabled);
        }
    }
}