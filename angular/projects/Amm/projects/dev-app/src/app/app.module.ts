import { CoreModule } from '@abp/ng.core';
import { registerLocale } from '@abp/ng.core/locale';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AmmConfigModule } from '@amm/config';
import { CommercialUiConfigModule } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule } from '@volo/abp.ng.account/admin/config';
import { AccountPublicConfigModule } from '@volo/abp.ng.account/public/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
      sendNullsAsQueryParam: false,
      skipGetAppConfiguration: false,
    }),
    ThemeSharedModule.forRoot(),
    AccountAdminConfigModule.forRoot(),
    AccountPublicConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    AmmConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonModule.forRoot(),
    CommercialUiConfigModule.forRoot(),
  ],
  providers: [APP_ROUTE_PROVIDER],
  declarations: [AppComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
