using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.Partners
{
    public interface IPartnersAppService : IApplicationService
    {
        Task<PagedResultDto<PartnerDto>> GetListAsync(GetPartnersInput input);

        Task<PartnerDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<PartnerDto> CreateAsync(PartnerCreateDto input);

        Task<PartnerDto> UpdateAsync(Guid id, PartnerUpdateDto input);
    }
}