using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.ShipCabinTypes
{
    public interface IShipCabinTypesAppService : IApplicationService
    {
        Task<PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>> GetListAsync(GetShipCabinTypesInput input);

        Task<ShipCabinTypeWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ShipCabinTypeDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetShipDeckLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ShipCabinTypeDto> CreateAsync(ShipCabinTypeCreateDto input);

        Task<ShipCabinTypeDto> UpdateAsync(Guid id, ShipCabinTypeUpdateDto input);
    }
}