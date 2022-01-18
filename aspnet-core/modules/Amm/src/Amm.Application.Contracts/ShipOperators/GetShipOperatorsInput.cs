using Volo.Abp.Application.Dtos;
using System;

namespace Amm.ShipOperators
{
    public class GetShipOperatorsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string OperatorName { get; set; }

        public GetShipOperatorsInput()
        {

        }
    }
}