using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.CancellationPolicies
{
    public class GetCancellationPoliciesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string NameString { get; set; }
        public Guid? OperatorName { get; set; }
        public Guid? PolicyName { get; set; }

        public GetCancellationPoliciesInput()
        {

        }
    }
}