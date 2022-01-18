import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Amm',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44307',
    redirectUri: baseUrl,
    clientId: 'Amm_App',
    responseType: 'code',
    scope: 'offline_access Amm',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44307',
      rootNamespace: 'Amm',
    },
    Amm: {
      url: 'https://localhost:44320',
      rootNamespace: 'Amm',
    },
  },
} as Environment;
