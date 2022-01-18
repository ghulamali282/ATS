using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.CharterShips
{
    public interface ICharterShipRepository : IRepository<CharterShip, Guid>
    {
        Task<List<CharterShip>> GetListAsync(
            string filterText = null,
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            Guid? shipNamePrefix = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string tabs = null,
            string video = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internet = null,
            bool? transferIncluded = null,
            bool? enabledByUser = null,
            int? disabledBySystemMin = null,
            int? disabledBySystemMax = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
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
            Guid? operatorName = null,
            int? seasonMin = null,
            int? seasonMax = null,
            Guid? shipNamePrefix = null,
            Guid? ship = null,
            Guid? itinerary = null,
            string tabs = null,
            string video = null,
            bool? featured = null,
            bool? freeInternetOnBoard = null,
            bool? internet = null,
            bool? transferIncluded = null,
            bool? enabledByUser = null,
            int? disabledBySystemMin = null,
            int? disabledBySystemMax = null,
            bool? b2B = null,
            bool? b2C = null,
            bool? b2B_Agent = null,
            bool? b2C_Agent = null,
            Guid? shipAmenities = null,
            Guid? shipArticles = null,
            Guid? shipPhotos = null,
            Guid? cabinAmenities = null,
            Guid? cabinArticles = null,
            Guid? cabinPhotos = null,
            CancellationToken cancellationToken = default);
    }
}