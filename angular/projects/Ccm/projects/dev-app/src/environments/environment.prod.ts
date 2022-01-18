import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Ccm',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44318',
    redirectUri: baseUrl,
    clientId: 'Ccm_App',
    responseType: 'code',
    scope: 'offline_access Ccm',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44318',
      rootNamespace: 'Ccm',
    },
    Ccm: {
      url: 'https://localhost:44394',
      rootNamespace: 'Ccm',
    },
  },
} as Environment;
