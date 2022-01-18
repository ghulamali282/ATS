using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Countries
{
    public class CountryDto : EntityDto<string>
    {
        public string CountryName { get; set; }
        public string CultureName { get; set; }
    }
}