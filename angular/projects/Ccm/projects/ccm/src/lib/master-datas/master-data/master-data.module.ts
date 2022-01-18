import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { MasterDataComponent } from './components/master-data.component';
import { MasterDataRoutingModule } from './master-data-routing.module';

@NgModule({
  declarations: [MasterDataComponent],
  imports: [
    MasterDataRoutingModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule,
    NgbNavModule
  ],
})
export class MasterDataModule {}

export function loadMasterDataModuleAsChild() {
  return Promise.resolve(MasterDataModule);
}
