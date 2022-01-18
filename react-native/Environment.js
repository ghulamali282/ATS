const ENV = {
  dev: {
        apiUrl: 'http://localhost:44333',
    oAuthConfig: {
        issuer: 'http://localhost:44333',
        clientId: 'ATS_App',
      clientSecret: '1q2w3e*',
        scope: 'offline_access ATS',
    },
    localization: {
        defaultResourceName: 'ATS',
    },
  },
  prod: {
      apiUrl: 'http://localhost:44333',
    oAuthConfig: {
        issuer: 'http://localhost:44333',
        clientId: 'ATS_App',
      clientSecret: '1q2w3e*',
        scope: 'offline_access ATS',
    },
    localization: {
        defaultResourceName: 'ATS',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
