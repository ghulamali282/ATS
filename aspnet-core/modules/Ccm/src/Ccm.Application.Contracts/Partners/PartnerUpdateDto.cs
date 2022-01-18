using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Partners
{
    public class PartnerUpdateDto
    {
        [Required]
        [StringLength(PartnerConsts.PartnerNameMaxLength)]
        public string PartnerName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [StringLength(PartnerConsts.TaxNoMaxLength)]
        public string TaxNo { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(PartnerConsts.BookingEmailMaxLength)]
        public string BookingEmail { get; set; }
        [Required]
        [StringLength(PartnerConsts.BookingCellPhoneMaxLength)]
        public string BookingCellPhone { get; set; }
        public bool BookingEmailConfirmed { get; set; }
        public bool BookingPhoneConfirmed { get; set; }
        [EmailAddress]
        [StringLength(PartnerConsts.EmailMaxLength)]
        public string Email { get; set; }
        [StringLength(PartnerConsts.PhoneMaxLength)]
        public string Phone { get; set; }
        public string CountryName { get; set; }
    }
}