import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartnerDto } from '../partners/models';

export interface DepartureSeasonCreateDto {
  season: number;
  seasonName: string;
  partner: string;
}

export interface DepartureSeasonDto extends EntityDto<string> {
  season: number;
  seasonName: string;
  partner: string;
}

export interface DepartureSeasonUpdateDto {
  season: number;
  seasonName: string;
  partner: string;
}

export interface DepartureSeasonWithNavigationPropertiesDto {
  departureSeason: DepartureSeasonDto;
  partner: PartnerDto;
}

export interface GetDepartureSeasonsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  seasonMin?: number;
  seasonMax?: number;
  seasonName?: string;
  partner?: string;
}
