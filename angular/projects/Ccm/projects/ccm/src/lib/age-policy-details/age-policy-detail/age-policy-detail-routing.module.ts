import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgePolicyDetailComponent } from './components/age-policy-detail.component';

const routes: Routes = [
  {
    path: '',
    component: AgePolicyDetailComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AgePolicyDetailRoutingModule {}
