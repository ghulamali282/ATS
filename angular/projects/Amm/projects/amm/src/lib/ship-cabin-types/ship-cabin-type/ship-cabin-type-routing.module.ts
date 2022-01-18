import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShipCabinTypeComponent } from './components/ship-cabin-type.component';

const routes: Routes = [
  {
    path: '',
    component: ShipCabinTypeComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShipCabinTypeRoutingModule {}
