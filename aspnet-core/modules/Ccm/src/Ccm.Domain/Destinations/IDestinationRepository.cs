using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Destinations
{
    public interface IDestinationRepository : IRepository<Destination, Guid>
    {
        Task<List<Destination>> GetListAsync(
            string filterText = null,
            string city = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string city = null,
            CancellationToken cancellationToken = default);
    }
}