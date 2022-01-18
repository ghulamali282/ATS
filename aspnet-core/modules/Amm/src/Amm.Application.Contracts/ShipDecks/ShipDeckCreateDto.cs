using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.ShipDecks
{
    public class ShipDeckCreateDto
    {
        [Required]
        public string ShipDeckNameTEMP { get; set; }
        [Required]
        public int SortOrder { get; set; }
        [Required]
        public string Ship { get; set; }
        public Guid Deck { get; set; }
    }
}