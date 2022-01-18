using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.CruiseRegions
{
    public interface ICruiseRegionRepository : IRepository<CruiseRegion, Guid>
    {
        Task<CruiseRegionWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CruiseRegionWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string freeEntry = null,
            Guid? cruiseRegionName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<CruiseRegion>> GetListAsync(
                    string filterText = null,
                    string freeEntry = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string freeEntry = null,
            Guid? cruiseRegionName = null,
            CancellationToken cancellationToken = default);
    }
}