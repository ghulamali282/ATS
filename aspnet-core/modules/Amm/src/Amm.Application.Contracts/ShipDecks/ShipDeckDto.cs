using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShipDecks
{
    public class ShipDeckDto : EntityDto<Guid>
    {
        public string ShipDeckNameTEMP { get; set; }
        public int SortOrder { get; set; }
        public string Ship { get; set; }
        public Guid Deck { get; set; }
    }
}