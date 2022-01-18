using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Companies
{
    public class Company : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string LegalName { get; set; }

        [NotNull]
        public virtual string CompanyCode { get; set; }

        [NotNull]
        public virtual string Street { get; set; }

        [NotNull]
        public virtual string StreetNumber { get; set; }

        [NotNull]
        public virtual string ZipCode { get; set; }

        [NotNull]
        public virtual string City { get; set; }

        [CanBeNull]
        public virtual string StateRegion { get; set; }

        [NotNull]
        public virtual string Country { get; set; }

        public virtual bool? InEU { get; set; }

        [NotNull]
        public virtual string TaxNo { get; set; }

        [CanBeNull]
        public virtual string TravelAgencyCode { get; set; }

        [CanBeNull]
        public virtual string InvoicePrefix { get; set; }

        [CanBeNull]
        public virtual string InvoiceLegal1 { get; set; }

        [CanBeNull]
        public virtual string InvoiceLegal2 { get; set; }

        [CanBeNull]
        public virtual string PaymentInfo { get; set; }

        [CanBeNull]
        public virtual string WebSite { get; set; }

        [NotNull]
        public virtual string CompanyEmail { get; set; }

        [CanBeNull]
        public virtual string Telephone { get; set; }

        [CanBeNull]
        public virtual string Fax { get; set; }

        [CanBeNull]
        public virtual string FacebookPage { get; set; }

        [CanBeNull]
        public virtual string TwiterPage { get; set; }

        [CanBeNull]
        public virtual string Instagram { get; set; }

        [CanBeNull]
        public virtual string CeoName { get; set; }

        [CanBeNull]
        public virtual string CeoEmail { get; set; }

        [NotNull]
        public virtual string BookingEmail { get; set; }

        public virtual bool BookingEmailConfirmed { get; set; }

        [NotNull]
        public virtual string BookingCellPhone { get; set; }

        public virtual bool BookingPhoneConfirmed { get; set; }

        public virtual int? WorkingYear { get; set; }

        [CanBeNull]
        public virtual string TenantCurrency { get; set; }

        public virtual int? RoundingAfterExchange { get; set; }

        public virtual decimal DefaultCruiseDeposit { get; set; }

        public virtual decimal DefaultCharterDeposit { get; set; }

        [NotNull]
        public virtual string DefaultCruiseDepositType { get; set; }

        [NotNull]
        public virtual string DefautCharterDepositType { get; set; }

        public virtual int RequestDurationCruise { get; set; }

        public virtual int RequestDurationCharter { get; set; }

        public virtual int? OptionDurationCruise { get; set; }

        public virtual int OptionDurationCharter { get; set; }

        public virtual int? CruiseFinalPaymentDueDays { get; set; }

        public virtual int CharterFinalPaymentDueDays { get; set; }

        public virtual int CruiseFullPaymentRequiredDays { get; set; }

        public virtual int? CharterFullPaymentRequiredDays { get; set; }

        public Company()
        {

        }

        public Company(Guid id, string country, string bookingEmail, bool bookingEmailConfirmed, string bookingCellPhone, bool bookingPhoneConfirmed, decimal defaultCruiseDeposit, decimal defaultCharterDeposit, string defaultCruiseDepositType, string defautCharterDepositType, int requestDurationCruise, int requestDurationCharter, int optionDurationCharter, int charterFinalPaymentDueDays, int cruiseFullPaymentRequiredDays, string legalName = null, string companyCode = null, string street = null, string streetNumber = null, string zipCode = null, string city = null, string stateRegion = null, bool? inEU = null, string taxNo = null, string travelAgencyCode = null, string invoicePrefix = null, string invoiceLegal1 = null, string invoiceLegal2 = null, string paymentInfo = null, string webSite = null, string companyEmail = null, string telephone = null, string fax = null, string facebookPage = null, string twiterPage = null, string instagram = null, string ceoName = null, string ceoEmail = null, int? workingYear = null, string tenantCurrency = null, int? roundingAfterExchange = null, int? optionDurationCruise = null, int? cruiseFinalPaymentDueDays = null, int? charterFullPaymentRequiredDays = null)
        {
            Id = id;
            Check.NotNull(country, nameof(country));
            Check.Length(country, nameof(country), CompanyConsts.CountryMaxLength, 0);
            Check.NotNull(bookingEmail, nameof(bookingEmail));
            Check.NotNull(bookingCellPhone, nameof(bookingCellPhone));
            Check.NotNull(defaultCruiseDepositType, nameof(defaultCruiseDepositType));
            Check.Length(defaultCruiseDepositType, nameof(defaultCruiseDepositType), CompanyConsts.DefaultCruiseDepositTypeMaxLength, 0);
            Check.NotNull(defautCharterDepositType, nameof(defautCharterDepositType));
            Check.Length(defautCharterDepositType, nameof(defautCharterDepositType), CompanyConsts.DefautCharterDepositTypeMaxLength, 0);
            Check.NotNull(legalName, nameof(legalName));
            Check.Length(legalName, nameof(legalName), CompanyConsts.LegalNameMaxLength, 0);
            Check.NotNull(companyCode, nameof(companyCode));
            Check.Length(companyCode, nameof(companyCode), CompanyConsts.CompanyCodeMaxLength, 0);
            Check.NotNull(street, nameof(street));
            Check.Length(street, nameof(street), CompanyConsts.StreetMaxLength, 0);
            Check.NotNull(streetNumber, nameof(streetNumber));
            Check.Length(streetNumber, nameof(streetNumber), CompanyConsts.StreetNumberMaxLength, 0);
            Check.NotNull(zipCode, nameof(zipCode));
            Check.Length(zipCode, nameof(zipCode), CompanyConsts.ZipCodeMaxLength, 0);
            Check.NotNull(city, nameof(city));
            Check.Length(city, nameof(city), CompanyConsts.CityMaxLength, 0);
            Check.Length(stateRegion, nameof(stateRegion), CompanyConsts.StateRegionMaxLength, 0);
            Check.NotNull(taxNo, nameof(taxNo));
            Check.Length(taxNo, nameof(taxNo), CompanyConsts.TaxNoMaxLength, 0);
            Check.Length(travelAgencyCode, nameof(travelAgencyCode), CompanyConsts.TravelAgencyCodeMaxLength, 0);
            Check.Length(invoicePrefix, nameof(invoicePrefix), CompanyConsts.InvoicePrefixMaxLength, 0);
            Check.Length(webSite, nameof(webSite), CompanyConsts.WebSiteMaxLength, 0);
            Check.NotNull(companyEmail, nameof(companyEmail));
            Check.Length(companyEmail, nameof(companyEmail), CompanyConsts.CompanyEmailMaxLength, 0);
            Check.Length(telephone, nameof(telephone), CompanyConsts.TelephoneMaxLength, 0);
            Check.Length(fax, nameof(fax), CompanyConsts.FaxMaxLength, 0);
            Check.Length(facebookPage, nameof(facebookPage), CompanyConsts.FacebookPageMaxLength, 0);
            Check.Length(twiterPage, nameof(twiterPage), CompanyConsts.TwiterPageMaxLength, 0);
            Check.Length(instagram, nameof(instagram), CompanyConsts.InstagramMaxLength, 0);
            Check.Length(ceoName, nameof(ceoName), CompanyConsts.CeoNameMaxLength, 0);
            Check.Length(ceoEmail, nameof(ceoEmail), CompanyConsts.CeoEmailMaxLength, 0);
            Check.Length(tenantCurrency, nameof(tenantCurrency), CompanyConsts.TenantCurrencyMaxLength, 0);
            Country = country;
            BookingEmail = bookingEmail;
            BookingEmailConfirmed = bookingEmailConfirmed;
            BookingCellPhone = bookingCellPhone;
            BookingPhoneConfirmed = bookingPhoneConfirmed;
            DefaultCruiseDeposit = defaultCruiseDeposit;
            DefaultCharterDeposit = defaultCharterDeposit;
            DefaultCruiseDepositType = defaultCruiseDepositType;
            DefautCharterDepositType = defautCharterDepositType;
            RequestDurationCruise = requestDurationCruise;
            RequestDurationCharter = requestDurationCharter;
            OptionDurationCharter = optionDurationCharter;
            CharterFinalPaymentDueDays = charterFinalPaymentDueDays;
            CruiseFullPaymentRequiredDays = cruiseFullPaymentRequiredDays;
            LegalName = legalName;
            CompanyCode = companyCode;
            Street = street;
            StreetNumber = streetNumber;
            ZipCode = zipCode;
            City = city;
            StateRegion = stateRegion;
            InEU = inEU;
            TaxNo = taxNo;
            TravelAgencyCode = travelAgencyCode;
            InvoicePrefix = invoicePrefix;
            InvoiceLegal1 = invoiceLegal1;
            InvoiceLegal2 = invoiceLegal2;
            PaymentInfo = paymentInfo;
            WebSite = webSite;
            CompanyEmail = companyEmail;
            Telephone = telephone;
            Fax = fax;
            FacebookPage = facebookPage;
            TwiterPage = twiterPage;
            Instagram = instagram;
            CeoName = ceoName;
            CeoEmail = ceoEmail;
            WorkingYear = workingYear;
            TenantCurrency = tenantCurrency;
            RoundingAfterExchange = roundingAfterExchange;
            OptionDurationCruise = optionDurationCruise;
            CruiseFinalPaymentDueDays = cruiseFinalPaymentDueDays;
            CharterFullPaymentRequiredDays = charterFullPaymentRequiredDays;
        }
    }
}