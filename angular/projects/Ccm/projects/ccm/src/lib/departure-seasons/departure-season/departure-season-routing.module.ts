import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartureSeasonComponent } from './components/departure-season.component';

const routes: Routes = [
  {
    path: '',
    component: DepartureSeasonComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DepartureSeasonRoutingModule {}
