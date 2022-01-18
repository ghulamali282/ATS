import type { FullAuditedEntityDto } from '@abp/ng.core';

export interface MasterDataDto extends FullAuditedEntityDto<string> {
  parentId?: string;
  name: string;
  sortOrder: number;
}
