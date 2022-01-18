import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShipOperatorsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  operatorName?: string;
}

export interface ShipOperatorCreateDto {
  operatorName: string;
}

export interface ShipOperatorDto extends EntityDto<string> {
  operatorName: string;
}

export interface ShipOperatorUpdateDto {
  operatorName: string;
}
