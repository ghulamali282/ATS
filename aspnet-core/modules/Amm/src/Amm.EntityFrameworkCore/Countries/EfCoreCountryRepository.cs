using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Amm.EntityFrameworkCore;

namespace Amm.Countries
{
    public class EfCoreCountryRepository : EfCoreRepository<AmmDbContext, Country, string>, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<AmmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Country>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, countryName, cultureName, currency, currencyCode, currencySymbol, languageName, placeId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CountryConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string countryName = null,
            string cultureName = null,
            string currency = null,
            string currencyCode = null,
            string currencySymbol = null,
            string languageName = null,
            string placeId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, countryName, cultureName, currency, currencyCode, currencySymbol, languageName, placeId);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Country> ApplyFilter(
            IQueryable<Country> query,
            string filterText,
            string countryName = null,
            string cultureName = null,
            string currency = null,
            string currencyCode = null,
            string currencySymbol = null,
            string languageName = null,
            string placeId = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CountryName.Contains(filterText) || e.CultureName.Contains(filterText) || e.Currency.Contains(filterText) || e.CurrencyCode.Contains(filterText) || e.CurrencySymbol.Contains(filterText) || e.LanguageName.Contains(filterText) || e.PlaceId.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(countryName), e => e.CountryName.Contains(countryName))
                    .WhereIf(!string.IsNullOrWhiteSpace(cultureName), e => e.CultureName.Contains(cultureName))
                    .WhereIf(!string.IsNullOrWhiteSpace(currency), e => e.Currency.Contains(currency))
                    .WhereIf(!string.IsNullOrWhiteSpace(currencyCode), e => e.CurrencyCode.Contains(currencyCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(currencySymbol), e => e.CurrencySymbol.Contains(currencySymbol))
                    .WhereIf(!string.IsNullOrWhiteSpace(languageName), e => e.LanguageName.Contains(languageName))
                    .WhereIf(!string.IsNullOrWhiteSpace(placeId), e => e.PlaceId.Contains(placeId));
        }
    }
}