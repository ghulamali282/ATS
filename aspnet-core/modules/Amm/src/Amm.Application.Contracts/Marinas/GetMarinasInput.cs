using Volo.Abp.Application.Dtos;
using System;

namespace Amm.Marinas
{
    public class GetMarinasInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string MarinaNameString { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid? MarinaName { get; set; }
        public Guid? Destination { get; set; }

        public GetMarinasInput()
        {

        }
    }
}