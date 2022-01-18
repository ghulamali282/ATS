using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Destinations
{
    public class GetDestinationsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string City { get; set; }

        public GetDestinationsInput()
        {

        }
    }
}