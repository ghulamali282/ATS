using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.AppDefaults
{
    public interface IAppDefaultsAppService : IApplicationService
    {
        Task<PagedResultDto<AppDefaultDto>> GetListAsync(GetAppDefaultsInput input);

        Task<AppDefaultDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<AppDefaultDto> CreateAsync(AppDefaultCreateDto input);

        Task<AppDefaultDto> UpdateAsync(Guid id, AppDefaultUpdateDto input);
    }
}