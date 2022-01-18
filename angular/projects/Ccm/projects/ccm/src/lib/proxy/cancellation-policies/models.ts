import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartnerDto } from '../partners/models';
import type { MasterDataDto } from '../master-datas/models';

export interface CancellationPolicyCreateDto {
  nameString: string;
  operatorName: string;
  policyName: string;
}

export interface CancellationPolicyDto extends EntityDto<string> {
  nameString: string;
  operatorName: string;
  policyName: string;
}

export interface CancellationPolicyUpdateDto {
  nameString: string;
  operatorName: string;
  policyName: string;
}

export interface CancellationPolicyWithNavigationPropertiesDto {
  cancellationPolicy: CancellationPolicyDto;
  partner: PartnerDto;
  masterData: MasterDataDto;
}

export interface GetCancellationPoliciesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  nameString?: string;
  operatorName?: string;
  policyName?: string;
}
