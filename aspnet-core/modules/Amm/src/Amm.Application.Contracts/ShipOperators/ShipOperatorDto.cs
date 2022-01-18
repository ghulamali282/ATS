using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShipOperators
{
    public class ShipOperatorDto : EntityDto<Guid>
    {
        public string OperatorName { get; set; }
    }
}