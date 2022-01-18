using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Companies
{
    public class CompanyDto : EntityDto<Guid>
    {
        public string LegalName { get; set; }
        public string CompanyCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string StateRegion { get; set; }
        public string Country { get; set; }
        public bool? InEU { get; set; }
        public string TaxNo { get; set; }
        public string TravelAgencyCode { get; set; }
        public string InvoicePrefix { get; set; }
        public string InvoiceLegal1 { get; set; }
        public string InvoiceLegal2 { get; set; }
        public string PaymentInfo { get; set; }
        public string WebSite { get; set; }
        public string CompanyEmail { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string FacebookPage { get; set; }
        public string TwiterPage { get; set; }
        public string Instagram { get; set; }
        public string CeoName { get; set; }
        public string CeoEmail { get; set; }
        public string BookingEmail { get; set; }
        public bool BookingEmailConfirmed { get; set; }
        public string BookingCellPhone { get; set; }
        public bool BookingPhoneConfirmed { get; set; }
        public int? WorkingYear { get; set; }
        public string TenantCurrency { get; set; }
        public int? RoundingAfterExchange { get; set; }
        public decimal DefaultCruiseDeposit { get; set; }
        public decimal DefaultCharterDeposit { get; set; }
        public string DefaultCruiseDepositType { get; set; }
        public string DefautCharterDepositType { get; set; }
        public int RequestDurationCruise { get; set; }
        public int RequestDurationCharter { get; set; }
        public int? OptionDurationCruise { get; set; }
        public int OptionDurationCharter { get; set; }
        public int? CruiseFinalPaymentDueDays { get; set; }
        public int CharterFinalPaymentDueDays { get; set; }
        public int CruiseFullPaymentRequiredDays { get; set; }
        public int? CharterFullPaymentRequiredDays { get; set; }
    }
}