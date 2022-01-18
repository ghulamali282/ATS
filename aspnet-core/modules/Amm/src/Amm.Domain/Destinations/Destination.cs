using Amm.Countries;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.Destinations
{
    public class Destination : Entity<Guid>
    {
        [NotNull]
        public virtual string City { get; set; }

        [NotNull]
        public virtual string CityLocalName { get; set; }

        public virtual double latitude { get; set; }

        public virtual double longitude { get; set; }

        [CanBeNull]
        public virtual string VideoUrl { get; set; }

        [NotNull]
        public virtual string PlaceId { get; set; }
        public string DestCountry { get; set; }

        public Destination()
        {

        }

        public Destination(Guid id, string city, string destCountry, string cityLocalName, double latitude, double longitude, string placeId, string videoUrl = null)
        {
            Id = id;
            Check.NotNull(city, nameof(city));
            Check.Length(city, nameof(city), DestinationConsts.CityMaxLength, 0);
            Check.NotNull(cityLocalName, nameof(cityLocalName));
            Check.Length(cityLocalName, nameof(cityLocalName), DestinationConsts.CityLocalNameMaxLength, 0);
            Check.NotNull(placeId, nameof(placeId));
            Check.Length(placeId, nameof(placeId), DestinationConsts.PlaceIdMaxLength, 0);
            Check.Length(videoUrl, nameof(videoUrl), DestinationConsts.VideoUrlMaxLength, 0);
            City = city;
            CityLocalName = cityLocalName;
            latitude = latitude;
            longitude = longitude;
            PlaceId = placeId;
            VideoUrl = videoUrl;
            DestCountry = destCountry;
        }
    }
}