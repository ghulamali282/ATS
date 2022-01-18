import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <app-host-dashboard *abpPermission="'ATS.Dashboard.Host'"></app-host-dashboard>
    <app-tenant-dashboard *abpPermission="'ATS.Dashboard.Tenant'"></app-tenant-dashboard>
  `,
})
export class DashboardComponent {}
