using Amm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Amm.BookingStatuses
{
    public interface IBookingStatusesAppService : IApplicationService
    {
        Task<PagedResultDto<BookingStatusWithNavigationPropertiesDto>> GetListAsync(GetBookingStatusesInput input);

        Task<BookingStatusWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id);

        Task<BookingStatusDto> GetAsync(int id);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task DeleteAsync(int id);

        Task<BookingStatusDto> CreateAsync(BookingStatusCreateDto input);

        Task<BookingStatusDto> UpdateAsync(int id, BookingStatusUpdateDto input);
    }
}