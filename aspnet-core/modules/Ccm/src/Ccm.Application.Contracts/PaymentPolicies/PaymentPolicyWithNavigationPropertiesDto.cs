using Ccm.Partners;
using Ccm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.PaymentPolicies
{
    public class PaymentPolicyWithNavigationPropertiesDto
    {
        public PaymentPolicyDto PaymentPolicy { get; set; }

        public PartnerDto Partner { get; set; }
        public MasterDataDto MasterData { get; set; }

    }
}