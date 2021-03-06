import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CompanyCreateDto {
  legalName: string;
  companyCode: string;
  street: string;
  streetNumber: string;
  zipCode: string;
  city: string;
  stateRegion?: string;
  country: string;
  inEU?: boolean;
  taxNo: string;
  travelAgencyCode?: string;
  invoicePrefix?: string;
  invoiceLegal1?: string;
  invoiceLegal2?: string;
  paymentInfo?: string;
  webSite?: string;
  companyEmail: string;
  telephone?: string;
  fax?: string;
  facebookPage?: string;
  twiterPage?: string;
  instagram?: string;
  ceoName?: string;
  ceoEmail?: string;
  bookingEmail: string;
  bookingEmailConfirmed: boolean;
  bookingCellPhone: string;
  bookingPhoneConfirmed?: boolean;
  workingYear?: number;
  tenantCurrency?: string;
  roundingAfterExchange?: number;
  defaultCruiseDeposit: number;
  defaultCharterDeposit: number;
  defaultCruiseDepositType: string;
  defautCharterDepositType: string;
  requestDurationCruise: number;
  requestDurationCharter: number;
  optionDurationCruise?: number;
  optionDurationCharter: number;
  cruiseFinalPaymentDueDays?: number;
  charterFinalPaymentDueDays: number;
  cruiseFullPaymentRequiredDays: number;
  charterFullPaymentRequiredDays?: number;
}

export interface CompanyDto extends EntityDto<string> {
  legalName: string;
  companyCode: string;
  street: string;
  streetNumber: string;
  zipCode: string;
  city: string;
  stateRegion?: string;
  country: string;
  inEU?: boolean;
  taxNo: string;
  travelAgencyCode?: string;
  invoicePrefix?: string;
  invoiceLegal1?: string;
  invoiceLegal2?: string;
  paymentInfo?: string;
  webSite?: string;
  companyEmail: string;
  telephone?: string;
  fax?: string;
  facebookPage?: string;
  twiterPage?: string;
  instagram?: string;
  ceoName?: string;
  ceoEmail?: string;
  bookingEmail: string;
  bookingEmailConfirmed: boolean;
  bookingCellPhone: string;
  bookingPhoneConfirmed?: boolean;
  workingYear?: number;
  tenantCurrency?: string;
  roundingAfterExchange?: number;
  defaultCruiseDeposit: number;
  defaultCharterDeposit: number;
  defaultCruiseDepositType: string;
  defautCharterDepositType: string;
  requestDurationCruise: number;
  requestDurationCharter: number;
  optionDurationCruise?: number;
  optionDurationCharter: number;
  cruiseFinalPaymentDueDays?: number;
  charterFinalPaymentDueDays: number;
  cruiseFullPaymentRequiredDays: number;
  charterFullPaymentRequiredDays?: number;
}

export interface CompanyUpdateDto {
  legalName: string;
  companyCode: string;
  street: string;
  streetNumber: string;
  zipCode: string;
  city: string;
  stateRegion?: string;
  country: string;
  inEU?: boolean;
  taxNo: string;
  travelAgencyCode?: string;
  invoicePrefix?: string;
  invoiceLegal1?: string;
  invoiceLegal2?: string;
  paymentInfo?: string;
  webSite?: string;
  companyEmail: string;
  telephone?: string;
  fax?: string;
  facebookPage?: string;
  twiterPage?: string;
  instagram?: string;
  ceoName?: string;
  ceoEmail?: string;
  bookingEmail: string;
  bookingEmailConfirmed: boolean;
  bookingCellPhone: string;
  bookingPhoneConfirmed?: boolean;
  workingYear?: number;
  tenantCurrency?: string;
  roundingAfterExchange?: number;
  defaultCruiseDeposit: number;
  defaultCharterDeposit: number;
  defaultCruiseDepositType: string;
  defautCharterDepositType: string;
  requestDurationCruise: number;
  requestDurationCharter: number;
  optionDurationCruise?: number;
  optionDurationCharter: number;
  cruiseFinalPaymentDueDays?: number;
  charterFinalPaymentDueDays: number;
  cruiseFullPaymentRequiredDays: number;
  charterFullPaymentRequiredDays?: number;
}

export interface GetCompaniesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  legalName?: string;
  companyCode?: string;
  street?: string;
  streetNumber?: string;
  zipCode?: string;
  city?: string;
  stateRegion?: string;
  country?: string;
  inEU?: boolean;
  taxNo?: string;
  travelAgencyCode?: string;
  invoicePrefix?: string;
  invoiceLegal1?: string;
  invoiceLegal2?: string;
  paymentInfo?: string;
  webSite?: string;
  companyEmail?: string;
  telephone?: string;
  fax?: string;
  facebookPage?: string;
  twiterPage?: string;
  instagram?: string;
  ceoName?: string;
  ceoEmail?: string;
  bookingEmail?: string;
  bookingEmailConfirmed?: boolean;
  bookingCellPhone?: string;
  bookingPhoneConfirmed?: boolean;
  workingYearMin?: number;
  workingYearMax?: number;
  tenantCurrency?: string;
  roundingAfterExchangeMin?: number;
  roundingAfterExchangeMax?: number;
  defaultCruiseDepositMin?: number;
  defaultCruiseDepositMax?: number;
  defaultCharterDepositMin?: number;
  defaultCharterDepositMax?: number;
  defaultCruiseDepositType?: string;
  defautCharterDepositType?: string;
  requestDurationCruiseMin?: number;
  requestDurationCruiseMax?: number;
  requestDurationCharterMin?: number;
  requestDurationCharterMax?: number;
  optionDurationCruiseMin?: number;
  optionDurationCruiseMax?: number;
  optionDurationCharterMin?: number;
  optionDurationCharterMax?: number;
  cruiseFinalPaymentDueDaysMin?: number;
  cruiseFinalPaymentDueDaysMax?: number;
  charterFinalPaymentDueDaysMin?: number;
  charterFinalPaymentDueDaysMax?: number;
  cruiseFullPaymentRequiredDaysMin?: number;
  cruiseFullPaymentRequiredDaysMax?: number;
  charterFullPaymentRequiredDaysMin?: number;
  charterFullPaymentRequiredDaysMax?: number;
}
