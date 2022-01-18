using Ccm.Countries;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Partners
{
    public class Partner : AuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string PartnerName { get; set; }

        [NotNull]
        public virtual string Address { get; set; }

        [NotNull]
        public virtual string TaxNo { get; set; }

        [NotNull]
        public virtual string BookingEmail { get; set; }

        [NotNull]
        public virtual string BookingCellPhone { get; set; }

        public virtual bool BookingEmailConfirmed { get; set; }

        public virtual bool BookingPhoneConfirmed { get; set; }

        [CanBeNull]
        public virtual string Email { get; set; }

        [CanBeNull]
        public virtual string Phone { get; set; }
        public string CountryName { get; set; }

        public Partner()
        {

        }

        public Partner(Guid id, string partnerName, string countryName, string address, string bookingEmail, string bookingCellPhone, bool bookingEmailConfirmed, bool bookingPhoneConfirmed, string taxNo = null, string email = null, string phone = null)
        {
            Id = id;
            Check.NotNull(partnerName, nameof(partnerName));
            Check.Length(partnerName, nameof(partnerName), PartnerConsts.PartnerNameMaxLength, 0);
            Check.NotNull(address, nameof(address));
            Check.NotNull(bookingEmail, nameof(bookingEmail));
            Check.Length(bookingEmail, nameof(bookingEmail), PartnerConsts.BookingEmailMaxLength, 0);
            Check.NotNull(bookingCellPhone, nameof(bookingCellPhone));
            Check.Length(bookingCellPhone, nameof(bookingCellPhone), PartnerConsts.BookingCellPhoneMaxLength, 0);
            Check.NotNull(taxNo, nameof(taxNo));
            Check.Length(taxNo, nameof(taxNo), PartnerConsts.TaxNoMaxLength, 0);
            Check.Length(email, nameof(email), PartnerConsts.EmailMaxLength, 0);
            Check.Length(phone, nameof(phone), PartnerConsts.PhoneMaxLength, 0);
            PartnerName = partnerName;
            Address = address;
            BookingEmail = bookingEmail;
            BookingCellPhone = bookingCellPhone;
            BookingEmailConfirmed = bookingEmailConfirmed;
            BookingPhoneConfirmed = bookingPhoneConfirmed;
            TaxNo = taxNo;
            Email = email;
            Phone = phone;
            CountryName = countryName;
        }
    }
}