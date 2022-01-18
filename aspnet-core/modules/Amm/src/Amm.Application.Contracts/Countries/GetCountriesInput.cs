using Volo.Abp.Application.Dtos;
using System;

namespace Amm.Countries
{
    public class GetCountriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string CountryName { get; set; }
        public string CultureName { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
        public string LanguageName { get; set; }
        public string PlaceId { get; set; }

        public GetCountriesInput()
        {

        }
    }
}