import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule} from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { CruiseComponent } from './components/cruise.component';
import { CruiseRoutingModule } from './cruise-routing.module';

@NgModule({
  declarations: [CruiseComponent],
  imports: [
    CruiseRoutingModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule,

  ],
})
export class CruiseModule {}

export function loadCruiseModuleAsChild() {
  return Promise.resolve(CruiseModule);
}
