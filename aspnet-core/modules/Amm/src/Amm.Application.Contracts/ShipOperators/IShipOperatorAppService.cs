using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.ShipOperators
{
    public interface IShipOperatorsAppService : IApplicationService
    {
        Task<PagedResultDto<ShipOperatorDto>> GetListAsync(GetShipOperatorsInput input);

        Task<ShipOperatorDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShipOperatorDto> CreateAsync(ShipOperatorCreateDto input);

        Task<ShipOperatorDto> UpdateAsync(Guid id, ShipOperatorUpdateDto input);
    }
}