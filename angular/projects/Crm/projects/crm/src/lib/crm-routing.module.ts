import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrmComponent } from './components/crm.component';
import { loadContractModuleAsChild } from './contracts/contract/contract.module';
import { loadClientModuleAsChild } from './clients/client/client.module';
import { loadPassengerModuleAsChild } from './passengers/passenger/passenger.module';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: CrmComponent,
  },
  { path: 'contracts', loadChildren: loadContractModuleAsChild },
  { path: 'clients', loadChildren: loadClientModuleAsChild },
  { path: 'passengers', loadChildren: loadPassengerModuleAsChild },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CrmRoutingModule {}
