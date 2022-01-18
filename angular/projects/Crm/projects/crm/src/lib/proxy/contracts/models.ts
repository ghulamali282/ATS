import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface ContractCreateDto {
  operatorName: string;
  season: number;
  isEnabledAgent: boolean;
  isEnabledOperator: boolean;
}

export interface ContractDto extends EntityDto<string> {
  operatorName: string;
  season: number;
  isEnabledAgent: boolean;
  isEnabledOperator: boolean;
}

export interface ContractUpdateDto {
  operatorName: string;
  season: number;
  isEnabledAgent: boolean;
  isEnabledOperator: boolean;
}

export interface GetContractsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  operatorName?: string;
  seasonMin?: number;
  seasonMax?: number;
  isEnabledAgent?: boolean;
  isEnabledOperator?: boolean;
}
