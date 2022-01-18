using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Countries
{
    public class GetCountriesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string CountryName { get; set; }
        public string CultureName { get; set; }

        public GetCountriesInput()
        {

        }
    }
}