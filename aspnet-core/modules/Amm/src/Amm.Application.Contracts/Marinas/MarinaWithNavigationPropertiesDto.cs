using Amm.MasterDatas;
using Amm.Destinations;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Marinas
{
    public class MarinaWithNavigationPropertiesDto
    {
        public MarinaDto Marina { get; set; }

        public MasterDataDto MasterData { get; set; }
        public DestinationDto Destination { get; set; }

    }
}