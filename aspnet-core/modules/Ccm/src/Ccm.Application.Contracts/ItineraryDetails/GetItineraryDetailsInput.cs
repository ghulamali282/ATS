using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.ItineraryDetails
{
    public class GetItineraryDetailsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? Itinerary { get; set; }
        public Guid? Name { get; set; }
        public int? DayMin { get; set; }
        public int? DayMax { get; set; }
        public string Ports { get; set; }
        public string AlternativePorts { get; set; }
        public bool? WelcomeDrink { get; set; }
        public bool? WelcomeSnack { get; set; }
        public bool? Breakfast { get; set; }
        public bool? Brunch { get; set; }
        public bool? Lunch { get; set; }
        public bool? AfternoonSnack { get; set; }
        public bool? Dinner { get; set; }
        public bool? CaptainDinner { get; set; }
        public bool? LiveMusic { get; set; }
        public bool? WineTasting { get; set; }
        public bool? OvernightOnAnchor { get; set; }
        public bool? OvernightAtMarina { get; set; }

        public GetItineraryDetailsInput()
        {

        }
    }
}