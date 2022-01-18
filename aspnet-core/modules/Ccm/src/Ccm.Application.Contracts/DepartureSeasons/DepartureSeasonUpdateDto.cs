using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.DepartureSeasons
{
    public class DepartureSeasonUpdateDto
    {
        [Required]
        public int Season { get; set; }
        [Required]
        public string SeasonName { get; set; }
        public Guid Partner { get; set; }
    }
}