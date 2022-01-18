using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.Ships
{
    public interface IShipsAppService : IApplicationService
    {
        Task<PagedResultDto<ShipWithNavigationPropertiesDto>> GetListAsync(GetShipsInput input);

        Task<ShipWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ShipDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid?>>> GetShipOperatorLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ShipDto> CreateAsync(ShipCreateDto input);

        Task<ShipDto> UpdateAsync(Guid id, ShipUpdateDto input);
    }
}