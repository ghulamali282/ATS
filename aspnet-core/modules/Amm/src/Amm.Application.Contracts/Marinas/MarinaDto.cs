using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Marinas
{
    public class MarinaDto : EntityDto<Guid>
    {
        public string MarinaNameString { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Guid MarinaName { get; set; }
        public Guid Destination { get; set; }
    }
}