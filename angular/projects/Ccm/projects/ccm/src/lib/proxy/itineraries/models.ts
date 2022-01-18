import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { PartnerDto } from '../partners/models';
import type { MasterDataDto } from '../master-datas/models';
import type { AgePolicyDto } from '../age-policies/models';
import type { DestinationDto } from '../destinations/models';
import type { CancellationPolicyDto } from '../cancellation-policies/models';
import type { PaymentPolicyDto } from '../payment-policies/models';

export interface GetItinerariesInput extends PagedAndSortedResultRequestDto {
  filterText?: string;
  itineraryNameString?: string;
  itineraryCode?: string;
  googleMapLink?: string;
  durationMin?: number;
  durationMax?: number;
  extendedItinerary?: boolean;
  marina?: string;
  embarcationLatitude?: string;
  embarcationLongitude?: string;
  disembarkationLatitude?: string;
  disembarkationLongitude?: string;
  checkInTime?: string;
  checkOutTime?: string;
  transferIncluded?: boolean;
  video?: string;
  requestDurationMin?: number;
  requestDurationMax?: number;
  optionDurationMin?: number;
  optionDurationMax?: number;
  operatorName?: string;
  themes?: string;
  boarding?: string;
  agePolicyId?: string;
  embarcationPort?: string;
  disembarkationPort?: string;
  cancellationPolicy?: string;
  paymentPolicy?: string;
  itineraryName?: string;
}

export interface ItineraryCreateDto {
  itineraryNameString: string;
  itineraryCode: string;
  googleMapLink?: string;
  duration: number;
  extendedItinerary: boolean;
  marina?: string;
  embarcationLatitude: string;
  embarcationLongitude: string;
  disembarkationLatitude: string;
  disembarkationLongitude: string;
  checkInTime: string;
  checkOutTime: string;
  transferIncluded: boolean;
  video?: string;
  requestDuration: number;
  optionDuration: number;
  operatorName: string;
  themes: string;
  boarding: string;
  agePolicyId: string;
  embarcationPort: string;
  disembarkationPort: string;
  cancellationPolicy: string;
  paymentPolicy: string;
  itineraryName: string;
}

export interface ItineraryDto extends EntityDto<string> {
  itineraryNameString: string;
  itineraryCode: string;
  googleMapLink?: string;
  duration: number;
  extendedItinerary: boolean;
  marina?: string;
  embarcationLatitude: string;
  embarcationLongitude: string;
  disembarkationLatitude: string;
  disembarkationLongitude: string;
  checkInTime: string;
  checkOutTime: string;
  transferIncluded: boolean;
  video?: string;
  requestDuration: number;
  optionDuration: number;
  operatorName: string;
  themes: string;
  boarding: string;
  agePolicyId: string;
  embarcationPort: string;
  disembarkationPort: string;
  cancellationPolicy: string;
  paymentPolicy: string;
  itineraryName: string;
}

export interface ItineraryUpdateDto {
  itineraryNameString: string;
  itineraryCode: string;
  googleMapLink?: string;
  duration: number;
  extendedItinerary: boolean;
  marina?: string;
  embarcationLatitude: string;
  embarcationLongitude: string;
  disembarkationLatitude: string;
  disembarkationLongitude: string;
  checkInTime: string;
  checkOutTime: string;
  transferIncluded: boolean;
  video?: string;
  requestDuration: number;
  optionDuration: number;
  operatorName: string;
  themes: string;
  boarding: string;
  agePolicyId: string;
  embarcationPort: string;
  disembarkationPort: string;
  cancellationPolicy: string;
  paymentPolicy: string;
  itineraryName: string;
}

export interface ItineraryWithNavigationPropertiesDto {
  itinerary: ItineraryDto;
  partner: PartnerDto;
  masterData: MasterDataDto;
  agePolicy: AgePolicyDto;
  destination: DestinationDto;
  cancellationPolicy: CancellationPolicyDto;
  paymentPolicy: PaymentPolicyDto;
}
