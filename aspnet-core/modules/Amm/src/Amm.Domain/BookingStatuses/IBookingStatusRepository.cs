using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.BookingStatuses
{
    public interface IBookingStatusRepository : IRepository<BookingStatus, int>
    {
        Task<BookingStatusWithNavigationProperties> GetWithNavigationPropertiesAsync(
    int id,
    CancellationToken cancellationToken = default
);

        Task<List<BookingStatusWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string statusColor = null,
            Guid? bookingStatusName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<BookingStatus>> GetListAsync(
                    string filterText = null,
                    string statusColor = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string statusColor = null,
            Guid? bookingStatusName = null,
            CancellationToken cancellationToken = default);
    }
}