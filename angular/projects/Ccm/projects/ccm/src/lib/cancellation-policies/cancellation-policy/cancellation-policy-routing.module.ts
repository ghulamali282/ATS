import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CancellationPolicyComponent } from './components/cancellation-policy.component';

const routes: Routes = [
  {
    path: '',
    component: CancellationPolicyComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CancellationPolicyRoutingModule {}
