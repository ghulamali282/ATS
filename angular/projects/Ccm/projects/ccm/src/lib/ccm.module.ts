import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CcmComponent } from './components/ccm.component';
import { CcmRoutingModule } from './ccm-routing.module';

@NgModule({
  declarations: [CcmComponent],
  imports: [CoreModule, ThemeSharedModule, CcmRoutingModule],
  exports: [CcmComponent],
})
export class CcmModule {
  static forChild(): ModuleWithProviders<CcmModule> {
    return {
      ngModule: CcmModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CcmModule> {
    return new LazyModuleFactory(CcmModule.forChild());
  }
}
