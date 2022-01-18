using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.CancellationPolicies
{
    public interface ICancellationPolicyRepository : IRepository<CancellationPolicy, Guid>
    {
        Task<CancellationPolicyWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CancellationPolicyWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string nameString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<CancellationPolicy>> GetListAsync(
                    string filterText = null,
                    string nameString = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string nameString = null,
            Guid? operatorName = null,
            Guid? policyName = null,
            CancellationToken cancellationToken = default);
    }
}