import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { CancellationPolicyComponent } from './components/cancellation-policy.component';
import { CancellationPolicyRoutingModule } from './cancellation-policy-routing.module';

@NgModule({
  declarations: [CancellationPolicyComponent],
  imports: [
    CancellationPolicyRoutingModule,
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
export class CancellationPolicyModule {}

export function loadCancellationPolicyModuleAsChild() {
  return Promise.resolve(CancellationPolicyModule);
}
