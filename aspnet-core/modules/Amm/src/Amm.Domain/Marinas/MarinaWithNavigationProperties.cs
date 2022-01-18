using Amm.MasterDatas;
using Amm.Destinations;

namespace Amm.Marinas
{
    public class MarinaWithNavigationProperties
    {
        public Marina Marina { get; set; }

        public MasterData MasterData { get; set; }
        public Destination Destination { get; set; }
        
    }
}