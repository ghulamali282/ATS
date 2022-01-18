using Amm.Countries;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Countries
{
    public class CountryWithNavigationPropertiesDto
    {
        public CountryDto Country { get; set; }

        public CountryDto Country1 { get; set; }

    }
}