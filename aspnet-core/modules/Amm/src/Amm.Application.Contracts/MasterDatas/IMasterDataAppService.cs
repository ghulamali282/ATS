using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.MasterDatas
{
    public interface IMasterDatasAppService : IApplicationService
    {
        Task<PagedResultDto<MasterDataDto>> GetListAsync(GetMasterDatasInput input);

        Task<MasterDataDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MasterDataDto> CreateAsync(MasterDataCreateDto input);

        Task<MasterDataDto> UpdateAsync(Guid id, MasterDataUpdateDto input);
    }
}