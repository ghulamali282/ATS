using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Ships
{
    public interface IShipRepository : IRepository<Ship, Guid>
    {
        Task<List<Ship>> GetListAsync(
            string filterText = null,
            string shipName = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            Guid? type = null,
            string flag = null,
            Guid? homePort = null,
            Guid? manufacturer = null,
            Guid? model = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string shipName = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            Guid? type = null,
            string flag = null,
            Guid? homePort = null,
            Guid? manufacturer = null,
            Guid? model = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            CancellationToken cancellationToken = default);
    }
}