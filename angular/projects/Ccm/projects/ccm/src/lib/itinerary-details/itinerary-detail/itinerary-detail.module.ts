import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { ItineraryDetailComponent } from './components/itinerary-detail.component';
import { ItineraryDetailRoutingModule } from './itinerary-detail-routing.module';

@NgModule({
  declarations: [ItineraryDetailComponent],
  imports: [
    ItineraryDetailRoutingModule,
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
export class ItineraryDetailModule {}

export function loadItineraryDetailModuleAsChild() {
  return Promise.resolve(ItineraryDetailModule);
}
