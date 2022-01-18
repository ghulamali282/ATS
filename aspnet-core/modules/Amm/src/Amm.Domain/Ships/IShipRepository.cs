using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.Ships
{
    public interface IShipRepository : IRepository<Ship, Guid>
    {
        Task<ShipWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<ShipWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            Guid? homePort = null,
            string flag = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<Ship>> GetListAsync(
                    string filterText = null,
                    string shipName = null,
                    int? yearBuildMin = null,
                    int? yearBuildMax = null,
                    int? yearRefurbishedMin = null,
                    int? yearRefurbishedMax = null,
                    bool? ensuitedCabins = null,
                    int? sharedToiletsMin = null,
                    int? sharedToiletsMax = null,
                    int? sharedShowersMin = null,
                    int? sharedShowersMax = null,
                    int? crewNoMin = null,
                    int? crewNoMax = null,
                    int? lenghtMin = null,
                    int? lenghtMax = null,
                    int? beamMin = null,
                    int? beamMax = null,
                    int? draftMin = null,
                    int? draftMax = null,
                    int? cruiseSpeedMin = null,
                    int? cruiseSpeedMax = null,
                    int? maxSpeedMin = null,
                    int? maxSpeedMax = null,
                    string videoUrl = null,
                    bool? useCabinDeckPosition = null,
                    bool? useDeckLocation = null,
                    bool? shipEnabled = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string shipName = null,
            int? yearBuildMin = null,
            int? yearBuildMax = null,
            int? yearRefurbishedMin = null,
            int? yearRefurbishedMax = null,
            bool? ensuitedCabins = null,
            int? sharedToiletsMin = null,
            int? sharedToiletsMax = null,
            int? sharedShowersMin = null,
            int? sharedShowersMax = null,
            int? crewNoMin = null,
            int? crewNoMax = null,
            int? lenghtMin = null,
            int? lenghtMax = null,
            int? beamMin = null,
            int? beamMax = null,
            int? draftMin = null,
            int? draftMax = null,
            int? cruiseSpeedMin = null,
            int? cruiseSpeedMax = null,
            int? maxSpeedMin = null,
            int? maxSpeedMax = null,
            string videoUrl = null,
            bool? useCabinDeckPosition = null,
            bool? useDeckLocation = null,
            bool? shipEnabled = null,
            Guid? homePort = null,
            string flag = null,
            Guid? shipCategory = null,
            Guid? shipOperator = null,
            CancellationToken cancellationToken = default);
    }
}