using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Departures
{
    public class DepartureCreateDto
    {
        [Required]
        public string DeparturesArray { get; set; }
        [Required]
        [StringLength(DepartureConsts.SeasonGroupMaxLength)]
        public string SeasonGroup { get; set; }
        public Guid Partner { get; set; }
        public Guid SeasonName { get; set; }
    }
}