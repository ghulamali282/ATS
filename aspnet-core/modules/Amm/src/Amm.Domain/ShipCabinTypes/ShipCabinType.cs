using Amm.MasterDatas;
using Amm.ShipDecks;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.ShipCabinTypes
{
    public class ShipCabinType : Entity<Guid>
    {
        public virtual Guid Ship { get; set; }

        public virtual int SortOrder { get; set; }
        public Guid CabinCategory { get; set; }
        public Guid Deck { get; set; }
        public Guid DeckLocation { get; set; }
        public Guid? DeckPosition { get; set; }

        public ShipCabinType()
        {

        }

        public ShipCabinType(Guid id, Guid ship, int sortOrder, Guid cabinCategory, Guid deck, Guid deckLocation)
        {
            Id = id;
            Ship = ship;
            SortOrder = sortOrder;
            CabinCategory = cabinCategory;
            Deck = deck;
            DeckLocation = deckLocation;
        }
    }
}