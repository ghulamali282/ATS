using Ccm.Countries;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Partners
{
    public class PartnerWithNavigationPropertiesDto
    {
        public PartnerDto Partner { get; set; }

        public CountryDto Country { get; set; }

    }
}