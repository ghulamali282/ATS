using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.ShipCabinTypes
{
    public interface IShipCabinTypeRepository : IRepository<ShipCabinType, Guid>
    {
        Task<ShipCabinTypeWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<ShipCabinTypeWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            Guid? cabinCategory = null,
            Guid? deck = null,
            Guid? deckLocation = null,
            Guid? deckPosition = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<ShipCabinType>> GetListAsync(
                    string filterText = null,
                    Guid? ship = null,
                    int? sortOrderMin = null,
                    int? sortOrderMax = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? ship = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            Guid? cabinCategory = null,
            Guid? deck = null,
            Guid? deckLocation = null,
            Guid? deckPosition = null,
            CancellationToken cancellationToken = default);
    }
}