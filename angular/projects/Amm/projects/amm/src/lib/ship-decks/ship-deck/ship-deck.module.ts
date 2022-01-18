import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { ShipDeckComponent } from './components/ship-deck.component';
import { ShipDeckRoutingModule } from './ship-deck-routing.module';

@NgModule({
  declarations: [ShipDeckComponent],
  imports: [
    ShipDeckRoutingModule,
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
export class ShipDeckModule {}

export function loadShipDeckModuleAsChild() {
  return Promise.resolve(ShipDeckModule);
}
