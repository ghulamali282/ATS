using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.ItineraryDetails
{
    public interface IItineraryDetailsAppService : IApplicationService
    {
        Task<PagedResultDto<ItineraryDetailDto>> GetListAsync(GetItineraryDetailsInput input);

        Task<ItineraryDetailDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ItineraryDetailDto> CreateAsync(ItineraryDetailCreateDto input);

        Task<ItineraryDetailDto> UpdateAsync(Guid id, ItineraryDetailUpdateDto input);
    }
}