using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.ShipDecks
{
    public interface IShipDecksAppService : IApplicationService
    {
        Task<PagedResultDto<ShipDeckWithNavigationPropertiesDto>> GetListAsync(GetShipDecksInput input);

        Task<ShipDeckWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ShipDeckDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ShipDeckDto> CreateAsync(ShipDeckCreateDto input);

        Task<ShipDeckDto> UpdateAsync(Guid id, ShipDeckUpdateDto input);
    }
}