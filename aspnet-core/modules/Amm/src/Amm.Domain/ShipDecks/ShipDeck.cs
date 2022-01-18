using Amm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.ShipDecks
{
    public class ShipDeck : Entity<Guid>
    {
        [NotNull]
        public virtual string ShipDeckNameTEMP { get; set; }

        public virtual int SortOrder { get; set; }

        [NotNull]
        public virtual string Ship { get; set; }
        public Guid Deck { get; set; }

        public ShipDeck()
        {

        }

        public ShipDeck(Guid id, string shipDeckNameTEMP, int sortOrder, string ship, Guid deck)
        {
            Id = id;
            Check.NotNull(shipDeckNameTEMP, nameof(shipDeckNameTEMP));
            Check.NotNull(ship, nameof(ship));
            ShipDeckNameTEMP = shipDeckNameTEMP;
            SortOrder = sortOrder;
            Ship = ship;
            Deck = deck;
        }
    }
}