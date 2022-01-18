using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Partners
{
    public class PartnerDto : AuditedEntityDto<Guid>
    {
        public string PartnerName { get; set; }
        public string Address { get; set; }
        public string TaxNo { get; set; }
        public string BookingEmail { get; set; }
        public string BookingCellPhone { get; set; }
        public bool BookingEmailConfirmed { get; set; }
        public bool BookingPhoneConfirmed { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CountryName { get; set; }
    }
}