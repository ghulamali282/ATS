using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Companies
{
    public class GetCompaniesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

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
        public bool? BookingEmailConfirmed { get; set; }
        public string BookingCellPhone { get; set; }
        public bool? BookingPhoneConfirmed { get; set; }
        public int? WorkingYearMin { get; set; }
        public int? WorkingYearMax { get; set; }
        public string TenantCurrency { get; set; }
        public int? RoundingAfterExchangeMin { get; set; }
        public int? RoundingAfterExchangeMax { get; set; }
        public decimal? DefaultCruiseDepositMin { get; set; }
        public decimal? DefaultCruiseDepositMax { get; set; }
        public decimal? DefaultCharterDepositMin { get; set; }
        public decimal? DefaultCharterDepositMax { get; set; }
        public string DefaultCruiseDepositType { get; set; }
        public string DefautCharterDepositType { get; set; }
        public int? RequestDurationCruiseMin { get; set; }
        public int? RequestDurationCruiseMax { get; set; }
        public int? RequestDurationCharterMin { get; set; }
        public int? RequestDurationCharterMax { get; set; }
        public int? OptionDurationCruiseMin { get; set; }
        public int? OptionDurationCruiseMax { get; set; }
        public int? OptionDurationCharterMin { get; set; }
        public int? OptionDurationCharterMax { get; set; }
        public int? CruiseFinalPaymentDueDaysMin { get; set; }
        public int? CruiseFinalPaymentDueDaysMax { get; set; }
        public int? CharterFinalPaymentDueDaysMin { get; set; }
        public int? CharterFinalPaymentDueDaysMax { get; set; }
        public int? CruiseFullPaymentRequiredDaysMin { get; set; }
        public int? CruiseFullPaymentRequiredDaysMax { get; set; }
        public int? CharterFullPaymentRequiredDaysMin { get; set; }
        public int? CharterFullPaymentRequiredDaysMax { get; set; }

        public GetCompaniesInput()
        {

        }
    }
}