import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { NgxValidateCoreModule } from '@ngx-validate/core';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { PageModule } from '@abp/ng.components/page';
import { BookingStatusComponent } from './components/booking-status.component';
import { BookingStatusRoutingModule } from './booking-status-routing.module';


@NgModule({
  declarations: [BookingStatusComponent],
  imports: [
    BookingStatusRoutingModule,
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
export class BookingStatusModule {}       



export function loadBookingStatusModuleAsChild() {
  return Promise.resolve(BookingStatusModule);
}
