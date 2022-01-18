using System;
using Volo.Abp.Application.Dtos;

namespace Crm.Contracts
{
    public class ContractDto : EntityDto<Guid>
    {
        public Guid OperatorName { get; set; }
        public int Season { get; set; }
        public bool IsEnabledAgent { get; set; }
        public bool IsEnabledOperator { get; set; }
    }
}