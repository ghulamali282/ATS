using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.DepartureSeasons
{
    public interface IDepartureSeasonsAppService : IApplicationService
    {
        Task<PagedResultDto<DepartureSeasonWithNavigationPropertiesDto>> GetListAsync(GetDepartureSeasonsInput input);

        Task<DepartureSeasonWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<DepartureSeasonDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<DepartureSeasonDto> CreateAsync(DepartureSeasonCreateDto input);

        Task<DepartureSeasonDto> UpdateAsync(Guid id, DepartureSeasonUpdateDto input);
    }
}