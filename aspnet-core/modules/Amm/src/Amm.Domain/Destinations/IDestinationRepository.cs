using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.Destinations
{
    public interface IDestinationRepository : IRepository<Destination, Guid>
    {
        Task<DestinationWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<DestinationWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string destCountry = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Destination>> GetListAsync(
                    string filterText = null,
                    string city = null,
                    string cityLocalName = null,
                    double? latitudeMin = null,
                    double? latitudeMax = null,
                    double? longitudeMin = null,
                    double? longitudeMax = null,
                    string videoUrl = null,
                    string placeId = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string city = null,
            string cityLocalName = null,
            double? latitudeMin = null,
            double? latitudeMax = null,
            double? longitudeMin = null,
            double? longitudeMax = null,
            string videoUrl = null,
            string placeId = null,
            string destCountry = null,
            CancellationToken cancellationToken = default);
    }
}