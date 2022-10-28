window.msalConfig = {
    auth: {

    }
}



const loginRequest = {
    scopes: ["User.ReadWrite"]
}

export function setMsalConfig(config) {
    window.msalConfig = config;
}

export function getMsalConfig() {
    return window.msalConfig;
}

export function setMsalAccessToken(accessToken) {
    window.msalAccessToken = accessToken;
}

export function getMsalAccessToken() {
    return window.msalAccessToken;
}

export function createMsalObject() {
    console.log(window.msalConfig)
    window.msalObj = new msal.PublicClientApplication(window.msalConfig);
    window.msalObj.handleRedirectPromise().then((tokenResponse) => {
        console.log(tokenResponse);
        setMsalAccessToken(tokenResponse.idToken);
    }).catch(error => {
        console.log('error', error)
    });
}

export function loginRedirect() {
    window.msalObj.loginRedirect()
        .then(function (loginResponse) {
            console.log(loginResponse);
        })
}