using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.AgePolicyDetails
{
    public class GetAgePolicyDetailsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public int? AgeFromMin { get; set; }
        public int? AgeFromMax { get; set; }
        public Guid? AgePolicy { get; set; }
        public int? AgeToMin { get; set; }
        public int? AgeToMax { get; set; }
        public Guid? Service { get; set; }

        public GetAgePolicyDetailsInput()
        {

        }
    }
}