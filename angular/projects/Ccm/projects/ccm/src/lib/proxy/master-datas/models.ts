import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface GetMasterDatasInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  parentId?: string;
  name?: string;
  value?: string;
  inlineValue?: boolean;
  visibleToTenant?: boolean;
  isSection?: boolean;
  isRadio?: boolean;
  isExportable?: boolean;
  icon?: string;
  cultureName?: string;
  sortOrderMin?: number;
  sortOrderMax?: number;
}

export interface MasterDataCreateDto {
  parentId?: string;
  name: string;
  value?: string;
  inlineValue?: boolean;
  visibleToTenant?: boolean;
  isSection?: boolean;
  isRadio?: boolean;
  isExportable?: boolean;
  icon?: string;
  cultureName: string;
  sortOrder: number;
}

export interface MasterDataDto extends EntityDto<string> {
  parentId?: string;
  name: string;
  value?: string;
  inlineValue?: boolean;
  visibleToTenant?: boolean;
  isSection?: boolean;
  isRadio?: boolean;
  isExportable?: boolean;
  icon?: string;
  cultureName: string;
  sortOrder: number;
}

export interface MasterDataUpdateDto {
  parentId?: string;
  name: string;
  value?: string;
  inlineValue?: boolean;
  visibleToTenant?: boolean;
  isSection?: boolean;
  isRadio?: boolean;
  isExportable?: boolean;
  icon?: string;
  cultureName: string;
  sortOrder: number;
}
