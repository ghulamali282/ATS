using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.ShpCabins
{
    public interface IShpCabinsAppService : IApplicationService
    {
        Task<PagedResultDto<ShpCabinDto>> GetListAsync(GetShpCabinsInput input);

        Task<ShpCabinDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShpCabinDto> CreateAsync(ShpCabinCreateDto input);

        Task<ShpCabinDto> UpdateAsync(Guid id, ShpCabinUpdateDto input);
    }
}