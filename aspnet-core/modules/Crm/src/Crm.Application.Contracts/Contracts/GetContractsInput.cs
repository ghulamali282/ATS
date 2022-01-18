using Volo.Abp.Application.Dtos;
using System;

namespace Crm.Contracts
{
    public class GetContractsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? OperatorName { get; set; }
        public int? SeasonMin { get; set; }
        public int? SeasonMax { get; set; }
        public bool? IsEnabledAgent { get; set; }
        public bool? IsEnabledOperator { get; set; }

        public GetContractsInput()
        {

        }
    }
}