using Amm.MasterDatas;
using Amm.ShipDecks;
using Amm.MasterDatas;
using Amm.MasterDatas;

namespace Amm.ShipCabinTypes
{
    public class ShipCabinTypeWithNavigationProperties
    {
        public ShipCabinType ShipCabinType { get; set; }

        public MasterData MasterData { get; set; }
        public ShipDeck ShipDeck { get; set; }
        public MasterData MasterData1 { get; set; }
        public MasterData MasterData2 { get; set; }
        
    }
}