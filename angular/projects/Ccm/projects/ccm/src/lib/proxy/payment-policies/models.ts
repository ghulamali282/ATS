import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartnerDto } from '../partners/models';
import type { MasterDataDto } from '../master-datas/models';

export interface GetPaymentPoliciesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  delayedDepositAt?: string;
  depositMin?: number;
  depositMax?: number;
  depositAtReservation?: boolean;
  depositType?: string;
  finalPaymentDueDaysMin?: number;
  finalPaymentDueDaysMax?: number;
  fullPaymentRequiredDaysMin?: number;
  fullPaymentRequiredDaysMax?: number;
  policyString?: string;
  operatorName?: string;
  policyName?: string;
}

export interface PaymentPolicyCreateDto {
  delayedDepositAt?: string;
  deposit: number;
  depositAtReservation: boolean;
  depositType: string;
  finalPaymentDueDays: number;
  fullPaymentRequiredDays: number;
  policyString: string;
  operatorName: string;
  policyName: string;
}

export interface PaymentPolicyDto extends EntityDto<string> {
  delayedDepositAt?: string;
  deposit: number;
  depositAtReservation: boolean;
  depositType: string;
  finalPaymentDueDays: number;
  fullPaymentRequiredDays: number;
  policyString: string;
  operatorName: string;
  policyName: string;
}

export interface PaymentPolicyUpdateDto {
  delayedDepositAt?: string;
  deposit: number;
  depositAtReservation: boolean;
  depositType: string;
  finalPaymentDueDays: number;
  fullPaymentRequiredDays: number;
  policyString: string;
  operatorName: string;
  policyName: string;
}

export interface PaymentPolicyWithNavigationPropertiesDto {
  paymentPolicy: PaymentPolicyDto;
  partner: PartnerDto;
  masterData: MasterDataDto;
}
