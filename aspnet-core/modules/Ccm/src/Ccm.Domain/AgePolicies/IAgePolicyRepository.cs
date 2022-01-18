using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.AgePolicies
{
    public interface IAgePolicyRepository : IRepository<AgePolicy, Guid>
    {
        Task<AgePolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<AgePolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string demoField = null,
            Guid? name = null,
            Guid? operatorName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<AgePolicy>> GetListAsync(
                    string filterText = null,
                    string demoField = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string demoField = null,
            Guid? name = null,
            Guid? operatorName = null,
            CancellationToken cancellationToken = default);
    }
}