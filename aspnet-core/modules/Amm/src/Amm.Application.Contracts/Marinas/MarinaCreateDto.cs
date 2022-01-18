using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.Marinas
{
    public class MarinaCreateDto
    {
        [StringLength(MarinaConsts.MarinaNameStringMaxLength)]
        public string MarinaNameString { get; set; }
        [Required]
        [StringLength(MarinaConsts.LatitudeMaxLength)]
        public string Latitude { get; set; }
        [Required]
        [StringLength(MarinaConsts.LongitudeMaxLength)]
        public string Longitude { get; set; }
        public Guid MarinaName { get; set; }
        public Guid Destination { get; set; }
    }
}