using Amm.Destinations;
using Amm.Countries;
using Amm.MasterDatas;
using Amm.ShipOperators;

namespace Amm.Ships
{
    public class ShipWithNavigationProperties
    {
        public Ship Ship { get; set; }

        public Destination Destination { get; set; }
        public Country Country { get; set; }
        public MasterData MasterData { get; set; }
        public ShipOperator ShipOperator { get; set; }
        
    }
}