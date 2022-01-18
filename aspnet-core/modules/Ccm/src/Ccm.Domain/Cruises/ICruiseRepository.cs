using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.Cruises
{
    public interface ICruiseRepository : IRepository<Cruise, Guid>
    {
        Task<CruiseWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<CruiseWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Cruise>> GetListAsync(
                    string filterText = null,
                    int? seasonMin = null,
                    int? seasonMax = null,
                    bool? cruiseEnabled = null,
                    bool? featured = null,
                    bool? freeInternetOnBoard = null,
                    bool? internetOnBoard = null,
                    string video = null,
                    bool? b2B = null,
                    bool? b2C = null,
                    bool? b2B_Agent = null,
                    bool? b2C_Agent = null,
                    Guid? cruiseDescriptions = null,
                    Guid? shipAmenities = null,
                    Guid? shipArticles = null,
                    Guid? shipPhotos = null,
                    Guid? cabinAmenities = null,
                    Guid? cabinArticles = null,
                    Guid? cabinPhotos = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            int? seasonMin = null,
            int? seasonMax = null,
            bool? cruiseEnabled = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internetOnBoard = null,
            string video = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? cruiseDescriptions = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            Guid? ship = null,
            Guid? itinerary = null,
            CancellationToken cancellationToken = default);
    }
}