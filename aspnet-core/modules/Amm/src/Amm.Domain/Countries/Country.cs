using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.Countries
{
    public class Country : Entity<string>
    {
        [NotNull]
        public virtual string CountryName { get; set; }

        [NotNull]
        public virtual string CultureName { get; set; }

        [NotNull]
        public virtual string Currency { get; set; }

        [NotNull]
        public virtual string CurrencyCode { get; set; }

        [NotNull]
        public virtual string CurrencySymbol { get; set; }

        [NotNull]
        public virtual string LanguageName { get; set; }

        [CanBeNull]
        public virtual string PlaceId { get; set; }

        public Country()
        {

        }

        public Country(string id, string countryName, string cultureName, string currency, string currencyCode, string currencySymbol, string languageName, string placeId = null)
        {
            Id = id;
            Check.NotNull(countryName, nameof(countryName));
            Check.NotNull(cultureName, nameof(cultureName));
            Check.Length(cultureName, nameof(cultureName), CountryConsts.CultureNameMaxLength, 0);
            Check.NotNull(currency, nameof(currency));
            Check.Length(currency, nameof(currency), CountryConsts.CurrencyMaxLength, 0);
            Check.NotNull(currencyCode, nameof(currencyCode));
            Check.Length(currencyCode, nameof(currencyCode), CountryConsts.CurrencyCodeMaxLength, 0);
            Check.NotNull(currencySymbol, nameof(currencySymbol));
            Check.Length(currencySymbol, nameof(currencySymbol), CountryConsts.CurrencySymbolMaxLength, 0);
            Check.NotNull(languageName, nameof(languageName));
            Check.Length(languageName, nameof(languageName), CountryConsts.LanguageNameMaxLength, 0);
            Check.Length(placeId, nameof(placeId), CountryConsts.PlaceIdMaxLength, 0);
            CountryName = countryName;
            CultureName = cultureName;
            Currency = currency;
            CurrencyCode = currencyCode;
            CurrencySymbol = currencySymbol;
            LanguageName = languageName;
            PlaceId = placeId;
        }
    }
}