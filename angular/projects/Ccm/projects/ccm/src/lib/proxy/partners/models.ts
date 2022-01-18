import type { AuditedEntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CountryDto } from '../countries/models';

export interface GetPartnersInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  partnerName?: string;
  address?: string;
  taxNo?: string;
  bookingEmail?: string;
  bookingCellPhone?: string;
  bookingEmailConfirmed?: boolean;
  bookingPhoneConfirmed?: boolean;
  email?: string;
  phone?: string;
  countryName?: string;
}

export interface PartnerCreateDto {
  partnerName: string;
  address: string;
  taxNo: string;
  bookingEmail: string;
  bookingCellPhone: string;
  bookingEmailConfirmed?: boolean;
  bookingPhoneConfirmed?: boolean;
  email?: string;
  phone?: string;
  countryName: string;
}

export interface PartnerDto extends AuditedEntityDto<string> {
  partnerName: string;
  address: string;
  taxNo: string;
  bookingEmail: string;
  bookingCellPhone: string;
  bookingEmailConfirmed?: boolean;
  bookingPhoneConfirmed?: boolean;
  email?: string;
  phone?: string;
  countryName: string;
}

export interface PartnerUpdateDto {
  partnerName: string;
  address: string;
  taxNo: string;
  bookingEmail: string;
  bookingCellPhone: string;
  bookingEmailConfirmed?: boolean;
  bookingPhoneConfirmed?: boolean;
  email?: string;
  phone?: string;
  countryName: string;
}

export interface PartnerWithNavigationPropertiesDto {
  partner: PartnerDto;
  country: CountryDto;
}
