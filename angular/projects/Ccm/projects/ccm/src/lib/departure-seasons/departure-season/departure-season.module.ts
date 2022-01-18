import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { DepartureSeasonComponent } from './components/departure-season.component';
import { DepartureSeasonRoutingModule } from './departure-season-routing.module';

@NgModule({
  declarations: [DepartureSeasonComponent],
  imports: [
    DepartureSeasonRoutingModule,
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
export class DepartureSeasonModule {}

export function loadDepartureSeasonModuleAsChild() {
  return Promise.resolve(DepartureSeasonModule);
}
