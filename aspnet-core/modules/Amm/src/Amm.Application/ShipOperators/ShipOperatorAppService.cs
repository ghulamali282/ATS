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
using Amm.ShipOperators;

namespace Amm.ShipOperators
{

    [Authorize(AmmPermissions.ShipOperators.Default)]
    public class ShipOperatorsAppService : ApplicationService, IShipOperatorsAppService
    {
        private readonly IShipOperatorRepository _shipOperatorRepository;

        public ShipOperatorsAppService(IShipOperatorRepository shipOperatorRepository)
        {
            _shipOperatorRepository = shipOperatorRepository;
        }

        public virtual async Task<PagedResultDto<ShipOperatorDto>> GetListAsync(GetShipOperatorsInput input)
        {
            var totalCount = await _shipOperatorRepository.GetCountAsync(input.FilterText, input.OperatorName);
            var items = await _shipOperatorRepository.GetListAsync(input.FilterText, input.OperatorName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShipOperatorDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipOperator>, List<ShipOperatorDto>>(items)
            };
        }

        public virtual async Task<ShipOperatorDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShipOperator, ShipOperatorDto>(await _shipOperatorRepository.GetAsync(id));
        }

        [Authorize(AmmPermissions.ShipOperators.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shipOperatorRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.ShipOperators.Create)]
        public virtual async Task<ShipOperatorDto> CreateAsync(ShipOperatorCreateDto input)
        {

            var shipOperator = ObjectMapper.Map<ShipOperatorCreateDto, ShipOperator>(input);

            shipOperator = await _shipOperatorRepository.InsertAsync(shipOperator, autoSave: true);
            return ObjectMapper.Map<ShipOperator, ShipOperatorDto>(shipOperator);
        }

        [Authorize(AmmPermissions.ShipOperators.Edit)]
        public virtual async Task<ShipOperatorDto> UpdateAsync(Guid id, ShipOperatorUpdateDto input)
        {

            var shipOperator = await _shipOperatorRepository.GetAsync(id);
            ObjectMapper.Map(input, shipOperator);
            shipOperator = await _shipOperatorRepository.UpdateAsync(shipOperator, autoSave: true);
            return ObjectMapper.Map<ShipOperator, ShipOperatorDto>(shipOperator);
        }
    }
}