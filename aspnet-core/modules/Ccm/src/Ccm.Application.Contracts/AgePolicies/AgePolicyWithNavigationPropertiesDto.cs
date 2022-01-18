using Ccm.MasterDatas;
using Ccm.Partners;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.AgePolicies
{
    public class AgePolicyWithNavigationPropertiesDto
    {
        public AgePolicyDto AgePolicy { get; set; }

        public MasterDataDto MasterData { get; set; }
        public PartnerDto Partner { get; set; }

    }
}