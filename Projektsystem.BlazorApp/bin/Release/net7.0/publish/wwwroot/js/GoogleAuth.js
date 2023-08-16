
let AuthenticationStateProviderInstance = null;

function ProjectGoogleInitialize(clientId, AuthenticationStateProvider) {
    // disable Exponential cool-down
    /*document.cookie = `g_state=;path=/;expires=Thu, 01 Jan 1970 00:00:01 GMT`;*/
    AuthenticationStateProviderInstance = AuthenticationStateProvider;
    google.accounts.id.initialize({ client_id: clientId, callback: ProjectCallback });
}

function ProjectGooglePrompt() {
    google.accounts.id.prompt((notification) => {
        if (notification.isNotDisplayed() || notification.isSkippedMoment()) {
            console.info(notification.getNotDisplayedReason());
            console.info(notification.getSkippedReason());
        }
    });
}

function ProjectCallback(googleResponse) {
    AuthenticationStateProviderInstance.invokeMethodAsync("GoogleLogin", { ClientId: googleResponse.clientId, SelectedBy: googleResponse.select_by, Credential: googleResponse.credential });
   
}