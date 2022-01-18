using Amm.Countries;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Destinations
{
    public class DestinationWithNavigationPropertiesDto
    {
        public DestinationDto Destination { get; set; }

        public CountryDto Country { get; set; }

    }
}