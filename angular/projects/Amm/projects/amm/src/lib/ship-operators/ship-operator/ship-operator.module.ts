import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { ShipOperatorComponent } from './components/ship-operator.component';
import { ShipOperatorRoutingModule } from './ship-operator-routing.module';

@NgModule({
  declarations: [ShipOperatorComponent],
  imports: [
    ShipOperatorRoutingModule,
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
export class ShipOperatorModule {}

export function loadShipOperatorModuleAsChild() {
  return Promise.resolve(ShipOperatorModule);
}
