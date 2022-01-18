using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Ships
{
    public interface IShipsAppService : IApplicationService
    {
        Task<PagedResultDto<ShipDto>> GetListAsync(GetShipsInput input);

        Task<ShipDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShipDto> CreateAsync(ShipCreateDto input);

        Task<ShipDto> UpdateAsync(Guid id, ShipUpdateDto input);
    }
}