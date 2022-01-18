import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { AgePolicyDetailComponent } from './components/age-policy-detail.component';
import { AgePolicyDetailRoutingModule } from './age-policy-detail-routing.module';

@NgModule({
  declarations: [AgePolicyDetailComponent],
  imports: [
    AgePolicyDetailRoutingModule,
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
export class AgePolicyDetailModule {}

export function loadAgePolicyDetailModuleAsChild() {
  return Promise.resolve(AgePolicyDetailModule);
}
