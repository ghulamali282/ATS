using Volo.Abp.Application.Dtos;
using System;

namespace Amm.MasterDatas
{
    public class GetMasterDatasInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public int? SortOrderMin { get; set; }
        public int? SortOrderMax { get; set; }

        public GetMasterDatasInput()
        {

        }
    }
}