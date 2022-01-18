import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { ShipCabinTypeComponent } from './components/ship-cabin-type.component';
import { ShipCabinTypeRoutingModule } from './ship-cabin-type-routing.module';

@NgModule({
  declarations: [ShipCabinTypeComponent],
  imports: [
    ShipCabinTypeRoutingModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule
  ],
})
export class ShipCabinTypeModule {}

export function loadShipCabinTypeModuleAsChild() {
  return Promise.resolve(ShipCabinTypeModule);
}
