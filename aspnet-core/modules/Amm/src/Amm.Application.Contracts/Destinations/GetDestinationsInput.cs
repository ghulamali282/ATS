using Volo.Abp.Application.Dtos;
using System;

namespace Amm.Destinations
{
    public class GetDestinationsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string City { get; set; }
        public string CityLocalName { get; set; }
        public double? latitudeMin { get; set; }
        public double? latitudeMax { get; set; }
        public double? longitudeMin { get; set; }
        public double? longitudeMax { get; set; }
        public string VideoUrl { get; set; }
        public string PlaceId { get; set; }
        public string DestCountry { get; set; }

        public GetDestinationsInput()
        {

        }
    }
}