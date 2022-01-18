using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShipCabinTypes
{
    public class ShipCabinTypeDto : EntityDto<Guid>
    {
        public Guid Ship { get; set; }
        public int SortOrder { get; set; }
        public Guid CabinCategory { get; set; }
        public Guid Deck { get; set; }
        public Guid DeckLocation { get; set; }
        public Guid? DeckPosition { get; set; }
    }
}