using Ccm.Partners;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.DepartureSeasons
{
    public class DepartureSeasonWithNavigationPropertiesDto
    {
        public DepartureSeasonDto DepartureSeason { get; set; }

        public PartnerDto Partner { get; set; }

    }
}