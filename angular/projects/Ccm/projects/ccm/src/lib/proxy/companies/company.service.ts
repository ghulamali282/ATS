import type { CompanyCreateDto, CompanyDto, CompanyUpdateDto, GetCompaniesInput } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  apiName = 'Ccm';

  create = (input: CompanyCreateDto) =>
    this.restService.request<any, CompanyDto>({
      method: 'POST',
      url: '/api/ccm/companies',
      body: input,
    },
    { apiName: this.apiName });

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/ccm/companies/${id}`,
    },
    { apiName: this.apiName });

  get = (id: string) =>
    this.restService.request<any, CompanyDto>({
      method: 'GET',
      url: `/api/ccm/companies/${id}`,
    },
    { apiName: this.apiName });

  getList = (input: GetCompaniesInput) =>
    this.restService.request<any, PagedResultDto<CompanyDto>>({
      method: 'GET',
      url: '/api/ccm/companies',
      params: { filterText: input.filterText, legalName: input.legalName, companyCode: input.companyCode, street: input.street, streetNumber: input.streetNumber, zipCode: input.zipCode, city: input.city, stateRegion: input.stateRegion, country: input.country, inEU: input.inEU, taxNo: input.taxNo, travelAgencyCode: input.travelAgencyCode, invoicePrefix: input.invoicePrefix, invoiceLegal1: input.invoiceLegal1, invoiceLegal2: input.invoiceLegal2, paymentInfo: input.paymentInfo, webSite: input.webSite, companyEmail: input.companyEmail, telephone: input.telephone, fax: input.fax, facebookPage: input.facebookPage, twiterPage: input.twiterPage, instagram: input.instagram, ceoName: input.ceoName, ceoEmail: input.ceoEmail, bookingEmail: input.bookingEmail, bookingEmailConfirmed: input.bookingEmailConfirmed, bookingCellPhone: input.bookingCellPhone, bookingPhoneConfirmed: input.bookingPhoneConfirmed, workingYearMin: input.workingYearMin, workingYearMax: input.workingYearMax, tenantCurrency: input.tenantCurrency, roundingAfterExchangeMin: input.roundingAfterExchangeMin, roundingAfterExchangeMax: input.roundingAfterExchangeMax, defaultCruiseDepositMin: input.defaultCruiseDepositMin, defaultCruiseDepositMax: input.defaultCruiseDepositMax, defaultCharterDepositMin: input.defaultCharterDepositMin, defaultCharterDepositMax: input.defaultCharterDepositMax, defaultCruiseDepositType: input.defaultCruiseDepositType, defautCharterDepositType: input.defautCharterDepositType, requestDurationCruiseMin: input.requestDurationCruiseMin, requestDurationCruiseMax: input.requestDurationCruiseMax, requestDurationCharterMin: input.requestDurationCharterMin, requestDurationCharterMax: input.requestDurationCharterMax, optionDurationCruiseMin: input.optionDurationCruiseMin, optionDurationCruiseMax: input.optionDurationCruiseMax, optionDurationCharterMin: input.optionDurationCharterMin, optionDurationCharterMax: input.optionDurationCharterMax, cruiseFinalPaymentDueDaysMin: input.cruiseFinalPaymentDueDaysMin, cruiseFinalPaymentDueDaysMax: input.cruiseFinalPaymentDueDaysMax, charterFinalPaymentDueDaysMin: input.charterFinalPaymentDueDaysMin, charterFinalPaymentDueDaysMax: input.charterFinalPaymentDueDaysMax, cruiseFullPaymentRequiredDaysMin: input.cruiseFullPaymentRequiredDaysMin, cruiseFullPaymentRequiredDaysMax: input.cruiseFullPaymentRequiredDaysMax, charterFullPaymentRequiredDaysMin: input.charterFullPaymentRequiredDaysMin, charterFullPaymentRequiredDaysMax: input.charterFullPaymentRequiredDaysMax, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });

  update = (id: string, input: CompanyUpdateDto) =>
    this.restService.request<any, CompanyDto>({
      method: 'PUT',
      url: `/api/ccm/companies/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
