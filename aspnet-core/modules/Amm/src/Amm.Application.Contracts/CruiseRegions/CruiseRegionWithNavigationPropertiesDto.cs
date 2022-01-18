using Amm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.CruiseRegions
{
    public class CruiseRegionWithNavigationPropertiesDto
    {
        public CruiseRegionDto CruiseRegion { get; set; }

        public MasterDataDto MasterData { get; set; }

    }
}