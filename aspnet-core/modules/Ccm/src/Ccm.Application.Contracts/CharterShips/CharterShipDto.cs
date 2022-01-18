using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.CharterShips
{
    public class CharterShipDto : EntityDto<Guid>
    {
        public Guid OperatorName { get; set; }
        public int Season { get; set; }
        public Guid? ShipNamePrefix { get; set; }
        public Guid Ship { get; set; }
        public Guid Itinerary { get; set; }
        public string Tabs { get; set; }
        public string Video { get; set; }
        public bool Featured { get; set; }
        public bool FreeInternetOnBoard { get; set; }
        public bool Internet { get; set; }
        public bool TransferIncluded { get; set; }
        public bool EnabledByUser { get; set; }
        public int? DisabledBySystem { get; set; }
        public bool B2B { get; set; }
        public bool B2C { get; set; }
        public bool B2B_Agent { get; set; }
        public bool B2C_Agent { get; set; }
        public Guid? ShipAmenities { get; set; }
        public Guid? ShipArticles { get; set; }
        public Guid? ShipPhotos { get; set; }
        public Guid? CabinAmenities { get; set; }
        public Guid? CabinArticles { get; set; }
        public Guid? CabinPhotos { get; set; }
    }
}