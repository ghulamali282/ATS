using Ccm.Partners;
using Ccm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicyWithNavigationPropertiesDto
    {
        public CancellationPolicyDto CancellationPolicy { get; set; }

        public PartnerDto Partner { get; set; }
        public MasterDataDto MasterData { get; set; }

    }
}