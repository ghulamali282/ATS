import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { PaymentPolicyComponent } from './components/payment-policy.component';
import { PaymentPolicyRoutingModule } from './payment-policy-routing.module';

@NgModule({
  declarations: [PaymentPolicyComponent],
  imports: [
    PaymentPolicyRoutingModule,
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
export class PaymentPolicyModule {}

export function loadPaymentPolicyModuleAsChild() {
  return Promise.resolve(PaymentPolicyModule);
}
