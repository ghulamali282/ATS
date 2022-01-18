import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { CountryDto } from '../countries/models';

export interface DestinationCreateDto {
  city: string;
  cityLocalName: string;
  latitude: number;
  longitude: number;
  videoUrl?: string;
  placeId: string;
  destCountry: string;
}

export interface DestinationDto extends EntityDto<string> {
  city: string;
  cityLocalName: string;
  latitude: number;
  longitude: number;
  videoUrl?: string;
  placeId: string;
  destCountry: string;
}

export interface DestinationUpdateDto {
  city: string;
  cityLocalName: string;
  latitude: number;
  longitude: number;
  videoUrl?: string;
  placeId: string;
  destCountry: string;
}

export interface DestinationWithNavigationPropertiesDto {
  destination: DestinationDto;
  country: CountryDto;
}

export interface GetDestinationsInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  city?: string;
  cityLocalName?: string;
  latitudeMin?: number;
  latitudeMax?: number;
  longitudeMin?: number;
  longitudeMax?: number;
  videoUrl?: string;
  placeId?: string;
  destCountry?: string;
}
