import { CoreModule } from '@abp/ng.core';
import { SettingManagementConfigModule } from '@abp/ng.setting-management/config';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommercialUiConfigModule } from '@volo/abp.commercial.ng.ui/config';
import { AccountAdminConfigModule } from '@volo/abp.ng.account/admin/config';
import { AccountPublicConfigModule } from '@volo/abp.ng.account/public/config';
import { AuditLoggingConfigModule } from '@volo/abp.ng.audit-logging/config';
import { IdentityServerConfigModule } from '@volo/abp.ng.identity-server/config';
import { IdentityConfigModule } from '@volo/abp.ng.identity/config';
import { LanguageManagementConfigModule } from '@volo/abp.ng.language-management/config';
import { registerLocale } from '@volo/abp.ng.language-management/locale';
import { SaasConfigModule } from '@volo/abp.ng.saas/config';
import { TextTemplateManagementConfigModule } from '@volo/abp.ng.text-template-management/config';
import { HttpErrorComponent, ThemeLeptonModule } from '@volo/abp.ng.theme.lepton';
import { AmmConfigModule } from 'Amm/projects/amm/config';
import { CcmConfigModule } from 'Ccm/projects/ccm/config';
import { CrmConfigModule } from 'Crm/projects/crm/config';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MANAGE_PROFILE_TAB_PROVIDER } from './providers/manage-profile-tabs.provider';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { UserProfileSettingComponent } from './profile-tabs/user-profile-setting/user-profile-setting.component';

@NgModule({
  declarations: [AppComponent, UserProfileSettingComponent, UserProfileSettingComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    CoreModule.forRoot({
      environment,
      registerLocaleFn: registerLocale(),
    }),
    ThemeSharedModule.forRoot({
      httpErrorConfig: {
        errorScreen: {
          component: HttpErrorComponent,
          forWhichErrors: [401, 403, 404, 500],
          hideCloseIcon: true,
        },
      },
    }),
    AccountAdminConfigModule.forRoot(),
    AccountPublicConfigModule.forRoot(),
    IdentityConfigModule.forRoot(),
    LanguageManagementConfigModule.forRoot(),
    SaasConfigModule.forRoot(),
    AuditLoggingConfigModule.forRoot(),
    IdentityServerConfigModule.forRoot(),
    TextTemplateManagementConfigModule.forRoot(),
    SettingManagementConfigModule.forRoot(),
    ThemeLeptonModule.forRoot(),
    CommercialUiConfigModule.forRoot(),
    AmmConfigModule.forRoot(),
    CcmConfigModule.forRoot(),
    CrmConfigModule.forRoot(),
  ],
  providers: [APP_ROUTE_PROVIDER, MANAGE_PROFILE_TAB_PROVIDER],
  bootstrap: [AppComponent],
})
export class AppModule {}
