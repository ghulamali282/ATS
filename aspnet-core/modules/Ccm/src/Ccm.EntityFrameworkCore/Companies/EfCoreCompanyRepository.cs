using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Ccm.EntityFrameworkCore;

namespace Ccm.Companies
{
    public class EfCoreCompanyRepository : EfCoreRepository<CcmDbContext, Company, Guid>, ICompanyRepository
    {
        public EfCoreCompanyRepository(IDbContextProvider<CcmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Company>> GetListAsync(
            string filterText = null,
            string legalName = null,
            string companyCode = null,
            string street = null,
            string streetNumber = null,
            string zipCode = null,
            string city = null,
            string stateRegion = null,
            string country = null,
            bool? inEU = null,
            string taxNo = null,
            string travelAgencyCode = null,
            string invoicePrefix = null,
            string invoiceLegal1 = null,
            string invoiceLegal2 = null,
            string paymentInfo = null,
            string webSite = null,
            string companyEmail = null,
            string telephone = null,
            string fax = null,
            string facebookPage = null,
            string twiterPage = null,
            string instagram = null,
            string ceoName = null,
            string ceoEmail = null,
            string bookingEmail = null,
            bool? bookingEmailConfirmed = null,
            string bookingCellPhone = null,
            bool? bookingPhoneConfirmed = null,
            int? workingYearMin = null,
            int? workingYearMax = null,
            string tenantCurrency = null,
            int? roundingAfterExchangeMin = null,
            int? roundingAfterExchangeMax = null,
            decimal? defaultCruiseDepositMin = null,
            decimal? defaultCruiseDepositMax = null,
            decimal? defaultCharterDepositMin = null,
            decimal? defaultCharterDepositMax = null,
            string defaultCruiseDepositType = null,
            string defautCharterDepositType = null,
            int? requestDurationCruiseMin = null,
            int? requestDurationCruiseMax = null,
            int? requestDurationCharterMin = null,
            int? requestDurationCharterMax = null,
            int? optionDurationCruiseMin = null,
            int? optionDurationCruiseMax = null,
            int? optionDurationCharterMin = null,
            int? optionDurationCharterMax = null,
            int? cruiseFinalPaymentDueDaysMin = null,
            int? cruiseFinalPaymentDueDaysMax = null,
            int? charterFinalPaymentDueDaysMin = null,
            int? charterFinalPaymentDueDaysMax = null,
            int? cruiseFullPaymentRequiredDaysMin = null,
            int? cruiseFullPaymentRequiredDaysMax = null,
            int? charterFullPaymentRequiredDaysMin = null,
            int? charterFullPaymentRequiredDaysMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, legalName, companyCode, street, streetNumber, zipCode, city, stateRegion, country, inEU, taxNo, travelAgencyCode, invoicePrefix, invoiceLegal1, invoiceLegal2, paymentInfo, webSite, companyEmail, telephone, fax, facebookPage, twiterPage, instagram, ceoName, ceoEmail, bookingEmail, bookingEmailConfirmed, bookingCellPhone, bookingPhoneConfirmed, workingYearMin, workingYearMax, tenantCurrency, roundingAfterExchangeMin, roundingAfterExchangeMax, defaultCruiseDepositMin, defaultCruiseDepositMax, defaultCharterDepositMin, defaultCharterDepositMax, defaultCruiseDepositType, defautCharterDepositType, requestDurationCruiseMin, requestDurationCruiseMax, requestDurationCharterMin, requestDurationCharterMax, optionDurationCruiseMin, optionDurationCruiseMax, optionDurationCharterMin, optionDurationCharterMax, cruiseFinalPaymentDueDaysMin, cruiseFinalPaymentDueDaysMax, charterFinalPaymentDueDaysMin, charterFinalPaymentDueDaysMax, cruiseFullPaymentRequiredDaysMin, cruiseFullPaymentRequiredDaysMax, charterFullPaymentRequiredDaysMin, charterFullPaymentRequiredDaysMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string legalName = null,
            string companyCode = null,
            string street = null,
            string streetNumber = null,
            string zipCode = null,
            string city = null,
            string stateRegion = null,
            string country = null,
            bool? inEU = null,
            string taxNo = null,
            string travelAgencyCode = null,
            string invoicePrefix = null,
            string invoiceLegal1 = null,
            string invoiceLegal2 = null,
            string paymentInfo = null,
            string webSite = null,
            string companyEmail = null,
            string telephone = null,
            string fax = null,
            string facebookPage = null,
            string twiterPage = null,
            string instagram = null,
            string ceoName = null,
            string ceoEmail = null,
            string bookingEmail = null,
            bool? bookingEmailConfirmed = null,
            string bookingCellPhone = null,
            bool? bookingPhoneConfirmed = null,
            int? workingYearMin = null,
            int? workingYearMax = null,
            string tenantCurrency = null,
            int? roundingAfterExchangeMin = null,
            int? roundingAfterExchangeMax = null,
            decimal? defaultCruiseDepositMin = null,
            decimal? defaultCruiseDepositMax = null,
            decimal? defaultCharterDepositMin = null,
            decimal? defaultCharterDepositMax = null,
            string defaultCruiseDepositType = null,
            string defautCharterDepositType = null,
            int? requestDurationCruiseMin = null,
            int? requestDurationCruiseMax = null,
            int? requestDurationCharterMin = null,
            int? requestDurationCharterMax = null,
            int? optionDurationCruiseMin = null,
            int? optionDurationCruiseMax = null,
            int? optionDurationCharterMin = null,
            int? optionDurationCharterMax = null,
            int? cruiseFinalPaymentDueDaysMin = null,
            int? cruiseFinalPaymentDueDaysMax = null,
            int? charterFinalPaymentDueDaysMin = null,
            int? charterFinalPaymentDueDaysMax = null,
            int? cruiseFullPaymentRequiredDaysMin = null,
            int? cruiseFullPaymentRequiredDaysMax = null,
            int? charterFullPaymentRequiredDaysMin = null,
            int? charterFullPaymentRequiredDaysMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, legalName, companyCode, street, streetNumber, zipCode, city, stateRegion, country, inEU, taxNo, travelAgencyCode, invoicePrefix, invoiceLegal1, invoiceLegal2, paymentInfo, webSite, companyEmail, telephone, fax, facebookPage, twiterPage, instagram, ceoName, ceoEmail, bookingEmail, bookingEmailConfirmed, bookingCellPhone, bookingPhoneConfirmed, workingYearMin, workingYearMax, tenantCurrency, roundingAfterExchangeMin, roundingAfterExchangeMax, defaultCruiseDepositMin, defaultCruiseDepositMax, defaultCharterDepositMin, defaultCharterDepositMax, defaultCruiseDepositType, defautCharterDepositType, requestDurationCruiseMin, requestDurationCruiseMax, requestDurationCharterMin, requestDurationCharterMax, optionDurationCruiseMin, optionDurationCruiseMax, optionDurationCharterMin, optionDurationCharterMax, cruiseFinalPaymentDueDaysMin, cruiseFinalPaymentDueDaysMax, charterFinalPaymentDueDaysMin, charterFinalPaymentDueDaysMax, cruiseFullPaymentRequiredDaysMin, cruiseFullPaymentRequiredDaysMax, charterFullPaymentRequiredDaysMin, charterFullPaymentRequiredDaysMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Company> ApplyFilter(
            IQueryable<Company> query,
            string filterText,
            string legalName = null,
            string companyCode = null,
            string street = null,
            string streetNumber = null,
            string zipCode = null,
            string city = null,
            string stateRegion = null,
            string country = null,
            bool? inEU = null,
            string taxNo = null,
            string travelAgencyCode = null,
            string invoicePrefix = null,
            string invoiceLegal1 = null,
            string invoiceLegal2 = null,
            string paymentInfo = null,
            string webSite = null,
            string companyEmail = null,
            string telephone = null,
            string fax = null,
            string facebookPage = null,
            string twiterPage = null,
            string instagram = null,
            string ceoName = null,
            string ceoEmail = null,
            string bookingEmail = null,
            bool? bookingEmailConfirmed = null,
            string bookingCellPhone = null,
            bool? bookingPhoneConfirmed = null,
            int? workingYearMin = null,
            int? workingYearMax = null,
            string tenantCurrency = null,
            int? roundingAfterExchangeMin = null,
            int? roundingAfterExchangeMax = null,
            decimal? defaultCruiseDepositMin = null,
            decimal? defaultCruiseDepositMax = null,
            decimal? defaultCharterDepositMin = null,
            decimal? defaultCharterDepositMax = null,
            string defaultCruiseDepositType = null,
            string defautCharterDepositType = null,
            int? requestDurationCruiseMin = null,
            int? requestDurationCruiseMax = null,
            int? requestDurationCharterMin = null,
            int? requestDurationCharterMax = null,
            int? optionDurationCruiseMin = null,
            int? optionDurationCruiseMax = null,
            int? optionDurationCharterMin = null,
            int? optionDurationCharterMax = null,
            int? cruiseFinalPaymentDueDaysMin = null,
            int? cruiseFinalPaymentDueDaysMax = null,
            int? charterFinalPaymentDueDaysMin = null,
            int? charterFinalPaymentDueDaysMax = null,
            int? cruiseFullPaymentRequiredDaysMin = null,
            int? cruiseFullPaymentRequiredDaysMax = null,
            int? charterFullPaymentRequiredDaysMin = null,
            int? charterFullPaymentRequiredDaysMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.LegalName.Contains(filterText) || e.CompanyCode.Contains(filterText) || e.Street.Contains(filterText) || e.StreetNumber.Contains(filterText) || e.ZipCode.Contains(filterText) || e.City.Contains(filterText) || e.StateRegion.Contains(filterText) || e.Country.Contains(filterText) || e.TaxNo.Contains(filterText) || e.TravelAgencyCode.Contains(filterText) || e.InvoicePrefix.Contains(filterText) || e.InvoiceLegal1.Contains(filterText) || e.InvoiceLegal2.Contains(filterText) || e.PaymentInfo.Contains(filterText) || e.WebSite.Contains(filterText) || e.CompanyEmail.Contains(filterText) || e.Telephone.Contains(filterText) || e.Fax.Contains(filterText) || e.FacebookPage.Contains(filterText) || e.TwiterPage.Contains(filterText) || e.Instagram.Contains(filterText) || e.CeoName.Contains(filterText) || e.CeoEmail.Contains(filterText) || e.BookingEmail.Contains(filterText) || e.BookingCellPhone.Contains(filterText) || e.TenantCurrency.Contains(filterText) || e.DefaultCruiseDepositType.Contains(filterText) || e.DefautCharterDepositType.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(legalName), e => e.LegalName.Contains(legalName))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyCode), e => e.CompanyCode.Contains(companyCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(street), e => e.Street.Contains(street))
                    .WhereIf(!string.IsNullOrWhiteSpace(streetNumber), e => e.StreetNumber.Contains(streetNumber))
                    .WhereIf(!string.IsNullOrWhiteSpace(zipCode), e => e.ZipCode.Contains(zipCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(city), e => e.City.Contains(city))
                    .WhereIf(!string.IsNullOrWhiteSpace(stateRegion), e => e.StateRegion.Contains(stateRegion))
                    .WhereIf(!string.IsNullOrWhiteSpace(country), e => e.Country.Contains(country))
                    .WhereIf(inEU.HasValue, e => e.InEU == inEU)
                    .WhereIf(!string.IsNullOrWhiteSpace(taxNo), e => e.TaxNo.Contains(taxNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(travelAgencyCode), e => e.TravelAgencyCode.Contains(travelAgencyCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(invoicePrefix), e => e.InvoicePrefix.Contains(invoicePrefix))
                    .WhereIf(!string.IsNullOrWhiteSpace(invoiceLegal1), e => e.InvoiceLegal1.Contains(invoiceLegal1))
                    .WhereIf(!string.IsNullOrWhiteSpace(invoiceLegal2), e => e.InvoiceLegal2.Contains(invoiceLegal2))
                    .WhereIf(!string.IsNullOrWhiteSpace(paymentInfo), e => e.PaymentInfo.Contains(paymentInfo))
                    .WhereIf(!string.IsNullOrWhiteSpace(webSite), e => e.WebSite.Contains(webSite))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyEmail), e => e.CompanyEmail.Contains(companyEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(telephone), e => e.Telephone.Contains(telephone))
                    .WhereIf(!string.IsNullOrWhiteSpace(fax), e => e.Fax.Contains(fax))
                    .WhereIf(!string.IsNullOrWhiteSpace(facebookPage), e => e.FacebookPage.Contains(facebookPage))
                    .WhereIf(!string.IsNullOrWhiteSpace(twiterPage), e => e.TwiterPage.Contains(twiterPage))
                    .WhereIf(!string.IsNullOrWhiteSpace(instagram), e => e.Instagram.Contains(instagram))
                    .WhereIf(!string.IsNullOrWhiteSpace(ceoName), e => e.CeoName.Contains(ceoName))
                    .WhereIf(!string.IsNullOrWhiteSpace(ceoEmail), e => e.CeoEmail.Contains(ceoEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingEmail), e => e.BookingEmail.Contains(bookingEmail))
                    .WhereIf(bookingEmailConfirmed.HasValue, e => e.BookingEmailConfirmed == bookingEmailConfirmed)
                    .WhereIf(!string.IsNullOrWhiteSpace(bookingCellPhone), e => e.BookingCellPhone.Contains(bookingCellPhone))
                    .WhereIf(bookingPhoneConfirmed.HasValue, e => e.BookingPhoneConfirmed == bookingPhoneConfirmed)
                    .WhereIf(workingYearMin.HasValue, e => e.WorkingYear >= workingYearMin.Value)
                    .WhereIf(workingYearMax.HasValue, e => e.WorkingYear <= workingYearMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(tenantCurrency), e => e.TenantCurrency.Contains(tenantCurrency))
                    .WhereIf(roundingAfterExchangeMin.HasValue, e => e.RoundingAfterExchange >= roundingAfterExchangeMin.Value)
                    .WhereIf(roundingAfterExchangeMax.HasValue, e => e.RoundingAfterExchange <= roundingAfterExchangeMax.Value)
                    .WhereIf(defaultCruiseDepositMin.HasValue, e => e.DefaultCruiseDeposit >= defaultCruiseDepositMin.Value)
                    .WhereIf(defaultCruiseDepositMax.HasValue, e => e.DefaultCruiseDeposit <= defaultCruiseDepositMax.Value)
                    .WhereIf(defaultCharterDepositMin.HasValue, e => e.DefaultCharterDeposit >= defaultCharterDepositMin.Value)
                    .WhereIf(defaultCharterDepositMax.HasValue, e => e.DefaultCharterDeposit <= defaultCharterDepositMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(defaultCruiseDepositType), e => e.DefaultCruiseDepositType.Contains(defaultCruiseDepositType))
                    .WhereIf(!string.IsNullOrWhiteSpace(defautCharterDepositType), e => e.DefautCharterDepositType.Contains(defautCharterDepositType))
                    .WhereIf(requestDurationCruiseMin.HasValue, e => e.RequestDurationCruise >= requestDurationCruiseMin.Value)
                    .WhereIf(requestDurationCruiseMax.HasValue, e => e.RequestDurationCruise <= requestDurationCruiseMax.Value)
                    .WhereIf(requestDurationCharterMin.HasValue, e => e.RequestDurationCharter >= requestDurationCharterMin.Value)
                    .WhereIf(requestDurationCharterMax.HasValue, e => e.RequestDurationCharter <= requestDurationCharterMax.Value)
                    .WhereIf(optionDurationCruiseMin.HasValue, e => e.OptionDurationCruise >= optionDurationCruiseMin.Value)
                    .WhereIf(optionDurationCruiseMax.HasValue, e => e.OptionDurationCruise <= optionDurationCruiseMax.Value)
                    .WhereIf(optionDurationCharterMin.HasValue, e => e.OptionDurationCharter >= optionDurationCharterMin.Value)
                    .WhereIf(optionDurationCharterMax.HasValue, e => e.OptionDurationCharter <= optionDurationCharterMax.Value)
                    .WhereIf(cruiseFinalPaymentDueDaysMin.HasValue, e => e.CruiseFinalPaymentDueDays >= cruiseFinalPaymentDueDaysMin.Value)
                    .WhereIf(cruiseFinalPaymentDueDaysMax.HasValue, e => e.CruiseFinalPaymentDueDays <= cruiseFinalPaymentDueDaysMax.Value)
                    .WhereIf(charterFinalPaymentDueDaysMin.HasValue, e => e.CharterFinalPaymentDueDays >= charterFinalPaymentDueDaysMin.Value)
                    .WhereIf(charterFinalPaymentDueDaysMax.HasValue, e => e.CharterFinalPaymentDueDays <= charterFinalPaymentDueDaysMax.Value)
                    .WhereIf(cruiseFullPaymentRequiredDaysMin.HasValue, e => e.CruiseFullPaymentRequiredDays >= cruiseFullPaymentRequiredDaysMin.Value)
                    .WhereIf(cruiseFullPaymentRequiredDaysMax.HasValue, e => e.CruiseFullPaymentRequiredDays <= cruiseFullPaymentRequiredDaysMax.Value)
                    .WhereIf(charterFullPaymentRequiredDaysMin.HasValue, e => e.CharterFullPaymentRequiredDays >= charterFullPaymentRequiredDaysMin.Value)
                    .WhereIf(charterFullPaymentRequiredDaysMax.HasValue, e => e.CharterFullPaymentRequiredDays <= charterFullPaymentRequiredDaysMax.Value);
        }
    }
}