import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItineraryDetailComponent } from './components/itinerary-detail.component';

const routes: Routes = [
  {
    path: '',
    component: ItineraryDetailComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ItineraryDetailRoutingModule {}
