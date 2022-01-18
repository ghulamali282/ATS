import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';

export interface CharterShipCreateDto {
  operatorName: string;
  season: number;
  shipNamePrefix?: string;
  ship: string;
  itinerary: string;
  tabs: string;
  video?: string;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internet: boolean;
  transferIncluded: boolean;
  enabledByUser: boolean;
  disabledBySystem?: number;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
}

export interface CharterShipDto extends EntityDto<string> {
  operatorName: string;
  season: number;
  shipNamePrefix?: string;
  ship: string;
  itinerary: string;
  tabs: string;
  video?: string;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internet: boolean;
  transferIncluded: boolean;
  enabledByUser: boolean;
  disabledBySystem?: number;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
}

export interface CharterShipUpdateDto {
  operatorName: string;
  season: number;
  shipNamePrefix?: string;
  ship: string;
  itinerary: string;
  tabs: string;
  video?: string;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internet: boolean;
  transferIncluded: boolean;
  enabledByUser: boolean;
  disabledBySystem?: number;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
}

export interface GetCharterShipsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  operatorName?: string;
  seasonMin?: number;
  seasonMax?: number;
  shipNamePrefix?: string;
  ship?: string;
  itinerary?: string;
  tabs?: string;
  video?: string;
  featured?: boolean;
  freeInternetOnBoard?: boolean;
  internet?: boolean;
  transferIncluded?: boolean;
  enabledByUser?: boolean;
  disabledBySystemMin?: number;
  disabledBySystemMax?: number;
  b2B?: boolean;
  b2C?: boolean;
  b2B_Agent?: boolean;
  b2C_Agent?: boolean;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
}
