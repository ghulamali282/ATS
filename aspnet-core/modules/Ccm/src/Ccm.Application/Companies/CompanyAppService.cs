using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Ccm.Permissions;
using Ccm.Companies;

namespace Ccm.Companies
{

    [Authorize(CcmPermissions.Companies.Default)]
    public class CompaniesAppService : ApplicationService, ICompaniesAppService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesAppService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public virtual async Task<PagedResultDto<CompanyDto>> GetListAsync(GetCompaniesInput input)
        {
            var totalCount = await _companyRepository.GetCountAsync(input.FilterText, input.LegalName, input.CompanyCode, input.Street, input.StreetNumber, input.ZipCode, input.City, input.StateRegion, input.Country, input.InEU, input.TaxNo, input.TravelAgencyCode, input.InvoicePrefix, input.InvoiceLegal1, input.InvoiceLegal2, input.PaymentInfo, input.WebSite, input.CompanyEmail, input.Telephone, input.Fax, input.FacebookPage, input.TwiterPage, input.Instagram, input.CeoName, input.CeoEmail, input.BookingEmail, input.BookingEmailConfirmed, input.BookingCellPhone, input.BookingPhoneConfirmed, input.WorkingYearMin, input.WorkingYearMax, input.TenantCurrency, input.RoundingAfterExchangeMin, input.RoundingAfterExchangeMax, input.DefaultCruiseDepositMin, input.DefaultCruiseDepositMax, input.DefaultCharterDepositMin, input.DefaultCharterDepositMax, input.DefaultCruiseDepositType, input.DefautCharterDepositType, input.RequestDurationCruiseMin, input.RequestDurationCruiseMax, input.RequestDurationCharterMin, input.RequestDurationCharterMax, input.OptionDurationCruiseMin, input.OptionDurationCruiseMax, input.OptionDurationCharterMin, input.OptionDurationCharterMax, input.CruiseFinalPaymentDueDaysMin, input.CruiseFinalPaymentDueDaysMax, input.CharterFinalPaymentDueDaysMin, input.CharterFinalPaymentDueDaysMax, input.CruiseFullPaymentRequiredDaysMin, input.CruiseFullPaymentRequiredDaysMax, input.CharterFullPaymentRequiredDaysMin, input.CharterFullPaymentRequiredDaysMax);
            var items = await _companyRepository.GetListAsync(input.FilterText, input.LegalName, input.CompanyCode, input.Street, input.StreetNumber, input.ZipCode, input.City, input.StateRegion, input.Country, input.InEU, input.TaxNo, input.TravelAgencyCode, input.InvoicePrefix, input.InvoiceLegal1, input.InvoiceLegal2, input.PaymentInfo, input.WebSite, input.CompanyEmail, input.Telephone, input.Fax, input.FacebookPage, input.TwiterPage, input.Instagram, input.CeoName, input.CeoEmail, input.BookingEmail, input.BookingEmailConfirmed, input.BookingCellPhone, input.BookingPhoneConfirmed, input.WorkingYearMin, input.WorkingYearMax, input.TenantCurrency, input.RoundingAfterExchangeMin, input.RoundingAfterExchangeMax, input.DefaultCruiseDepositMin, input.DefaultCruiseDepositMax, input.DefaultCharterDepositMin, input.DefaultCharterDepositMax, input.DefaultCruiseDepositType, input.DefautCharterDepositType, input.RequestDurationCruiseMin, input.RequestDurationCruiseMax, input.RequestDurationCharterMin, input.RequestDurationCharterMax, input.OptionDurationCruiseMin, input.OptionDurationCruiseMax, input.OptionDurationCharterMin, input.OptionDurationCharterMax, input.CruiseFinalPaymentDueDaysMin, input.CruiseFinalPaymentDueDaysMax, input.CharterFinalPaymentDueDaysMin, input.CharterFinalPaymentDueDaysMax, input.CruiseFullPaymentRequiredDaysMin, input.CruiseFullPaymentRequiredDaysMax, input.CharterFullPaymentRequiredDaysMin, input.CharterFullPaymentRequiredDaysMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Company>, List<CompanyDto>>(items)
            };
        }

        public virtual async Task<CompanyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Company, CompanyDto>(await _companyRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.Companies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Companies.Create)]
        public virtual async Task<CompanyDto> CreateAsync(CompanyCreateDto input)
        {

            var company = ObjectMapper.Map<CompanyCreateDto, Company>(input);
            company.TenantId = CurrentTenant.Id;
            company = await _companyRepository.InsertAsync(company, autoSave: true);
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }

        [Authorize(CcmPermissions.Companies.Edit)]
        public virtual async Task<CompanyDto> UpdateAsync(Guid id, CompanyUpdateDto input)
        {

            var company = await _companyRepository.GetAsync(id);
            ObjectMapper.Map(input, company);
            company = await _companyRepository.UpdateAsync(company, autoSave: true);
            return ObjectMapper.Map<Company, CompanyDto>(company);
        }
    }
}