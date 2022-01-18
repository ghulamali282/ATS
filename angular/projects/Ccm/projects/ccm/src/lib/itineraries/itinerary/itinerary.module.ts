import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule, NgbTimepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { ItineraryComponent } from './components/itinerary.component';
import { ItineraryRoutingModule } from './itinerary-routing.module';

@NgModule({
  declarations: [ItineraryComponent],
  imports: [
    ItineraryRoutingModule,
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    NgxValidateCoreModule,
    NgbCollapseModule,
    NgbDatepickerModule,
    NgbDropdownModule,
    PageModule,
    NgbTimepickerModule
    
  ],
})
export class ItineraryModule {}


export function loadItineraryModuleAsChild() {
  return Promise.resolve(ItineraryModule);
}
