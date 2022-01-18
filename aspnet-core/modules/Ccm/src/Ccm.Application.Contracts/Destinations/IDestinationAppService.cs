using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Destinations
{
    public interface IDestinationsAppService : IApplicationService
    {
        Task<PagedResultDto<DestinationDto>> GetListAsync(GetDestinationsInput input);

        Task<DestinationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<DestinationDto> CreateAsync(DestinationCreateDto input);

        Task<DestinationDto> UpdateAsync(Guid id, DestinationUpdateDto input);
    }
}