using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Crm.Contracts
{
    public interface IContractRepository : IRepository<Contract, Guid>
    {
        Task<List<Contract>> GetListAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? isEnabledAgent = null,
            bool? isEnabledOperator = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? isEnabledAgent = null,
            bool? isEnabledOperator = null,
            CancellationToken cancellationToken = default);
    }
}