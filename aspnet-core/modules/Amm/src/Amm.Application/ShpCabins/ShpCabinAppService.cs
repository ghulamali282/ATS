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
using Amm.ShpCabins;

namespace Amm.ShpCabins
{

    [Authorize(AmmPermissions.ShpCabins.Default)]
    public class ShpCabinsAppService : ApplicationService, IShpCabinsAppService
    {
        private readonly IShpCabinRepository _shpCabinRepository;

        public ShpCabinsAppService(IShpCabinRepository shpCabinRepository)
        {
            _shpCabinRepository = shpCabinRepository;
        }

        public virtual async Task<PagedResultDto<ShpCabinDto>> GetListAsync(GetShpCabinsInput input)
        {
            var totalCount = await _shpCabinRepository.GetCountAsync(input.FilterText, input.Ship, input.CabinCategory, input.CabinNo, input.CabinNoNumericMin, input.CabinNoNumericMax, input.BedLayout, input.StandardCapacityMin, input.StandardCapacityMax, input.MaxCapacityMin, input.MaxCapacityMax, input.Portohole, input.Window, input.CabinAreaMin, input.CabinAreaMax, input.Balcon, input.BalconAreaMin, input.BalconAreaMax, input.IsDisabled);
            var items = await _shpCabinRepository.GetListAsync(input.FilterText, input.Ship, input.CabinCategory, input.CabinNo, input.CabinNoNumericMin, input.CabinNoNumericMax, input.BedLayout, input.StandardCapacityMin, input.StandardCapacityMax, input.MaxCapacityMin, input.MaxCapacityMax, input.Portohole, input.Window, input.CabinAreaMin, input.CabinAreaMax, input.Balcon, input.BalconAreaMin, input.BalconAreaMax, input.IsDisabled, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShpCabinDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShpCabin>, List<ShpCabinDto>>(items)
            };
        }

        public virtual async Task<ShpCabinDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShpCabin, ShpCabinDto>(await _shpCabinRepository.GetAsync(id));
        }

        [Authorize(AmmPermissions.ShpCabins.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shpCabinRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.ShpCabins.Create)]
        public virtual async Task<ShpCabinDto> CreateAsync(ShpCabinCreateDto input)
        {

            var shpCabin = ObjectMapper.Map<ShpCabinCreateDto, ShpCabin>(input);

            shpCabin = await _shpCabinRepository.InsertAsync(shpCabin, autoSave: true);
            return ObjectMapper.Map<ShpCabin, ShpCabinDto>(shpCabin);
        }

        [Authorize(AmmPermissions.ShpCabins.Edit)]
        public virtual async Task<ShpCabinDto> UpdateAsync(Guid id, ShpCabinUpdateDto input)
        {

            var shpCabin = await _shpCabinRepository.GetAsync(id);
            ObjectMapper.Map(input, shpCabin);
            shpCabin = await _shpCabinRepository.UpdateAsync(shpCabin, autoSave: true);
            return ObjectMapper.Map<ShpCabin, ShpCabinDto>(shpCabin);
        }
    }
}