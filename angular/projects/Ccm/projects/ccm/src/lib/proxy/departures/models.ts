import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartnerDto } from '../partners/models';
import type { DepartureSeasonDto } from '../departure-seasons/models';

export interface DepartureCreateDto {
  departuresArray: string;
  seasonGroup: string;
  partner: string;
  seasonName: string;
}

export interface DepartureDto extends EntityDto<string> {
  departuresArray: string;
  seasonGroup: string;
  partner: string;
  seasonName: string;
}

export interface DepartureUpdateDto {
  departuresArray: string;
  seasonGroup: string;
  partner: string;
  seasonName: string;
}

export interface DepartureWithNavigationPropertiesDto {
  departure: DepartureDto;
  partner: PartnerDto;
  departureSeason: DepartureSeasonDto;
}

export interface GetDeparturesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  departuresArray?: string;
  seasonGroup?: string;
  partner?: string;
  seasonName?: string;
}
