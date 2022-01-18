import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetShpCabinsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  ship?: string;
  cabinCategory?: string;
  cabinNo?: string;
  cabinNoNumericMin?: number;
  cabinNoNumericMax?: number;
  bedLayout?: string;
  standardCapacityMin?: number;
  standardCapacityMax?: number;
  maxCapacityMin?: number;
  maxCapacityMax?: number;
  portohole?: boolean;
  window?: boolean;
  cabinAreaMin?: number;
  cabinAreaMax?: number;
  balcon?: boolean;
  balconAreaMin?: number;
  balconAreaMax?: number;
  isDisabled?: boolean;
}

export interface ShpCabinCreateDto {
  ship: string;
  cabinCategory: string;
  cabinNo: string;
  cabinNoNumeric: number;
  bedLayout: string;
  standardCapacity: number;
  maxCapacity: number;
  portohole: boolean;
  window: boolean;
  cabinArea: number;
  balcon: boolean;
  balconArea: number;
  isDisabled: boolean;
}

export interface ShpCabinDto extends EntityDto<string> {
  ship: string;
  cabinCategory: string;
  cabinNo: string;
  cabinNoNumeric: number;
  bedLayout: string;
  standardCapacity: number;
  maxCapacity: number;
  portohole: boolean;
  window: boolean;
  cabinArea: number;
  balcon: boolean;
  balconArea: number;
  isDisabled: boolean;
}

export interface ShpCabinUpdateDto {
  ship: string;
  cabinCategory: string;
  cabinNo: string;
  cabinNoNumeric: number;
  bedLayout: string;
  standardCapacity: number;
  maxCapacity: number;
  portohole: boolean;
  window: boolean;
  cabinArea: number;
  balcon: boolean;
  balconArea: number;
  isDisabled: boolean;
}
