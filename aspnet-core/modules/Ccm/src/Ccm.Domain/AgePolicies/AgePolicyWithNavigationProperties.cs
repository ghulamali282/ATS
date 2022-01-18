using Ccm.MasterDatas;
using Ccm.Partners;

namespace Ccm.AgePolicies
{
    public class AgePolicyWithNavigationProperties
    {
        public AgePolicy AgePolicy { get; set; }

        public MasterData MasterData { get; set; }
        public Partner Partner { get; set; }
        
    }
}