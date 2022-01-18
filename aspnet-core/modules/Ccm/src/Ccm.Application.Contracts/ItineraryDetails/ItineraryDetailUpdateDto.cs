using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.ItineraryDetails
{
    public class ItineraryDetailUpdateDto
    {
        [Required]
        public Guid Itinerary { get; set; }
        [Required]
        public Guid Name { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        [StringLength(ItineraryDetailConsts.PortsMaxLength)]
        public string Ports { get; set; }
        [StringLength(ItineraryDetailConsts.AlternativePortsMaxLength)]
        public string AlternativePorts { get; set; }
        [Required]
        public bool WelcomeDrink { get; set; }
        [Required]
        public bool WelcomeSnack { get; set; }
        [Required]
        public bool Breakfast { get; set; }
        [Required]
        public bool Brunch { get; set; }
        [Required]
        public bool Lunch { get; set; }
        [Required]
        public bool AfternoonSnack { get; set; }
        [Required]
        public bool Dinner { get; set; }
        [Required]
        public bool CaptainDinner { get; set; }
        [Required]
        public bool LiveMusic { get; set; }
        [Required]
        public bool WineTasting { get; set; }
        [Required]
        public bool OvernightOnAnchor { get; set; }
        [Required]
        public bool OvernightAtMarina { get; set; }
    }
}