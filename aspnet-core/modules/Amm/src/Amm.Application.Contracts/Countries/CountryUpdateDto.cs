using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.Countries
{
    public class CountryUpdateDto
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        [StringLength(CountryConsts.CultureNameMaxLength)]
        public string CultureName { get; set; }
        [Required]
        [StringLength(CountryConsts.CurrencyMaxLength)]
        public string Currency { get; set; }
        [Required]
        [StringLength(CountryConsts.CurrencyCodeMaxLength)]
        public string CurrencyCode { get; set; }
        [Required]
        [StringLength(CountryConsts.CurrencySymbolMaxLength)]
        public string CurrencySymbol { get; set; }
        [Required]
        [StringLength(CountryConsts.LanguageNameMaxLength)]
        public string LanguageName { get; set; }
        [StringLength(CountryConsts.PlaceIdMaxLength)]
        public string PlaceId { get; set; }
    }
}