import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { CharterShipComponent } from './components/charter-ship.component';
import { CharterShipRoutingModule } from './charter-ship-routing.module';

@NgModule({
  declarations: [CharterShipComponent],
  imports: [
    CharterShipRoutingModule,
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
export class CharterShipModule {}

export function loadCharterShipModuleAsChild() {
  return Promise.resolve(CharterShipModule);
}
