using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Companies
{
    public class CompanyUpdateDto
    {
        [Required]
        [StringLength(CompanyConsts.LegalNameMaxLength)]
        public string LegalName { get; set; }
        [Required]
        [StringLength(CompanyConsts.CompanyCodeMaxLength)]
        public string CompanyCode { get; set; }
        [Required]
        [StringLength(CompanyConsts.StreetMaxLength)]
        public string Street { get; set; }
        [Required]
        [StringLength(CompanyConsts.StreetNumberMaxLength)]
        public string StreetNumber { get; set; }
        [Required]
        [StringLength(CompanyConsts.ZipCodeMaxLength)]
        public string ZipCode { get; set; }
        [Required]
        [StringLength(CompanyConsts.CityMaxLength)]
        public string City { get; set; }
        [StringLength(CompanyConsts.StateRegionMaxLength)]
        public string StateRegion { get; set; }
        [Required]
        [StringLength(CompanyConsts.CountryMaxLength)]
        public string Country { get; set; }
        public bool? InEU { get; set; }
        [Required]
        [StringLength(CompanyConsts.TaxNoMaxLength)]
        public string TaxNo { get; set; }
        [StringLength(CompanyConsts.TravelAgencyCodeMaxLength)]
        public string TravelAgencyCode { get; set; }
        [StringLength(CompanyConsts.InvoicePrefixMaxLength)]
        public string InvoicePrefix { get; set; }
        public string InvoiceLegal1 { get; set; }
        public string InvoiceLegal2 { get; set; }
        public string PaymentInfo { get; set; }
        [StringLength(CompanyConsts.WebSiteMaxLength)]
        public string WebSite { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(CompanyConsts.CompanyEmailMaxLength)]
        public string CompanyEmail { get; set; }
        [StringLength(CompanyConsts.TelephoneMaxLength)]
        public string Telephone { get; set; }
        [StringLength(CompanyConsts.FaxMaxLength)]
        public string Fax { get; set; }
        [StringLength(CompanyConsts.FacebookPageMaxLength)]
        public string FacebookPage { get; set; }
        [StringLength(CompanyConsts.TwiterPageMaxLength)]
        public string TwiterPage { get; set; }
        [StringLength(CompanyConsts.InstagramMaxLength)]
        public string Instagram { get; set; }
        [StringLength(CompanyConsts.CeoNameMaxLength)]
        public string CeoName { get; set; }
        [StringLength(CompanyConsts.CeoEmailMaxLength)]
        public string CeoEmail { get; set; }
        [Required]
        [EmailAddress]
        public string BookingEmail { get; set; }
        [Required]
        public bool BookingEmailConfirmed { get; set; }
        [Required]
        public string BookingCellPhone { get; set; }
        public bool BookingPhoneConfirmed { get; set; }
        public int? WorkingYear { get; set; }
        [StringLength(CompanyConsts.TenantCurrencyMaxLength)]
        public string TenantCurrency { get; set; }
        public int? RoundingAfterExchange { get; set; }
        [Required]
        public decimal DefaultCruiseDeposit { get; set; }
        [Required]
        public decimal DefaultCharterDeposit { get; set; }
        [Required]
        [StringLength(CompanyConsts.DefaultCruiseDepositTypeMaxLength)]
        public string DefaultCruiseDepositType { get; set; }
        [Required]
        [StringLength(CompanyConsts.DefautCharterDepositTypeMaxLength)]
        public string DefautCharterDepositType { get; set; }
        [Required]
        public int RequestDurationCruise { get; set; }
        [Required]
        public int RequestDurationCharter { get; set; }
        public int? OptionDurationCruise { get; set; }
        [Required]
        public int OptionDurationCharter { get; set; }
        public int? CruiseFinalPaymentDueDays { get; set; }
        [Required]
        public int CharterFinalPaymentDueDays { get; set; }
        [Required]
        public int CruiseFullPaymentRequiredDays { get; set; }
        public int? CharterFullPaymentRequiredDays { get; set; }
    }
}