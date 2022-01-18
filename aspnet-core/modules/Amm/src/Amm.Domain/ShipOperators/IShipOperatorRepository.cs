using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.ShipOperators
{
    public interface IShipOperatorRepository : IRepository<ShipOperator, Guid>
    {
        Task<List<ShipOperator>> GetListAsync(
            string filterText = null,
            string operatorName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string operatorName = null,
            CancellationToken cancellationToken = default);
    }
}