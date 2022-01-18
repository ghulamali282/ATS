using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.Countries
{
    public class EfCoreCountryRepository : EfCoreRepository<CcmDbContext, Country, string>, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Country>> GetListAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, countryName, cultureName);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CountryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, countryName, cultureName);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Country> ApplyFilter(
            IQueryable<Country> query,
            string filterText,
            string countryName = null,
            string cultureName = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CountryName.Contains(filterText) || e.CultureName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(countryName), e => e.CountryName.Contains(countryName))
                    .WhereIf(!string.IsNullOrWhiteSpace(cultureName), e => e.CultureName.Contains(cultureName));
        }
    }
}