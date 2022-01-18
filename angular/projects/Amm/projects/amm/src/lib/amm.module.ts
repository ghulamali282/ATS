import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AmmComponent } from './components/amm.component';
import { AmmRoutingModule } from './amm-routing.module';

@NgModule({
  declarations: [AmmComponent],
  imports: [CoreModule, ThemeSharedModule, AmmRoutingModule],
  exports: [AmmComponent],
})
export class AmmModule {
  static forChild(): ModuleWithProviders<AmmModule> {
    return {
      ngModule: AmmModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AmmModule> {
    return new LazyModuleFactory(AmmModule.forChild());
  }
}
