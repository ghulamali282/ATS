import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShipsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  shipName?: string;
  shipCategory?: string;
  shipOperator?: string;
  type?: string;
  flag?: string;
  homePort?: string;
  manufacturer?: string;
  model?: string;
  yearBuildMin?: number;
  yearBuildMax?: number;
}

export interface ShipCreateDto {
  shipName: string;
  shipCategory: string;
  shipOperator?: string;
  type?: string;
  flag: string;
  homePort: string;
  manufacturer?: string;
  model?: string;
  yearBuild: number;
}

export interface ShipDto extends EntityDto<string> {
  shipName: string;
  shipCategory: string;
  shipOperator?: string;
  type?: string;
  flag: string;
  homePort: string;
  manufacturer?: string;
  model?: string;
  yearBuild: number;
}

export interface ShipUpdateDto {
  shipName: string;
  shipCategory: string;
  shipOperator?: string;
  type?: string;
  flag: string;
  homePort: string;
  manufacturer?: string;
  model?: string;
  yearBuild: number;
}
