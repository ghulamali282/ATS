using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.Marinas
{
    public interface IMarinaRepository : IRepository<Marina, Guid>
    {
        Task<MarinaWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<MarinaWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            Guid? marinaName = null,
            Guid? destination = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Marina>> GetListAsync(
                    string filterText = null,
                    string marinaNameString = null,
                    string latitude = null,
                    string longitude = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string marinaNameString = null,
            string latitude = null,
            string longitude = null,
            Guid? marinaName = null,
            Guid? destination = null,
            CancellationToken cancellationToken = default);
    }
}