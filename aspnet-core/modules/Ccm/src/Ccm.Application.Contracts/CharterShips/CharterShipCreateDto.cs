using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.CharterShips
{
    public class CharterShipCreateDto
    {
        [Required]
        public Guid OperatorName { get; set; }
        [Required]
        public int Season { get; set; }
        public Guid? ShipNamePrefix { get; set; }
        [Required]
        public Guid Ship { get; set; }
        [Required]
        public Guid Itinerary { get; set; }
        [Required]
        [StringLength(CharterShipConsts.TabsMaxLength)]
        public string Tabs { get; set; }
        [StringLength(CharterShipConsts.VideoMaxLength)]
        public string Video { get; set; }
        [Required]
        public bool Featured { get; set; }
        [Required]
        public bool FreeInternetOnBoard { get; set; }
        [Required]
        public bool Internet { get; set; }
        [Required]
        public bool TransferIncluded { get; set; }
        [Required]
        public bool EnabledByUser { get; set; }
        public int? DisabledBySystem { get; set; }
        [Required]
        public bool B2B { get; set; }
        [Required]
        public bool B2C { get; set; }
        [Required]
        public bool B2B_Agent { get; set; }
        [Required]
        public bool B2C_Agent { get; set; }
        public Guid? ShipAmenities { get; set; }
        public Guid? ShipArticles { get; set; }
        public Guid? ShipPhotos { get; set; }
        public Guid? CabinAmenities { get; set; }
        public Guid? CabinArticles { get; set; }
        public Guid? CabinPhotos { get; set; }
    }
}