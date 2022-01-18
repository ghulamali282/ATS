import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CountryCreateDto {
  countryName: string;
  cultureName: string;
  currency: string;
  currencyCode: string;
  currencySymbol: string;
  languageName: string;
  placeId?: string;
}

export interface CountryDto extends EntityDto<string> {
  countryName: string;
  cultureName: string;
  currency: string;
  currencyCode: string;
  currencySymbol: string;
  languageName: string;
  placeId?: string;
}

export interface CountryUpdateDto {
  countryName: string;
  cultureName: string;
  currency: string;
  currencyCode: string;
  currencySymbol: string;
  languageName: string;
  placeId?: string;
}

export interface GetCountriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  countryName?: string;
  cultureName?: string;
  currency?: string;
  currencyCode?: string;
  currencySymbol?: string;
  languageName?: string;
  placeId?: string;
}
