using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.AppDefaults
{
    public interface IAppDefaultRepository : IRepository<AppDefault, Guid>
    {
        Task<List<AppDefault>> GetListAsync(
            string filterText = null,
            string settingsName = null,
            string settingsValue = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string settingsName = null,
            string settingsValue = null,
            CancellationToken cancellationToken = default);
    }
}