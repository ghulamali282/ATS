import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Crm',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44306',
    redirectUri: baseUrl,
    clientId: 'Crm_App',
    responseType: 'code',
    scope: 'offline_access Crm',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44306',
      rootNamespace: 'Crm',
    },
    Crm: {
      url: 'https://localhost:44385',
      rootNamespace: 'Crm',
    },
  },
} as Environment;
