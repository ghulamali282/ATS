using Ccm.Partners;
using Ccm.MasterDatas;

namespace Ccm.PaymentPolicies
{
    public class PaymentPolicyWithNavigationProperties
    {
        public PaymentPolicy PaymentPolicy { get; set; }

        public Partner Partner { get; set; }
        public MasterData MasterData { get; set; }
        
    }
}