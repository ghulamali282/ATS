using Ccm.Partners;
using Ccm.MasterDatas;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicyWithNavigationProperties
    {
        public CancellationPolicy CancellationPolicy { get; set; }

        public Partner Partner { get; set; }
        public MasterData MasterData { get; set; }
        
    }
}