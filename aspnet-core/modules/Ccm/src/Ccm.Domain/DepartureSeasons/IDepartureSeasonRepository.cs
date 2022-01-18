using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.DepartureSeasons
{
    public interface IDepartureSeasonRepository : IRepository<DepartureSeason, Guid>
    {
        Task<DepartureSeasonWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<DepartureSeasonWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            Guid? partner = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<DepartureSeason>> GetListAsync(
                    string filterText = null,
                    int? seasonMin = null,
                    int? seasonMax = null,
                    string seasonName = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            string seasonName = null,
            Guid? partner = null,
            CancellationToken cancellationToken = default);
    }
}