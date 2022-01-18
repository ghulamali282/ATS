using Volo.Abp.Application.Dtos;
using System;

namespace Amm.ShipDecks
{
    public class GetShipDecksInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ShipDeckNameTEMP { get; set; }
        public int? SortOrderMin { get; set; }
        public int? SortOrderMax { get; set; }
        public string Ship { get; set; }
        public Guid? Deck { get; set; }

        public GetShipDecksInput()
        {

        }
    }
}