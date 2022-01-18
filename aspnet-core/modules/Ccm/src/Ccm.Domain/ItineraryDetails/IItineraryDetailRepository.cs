using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Ccm.ItineraryDetails
{
    public interface IItineraryDetailRepository : IRepository<ItineraryDetail, Guid>
    {
        Task<List<ItineraryDetail>> GetListAsync(
            string filterText = null,
            Guid? itinerary = null,
            Guid? name = null,
            int? dayMin = null,
            int? dayMax = null,
            string ports = null,
            string alternativePorts = null,
            bool? welcomeDrink = null,
            bool? welcomeSnack = null,
            bool? breakfast = null,
            bool? brunch = null,
            bool? lunch = null,
            bool? afternoonSnack = null,
            bool? dinner = null,
            bool? captainDinner = null,
            bool? liveMusic = null,
            bool? wineTasting = null,
            bool? overnightOnAnchor = null,
            bool? overnightAtMarina = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? itinerary = null,
            Guid? name = null,
            int? dayMin = null,
            int? dayMax = null,
            string ports = null,
            string alternativePorts = null,
            bool? welcomeDrink = null,
            bool? welcomeSnack = null,
            bool? breakfast = null,
            bool? brunch = null,
            bool? lunch = null,
            bool? afternoonSnack = null,
            bool? dinner = null,
            bool? captainDinner = null,
            bool? liveMusic = null,
            bool? wineTasting = null,
            bool? overnightOnAnchor = null,
            bool? overnightAtMarina = null,
            CancellationToken cancellationToken = default);
    }
}