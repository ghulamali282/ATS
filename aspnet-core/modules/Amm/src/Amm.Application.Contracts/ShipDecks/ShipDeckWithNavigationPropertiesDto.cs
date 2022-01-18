using Amm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShipDecks
{
    public class ShipDeckWithNavigationPropertiesDto
    {
        public ShipDeckDto ShipDeck { get; set; }

        public MasterDataDto MasterData { get; set; }

    }
}