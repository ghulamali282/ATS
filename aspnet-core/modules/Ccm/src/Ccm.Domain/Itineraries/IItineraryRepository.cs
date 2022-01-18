using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Itineraries
{
    public interface IItineraryRepository : IRepository<Itinerary, Guid>
    {
        Task<ItineraryWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<ItineraryWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            Guid? operatorName = null,
            Guid? themes = null,
            Guid? boarding = null,
            Guid? agePolicyId = null,
            Guid? embarcationPort = null,
            Guid? disembarkationPort = null,
            Guid? cancellationPolicy = null,
            Guid? paymentPolicy = null,
            Guid? itineraryName = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Itinerary>> GetListAsync(
                    string filterText = null,
                    string itineraryNameString = null,
                    string itineraryCode = null,
                    string googleMapLink = null,
                    int? durationMin = null,
                    int? durationMax = null,
                    bool? extendedItinerary = null,
                    Guid? marina = null,
                    string embarcationLatitude = null,
                    string embarcationLongitude = null,
                    string disembarkationLatitude = null,
                    string disembarkationLongitude = null,
                    string checkInTime = null,
                    string checkOutTime = null,
                    bool? transferIncluded = null,
                    string video = null,
                    int? requestDurationMin = null,
                    int? requestDurationMax = null,
                    int? optionDurationMin = null,
                    int? optionDurationMax = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string itineraryNameString = null,
            string itineraryCode = null,
            string googleMapLink = null,
            int? durationMin = null,
            int? durationMax = null,
            bool? extendedItinerary = null,
            Guid? marina = null,
            string embarcationLatitude = null,
            string embarcationLongitude = null,
            string disembarkationLatitude = null,
            string disembarkationLongitude = null,
            string checkInTime = null,
            string checkOutTime = null,
            bool? transferIncluded = null,
            string video = null,
            int? requestDurationMin = null,
            int? requestDurationMax = null,
            int? optionDurationMin = null,
            int? optionDurationMax = null,
            Guid? operatorName = null,
            Guid? themes = null,
            Guid? boarding = null,
            Guid? agePolicyId = null,
            Guid? embarcationPort = null,
            Guid? disembarkationPort = null,
            Guid? cancellationPolicy = null,
            Guid? paymentPolicy = null,
            Guid? itineraryName = null,
            CancellationToken cancellationToken = default);
    }
}