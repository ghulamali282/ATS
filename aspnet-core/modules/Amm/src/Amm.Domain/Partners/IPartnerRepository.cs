using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.Partners
{
    public interface IPartnerRepository : IRepository<Partner, Guid>
    {
        Task<List<Partner>> GetListAsync(
            string filterText = null,
            string partnerName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string partnerName = null,
            CancellationToken cancellationToken = default);
    }
}