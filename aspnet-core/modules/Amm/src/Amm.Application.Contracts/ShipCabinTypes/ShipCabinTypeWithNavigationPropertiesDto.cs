using Amm.MasterDatas;
using Amm.ShipDecks;
using Amm.MasterDatas;
using Amm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShipCabinTypes
{
    public class ShipCabinTypeWithNavigationPropertiesDto
    {
        public ShipCabinTypeDto ShipCabinType { get; set; }

        public MasterDataDto MasterData { get; set; }
        public ShipDeckDto ShipDeck { get; set; }
        public MasterDataDto MasterData1 { get; set; }
        public MasterDataDto MasterData2 { get; set; }

    }
}