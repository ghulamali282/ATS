using Ccm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.AgePolicyDetails
{
    public class AgePolicyDetailWithNavigationPropertiesDto
    {
        public AgePolicyDetailDto AgePolicyDetail { get; set; }

        public MasterDataDto MasterData { get; set; }

    }
}