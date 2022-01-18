using Amm.Shared;
using Amm.MasterDatas;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Amm.Permissions;
using Amm.BookingStatuses;

namespace Amm.BookingStatuses
{

    [Authorize(AmmPermissions.BookingStatuses.Default)]
    public class BookingStatusesAppService : ApplicationService, IBookingStatusesAppService
    {
        private readonly IBookingStatusRepository _bookingStatusRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public BookingStatusesAppService(IBookingStatusRepository bookingStatusRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _bookingStatusRepository = bookingStatusRepository; _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<BookingStatusWithNavigationPropertiesDto>> GetListAsync(GetBookingStatusesInput input)
        {
            var totalCount = await _bookingStatusRepository.GetCountAsync(input.FilterText, input.StatusColor, input.BookingStatusName);
            var items = await _bookingStatusRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.StatusColor, input.BookingStatusName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BookingStatusWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<BookingStatusWithNavigationProperties>, List<BookingStatusWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<BookingStatusWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return ObjectMapper.Map<BookingStatusWithNavigationProperties, BookingStatusWithNavigationPropertiesDto>
                (await _bookingStatusRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<BookingStatusDto> GetAsync(int id)
        {
            return ObjectMapper.Map<BookingStatus, BookingStatusDto>(await _bookingStatusRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            var query = (await _masterDataRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<MasterData>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterData>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.BookingStatuses.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _bookingStatusRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.BookingStatuses.Create)]
        public virtual async Task<BookingStatusDto> CreateAsync(BookingStatusCreateDto input)
        {
            if (input.BookingStatusName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var bookingStatus = ObjectMapper.Map<BookingStatusCreateDto, BookingStatus>(input);

            bookingStatus = await _bookingStatusRepository.InsertAsync(bookingStatus, autoSave: true);
            return ObjectMapper.Map<BookingStatus, BookingStatusDto>(bookingStatus);
        }

        [Authorize(AmmPermissions.BookingStatuses.Edit)]
        public virtual async Task<BookingStatusDto> UpdateAsync(int id, BookingStatusUpdateDto input)
        {
            if (input.BookingStatusName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var bookingStatus = await _bookingStatusRepository.GetAsync(id);
            ObjectMapper.Map(input, bookingStatus);
            bookingStatus = await _bookingStatusRepository.UpdateAsync(bookingStatus, autoSave: true);
            return ObjectMapper.Map<BookingStatus, BookingStatusDto>(bookingStatus);
        }
    }
}