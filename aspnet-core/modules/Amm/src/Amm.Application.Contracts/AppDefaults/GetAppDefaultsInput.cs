using Volo.Abp.Application.Dtos;
using System;

namespace Amm.AppDefaults
{
    public class GetAppDefaultsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string SettingsName { get; set; }
        public string SettingsValue { get; set; }

        public GetAppDefaultsInput()
        {

        }
    }
}