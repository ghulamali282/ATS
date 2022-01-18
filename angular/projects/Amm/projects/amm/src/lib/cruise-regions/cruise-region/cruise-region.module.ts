import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { CruiseRegionComponent } from './components/cruise-region.component';
import { CruiseRegionRoutingModule } from './cruise-region-routing.module';

@NgModule({
  declarations: [CruiseRegionComponent],
  imports: [
    CruiseRegionRoutingModule,
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
export class CruiseRegionModule {}

export function loadCruiseRegionModuleAsChild() {
  return Promise.resolve(CruiseRegionModule);
}
