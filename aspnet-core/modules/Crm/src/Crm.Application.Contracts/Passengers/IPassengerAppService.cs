using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.Passengers
{
    public interface IPassengersAppService : IApplicationService
    {
        Task<PagedResultDto<PassengerDto>> GetListAsync(GetPassengersInput input);

        Task<PassengerDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PassengerDto> CreateAsync(PassengerCreateDto input);

        Task<PassengerDto> UpdateAsync(Guid id, PassengerUpdateDto input);
    }
}