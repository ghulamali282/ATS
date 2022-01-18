import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AmmComponent } from './components/amm.component';
import { loadAppDefaultModuleAsChild } from './app-defaults/app-default/app-default.module';
import { loadBookingStatusModuleAsChild } from './booking-statuses/booking-status/booking-status.module';
import { loadCruiseRegionModuleAsChild } from './cruise-regions/cruise-region/cruise-region.module';
import { loadCountryModuleAsChild } from './countries/country/country.module';
import { loadDestinationModuleAsChild } from './destinations/destination/destination.module';
import { loadShipModuleAsChild } from './ships/ship/ship.module';
import { loadShipDeckModuleAsChild } from './ship-decks/ship-deck/ship-deck.module';
import { loadShipCabinTypeModuleAsChild } from './ship-cabin-types/ship-cabin-type/ship-cabin-type.module';
import { loadShpCabinModuleAsChild } from './shp-cabins/shp-cabin/shp-cabin.module';
import { loadShipOperatorModuleAsChild } from './ship-operators/ship-operator/ship-operator.module';
import { loadMarinaModuleAsChild } from './marinas/marina/marina.module';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: AmmComponent,
  },
  { path: 'app-defaults', loadChildren: loadAppDefaultModuleAsChild },
  { path: 'booking-statuses', loadChildren: loadBookingStatusModuleAsChild },
  { path: 'cruise-regions', loadChildren: loadCruiseRegionModuleAsChild },
  { path: 'countries', loadChildren: loadCountryModuleAsChild },
  { path: 'destinations', loadChildren: loadDestinationModuleAsChild },
  { path: 'ships', loadChildren: loadShipModuleAsChild },
  { path: 'ship-decks', loadChildren: loadShipDeckModuleAsChild },
  { path: 'ship-cabin-types', loadChildren: loadShipCabinTypeModuleAsChild },
  { path: 'shp-cabins', loadChildren: loadShpCabinModuleAsChild },
  { path: 'ship-operators', loadChildren: loadShipOperatorModuleAsChild },
  { path: 'marinas', loadChildren: loadMarinaModuleAsChild },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AmmRoutingModule {}
