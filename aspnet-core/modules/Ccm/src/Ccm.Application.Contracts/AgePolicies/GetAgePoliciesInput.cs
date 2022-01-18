using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.AgePolicies
{
    public class GetAgePoliciesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string DemoField { get; set; }
        public Guid? Name { get; set; }
        public Guid? OperatorName { get; set; }

        public GetAgePoliciesInput()
        {

        }
    }
}