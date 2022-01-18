import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CcmComponent } from './components/ccm.component';
import { loadMasterDataModuleAsChild } from './master-datas/master-data/master-data.module';
import { loadPartnerModuleAsChild } from './partners/partner/partner.module';
import { loadDepartureSeasonModuleAsChild } from './departure-seasons/departure-season/departure-season.module';
import { loadDepartureModuleAsChild } from './departures/departure/departure.module';
import { loadAgePolicyModuleAsChild } from './age-policies/age-policy/age-policy.module';
import { loadAgePolicyDetailModuleAsChild } from './age-policy-details/age-policy-detail/age-policy-detail.module';
import { loadCountryModuleAsChild } from './countries/country/country.module';
import { loadCompanyModuleAsChild } from './companies/company/company.module';
import { loadItineraryModuleAsChild } from './itineraries/itinerary/itinerary.module';
import { loadItineraryDetailModuleAsChild } from './itinerary-details/itinerary-detail/itinerary-detail.module';
import { loadCruiseModuleAsChild } from './cruises/cruise/cruise.module';
import { loadCharterShipModuleAsChild } from './charter-ships/charter-ship/charter-ship.module';
import { loadCancellationPolicyModuleAsChild } from './cancellation-policies/cancellation-policy/cancellation-policy.module';
import { loadPaymentPolicyModuleAsChild } from './payment-policies/payment-policy/payment-policy.module';
import { loadDestinationModuleAsChild } from './destinations/destination/destination.module';
import { loadShipModuleAsChild } from './ships/ship/ship.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: CcmComponent,
  },
  { path: 'master-datas', loadChildren: loadMasterDataModuleAsChild },
  { path: 'partners', loadChildren: loadPartnerModuleAsChild },
  { path: 'departure-seasons', loadChildren: loadDepartureSeasonModuleAsChild },
  { path: 'departures', loadChildren: loadDepartureModuleAsChild },
  { path: 'age-policies', loadChildren: loadAgePolicyModuleAsChild },
  { path: 'age-policy-details', loadChildren: loadAgePolicyDetailModuleAsChild },
  { path: 'countries', loadChildren: loadCountryModuleAsChild },
  { path: 'companies', loadChildren: loadCompanyModuleAsChild },
  { path: 'itineraries', loadChildren: loadItineraryModuleAsChild },
  { path: 'itinerary-details', loadChildren: loadItineraryDetailModuleAsChild },
  { path: 'cruises', loadChildren: loadCruiseModuleAsChild },
  { path: 'charter-ships', loadChildren: loadCharterShipModuleAsChild },
  { path: 'cancellation-policies', loadChildren: loadCancellationPolicyModuleAsChild },
  { path: 'payment-policies', loadChildren: loadPaymentPolicyModuleAsChild },
  { path: 'destinations', loadChildren: loadDestinationModuleAsChild },
  { path: 'ships', loadChildren: loadShipModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CcmRoutingModule {}
