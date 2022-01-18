import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CrmComponent } from './components/crm.component';
import { CrmRoutingModule } from './crm-routing.module';

@NgModule({
  declarations: [CrmComponent],
  imports: [CoreModule, ThemeSharedModule, CrmRoutingModule],
  exports: [CrmComponent],
})
export class CrmModule {
  static forChild(): ModuleWithProviders<CrmModule> {
    return {
      ngModule: CrmModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CrmModule> {
    return new LazyModuleFactory(CrmModule.forChild());
  }
}
