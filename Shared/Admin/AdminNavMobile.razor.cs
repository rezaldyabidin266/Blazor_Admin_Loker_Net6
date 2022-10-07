using BlazorAgentVs2022.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Shared.Admin
{
    public class AdminNavMobileBase: ComponentBase
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }

        [Inject]
        protected AuthenticationStateProvider? authenticationStateProvider { get; set; }        
        protected void goLogout()
        {
            ((MyAuthenticationProvider)authenticationStateProvider).MarkUserAsLogout();
            navigationManager.NavigateTo("/");
        }
    }
}
