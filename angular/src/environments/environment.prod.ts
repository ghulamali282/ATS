import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ATS',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44333',
    redirectUri: baseUrl,
    clientId: 'ATS_App',
    responseType: 'code',
    scope: 'offline_access ATS',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44333',
      rootNamespace: 'ATS',
    },
  },
} as Environment;
