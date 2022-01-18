using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.AgePolicyDetails
{
    public interface IAgePolicyDetailRepository : IRepository<AgePolicyDetail, Guid>
    {
        Task<AgePolicyDetailWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<AgePolicyDetailWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            Guid? service = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<AgePolicyDetail>> GetListAsync(
                    string filterText = null,
                    int? ageFromMin = null,
                    int? ageFromMax = null,
                    Guid? agePolicy = null,
                    int? ageToMin = null,
                    int? ageToMax = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            int? ageFromMin = null,
            int? ageFromMax = null,
            Guid? agePolicy = null,
            int? ageToMin = null,
            int? ageToMax = null,
            Guid? service = null,
            CancellationToken cancellationToken = default);
    }
}