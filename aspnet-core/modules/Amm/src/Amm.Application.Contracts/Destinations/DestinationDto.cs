using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Destinations
{
    public class DestinationDto : EntityDto<Guid>
    {
        public string City { get; set; }
        public string CityLocalName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string VideoUrl { get; set; }
        public string PlaceId { get; set; }
        public string DestCountry { get; set; }
    }
}