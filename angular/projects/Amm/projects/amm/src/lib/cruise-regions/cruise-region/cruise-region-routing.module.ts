import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CruiseRegionComponent } from './components/cruise-region.component';

const routes: Routes = [
  {
    path: '',
    component: CruiseRegionComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CruiseRegionRoutingModule {}
