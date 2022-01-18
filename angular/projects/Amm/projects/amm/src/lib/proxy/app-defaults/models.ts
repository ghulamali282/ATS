import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface AppDefaultCreateDto {
  settingsName: string;
  settingsValue: string;
}

export interface AppDefaultDto extends EntityDto<string> {
  settingsName: string;
  settingsValue: string;
}

export interface AppDefaultUpdateDto {
  settingsName: string;
  settingsValue: string;
}

export interface GetAppDefaultsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  settingsName?: string;
  settingsValue?: string;
}
