using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.CharterShips
{
    public interface ICharterShipsAppService : IApplicationService
    {
        Task<PagedResultDto<CharterShipDto>> GetListAsync(GetCharterShipsInput input);

        Task<CharterShipDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CharterShipDto> CreateAsync(CharterShipCreateDto input);

        Task<CharterShipDto> UpdateAsync(Guid id, CharterShipUpdateDto input);
    }
}