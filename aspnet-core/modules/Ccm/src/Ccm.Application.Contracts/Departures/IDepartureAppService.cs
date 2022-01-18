using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Departures
{
    public interface IDeparturesAppService : IApplicationService
    {
        Task<PagedResultDto<DepartureWithNavigationPropertiesDto>> GetListAsync(GetDeparturesInput input);

        Task<DepartureWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<DepartureDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetDepartureSeasonLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<DepartureDto> CreateAsync(DepartureCreateDto input);

        Task<DepartureDto> UpdateAsync(Guid id, DepartureUpdateDto input);
    }
}