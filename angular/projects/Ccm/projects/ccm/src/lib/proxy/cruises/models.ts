import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { ShipDto } from '../ships/models';
import type { ItineraryDto } from '../itineraries/models';

export interface CruiseCreateDto {
  season: number;
  cruiseEnabled: boolean;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internetOnBoard: boolean;
  video?: string;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  cruiseDescriptions?: string;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
  ship: string;
  itinerary: string;
}

export interface CruiseDto extends EntityDto<string> {
  season: number;
  cruiseEnabled: boolean;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internetOnBoard: boolean;
  video?: string;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  cruiseDescriptions?: string;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
  ship: string;
  itinerary: string;
}

export interface CruiseUpdateDto {
  season: number;
  cruiseEnabled: boolean;
  featured: boolean;
  freeInternetOnBoard: boolean;
  internetOnBoard: boolean;
  video?: string;
  b2B: boolean;
  b2C: boolean;
  b2B_Agent: boolean;
  b2C_Agent: boolean;
  cruiseDescriptions?: string;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
  ship: string;
  itinerary: string;
}

export interface CruiseWithNavigationPropertiesDto {
  cruise: CruiseDto;
  ship: ShipDto;
  itinerary: ItineraryDto;
}

export interface GetCruisesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  seasonMin?: number;
  seasonMax?: number;
  cruiseEnabled?: boolean;
  featured?: boolean;
  freeInternetOnBoard?: boolean;
  internetOnBoard?: boolean;
  video?: string;
  b2B?: boolean;
  b2C?: boolean;
  b2B_Agent?: boolean;
  b2C_Agent?: boolean;
  cruiseDescriptions?: string;
  shipAmenities?: string;
  shipArticles?: string;
  shipPhotos?: string;
  cabinAmenities?: string;
  cabinArticles?: string;
  cabinPhotos?: string;
  ship?: string;
  itinerary?: string;
}
