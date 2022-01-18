using Volo.Abp.Application.Dtos;
using System;

namespace Amm.Partners
{
    public class GetPartnersInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string PartnerName { get; set; }

        public GetPartnersInput()
        {

        }
    }
}