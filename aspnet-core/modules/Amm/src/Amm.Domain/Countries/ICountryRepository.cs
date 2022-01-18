using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.Countries
{
    public interface ICountryRepository : IRepository<Country, string>
    {
        Task<List<Country>> GetListAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            string currency = null,
            string currencyCode = null,
            string currencySymbol = null,
            string languageName = null,
            string placeId = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            string currency = null,
            string currencyCode = null,
            string currencySymbol = null,
            string languageName = null,
            string placeId = null,
            CancellationToken cancellationToken = default);
    }
}