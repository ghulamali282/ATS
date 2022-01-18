using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Countries
{
    public class CountryDto : EntityDto<string>
    {
        public string CountryName { get; set; }
        public string CultureName { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string LanguageName { get; set; }
        public string PlaceId { get; set; }
    }
}