using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.Marinas
{
    public interface IMarinasAppService : IApplicationService
    {
        Task<PagedResultDto<MarinaWithNavigationPropertiesDto>> GetListAsync(GetMarinasInput input);

        Task<MarinaWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<MarinaDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<MarinaDto> CreateAsync(MarinaCreateDto input);

        Task<MarinaDto> UpdateAsync(Guid id, MarinaUpdateDto input);
    }
}