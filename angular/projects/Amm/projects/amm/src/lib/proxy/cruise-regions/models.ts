import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';

export interface CruiseRegionCreateDto {
  freeEntry?: string;
  cruiseRegionName: string;
}

export interface CruiseRegionDto extends EntityDto<string> {
  freeEntry?: string;
  cruiseRegionName: string;
}

export interface CruiseRegionUpdateDto {
  freeEntry?: string;
  cruiseRegionName: string;
}

export interface CruiseRegionWithNavigationPropertiesDto {
  cruiseRegion: CruiseRegionDto;
  masterData: MasterDataDto;
}

export interface GetCruiseRegionsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  freeEntry?: string;
  cruiseRegionName?: string;
}
