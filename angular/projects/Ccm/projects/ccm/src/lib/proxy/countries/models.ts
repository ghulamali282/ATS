import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CountryCreateDto {
  countryName: string;
  cultureName: string;
}

export interface CountryDto extends EntityDto<string> {
  countryName: string;
  cultureName: string;
}

export interface CountryUpdateDto {
  countryName: string;
  cultureName: string;
}

export interface GetCountriesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  countryName?: string;
  cultureName?: string;
}
