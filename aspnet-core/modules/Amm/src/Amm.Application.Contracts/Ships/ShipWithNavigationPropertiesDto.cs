using Amm.Destinations;
using Amm.Countries;
using Amm.MasterDatas;
using Amm.ShipOperators;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Ships
{
    public class ShipWithNavigationPropertiesDto
    {
        public ShipDto Ship { get; set; }

        public DestinationDto Destination { get; set; }
        public CountryDto Country { get; set; }
        public MasterDataDto MasterData { get; set; }
        public ShipOperatorDto ShipOperator { get; set; }

    }
}