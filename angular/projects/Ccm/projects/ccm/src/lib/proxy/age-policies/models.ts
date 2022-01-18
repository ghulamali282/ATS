import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { MasterDataDto } from '../master-datas/models';
import type { PartnerDto } from '../partners/models';

export interface AgePolicyCreateDto {
  demoField?: string;
  name: string;
  operatorName: string;
}

export interface AgePolicyDto extends EntityDto<string> {
  demoField?: string;
  name: string;
  operatorName: string;
}

export interface AgePolicyUpdateDto {
  demoField?: string;
  name: string;
  operatorName: string;
}

export interface AgePolicyWithNavigationPropertiesDto {
  agePolicy: AgePolicyDto;
  masterData: MasterDataDto;
  partner: PartnerDto;
}

export interface GetAgePoliciesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  demoField?: string;
  name?: string;
  operatorName?: string;
}
