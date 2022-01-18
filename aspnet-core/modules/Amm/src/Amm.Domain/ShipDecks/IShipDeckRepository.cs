using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Amm.ShipDecks
{
    public interface IShipDeckRepository : IRepository<ShipDeck, Guid>
    {
        Task<ShipDeckWithNavigationProperties> GetWithNavigationPropertiesAsync(
    Guid id,
    CancellationToken cancellationToken = default
);

        Task<List<ShipDeckWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string filterText = null,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            Guid? deck = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<ShipDeck>> GetListAsync(
                    string filterText = null,
                    string shipDeckNameTEMP = null,
                    int? sortOrderMin = null,
                    int? sortOrderMax = null,
                    string ship = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string shipDeckNameTEMP = null,
            int? sortOrderMin = null,
            int? sortOrderMax = null,
            string ship = null,
            Guid? deck = null,
            CancellationToken cancellationToken = default);
    }
}