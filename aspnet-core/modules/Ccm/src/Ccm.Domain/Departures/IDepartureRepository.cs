using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Departures
{
    public interface IDepartureRepository : IRepository<Departure, Guid>
    {
        Task<DepartureWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<DepartureWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string departuresArray = null,
            string seasonGroup = null,
            Guid? partner = null,
            Guid? seasonName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Departure>> GetListAsync(
                    string filterText = null,
                    string departuresArray = null,
                    string seasonGroup = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string departuresArray = null,
            string seasonGroup = null,
            Guid? partner = null,
            Guid? seasonName = null,
            CancellationToken cancellationToken = default);
    }
}