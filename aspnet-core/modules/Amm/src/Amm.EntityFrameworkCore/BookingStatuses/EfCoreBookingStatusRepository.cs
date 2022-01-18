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

namespace Amm.BookingStatuses
{
    public class EfCoreBookingStatusRepository : EfCoreRepository<AmmDbContext, BookingStatus, int>, IBookingStatusRepository
    {
        public EfCoreBookingStatusRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<BookingStatusWithNavigationProperties> GetWithNavigationPropertiesAsync(int id, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryForNavigationPropertiesAsync())
                .FirstOrDefaultAsync(e => e.BookingStatus.Id == id, GetCancellationToken(cancellationToken));
        }

        public async Task<List<BookingStatusWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string statusColor = null,
            Guid? status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, statusColor, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? BookingStatusConsts.GetDefaultSorting(true) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        protected virtual async Task<IQueryable<BookingStatusWithNavigationProperties>> GetQueryForNavigationPropertiesAsync()
        {
            return from bookingStatus in (await GetDbSetAsync())
                   join masterData in (await GetDbContextAsync()).MasterDatas on bookingStatus.BookingStatusName equals masterData.Id into masterDatas
                   from masterData in masterDatas.DefaultIfEmpty()

                   select new BookingStatusWithNavigationProperties
                   {
                       BookingStatus = bookingStatus,
                       MasterData = masterData
                   };
        }

        protected virtual IQueryable<BookingStatusWithNavigationProperties> ApplyFilter(
            IQueryable<BookingStatusWithNavigationProperties> query,
            string filterText,
            string statusColor = null,
            Guid? status = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.BookingStatus.StatusColor.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(statusColor), e => e.BookingStatus.StatusColor.Contains(statusColor))
                    .WhereIf(status != null && status != Guid.Empty, e => e.MasterData != null && e.MasterData.Id == status);
        }

        public async Task<List<BookingStatus>> GetListAsync(
            string filterText = null,
            string statusColor = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, statusColor);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? BookingStatusConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string statusColor = null,
            Guid? status = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryForNavigationPropertiesAsync();
            query = ApplyFilter(query, filterText, statusColor, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<BookingStatus> ApplyFilter(
            IQueryable<BookingStatus> query,
            string filterText,
            string statusColor = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.StatusColor.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(statusColor), e => e.StatusColor.Contains(statusColor));
        }
    }
}