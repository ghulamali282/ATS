using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.ShipCabinTypes
{
    public class ShipCabinTypeUpdateDto
    {
        [Required]
        public Guid Ship { get; set; }
        [Required]
        public int SortOrder { get; set; }
        public Guid CabinCategory { get; set; }
        public Guid Deck { get; set; }
        public Guid DeckLocation { get; set; }
        public Guid? DeckPosition { get; set; }
    }
}