import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';

export interface AgePolicyDetailCreateDto {
  ageFrom: number;
  agePolicy: string;
  ageTo: number;
  service: string;
}

export interface AgePolicyDetailDto extends EntityDto<string> {
  ageFrom: number;
  agePolicy: string;
  ageTo: number;
  service: string;
}

export interface AgePolicyDetailUpdateDto {
  ageFrom: number;
  agePolicy: string;
  ageTo: number;
  service: string;
}

export interface AgePolicyDetailWithNavigationPropertiesDto {
  agePolicyDetail: AgePolicyDetailDto;
  masterData: MasterDataDto;
}

export interface GetAgePolicyDetailsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  ageFromMin?: number;
  ageFromMax?: number;
  agePolicy?: string;
  ageToMin?: number;
  ageToMax?: number;
  service?: string;
}
