using Volo.Abp.Application.Dtos;
using System;

namespace Amm.ShipCabinTypes
{
    public class GetShipCabinTypesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? Ship { get; set; }
        public int? SortOrderMin { get; set; }
        public int? SortOrderMax { get; set; }
        public Guid? CabinCategory { get; set; }
        public Guid? Deck { get; set; }
        public Guid? DeckLocation { get; set; }
        public Guid? DeckPosition { get; set; }

        public GetShipCabinTypesInput()
        {

        }
    }
}