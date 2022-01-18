using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Countries
{
    public interface ICountryRepository : IRepository<Country, string>
    {
        Task<List<Country>> GetListAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            CancellationToken cancellationToken = default);
    }
}