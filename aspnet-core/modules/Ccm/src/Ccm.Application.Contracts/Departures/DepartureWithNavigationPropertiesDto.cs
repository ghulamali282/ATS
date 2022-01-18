using Ccm.Partners;
using Ccm.DepartureSeasons;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Departures
{
    public class DepartureWithNavigationPropertiesDto
    {
        public DepartureDto Departure { get; set; }

        public PartnerDto Partner { get; set; }
        public DepartureSeasonDto DepartureSeason { get; set; }

    }
}