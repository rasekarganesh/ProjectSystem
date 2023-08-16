// Config object to be passed to Msal on creation
const msalConfig = {
    auth: {
        clientId: "9bb0817c-dec6-4043-b860-484f67a99b4b", // this is a fake id
        authority: "https://login.microsoftonline.com/common",
        redirectUri: "https://localhost:2023/login",
    },
    cache: {
        cacheLocation: "sessionStorage", // This configures where your cache will be stored
        storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
    }
};

const myMSALObj = new Msal.UserAgentApplication(msalConfig);



function MicrosoftLoginInitialise(AuthenticationStateProviderInstance) {

    const loginRequest = {
        scopes: ["profile", "User.Read"],
    };

    myMSALObj.loginPopup(loginRequest)
        .then((loginResponse) => {
            //Login Success callback code here
            console.log("loginResponse", loginResponse)
            AuthenticationStateProviderInstance.invokeMethodAsync("MicrosoftLoginAsync",
                { Name: loginResponse.account.name, Email: loginResponse.account.userName,Picture:'' }  );
        }).catch(function (error) {
            console.log(error);
        });

}